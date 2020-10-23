package com.imop.lj.gameserver.dataeye;

import java.util.HashMap;
import java.util.Map;

import com.dataeye.sdk.client.DCAgent;
import com.dataeye.sdk.client.domain.DCCoin;
import com.dataeye.sdk.client.domain.DCItem;
import com.dataeye.sdk.client.domain.DCLevelUp;
import com.dataeye.sdk.client.domain.DCTask;
import com.dataeye.sdk.client.domain.TaskType;
import com.dataeye.sdk.proto.DCServerSync.DCMessage.DCPay;
import com.dataeye.sdk.proto.DCServerSync.DCMessage.DCRoleInfo;
import com.dataeye.sdk.proto.DCServerSync.DCMessage.DCUserInfo;
import com.dataeye.sdk.proto.DCServerSync.DCMessage.PlatformType;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.TerminalTypeEnum;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.dataeye.DataEyeDef.DataEyeReportType;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.reyun.ReyunDef;
import com.imop.lj.gameserver.task.AbstractTask;

public class DataEyeService implements InitializeRequired {
	
	protected DCAgent dcAgent;

	public DataEyeService() {

	}

	@Override
	public void init() {
		DCAgent.setBaseConf(Globals.getServerConfig().getServerId(), Globals
				.getServerConfig().getDataEyeBaseFileDir(), Globals
				.getServerConfig().getDataEyeMaxHistoryLogFile(), Globals
				.getServerConfig().getDataEyeMaxHistoryDataFile());
		dcAgent = DCAgent.getInstance(Globals.getServerConfig().getDataEyeAppid());
	}

	protected DCUserInfo buildDCUserInfo(Player player) {
		PlatformType pt = PlatformType.ADR;
		if (player.getCurrTerminalType() == TerminalTypeEnum.IPAD || 
				player.getCurrTerminalType() == TerminalTypeEnum.IPHONE) {
			pt = PlatformType.IOS;
		}
		
		//来源是player的source字段
		return DCUserInfo.newBuilder().setAccountId(player.getPassportId())
				.setIp(player.getClientIpNoPort())
				.setPlatform(pt)
				.setChannel(player.getChannelName() != null ? player.getChannelName() : "")
				.setGameRegion(Globals.getServerConfig().getRegionId())
				.build();
	}

	protected DCRoleInfo buildDCRoleInfo(Player player) {
		Human human = player.getHuman();
		if (human == null) {
			return null;
		}

		return DCRoleInfo.newBuilder().setRoleId(human.getUUID() + "")
				.setLevel(human.getLevel())
				.setRoleRace(human.getCountry()+"")//XXX 这里使用了他们的种族字段记录是否log是否合法
				.build();
	}

	protected void reportOperation(Player player, DataEyeReportType reportType, Object param) {
		DataEyeReportOperation op = new DataEyeReportOperation(player, reportType, param);
		Globals.getAsyncService().createOperationAndExecuteAtOnce(op);
	}
	
	public void doReport(Player player, DataEyeReportType reportType, Object param) {
		if (player == null || player.getHuman() == null || param == null) {
			return;
		}
		
		switch (reportType) {
		case GIVE_MONEY:
		case COST_MONEY:
			if (!(param instanceof DCCoin)) {
				Loggers.localLogger.error("doReport param is invalid!pId=" + player.getPassportId() + 
						";roleId=" + player.getRoleUUID() + ";reportType=" + reportType + ";param=" + param);
				return;
			}
			break;
			
		case FINISH_TASK:
		case GIVEUP_TASK:
			if (!(param instanceof DCTask)) {
				Loggers.localLogger.error("doReport param is invalid!pId=" + player.getPassportId() + 
						";roleId=" + player.getRoleUUID() + ";reportType=" + reportType + ";param=" + param);
				return;
			}
			break;
			
		case ADD_ITEM:
		case BUY_ITEM:
		case REMOVE_ITEM:
			if (!(param instanceof DCItem)) {
				Loggers.localLogger.error("doReport param is invalid!pId=" + player.getPassportId() + 
						";roleId=" + player.getRoleUUID() + ";reportType=" + reportType + ";param=" + param);
				return;
			}
			break;
			
		case CHARGE:
			if (!(param instanceof DCPay)) {
				Loggers.localLogger.error("doReport param is invalid!pId=" + player.getPassportId() + 
						";roleId=" + player.getRoleUUID() + ";reportType=" + reportType + ";param=" + param);
				return;
			}
			break;
		case LEVELUP:
			if (!(param instanceof DCLevelUp)) {
				Loggers.localLogger.error("doReport param is invalid!pId=" + player.getPassportId() + 
						";roleId=" + player.getRoleUUID() + ";reportType=" + reportType + ";param=" + param);
				return;
			}
			break;
		case BEHAVIOR:
			if (!(param instanceof DCEventInfo)) {
				Loggers.localLogger.error("doReport param is invalid!pId=" + player.getPassportId() + 
						";roleId=" + player.getRoleUUID() + ";reportType=" + reportType + ";param=" + param);
				return;
			}
			break;
		default:
			break;
		
		}
		
		switch (reportType) {
		case GIVE_MONEY:
			dcAgent.coinGain(buildDCUserInfo(player), (DCCoin)param, buildDCRoleInfo(player));
			break;
		case COST_MONEY:
			dcAgent.coinLost(buildDCUserInfo(player), (DCCoin)param, buildDCRoleInfo(player));
			break;
		case FINISH_TASK:
			dcAgent.taskComplete(buildDCUserInfo(player), (DCTask)param, buildDCRoleInfo(player));
			break;
		case GIVEUP_TASK:
			dcAgent.taskFail(buildDCUserInfo(player), (DCTask)param, buildDCRoleInfo(player));
			break;
		case BUY_ITEM:
			dcAgent.itemBuy(buildDCUserInfo(player), (DCItem)param, buildDCRoleInfo(player));
			break;
		case ADD_ITEM:
			dcAgent.itemGet(buildDCUserInfo(player), (DCItem)param, buildDCRoleInfo(player));
			break;
		case REMOVE_ITEM:
			dcAgent.itemUse(buildDCUserInfo(player), (DCItem)param, buildDCRoleInfo(player));
			break;
		case CHARGE:
			dcAgent.pay(buildDCUserInfo(player), (DCPay)param, buildDCRoleInfo(player));
			break;
		case LEVELUP:
			dcAgent.levelUp(buildDCUserInfo(player), (DCLevelUp)param, buildDCRoleInfo(player));
			break;
		case BEHAVIOR:
			DCEventInfo eInfo = (DCEventInfo)param;
			dcAgent.onEvent(buildDCUserInfo(player), eInfo.getEventId(), eInfo.getLabelMap(), eInfo.getDuration(), 
					buildDCRoleInfo(player));
			break;
		default:
			break;
		}
	}
	
	/**
	 * 获得货币的日志
	 * @param player
	 * @param currency
	 * @param amount
	 * @param newAmount
	 * @param reason
	 * @param detailReason
	 */
	public void giveMoneyLog(Player player, Currency currency, long amount,
			long newAmount, MoneyLogReason reason, String detailReason) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		reportOperation(player, DataEyeReportType.GIVE_MONEY, 
				DCCoin.newBuilder().coinType(Globals.getLangService().readSysLang(currency.getNameKey()))
				.totalCoin((int) newAmount)
				.coinNum((int) amount)
				.type(reason.getReasonText())
				.build());
	}
	
	public void costMoneyLog(Player player, Currency currency, long amount,
			long newAmount, MoneyLogReason reason, String detailReason) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		reportOperation(player, DataEyeReportType.COST_MONEY, 
				DCCoin.newBuilder().coinType(Globals.getLangService().readSysLang(currency.getNameKey()))
				.totalCoin((int) newAmount)
				.coinNum((int) amount)
				.type(reason.getReasonText())
				.build());
	}
	
	@SuppressWarnings("rawtypes")
	public void finishTaskLog(Human human, AbstractTask task) {
		if (human == null || human.getPlayer() == null) {
			return;
		}
		
		TaskType tt = TaskType.Other;
		switch (task.getQuestType()) {
		case COMMON:
			tt = TaskType.MainLine;
			break;
		case DAY7_TARGET:
			tt = TaskType.GuideLine;
			break;
			
		case FORAGE:
			tt = TaskType.Daily;
			break;
		case PUB:
			tt = TaskType.Daily;
			break;
			
		case TEAM:
		case THESWEENEY:
		case TIME_LIMIT_MONSTER:
		case TIME_LIMIT_NPC:
		case TREASUREMAP:
		case CORPSTASK:
			tt = TaskType.Activity;
			break;
		default:
			break;
		}
		
		reportOperation(human.getPlayer(), DataEyeReportType.FINISH_TASK, 
				DCTask.newBuilder().taskId(task.getTemplate().getId() + "") //任务ID，必填
		        .taskType(tt) //任务类型，必填
		        .duration(1000) //任务耗时 1000秒，必填
		        .build());
	}
	
	@SuppressWarnings("rawtypes")
	public void giveupTaskLog(Human human, AbstractTask task) {
		if (human == null || human.getPlayer() == null) {
			return;
		}
		
		reportOperation(human.getPlayer(), DataEyeReportType.GIVEUP_TASK, 
				DCTask.newBuilder().taskId(task.getTemplate().getId() + "") //任务ID，必填
		        .taskType(TaskType.MainLine) //任务类型，必填
		        .duration(1000) //任务耗时 1000秒，必填
		        .failReason("giveup") //任务失败原因，必填
		        .build());
	}
	
	public void buyItemLog(Player player, int itemId, int itemNum, Currency currency, int currencyNum, String reason) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		ItemTemplate itemTpl = Globals.getTemplateCacheService().get(itemId, ItemTemplate.class);
		if (itemTpl == null) {
			return;
		}
		
		reportOperation(player, DataEyeReportType.BUY_ITEM, 
				DCItem.newBuilder().itemId(itemTpl.getName()) //道具ID，必填
	            .itemType(itemTpl.getItemType()+"") //道具类型，必填
	            .itemCnt(itemNum) //道具数量，必填
	            .coinNum(currencyNum) //消耗的虚拟币数量，必填
	            .coinType(Globals.getLangService().readSysLang(currency.getNameKey()))//虚拟币类型，必填
	            .reason(reason)
	            .build());
	}

	public void addItemLog(Player player, int itemId, int itemNum, String reason) {
		if (player == null || player.getHuman() == null) {
			return;
		}

		ItemTemplate itemTpl = Globals.getTemplateCacheService().get(itemId, ItemTemplate.class);
		if (itemTpl == null) {
			return;
		}
		
		reportOperation(player, DataEyeReportType.ADD_ITEM, 
				DCItem.newBuilder().itemId(itemTpl.getName()) //道具ID，必填
	            .itemType(itemTpl.getItemType()+"") //道具类型，必填
	            .itemCnt(itemNum) //道具数量，必填
	            .reason(reason)
	            .build());
	}
	
	public void removeItemLog(Player player, int itemId, int itemNum, String reason) {
		if (player == null || player.getHuman() == null) {
			return;
		}

		ItemTemplate itemTpl = Globals.getTemplateCacheService().get(itemId, ItemTemplate.class);
		if (itemTpl == null) {
			return;
		}
		
		reportOperation(player, DataEyeReportType.REMOVE_ITEM, 
				DCItem.newBuilder().itemId(itemTpl.getName()) //道具ID，必填
	            .itemType(itemTpl.getItemType()+"") //道具类型，必填
	            .itemCnt(itemNum) //道具数量，必填
	            .reason(reason)
	            .build());
	}
	
	public void chargeLog(Player player, int rmb, int bondNum, String orderId) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		reportOperation(player, DataEyeReportType.CHARGE, DCPay.newBuilder()
	            .setCurrencyAmount(rmb) //付费金额，必填
	            .setCurrencyType("CNY") //货币类型，必填
	            .setIapid("pay") //付费点，必填
	            .setPayTime((int) (Globals.getTimeService().now() / 1000)) //付费时间，必填
	            .setPayType("zhichong")//付费方式，必填
	            .setOrderId(orderId)
	            .build());
		
	}
	
	public void levelUpLog(Player player, int curLevel, int oldLevel) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		reportOperation(player, DataEyeReportType.LEVELUP, 
				DCLevelUp.newBuilder()//设置等级升级信息
                .startLevel(oldLevel)//升级前等级
                .endLevel(curLevel)//升级后等级
                .spendTimeInLevel(60)//耗时
                .build());
	}
	
	public void behaviorLog(Player player, BehaviorTypeEnum behaviorType, int num) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		Map<String, String> map = new HashMap<String, String>();
		map.put(ReyunDef.USER_DEF_BEHAVIOR_ID, behaviorType.getIndex() + "");
		map.put(ReyunDef.USER_DEF_BEHAVIOR_NAME, behaviorType.name());
		map.put(ReyunDef.USER_DEF_BEHAVIOR_NUM, num + "");
		
		DCEventInfo eInfo = new DCEventInfo();
		eInfo.setDuration(60);
		eInfo.setEventId("Behavior_" + behaviorType.getIndex());
		eInfo.setLabelMap(map);
		
		reportOperation(player, DataEyeReportType.BEHAVIOR, eInfo);
	}
}
