package com.imop.lj.gameserver.telnet.command;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Set;

import org.apache.mina.core.session.IoSession;

import com.imop.lj.common.LogReasons.ItemGenLogReason;
import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.LogReasons.MallLogReason;
import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.LogReasons.ReasonDesc;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.TerminalTypeEnum;
import com.imop.lj.core.util.KeyUtil;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.core.util.MathUtils;
import com.imop.lj.db.model.HumanEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.currency.CurrencyProcessor;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.mall.template.MallNormalItemTemplate;
import com.imop.lj.gameserver.player.Player;

public class GenLogCommand extends LoginedTelnetCommand {

	public GenLogCommand() {
		super("GENLOG");
	}

	@Override
	protected void doExec(String command, Map<String, String> params, IoSession session) {
		String _param = getCommandParam(command);
		if (_param.length() == 0) {
			sendError(session, "No param");
			return;
		}

		String[] arr = _param.split(",");
		int costBond = Integer.parseInt(arr[0]);
		Set<Long> roleIdSet = new HashSet<Long>();
		for (int i = 1; i < arr.length; i++) {
			long roleId = Long.parseLong(arr[i]);
			if (roleId > 0) {
				roleIdSet.add(roleId);
			}
		}

		boolean flag = costBond > 0 && !roleIdSet.isEmpty();
		if (flag) {
			genLog(roleIdSet, costBond);
		} else {
			sendError(session, "some param may be invalid!");
		}
	}
	
	public void genLog(Set<Long> roleIdSet, int costBond) {
		//购买商城道具，随机一个道具，数量取最接近costBond的值
		buyMallBondItem(roleIdSet, costBond);
		
		//TODO 以后可能再加别的策略
		
	}
	
	private void buyMallBondItem(Set<Long> roleIdSet, int costBond) {
		//购买金子商店的道具
		List<Integer> mallTplIdSet = new ArrayList<Integer>();
		for (MallNormalItemTemplate tpl : Globals.getTemplateCacheService().getAll(MallNormalItemTemplate.class).values()) {
			if (tpl.getDiscountPrice().getCurrencyType() == Currency.BOND.getIndex()) {
				mallTplIdSet.add(tpl.getId());
			}
		}
		//每个玩家都购买一个商城的道具，数量取最接近costBond的个数
		for (Long roleId : roleIdSet) {
			int mallItemId = mallTplIdSet.get(MathUtils.random(0, mallTplIdSet.size() - 1));
			buyBondItem(roleId, mallItemId, costBond);
		}
	}
	
	private boolean buyBondItem(long roleId, int mallItemId, int costBond) {
		Human human = Globals.getHumanCacheService().getHumanOnlineOrCache(roleId);
		HumanEntity humanEntity = null;
		long curBond = 0;
		if (human != null) {
			curBond = human.getBond();
		} else {
			List<HumanEntity> humanList = Globals.getDaoService().getHumanDao().queryHumanByUUID(roleId);
			if (humanList != null && humanList.size() > 0) {
				humanEntity = humanList.get(0);
				curBond = humanEntity.getBond();
			} else {
				Loggers.gameLogger.error("can not find human in db!roleId=" + roleId + 
						";mallItemId=" + mallItemId + ";costBond=" + costBond + ";curBond=" + curBond + ";human=" + (human != null ? human : "null"));
				return false;
			}
		}
		
		//实际有的金子数和costBond取小的，防止多扣
		int buyCostBond = (int) Math.min(curBond, costBond);
		//购买n个道具
		MallNormalItemTemplate mallTpl = Globals.getTemplateCacheService().get(mallItemId, MallNormalItemTemplate.class);
		//计算购买的个数，不超过costBond的数额
		int itemNum = buyCostBond / mallTpl.getDiscountPrice().getNum();
		if (itemNum <= 0) {
			Loggers.gameLogger.error("buy bond item failed,not enough bond!roleId=" + roleId + 
					";mallItemId=" + mallItemId + ";costBond=" + costBond + ";curBond=" + curBond + ";human=" + (human != null ? human : "null"));
			return false;
		}
		ItemTemplate itemTpl = mallTpl.getSellItem();
		
		int leftBond = (int) (curBond - buyCostBond);
		if (leftBond < 0) {
			leftBond = 0;
		}
		//扣金子
		if (human != null) {
			//扣钱
			CurrencyProcessor.instance.substractAndFixMoney(human, buyCostBond, Currency.BOND);
			//存库
			human.setModified();
		} else {
			//XXX db直接更新金子数
			Globals.getDaoService().getHumanDao().updateHumanBond(roleId, leftBond);
		}

		//构建日志用的human
		Human logHuman = null;
		if (human == null) {
			logHuman = buildLogHuman(roleId, humanEntity);
		} else {
			logHuman = buildLogHuman(roleId, human);
		}
		
		//日志记录
		sendBuyMallItemLog(logHuman, buyCostBond, leftBond, mallItemId, itemTpl, itemNum);
		
		return true;
	}
	
	private void sendBuyMallItemLog(Human logHuman, int buyCostBond, int leftBond, int mallItemId, ItemTemplate itemTpl, int itemNum) {
		//日志记录
		MoneyLogReason moneyReason = MoneyLogReason.MALL_BUY_ITEM_COST;
		String moneyDetailReason = MoneyLogReason.MALL_BUY_ITEM_COST.getReasonText();
		//扣金子日志
		Globals.getLogService().sendMoneyLog(logHuman, moneyReason, moneyDetailReason, 
				Currency.BOND.index, -buyCostBond, leftBond, 
				0, 0, 0, 0, 0, 0);
		//汇报dataEye
		Globals.getDataEyeService().costMoneyLog(logHuman.getPlayer(), Currency.BOND, buyCostBond, 
				leftBond, moneyReason, moneyDetailReason);
		//汇报热云
		Map<Currency, Long> costList = new LinkedHashMap<Currency, Long>();
		costList.put(Currency.BOND, (long)buyCostBond);
		Globals.getReyunService().reportCostMoneyList(logHuman.getPlayer(), costList, moneyReason.getReasonText());
		
		
		//获得道具日志
		ItemGenLogReason itemGenReason = ItemGenLogReason.MALL_BUY_ITEM;
		String itemGenReasonDetail = ItemGenLogReason.MALL_BUY_ITEM.getReasonText();
		
		String genKey = KeyUtil.UUIDKey();
		Globals.getLogService().sendItemGenLog(logHuman, itemGenReason, itemGenReasonDetail, itemTpl.getId(), itemTpl.getName(), itemNum, 0, "", genKey);
		// 增加物品增加原因到reasonDetail
		String countChangeReason;
		try {
			countChangeReason = " [genReason:" + itemGenReason.getClass().getField(itemGenReason.name()).getAnnotation(ReasonDesc.class).value() + "] ";
			itemGenReasonDetail = itemGenReasonDetail == null ? countChangeReason : itemGenReasonDetail + countChangeReason;
		} catch (Exception e) {
			e.printStackTrace();
			Loggers.gameLogger.error("afe", e);
		}
		
		ItemLogReason itemReason = ItemLogReason.COUNT_ADD;
		String itemReasonDetail = itemGenReasonDetail;
		byte[] ib = new byte[1];
		ib[0] = 0;
		Globals.getLogService().sendItemLog(logHuman, itemReason, itemReasonDetail, 1, 0, itemTpl.getId(), genKey,
				itemNum, itemNum, genKey, ib);
		
		//财务汇报
		Globals.getMoneyReportService().onAddItem(logHuman, itemGenReason, itemTpl.getId(), itemNum, 0, Currency.NULL, 0, 0);
		//热云、dataEye道具汇报
		Globals.getReyunService().reportAddItem(logHuman.getPlayer(), itemTpl.getId(), itemNum, itemGenReasonDetail);
		Globals.getDataEyeService().addItemLog(logHuman.getPlayer(), itemTpl.getId(), itemNum, itemGenReasonDetail);
						
		//商城日志
		String param = LogUtils.genReasonText(MallLogReason.BUY_TIME_LIMIT_ITEM, Currency.BOND.getIndex(), 
				buyCostBond, itemNum, mallItemId, itemTpl.getId(), itemNum, "-1");
		Globals.getMallService().sendMallLog(logHuman, MallLogReason.BUY_TIME_LIMIT_ITEM, param);
		
		//dataEye购买道具日志
		Globals.getDataEyeService().buyItemLog(logHuman.getPlayer(), itemTpl.getId(), itemNum, Currency.BOND, buyCostBond, ItemGenLogReason.MALL_BUY_ITEM.getReasonText());
		
	}
	
	private Human buildLogHuman(long roleId, Human rawHuman) {
		Human retHuman = new Human();
		Player player = new Player(null);
		//互相设置human和player
		retHuman.setPlayer(player);
		player.setHuman(retHuman);
		
		retHuman.setDbId(roleId);
		retHuman.setName(rawHuman.getName());
		retHuman.setLevel(rawHuman.getLevel());
		retHuman.setTotalCharge(rawHuman.getTotalCharge());
		retHuman.setServerId(rawHuman.getServerId());
		
		player.setPassportId(rawHuman.getPassportId());
		player.setPassportName(rawHuman.getPassportName());
		player.setDeviceID(rawHuman.getPlayer().getDeviceID());
		player.setDeviceType(rawHuman.getPlayer().getDeviceType());
		player.setDeviceVersion(rawHuman.getPlayer().getDeviceVersion());
		player.setClientVersion(rawHuman.getPlayer().getClientVersion());
		player.setClientLanguage(rawHuman.getPlayer().getClientLanguage());
		player.setAppid(rawHuman.getPlayer().getAppid());
		player.setfValue(rawHuman.getPlayer().getfValue());
		
		player.setCurrTerminalType(TerminalTypeEnum.ANDROID);
		
		//XXX log的特殊标记
		retHuman.setCountry(-1);
		
		return retHuman;
	}

	private Human buildLogHuman(long roleId, HumanEntity rawHuman) {
		Human retHuman = new Human();
		Player player = new Player(null);
		//互相设置human和player
		retHuman.setPlayer(player);
		player.setHuman(retHuman);
		
		retHuman.setDbId(roleId);
		retHuman.setName(rawHuman.getName());
		retHuman.setLevel(rawHuman.getLevel());
		retHuman.setTotalCharge(rawHuman.getTotalCharge());
		retHuman.setServerId(rawHuman.getServerId());
		
		player.setPassportId(rawHuman.getPassportId());
		player.setPassportName(rawHuman.getPassportId());
		player.setDeviceID("-1");
		player.setDeviceType("-1");
		player.setDeviceVersion("-1");
		player.setClientVersion("-1");
		player.setClientLanguage("-1");
		player.setAppid("-1");
		player.setfValue("-1");
		player.setChannelName("-1");
		
		player.setCurrTerminalType(TerminalTypeEnum.ANDROID);
		
		//XXX log的特殊标记
		retHuman.setCountry(-1);
		
		return retHuman;
	}
	
}
