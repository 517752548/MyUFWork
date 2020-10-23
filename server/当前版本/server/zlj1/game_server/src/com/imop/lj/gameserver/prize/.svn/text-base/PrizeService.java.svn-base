package com.imop.lj.gameserver.prize;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.ConcurrentMap;

import net.sf.json.JSONObject;

import org.slf4j.Logger;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.model.MoneyBonus;
import com.imop.lj.core.schedule.ScheduleService;
import com.imop.lj.core.util.StringUtils;
import com.imop.lj.db.model.PrizeInfo;
import com.imop.lj.db.model.UserPrize;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.ItemDef.Rarity;
import com.imop.lj.gameserver.item.ItemParam;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.player.async.PlayerQueryPrizes;
import com.imop.lj.gameserver.player.async.PlayerQueryPrizesCallback;
import com.imop.lj.gameserver.prize.msg.GCPrizeList;
import com.imop.lj.gameserver.prize.msg.GCPrizeListTip;
import com.imop.lj.gameserver.prize.msg.ScheduleGetPrizeNumMessage;
import com.imop.lj.gameserver.prize.msg.UserPrizeToMailMessage;

public class PrizeService implements InitializeRequired {
	protected static final Logger log = Loggers.msgLogger;
	
	/** 奖励缓存 */
	protected ConcurrentMap<Integer, PrizeInfo> prizeCache;
	
	/** 缓存大小 */
	protected static int CACHE_SIZE = 100;
	
	protected long openGameDateTime;
	
	/** 定时任务服务 */
	protected ScheduleService scheduleService;
	
	public PrizeService(ScheduleService scheduleService) {
		prizeCache = new ConcurrentHashMap<Integer, PrizeInfo>();
		SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
		String openGameDateStr = Globals.getGameConstants().getOpenGameDate();
		Date date;
		try {
			date = sdf.parse(openGameDateStr);
			openGameDateTime = date.getTime();
		} catch (Exception e) {
			log.warn("【openGameDateTime is null】");
		}
		
		this.scheduleService = scheduleService;
	}
	
	@Override
	public void init() {
		// 定时任务注册
		this.startCheckPrizeNumTask();
	}
	
	/**
	 * 发送平台奖励列表(统一调用的接口，平台礼包和gm补偿以前调用）
	 * 
	 * @param player
	 */
	public void sendPrizeListMsg(Player player)
	{
		PlayerQueryPrizes operation = new PlayerQueryPrizes(player, new PlayerQueryPrizesCallback() {
			
			@Override
			public void afterQueryComplete(Player player, boolean platFormQuery,
					List<PlatformPrizeHolder> platformPrizeHolders,
					boolean userPrizeQuery, List<UserPrizeInfo> userPrizes) {
				// 只要平台查询奖励和gm补偿奖励里面一个成功就算成功
				if(platFormQuery || userPrizeQuery){
					GCPrizeList gcPrizeList = new GCPrizeList();
					
					if(platformPrizeHolders == null){
						platformPrizeHolders = new ArrayList<PlatformPrizeHolder>();
					}
					
					if(userPrizes == null){
						userPrizes = new ArrayList<UserPrizeInfo>();
					}
					
					if(platFormQuery) //平台奖励和gm奖励合并						
					{
						userPrizes.addAll(UserPrizeInfo.getFromPlatformPrizeHolders(platformPrizeHolders));
					}
					
					gcPrizeList.setUserPrizes(userPrizes.toArray(new UserPrizeInfo[userPrizes.size()]));
				
					player.sendMessage(gcPrizeList);
					sendItemTipMessage(player, userPrizes);
					// 更新礼包数量显示
					int num = platformPrizeHolders.size() + userPrizes.size();
					 
					// 给玩家发消息
					if (player != null) {
						Human human = player.getHuman();
						if(human != null){
							human.setPrizeNum(num);
							Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.USER_PRIZE);
						}
					}
					
					// 如果两个礼包大小都为零则提示没有礼包领取
//					if(platformPrizeHolders.size() == 0
//							&& userPrizes.size() == 0){
//						player.sendErrorMessage(LangConstants.PRIZE_USER_NOT_EXIST);
//					}
				}
				else{
					player.sendErrorMessage(LangConstants.PRIZE_GET_FAIL);
				}
				
			}
		});
		Globals.getAsyncService().createOperationAndExecuteAtOnce(operation, player.getRoleUUID());
	}
	
	
	/**
	 * 获取奖品内具体道具信息
	 * @param player
	 * @param userPrizeInfo
	 * @return
	 */
	public UserPrizeTipInfo getUserPrizeTipInfo(Player player, UserPrizeInfo userPrizeInfo){
		String prizeIdStr = userPrizeInfo.getPrizeId();
		int prizeId = Integer.parseInt(prizeIdStr);
		BasePrizeHolder holder = null;
		Human human = player.getHuman();
		if(human == null){
			return null;
		}
		if(userPrizeInfo.getPrizeType() == 1){
			holder = fetchPlatformPrizeByPrizeId(userPrizeInfo.getUniqueId(), prizeId);
		}else{
			holder = fetchUserPrizeByCharId(human.getUUID(), prizeId);
		}
		List<UserPrizeItemTipInfo> moneyTipInfoList = new ArrayList<UserPrizeItemTipInfo>();
		List<UserPrizeItemTipInfo> itemTipInfoList = new ArrayList<UserPrizeItemTipInfo>();
		if(holder != null){
			MoneyBonus[] bouns = holder.getCoinList();
			ItemParam[] params = holder.getItemList();
			if(bouns != null){
				for(MoneyBonus boun : bouns){
					Currency currency = Currency.valueOf(boun.getType()) ;
					String name = Globals.getLangService().readSysLang(currency.getNameKey());
					int num = boun.getMoney();
					UserPrizeItemTipInfo moneyTipInfo = new UserPrizeItemTipInfo(num, name, Rarity.GREEN.getColor(), boun.getType());
					moneyTipInfoList.add(moneyTipInfo);
				}
			}
			if(params != null){
				for(ItemParam param : params){
					ItemTemplate template = Globals.getItemService().getItemTempByTempId(param.getTemplateId());
					String name = template.getName();
					int num = param.getCount();
					String color = Rarity.valueOf(template.getRarityId()).getColor();
					UserPrizeItemTipInfo itemTipInfo = new UserPrizeItemTipInfo(num, name, color, -1);
					itemTipInfoList.add(itemTipInfo);
				}
			}
		}
		
		UserPrizeItemTipInfo[] moneys = moneyTipInfoList.toArray(new UserPrizeItemTipInfo[moneyTipInfoList.size()]);
		UserPrizeItemTipInfo[] items = itemTipInfoList.toArray(new UserPrizeItemTipInfo[itemTipInfoList.size()]);
		UserPrizeTipInfo userPrizeTipInfo = new UserPrizeTipInfo(prizeIdStr, moneys, items);
		return userPrizeTipInfo;
	}
	
	/**
	 * 2013-8-13 增加，礼包内的具体物品信息，方便玩家查看
	 * @param player
	 * @param userPrizes
	 */
	public void sendItemTipMessage(Player player, List<UserPrizeInfo> userPrizes){
		if(userPrizes == null || userPrizes.isEmpty()){
			return;
		}
		List<UserPrizeTipInfo> tipInfoList = new ArrayList<UserPrizeTipInfo>();
		for(UserPrizeInfo userPrizeInfo : userPrizes){
			UserPrizeTipInfo userPrizeTipInfo = getUserPrizeTipInfo(player, userPrizeInfo);
			tipInfoList.add(userPrizeTipInfo);
		}
		GCPrizeListTip gcPrizeListTip = new GCPrizeListTip();
		gcPrizeListTip.setUserPrizeTips(tipInfoList.toArray(new UserPrizeTipInfo[tipInfoList.size()]));
		player.sendMessage(gcPrizeListTip);
	}
	
	/**
	 * 领取平台奖励
	 * 
	 * @param prizeId
	 * @return
	 */
	public PlatformPrizeHolder fetchPlatformPrizeByPrizeId(int uniqueId,
			int prizeId) {

		PrizeInfo _prizeInfo = prizeCache.get(prizeId);
		if (_prizeInfo == null) {
			_prizeInfo = Globals.getDaoService().getPlatformPrizeDao().getPrizesByPrizeId(prizeId);

			if (_prizeInfo != null) {
				if (prizeCache.size() == CACHE_SIZE) {
					// 缓存满了，全部清空从头再来
					clearCache();
				}
				PrizeInfo _tmp = prizeCache.putIfAbsent(
						_prizeInfo.getPrizeId(), _prizeInfo);
				if (_tmp != null) {
					_prizeInfo = _tmp;
				}
			}
		}
		if (_prizeInfo != null) {
			PlatformPrizeHolder _prize = toPlatformPrizeHolder(_prizeInfo);
			_prize.setUniqueId(uniqueId);
			return _prize;
		}

		return null;
	}
	
	
	/**
	 * 转换平台奖励
	 * 
	 * @param prizeInfo
	 * @return
	 */
	protected PlatformPrizeHolder toPlatformPrizeHolder(PrizeInfo prizeInfo) {
		PlatformPrizeHolder _holder = new PlatformPrizeHolder();
		_holder.setPrizeId(prizeInfo.getPrizeId());
		_holder.setPrizeName(prizeInfo.getPrizeName());
		_holder.setItemList(getPrizeItem(prizeInfo.getItem()));
		_holder.setCoinList(getPrizeCoin(prizeInfo.getCoin()));
		return _holder;
	}
	
	/**
	 * 清空缓存
	 */
	public void clearCache() {
		prizeCache.clear();
	}
	
	
	/**
	 * 更新用户奖励状态
	 * 
	 * @param prizeId
	 * @return
	 */
	public boolean updateUserPrizeStatus(int prizeId) {
		return Globals.getDaoService().getUserPrizeDao().updateUserPrizeStatus(prizeId);
	}
	
	/**
	 * 获取玩家奖励
	 * 
	 * @param passportId
	 * @param prizeId
	 * @return
	 */
	public UserPrizeHolder fetchUserPrizeByCharId(long charId, int prizeId) {

		UserPrize prize = Globals.getDaoService().getUserPrizeDao().getUserPrizeByPrizeId(charId, prizeId);
		if (prize != null) {
			UserPrizeHolder _prizeHolder = toUserPrizeHolder(prize);
			checkPrize(_prizeHolder);
			return _prizeHolder;
		}
		return null;
	}
	
	public UserPrizeHolder convertToPrizeHolder(UserPrize prize) {
		if (prize != null) {
			UserPrizeHolder _prizeHolder = toUserPrizeHolder(prize);
			try {
				checkPrize(_prizeHolder);
			} catch(Exception e) {
				e.printStackTrace();
				Loggers.prizeLogger.error("ERROR!convertToPrizeHolder failed! e=" + e);
				return null;
			}
			return _prizeHolder;
		}
		return null;
	}
	
	/**
	 * 获取玩家奖励列表
	 * 
	 * @param passportId
	 * @return
	 */
	public List<UserPrize> fetchUserPrizeNameListByPassportId(long charId) {
		return Globals.getDaoService().getUserPrizeDao()
				.getUserPrizeNameListByCharId(charId);
	}
	
	/**
	 * 转换用户奖励
	 * 
	 * @param userPrize
	 * @return
	 */
	protected UserPrizeHolder toUserPrizeHolder(UserPrize userPrize) {
		UserPrizeHolder _holder = new UserPrizeHolder();
		_holder.setId(userPrize.getId());
		_holder.setPassportId(userPrize.getPassportId());
		_holder.setType(userPrize.getType());
		_holder.setStatus(userPrize.getStatus());
		_holder.setItemList(getPrizeItem(userPrize.getItem()));
		_holder.setItemParamsList(parseItemWithParams(userPrize.getItemParams()));
		_holder.setCoinList(getPrizeCoin(userPrize.getCoin()));
		_holder.setPrizeInfo(userPrize.getUserPrizeName());
		return _holder;
	}
	
	/**
	 * 校验数据
	 * 
	 * @param prize
	 */
	protected void checkPrize(BasePrizeHolder prize) {

		// 物品ID存在,数量合法
		if (prize.getItemList() != null) {
			for (ItemParam _item : prize.getItemList()) {
				int _itemId = _item.getTemplateId();
				int _count = _item.getCount();

				ItemTemplate tmpl = Globals.getItemService()
						.getItemTempByTempId(_itemId);

				if (tmpl == null) {
					throw new IllegalArgumentException(prize
							+ " Item template cannot be found!");
				}
				if (_count <= 0) {// Constants
					throw new IllegalArgumentException(prize
							+ " Item count illegal!");
				}
			}
		}

		// 金钱类型合法，数量合法
		if (prize.getCoinList() != null) {
			for (MoneyBonus _money : prize.getCoinList()) {
				Currency currency = Currency.valueOf(_money.getType());
				int _count = _money.getMoney();

				if (currency == null || currency == Currency.NULL) {
					throw new IllegalArgumentException(prize
							+ " CurrencyType cannot be found!");
				}

				if (_count <= 0) {
					throw new IllegalArgumentException(prize
							+ " Currency count illegal!");
				}
			}
		}
	}
	
	
	
	
	/**
	 * 转换物品
	 * 
	 * @param itemStr
	 * @param itemMap
	 */
	protected ItemParam[] getPrizeItem(String itemStr) {
		if (itemStr == null || itemStr.trim().length() == 0) {
			return null;
		}
		String[] _items = itemStr.split(";");
		if (_items.length == 0) {
			return null;
		}
		Map<Integer, Integer> _itemMap = new HashMap<Integer, Integer>(
				_items.length);

		for (int i = 0; i < _items.length; i++) {
			String[] _itemEQ = _items[i].split("=");
			int _itemId = Integer.parseInt(_itemEQ[0].trim());
			int _itemCount = Integer.parseInt(_itemEQ[1].trim());
			// 同物品ID,叠加
			int _oldCount = 0;
			if (_itemMap.get(_itemId) != null) {
				_oldCount = _itemMap.get(_itemId);
			}
			_itemMap.put(_itemId, _itemCount + _oldCount);
		}

		ItemParam[] _holder = new ItemParam[_itemMap.size()];
		int i = 0;
		for (Entry<Integer, Integer> _entry : _itemMap.entrySet()) {
			int tmplId = _entry.getKey();
			int count = _entry.getValue();
//			TODO 以下内容删除			
//			ItemTemplate tmpl = Globals.getItemService().getItemTempByTempId(tmplId);
//			BindStatus bind = null;
//			if (tmpl != null) {
//				bind = tmpl.getBindStatusAfterOper(BindStatus.BIND_YET,	Oper.GET);
//			}
			_holder[i] = new ItemParam(tmplId, count);
			i++;
		}
		return _holder;
	}
	
	
	/** 角色ID key字符串 */
	protected static final String CHAR_ID = "id";
	/** passport ID key字符串 */
	protected static final String PARAM = "params";
//	/** 道具属性 A */
//	protected static final String ATTRA = "attrA";
//	/** 道具属性 B */
//	protected static final String ATTRB = "attrB";
	/**
	 * 解析带有属性的道具
	 * @param itemParams json串
	 * @return
	 * 
	 * commands 0：道具id， 1：道具数量, 2强化等级， 3附魔等级， 4装备打孔数量， 5技能id、6武器等级， 7属性A串，8属性B串：
	 * @param attrAStr 道具属性A
	 * @param attrBStr 道具属性B
	 * 
	 */
	protected ItemParam[] parseItemWithParams(String itemParams) {
		if (itemParams == null || itemParams.trim().length() == 0) {
			return null;
		}
		
		if (itemParams.length() == 0) {
			return null;
		}
		// 解析json串
		JSONObject _json = JSONObject.fromObject(itemParams);

		long charId = Long.parseLong(_json.getString(CHAR_ID));
		if(charId == 0) {
			return null;
		}
		final String param = _json.getString(PARAM);
//		final String attrAStr = _json.getString(ATTRA);
//		final String attrBStr = _json.getString(ATTRB);
		
		String[] commands = param.split(",");
		// 字符串检查如果常常小于9，非法
		if(commands.length != 6) {
			return null;
		}
		int itemId = Integer.parseInt(commands[0]);
		int count = Integer.parseInt(commands[1]);
//		int[] params = new int[commands.length - 2];
//		int srcPos = 2;
		// 定死：2-6 
//		for(int i  = 0; i< 5; i++) {
//			params[i] = Integer.parseInt(commands[srcPos + i]);
//		}
//		// 解析参数
//		int[] attrA = null;
//		if(attrAStr.trim() != "" && attrAStr.trim().length() > 0) {
//			attrA = StringUtils.getIntArray(attrAStr, ",");
//		}else {
//			attrA = new int[0];
//		}
//		int[] attrB = null;
//		if(attrBStr.trim() != "" && attrBStr.trim().length() > 0) {
//			attrB = StringUtils.getIntArray(attrBStr, ",");
//		} else {
//			attrB = new int[0];
//		}
		// 物品模板
		ItemTemplate template = Globals.getItemService().getItemTempByTempId(itemId);
		if (template == null) {
			return null;
		}
		
		ItemParam[] _holder = new ItemParam[1];
		ItemParam itemParam = new ItemParam(itemId, count);
		itemParam.setParams(itemParams);
		_holder[0] = itemParam;
		return _holder;
	}

	
	/**
	 * 转换金钱
	 * 
	 * @param coinStr
	 * @param coinMap
	 */
	protected MoneyBonus[] getPrizeCoin(String coinStr) {
		if (StringUtils.isEmpty(coinStr)) {
			return null;
		}
		String[] _coins = coinStr.split(";");
		if (_coins.length == 0) {
			return null;
		}
		Map<Integer, Integer> _coinMap = new HashMap<Integer, Integer>(coinStr
				.length());
		for (int i = 0; i < _coins.length; i++) {
			String[] _coinEQ = _coins[i].split("=");
			int _coinId = Integer.parseInt(_coinEQ[0].trim());
			int _coinCount = Integer.parseInt(_coinEQ[1].trim());
			int _oldCount = 0;
			// 同货币类型，叠加
			if (_coinMap.get(_coinId) != null) {
				_oldCount = _coinMap.get(_coinId);
			}
			_coinMap.put(_coinId, _coinCount + _oldCount);
		}

		MoneyBonus[] _holder = new MoneyBonus[_coins.length];
		int i = 0;
		for (Entry<Integer, Integer> _entry : _coinMap.entrySet()) {
			_holder[i++] = new MoneyBonus(_entry.getValue(), _entry.getKey());
		}
		return _holder;
	}

	public long getOpenGameDateTime() {
		return openGameDateTime;
	}

	public void setOpenGameDateTime(long openGameDateTime) {
		this.openGameDateTime = openGameDateTime;
	}
	
	/**
	 * 当登陆时
	 * 
	 * @param human
	 */
	public void onLogin(Human human){
		Player player = human.getPlayer();
		if(player == null){
			return;
		}
		
		//暂时改为通过邮件发奖励
//		player.putMessage(new CanGetPrizeNumMessage(player));
		player.putMessage(new UserPrizeToMailMessage(player));
	}
	
	/**
	 * 定时任务，检查玩家可领取礼包数量
	 */
	public void startCheckPrizeNumTask() {
		// 周期性的同步可领取礼包数量
		this.scheduleService.scheduleWithFixedDelay(new ScheduleGetPrizeNumMessage(Globals.getTimeService().now()), 
				Globals.getGameConstants().getUpdatePrizeNumPeriod(), 
				Globals.getGameConstants().getUpdatePrizeNumPeriod());
	}

}
