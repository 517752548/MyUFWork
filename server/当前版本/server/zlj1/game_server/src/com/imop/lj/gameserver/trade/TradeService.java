package com.imop.lj.gameserver.trade;

import java.sql.Timestamp;
import java.util.ArrayList;
import java.util.Collection;
import java.util.HashMap;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import net.sf.json.JSONArray;

import org.apache.commons.lang.math.NumberUtils;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons;
import com.imop.lj.common.LogReasons.CommodityBuyLogReason;
import com.imop.lj.common.LogReasons.CommoditySellLogReason;
import com.imop.lj.common.LogReasons.ItemGenLogReason;
import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.LogReasons.PetLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.ResultTypes;
import com.imop.lj.core.orm.SoftDeleteEntity;
import com.imop.lj.core.util.KeyUtil;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.db.model.TradeEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef.ItemType;
import com.imop.lj.gameserver.item.ItemDef.Position;
import com.imop.lj.gameserver.item.feature.EquipFeature;
import com.imop.lj.gameserver.mail.MailDef.MailType;
import com.imop.lj.gameserver.offlinedata.UserOfflineData;
import com.imop.lj.gameserver.offlinedata.UserPetData;
import com.imop.lj.gameserver.pet.PetPet;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.RewardDef.RewardType;
import com.imop.lj.gameserver.reward.RewardParam;
import com.imop.lj.gameserver.trade.TradeDef.CommodityType;
import com.imop.lj.gameserver.trade.TradeDef.TradeOrderType;
import com.imop.lj.gameserver.trade.TradeDef.TradeSortableFieldType;
import com.imop.lj.gameserver.trade.TradeDef.TradeStatue;
import com.imop.lj.gameserver.trade.bean.ICommodity;
import com.imop.lj.gameserver.trade.bean.TradeItem;
import com.imop.lj.gameserver.trade.bean.TradePet;
import com.imop.lj.gameserver.trade.msg.GCTradeBoothinfo;
import com.imop.lj.gameserver.trade.msg.GCTradeCommodityList;
import com.imop.lj.gameserver.trade.msg.GCTradeSellResult;
import com.imop.lj.gameserver.trade.search.SimpleSearchInfo;
import com.imop.lj.gameserver.trade.search.TradeSorter;
import com.imop.lj.gameserver.trade.template.TradeSaleableTemplate;

public class TradeService implements InitializeRequired{
	protected static boolean OPEN = true;
	
	/** 拍卖行里的所有商品 commodityType->sellerId->boothIndex->trade*/
	protected HashMap<CommodityType,HashMap<Long,HashMap<Integer,Trade>>> tradeMap = Maps.newHashMap();
	
	public static final Currency TRADE_CURRENCY = Currency.GOLD;
	
	protected Map<Integer,TradeSaleableTemplate> tstMap = Globals.getTemplateCacheService().getAll(TradeSaleableTemplate.class);
	@Override
	public void init() {
		initType();
		loadAllTrade();
	}

	public static boolean isOpen() {
		return OPEN;
	}
	
	protected void initType() {
		tradeMap.put(CommodityType.ITEM, new HashMap<Long,HashMap<Integer,Trade>>());
		tradeMap.put(CommodityType.PET, new HashMap<Long,HashMap<Integer,Trade>>());
	}

	protected void loadAllTrade() {
		List<TradeEntity> tradeList = Globals.getDaoService().getTradeDao().loadAllTradeEntity();
		for (TradeEntity entity : tradeList) {
			CommodityType type = CommodityType.valueOf(entity.getType());
			if (null == type || type == CommodityType.NULL) {
				// 非法数据
				continue;
			}
			TradeStatue ts = TradeStatue.valueOf(entity.getTradeStatus());
			if(ts == null || (ts != TradeStatue.LISTING && ts != TradeStatue.OVERDUE)){
				continue;
			}
			if(entity.getDeleted() != SoftDeleteEntity.UN_DELETED){
				continue;
			}
			Trade trade = new Trade();
			trade.fromEntity(entity);
			addToTradeMap(trade);
			trade.active();
		}
	}
	
	protected void addToTradeMap(Trade trade){
		if(!tradeMap.containsKey(trade.getCommodityType())){
			return;
		}
		if(!tradeMap.get(trade.getCommodityType()).containsKey(trade.getSellerId())){
			tradeMap.get(trade.getCommodityType()).put(trade.getSellerId(), new HashMap<Integer,Trade>());
		}
		if(!tradeMap.get(trade.getCommodityType()).get(trade.getSellerId()).containsKey(trade.getBoothIndex())){
			tradeMap.get(trade.getCommodityType()).get(trade.getSellerId()).put(trade.getBoothIndex(), trade);
		}else{
			Loggers.tradeLogger.error("TradeService.addToTradeMap boothIndex conflict![sellerId="+trade.getSellerId()+",boothIndex="+trade.getBoothIndex()+",tradeId="+trade.getId()+"]");
		}
	}
	
	/**
	 * 获得玩家摊位的交易信息
	 * @param human
	 * @return
	 */
	protected TradeInfo[] getBoothInfo(Human human){
		List<TradeInfo> list = new ArrayList<TradeInfo>();
		for(Entry<CommodityType, HashMap<Long, HashMap<Integer, Trade>>> entry : tradeMap.entrySet()){
			if(entry.getValue().containsKey(human.getUUID())){
				for(Entry<Integer, Trade> tradeEntry : entry.getValue().get(human.getUUID()).entrySet()){
					if(tradeEntry.getValue() != null){
						//这里就不做tradeStatue类型判断了，如果是listing和overdue就正常，如果有其他类型如soldout,takeoff说明出bug了
						list.add(tradeEntry.getValue().getTradeInfo());
					}
				}
			}
		}
		TradeInfo[] arr = new TradeInfo[list.size()];
		arr = list.toArray(arr);
		return arr;
	}
	
	/**
	 * 获得玩家摊位的交易
	 * @param human
	 * @return
	 */
	protected List<Trade> getBoothTrade(Human human){
		List<Trade> list = new ArrayList<Trade>();
		for(Entry<CommodityType, HashMap<Long, HashMap<Integer, Trade>>> entry : tradeMap.entrySet()){
			if(entry.getValue().containsKey(human.getUUID())){
				for(Entry<Integer, Trade> tradeEntry : entry.getValue().get(human.getUUID()).entrySet()){
					if(tradeEntry.getValue() != null){
						list.add(tradeEntry.getValue());
					}
				}
			}
		}
		return list;
	}
	
	
	protected boolean isAlreadyInUsed(Human human,Integer boothIndex){
		List<Trade> tradeList = getBoothTrade(human);
		for(Trade trade : tradeList){
			if(trade.getBoothIndex() == boothIndex){
				return true;
			}
		}
		return false;
	}
	/**
	 * 通过UUID获得属于玩家的商品
	 * @param human
	 * @param UUID
	 * @return
	 */
	protected ITradable<?> getCommodity(Human human, String UUID){
		if(NumberUtils.isNumber(UUID)){
			if(null != human.getPetManager().getPetByUuid(Long.parseLong(UUID)) && human.getPetManager().getPetByUuid(Long.parseLong(UUID)).isPet()){
				return ((PetPet)human.getPetManager().getPetByUuid(Long.parseLong(UUID)));
			}
		}
		if(null != human.getInventory().getItemByUUIDForTrade(UUID)){
			return human.getInventory().getItemByUUIDForTrade(UUID);
		}
		return null;
	}
	
	/**
	 * 获取宠物寿命
	 * @param human
	 * @param petId
	 * @return
	 */
	public int getLife(Human human,long petId) {
		 UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(human.getCharId());
		 if (offlineData != null ) {
			 UserPetData petData = offlineData.getPetData(petId);
			 if (petData != null) {
				 return (int) petData.getLife();
			 }
		}
		return 0;
	}
	/**
	 * 卖商品
	 * @param human 卖家
	 * @param type 商品类型
	 * @param boothIndex 摊位位置
	 * @param currencyType 交易货币类型
	 * @param currencyNum 售价
	 * @param commodity 商品
	 * @param commodityNum 商品数量
	 * @param i 
	 */
	public void sellCommodity(Human human, Integer boothIndex, Currency currencyType, Integer currencyNum, String commodityUUID, Integer commodityNum, Integer commodityType){
		//1.找到这件商品
		ITradable<?> commodityObj = getCommodity(human,commodityUUID);
		if(commodityObj == null){
			human.sendErrorMessage(LangConstants.COMMODITY_CAN_NOT_BE_FOUND);
			return ;
		}
		ICommodity<?> commodity = commodityObj.toCommodity();
		if(commodity == null || commodity.getCommodityType().index != commodityType){
			human.sendErrorMessage(LangConstants.COMMODITY_CAN_NOT_BE_FOUND);
			return ;
		}
		commodity.setCommodityOverLap(commodityNum);
//		//2.物品是否属于玩家
//		if(commodity.getSeller() != human){
//			human.sendErrorMessage(LangConstants.COMMODITY_IS_NOT_YOURS);
//			return ;
//		}
		//2.售价判断
		if(!commodity.inTheRange(currencyType,currencyNum)){
			human.sendErrorMessage(LangConstants.COMMODITY_PRICE_IS_ILLEGLE);
			return ;
		}
		//总价值不能超过int最大值，因为给奖励的时候是int
		long tt = commodityNum * currencyNum;
		if (tt >= Integer.MAX_VALUE) {
			human.sendErrorMessage(LangConstants.COMMODITY_PRICE_IS_ILLEGLE);
			return;
		}
		
		//3.物品是否允许交易
		if(!canBeSale(commodityObj,commodity)){
			human.sendErrorMessage(LangConstants.COMMODITY_CAN_NOT_BE_SALE);
			return ;
		}
		if(commodity.getOverLap() < commodityNum || commodityNum <= 0){
			human.sendErrorMessage(LangConstants.COMMODITY_IS_NOT_ENOUGH);
			return ;
		}
		
		//4.手续费判断
		if(!human.hasEnoughMoney(commodity.getListingFeeNum()*commodityNum, commodity.getListingFeeType(), false)){
			human.sendErrorMessage(LangConstants.LISTING_FEE_IS_NOT_ENOUGH);
			return ;
		}
		//5.摊位判断
		if(boothIndex <= 0 || boothIndex > Globals.getGameConstants().getHumanBoothSize()){
			human.sendErrorMessage(LangConstants.BOOTH_INDEX_OUT_LIMIT);
			return ;
		}
		if(isAlreadyInUsed(human,boothIndex)){
			human.sendErrorMessage(LangConstants.BOOTH_INDEX_IS_ALREADY_IN_USE);
			return ;
		}
		//6.创建商品信息
		Trade trade = buildTrade(human, boothIndex, currencyType, currencyNum, commodity, commodityNum);
		//7.扣手续费
		if(!human.costMoney(commodity.getListingFeeNum()*commodityNum,commodity.getListingFeeType(), true, 0, LogReasons.MoneyLogReason.COST_CURRENCY_BY_LISTING_COMMODITY_ON_TRADE, LogUtils.genReasonText(LogReasons.MoneyLogReason.COST_CURRENCY_BY_LISTING_COMMODITY_ON_TRADE, commodity.getCommodityType(),commodity.getCommodityId()), 0)){
			human.sendErrorMessage(LangConstants.COST_COMMODITY_CURRENCY_IS_FAIL);
			return ;
		}
		//8.移除玩家商品的从属关系(检查物品数量)
		if(!commodityObj.removeCommodityFromSeller(commodityNum)){
			human.sendErrorMessage(LangConstants.COMMODITY_REMOVE_FAIL);
			return ;
		}
		//9.更新map和数据库
		addToTradeMap(trade);
		trade.setModified();
		//10.发消息
		TradeInfo[] infos= getBoothInfo(human);
		human.sendMessage(new GCTradeBoothinfo(infos));
		//通知前台卖出商品成功
		human.sendMessage(new GCTradeSellResult(ResultTypes.SUCCESS.getIndex()));
		
		//日志
		JSONArray jsarray = new JSONArray();
		for (TradeInfo info : infos) {
			jsarray.add(info.toJson());
		}
		Globals.getLogService().sendCommoditySellLog(human, CommoditySellLogReason.SELL_COMMODITY, jsarray.toString(),"");
	}
	
	
	/**
	 * 查询交易信息 TODO
	 * @param human
	 */
	public void findTradeByConditions(Human human,String param){
		//human.sendMessage(new GCTradeBoothinfo(getMatchTrade(param)));
	}
	
	/**
	 * 刷新摊位信息
	 * @param human
	 */
	public void freshBoothInfo(Human human){
		human.sendMessage(new GCTradeBoothinfo(getBoothInfo(human)));
	}
	
	/**
	 * 买商品
	 * @param human
	 * @param commodityUUID
	 */
	public void buyCommodity(Human human, CommodityType type, Long sellerId, Integer boothId, String commodityId){
		//1.拿到这件商品
		Trade trade = getTrade(type,sellerId,boothId);
		if(trade == null || !trade.getCommodityPojo().getCommodityId().equals(commodityId) || trade.getTradeStatus() != TradeStatue.LISTING){
			human.sendErrorMessage(LangConstants.COMMODITY_IS_ALREADY_SOLD_OUT);
			return ;
		}
		//2.售价判断
		if(!human.hasEnoughMoney(trade.getCurrencyNum()*trade.getCommodityNum(), trade.getCurrencyType(), false)){
			human.sendErrorMessage(LangConstants.COMMODITY_CURRENCY_IS_NOT_ENOUGH);
			return ;
		}
		//3.宠物位置与物品位置判断
		if(!hasEnoughSpace(human,trade)){
			human.sendErrorMessage(LangConstants.NOT_ENOUGH_SPACE_TO_PUT_COMMODITY);
			return ;
		}
		//4.下架物品
		trade = tradeMap.get(type).get(sellerId).remove(boothId);
		if(trade == null){
			human.sendErrorMessage(LangConstants.COMMODITY_SET_DOWN_FAIL);
			return ;
		}
		trade.setTradeStatus(TradeStatue.SOLDOUT);
		trade.setModified();
		
		long cost = trade.getCurrencyNum()*trade.getCommodityNum();
		//5.扣钱
		if(!human.costMoney(cost, trade.getCurrencyType(), true, 0, LogReasons.MoneyLogReason.COST_CURRENCY_BY_LISTING_COMMODITY_ON_TRADE, LogUtils.genReasonText(LogReasons.MoneyLogReason.COST_CURRENCY_BY_LISTING_COMMODITY_ON_TRADE, trade.getCommodityType(),trade.getCommodityPojo().getCommodityId(),trade.getCommodityNum()), 0)){
			human.sendErrorMessage(LangConstants.COST_COMMODITY_CURRENCY_IS_FAIL);
			return ;
		}
		//6.给买家发货
		Boolean sendToBuyerSuccess = sendCommodityToHuman(human,trade,true);
		if(!sendToBuyerSuccess){
			human.sendErrorMessage(LangConstants.SEND_COMMODITY_FAIL);
			return ;
		}
		//7.给卖家发钱
		Boolean sendToSellerSuccess = sendCurrencyToSeller(trade);
		if(!sendToSellerSuccess){
			human.sendErrorMessage(LangConstants.SEND_COMMODITY_FAIL);
			return ;
		}
		//8.删除交易信息
		trade.delete();
		
		//日志
		Globals.getLogService().sendCommodityBuyLog(human, CommodityBuyLogReason.BUY_COMMODITY, trade.getTradeInfo().toJson().toString()
				+";tradeStatus=" + TradeStatue.SOLDOUT.index
				+";tradeBuyId=" + human.getCharId(),"");
	}
	
	protected boolean hasEnoughSpace(Human human,Trade trade) {
		switch(trade.getCommodityType()){
		case ITEM : {
			if (!(trade.getCommodityPojo() instanceof TradeItem)) {
				return false;
			}
			
			TradeItem ti = (TradeItem) trade.getCommodityPojo();
			//背包是否可以放下
			int maxCanAdd = human.getInventory().getCommonBagByType(ti.getTemplate().getBagType()).getMaxCanAdd(ti.getTemplate());
			if (maxCanAdd < ti.getOverlap()) {
				return false;
			}
			
			return true;
		}
		case PET : {
			if (Globals.getPetService().isPetNumMax(human)) {
				return false;
			}
			return true;
		}
		default:
			return false;
		}
	}

	/**给卖家发钱*/
	protected boolean sendCurrencyToSeller(Trade trade){
		Reward reward = Globals.getRewardService().createEmptyReward();
		reward.setUuid(KeyUtil.UUIDKey());
		List<RewardParam> rp = new LinkedList<RewardParam>();
		Integer totalMoney = (int)(trade.getCurrencyNum() * (1 - (float)Globals.getGameConstants().getCostTaxForTrade() / Globals.getGameConstants().getTradeBaseNum()))*trade.getCommodityNum();
		rp.add(new RewardParam(RewardType.REWARD_CURRENCY,trade.getCurrencyType().index,totalMoney));
		reward.initReward(rp);
		reward.setReasonType(RewardReasonType.TRADE_REWARD);
		Globals.getMailService().sendSysMail(trade.getSellerId(), MailType.SYSTEM, "拍卖行货物卖出", "", reward);
		return true;
	}
	
	
	/**给玩家发货*/
	protected boolean sendCommodityToHuman(Human human,Trade trade,boolean isBuy){
		switch(trade.getCommodityType()){
		case ITEM : {
			if (!(trade.getCommodityPojo() instanceof TradeItem)) {
				Loggers.tradeLogger.error("trade type is item but is not TradeItem!roleId=" + human.getCharId() + ";tradeId=" + trade.getCharId());
				return false;
			}
			TradeItem ti = (TradeItem) trade.getCommodityPojo();
			
			//背包是否可以放下
			int maxCanAdd = human.getInventory().getCommonBagByType(ti.getTemplate().getBagType()).getMaxCanAdd(ti.getTemplate());
			if (maxCanAdd < trade.getCommodityNum()) {
				return false;
			}
			
			ItemGenLogReason reason;
			ItemLogReason reasonItem;
			if(isBuy){
				reason = ItemGenLogReason.TRADE_BUY;
				reasonItem = ItemLogReason.TRADE_BUY;
			}else{
				reason = ItemGenLogReason.TRADE_TAKE_DOWN;
				reasonItem = ItemLogReason.TRADE_TAKE_DOWN;
			}
			
			int itemTplId = ti.getBaseTemplateId();
			String genDetailReason = LogUtils.genReasonText(reason);
			//装备，仙符
			if (ti.getTemplate().isEquipment() || ti.getTemplate().isSkillEffectItem()) {
				Item equipItem = Globals.getItemService().addItemWithFeature(reason, genDetailReason, reasonItem, human, itemTplId, ti.getFeature());
				if (equipItem == null) {
					return false;
				}
			} else {
				Collection<Item> items = human.getInventory().addItem(itemTplId, trade.getCommodityNum(), reason, genDetailReason, true);
				if(items.isEmpty()){//这里不限制一次只能有一个物品被交易，因为涉及到叠加的情况
					return false;
				}
			}
			
			return true; 
		}
		case PET : {
			if (!(trade.getCommodityPojo() instanceof TradePet)) {
				return false;
			}
			
			PetLogReason reason;
			if(isBuy){
				reason = PetLogReason.TRADE_PET_TO_BUYER;
			}else{
				reason = PetLogReason.TRADE_PET_TAKE_DOWN;
			}
			
			boolean flag = Globals.getPetService().tradeAddPet(human, (TradePet)trade.getCommodityPojo(), reason);
			
			return flag;
		}
		default:
			return false;
		}
	}
	
	public void takeDownTrade(Human human, CommodityType type, Integer boothId){
		//1.拿到这件商品
		Trade trade = getTrade(type,human.getUUID(),boothId);
		if(trade == null || 
				(trade.getTradeStatus() != TradeStatue.LISTING && trade.getTradeStatus() != TradeStatue.OVERDUE) ){
			human.sendErrorMessage(LangConstants.COMMODITY_IS_ALREADY_SOLD_OUT);
			return;
		}
		//3.宠物位置与物品位置判断
		if(!hasEnoughSpace(human,trade)){
			human.sendErrorMessage(LangConstants.NOT_ENOUGH_SPACE_TO_PUT_COMMODITY);
			return ;
		}
		//2.下架物品
		trade = tradeMap.get(type).get(human.getUUID()).remove(boothId);
		if(trade == null){
			human.sendErrorMessage(LangConstants.COMMODITY_SET_DOWN_FAIL);
			return ;
		}
		trade.setTradeStatus(TradeStatue.TAKEDOWN);
		trade.setModified();
		//3.退货
		Boolean sendToBuyerSuccess = sendCommodityToHuman(human,trade,false);
		if(!sendToBuyerSuccess){
			human.sendErrorMessage(LangConstants.SEND_COMMODITY_FAIL);
			return ;
		}
		trade.delete();
		//4.发消息
		human.sendMessage(new GCTradeBoothinfo(getBoothInfo(human)));
		
		//日志
		Globals.getLogService().sendCommoditySellLog(human, CommoditySellLogReason.TAKE_DOWN_COMMODITY, trade.toString(),"");
	}
	
	
	protected Trade getTrade(CommodityType type, Long sellerId, Integer boothId){
		if(!tradeMap.containsKey(type)){
			return null;
		}
		if(!tradeMap.get(type).containsKey(sellerId)){
			return null;
		}
		if(!tradeMap.get(type).get(sellerId).containsKey(boothId)){
			return null;
		}
		return tradeMap.get(type).get(sellerId).get(boothId);
	}
//	/**
//	 * 通过参数查询交易信息
//	 * @param param
//	 * @return
//	 */
//	@SuppressWarnings("unused")
//	protected TradeInfo[] getMatchTrade(String param){
//		List<TradeInfo> list = new ArrayList<TradeInfo>();
//		for(Entry<CommodityType, HashMap<Long, HashMap<Integer, Trade>>> TypeEntry : tradeMap.entrySet()){
//			for(Entry<Long, HashMap<Integer, Trade>> humanEntry : TypeEntry.getValue().entrySet()){
//				for(Entry<Integer, Trade> tradeEntry : humanEntry.getValue().entrySet()){
//					if(tradeEntry.getValue() != null && tradeEntry.getValue().getCommodityPojo() != null && tradeEntry.getValue().getCommodityPojo().isMatch()){
//						list.add(tradeEntry.getValue().getTradeInfo());
//					}
//				}
//			}
//		}
//		TradeInfo[] arr = new TradeInfo[list.size()];
//		arr = list.toArray(arr);
//		return arr;
//	}
	
	/**
	 * 通过参数查询交易信息
	 * @param param
	 * @return
	 */
	protected GCTradeCommodityList getMatchTradeBySimpleSearchInfo(SimpleSearchInfo ssi){
		//1.筛选
		List<Trade> tradeList = getMatchTradeList(ssi);
		//2.排序
		TradeSorter.sortTrade(tradeList,TradeSortableFieldType.valueOf(ssi.getSortField()),TradeOrderType.valueOf(ssi.getSortOrder()));
		//3.分页 修改的是tradeList,返回的是 [0]:当前页 [1]:总页数
		List<Integer> finalPageNumList = getTradeListByPageNum(tradeList,ssi.getPageNum());
		//4.生成tradeInfo
		TradeInfo[] arr = getTradeInfo(tradeList);
		//5.生成消息
		return buildGCTradeCommodityList(finalPageNumList, arr);
	}

	protected GCTradeCommodityList buildGCTradeCommodityList(
			List<Integer> finalPageNumList, TradeInfo[] arr) {
		GCTradeCommodityList gc =  new GCTradeCommodityList();
		gc.setTradeList(arr);
		gc.setPageNum(finalPageNumList.get(0));
		gc.setTotalPageNum(finalPageNumList.get(1));
		return gc;
	}

	protected TradeInfo[] getTradeInfo(List<Trade> tradeList) {
		List<TradeInfo> list = new ArrayList<TradeInfo>();
		for(Trade trade : tradeList){
			list.add(trade.getTradeInfo());
		}
		TradeInfo[] arr = new TradeInfo[list.size()];
		arr = list.toArray(arr);
		return arr;
	}

	protected List<Trade> getMatchTradeList(SimpleSearchInfo ssi) {
		List<Trade> tradeList = new ArrayList<Trade>();
		CommodityType ct = CommodityType.valueOf(ssi.getCommodityType());
		if(ct == null || ct == CommodityType.NULL){
			return tradeList;
		}
		if(!tradeMap.containsKey(ct)){
			return tradeList;
		}
		for(Entry<Long, HashMap<Integer, Trade>> humanEntry : tradeMap.get(ct).entrySet()){
			for(Entry<Integer, Trade> tradeEntry : humanEntry.getValue().entrySet()){
				if (tradeEntry.getValue() != null
						&& tradeEntry.getValue().getTradeStatus() == TradeStatue.LISTING
						&& tradeEntry.getValue().getCommodityPojo() != null
						&& tradeEntry.getValue().getCommodityPojo().isMatch(ssi)) {
					tradeList.add(tradeEntry.getValue());
				}
			}
		}
		return tradeList;
	}
	
	/**通过页数返回目的交易实际页数以及总页数，并修改传进来的list*/
	protected List<Integer> getTradeListByPageNum(List<Trade> srcList, Integer pageNum){
		List<Integer> pageNumList = new ArrayList<Integer>();
		if(srcList == null || srcList.isEmpty()){
			pageNumList.add(1);
			pageNumList.add(1);
			return pageNumList;
		}
		//取得当前list的最后一页
		Integer resultPageNum = 0;
		Integer lastPageNum = srcList.size() / Globals.getGameConstants().getTradeNumPerPage() + 1;
		if(lastPageNum >= pageNum){
			resultPageNum = pageNum;
		}else{
			resultPageNum = lastPageNum;
		}
		//计算所求页数下标范围
		Integer _begin = (resultPageNum - 1) * Globals.getGameConstants().getTradeNumPerPage();//0;8
		Integer _end = _begin - 1 + Globals.getGameConstants().getTradeNumPerPage();//7;15
		List<Trade> resultList = new ArrayList<Trade>();
		for(int i = _begin; i <= _end; i++){
			if(srcList.size() > i){
				resultList.add(srcList.get(i));
			}else{
				break;
			}
		}
		srcList.clear();
		srcList.addAll(resultList);
		pageNumList.add(resultPageNum);
		pageNumList.add(lastPageNum);
		return pageNumList;
	}
	/**
	 * 建立一个新的交易
	 * @param human
	 * @param boothIndex
	 * @param currencyType
	 * @param currencyNum
	 * @param commodity
	 */
	protected Trade buildTrade(Human human, Integer boothIndex,
			Currency currencyType, Integer currencyNum, ICommodity<?> commodity,Integer commodityNum) {
		Trade trade = new Trade(human);
		trade.active(); 
		trade.setBoothIndex(boothIndex);
		trade.setCurrencyType(currencyType);
		trade.setCurrencyNum(currencyNum);
		trade.setCommodityType(commodity.getCommodityType());
		trade.setCommodityPojo(commodity);
		trade.setTradeStatus(TradeStatue.LISTING);
		trade.setCommodityNum(commodityNum);
		trade.buildTradeInfo();
		return trade;
	}
	
	/**
	 * 判断物品是否能够交易
	 * @param type
	 * @param templateId
	 * @return
	 */
	public Boolean canBeSale(ITradable<?> commodityObj,ICommodity<?> commodity){
		if(commodity == null){
			return false ;
		}
		if(commodity.getBaseTemplateId() <= 0){
			return false ;
		}
		if(commodity.getCommodityType() == null || !tradeMap.containsKey(commodity.getCommodityType())){
			return false ;
		}
		for(Entry<Integer, TradeSaleableTemplate> entry : tstMap.entrySet()){
			if(entry.getValue().getIsAvailableForBoolean() && entry.getValue().getCommodityType() == commodity.getCommodityType().index && entry.getValue().getTemplateId() == commodity.getBaseTemplateId()){
				return isValid(commodityObj,commodity);
			}
		}
		return false;
	}
	
	/**
	 * 判断商品是否可以上架，装备的颜色等级等条件限制判断
	 * @return
	 */
	protected Boolean isValid(ITradable<?> commodityObj,ICommodity<?> commodity){
		Item item = null;
		CommodityType ct = commodity.getCommodityType();
		switch(ct){
			case ITEM : {
				item = (Item)commodityObj;
				if (item.getItemType() == ItemType.EQUIP){
					EquipFeature ef = (EquipFeature)item.getFeature();
					if(ef.getColor().index >= Globals.getGameConstants().getTradeEquipLowestColor() //颜色
							&& item.getLevel() >= Globals.getGameConstants().getTradeEquipLowestLevel() //等级
							&& (!(item.getPosition() == null || item.getPosition() == Position.NULL) && (item.getWearerId()==0)) /*没有装备在身上*/ ){ 
						return true;
					} else {
						return false;
					}
				}
				//普通物品
				return true; 
			}
			case PET : {
				//不能是出战宠物
				PetPet pet = (PetPet)commodityObj;
				return Globals.getPetService().getFightPetId(pet.getOwner().getCharId()) != pet.getUUID();
			}
		default:
			return false;
		}
	}
	/**
	 * 简单查询 
	 * @param human
	 * @param ssi
	 */
	public void simpleTradeSearch(Human human,SimpleSearchInfo ssi){
		GCTradeCommodityList gc = getMatchTradeBySimpleSearchInfo(ssi);
		if(gc.getPageNum() != ssi.getPageNum()){
			human.sendErrorMessage(LangConstants.ALL_COMMODITY_IS_SOLD_OUT_IN_PAGE);
		}
		human.sendMessage(gc);
	}
	
	public Integer getSubTagIdByTemplateId(Integer templateId){
		for(Entry<Integer, TradeSaleableTemplate> entry : tstMap.entrySet()){
			if(entry.getValue().getIsAvailableForBoolean() && entry.getValue().getTemplateId() == templateId){
				return entry.getValue().getSubTagId();
			}
		}
		return null;
	}
	
	/**过期检测  检查并将过期的商品状态改为 TradeStatue.OVERDUE*/
	public void overDueTest(){
		//1.拿到当前时间
		Timestamp now = new Timestamp(Globals.getTimeService().now());
		//2.过期检测
		for(Entry<CommodityType, HashMap<Long, HashMap<Integer, Trade>>> entry_1 : tradeMap.entrySet()){
			for(Entry<Long, HashMap<Integer, Trade>> entry_2 : entry_1.getValue().entrySet()){
				for(Entry<Integer, Trade> entry_3 : entry_2.getValue().entrySet()){
					if(entry_3.getValue() != null){
						if(entry_3.getValue().getTradeStatus() == TradeStatue.LISTING){
							if(entry_3.getValue().getOverDueTime().before(now)){
								//Trade trade = tradeMap.get(entry_1.getKey()).get(entry_2.getKey()).remove(entry_3.getKey());
								entry_3.getValue().setTradeStatus(TradeStatue.OVERDUE);
								entry_3.getValue().setModified();
								
								//给玩家发邮件，告知寄售的东西已过期，需要下架
								String mailTitle = Globals.getLangService().readSysLang(LangConstants.TRADE_OVERDUE_MAIL_TITLE);
								String mailContent = Globals.getLangService().readSysLang(LangConstants.TRADE_OVERDUE_MAIL_CONTENT,
										entry_3.getValue().getCommodityPojo().getName(), entry_3.getValue().getCommodityPojo().getOverLap());
								Globals.getMailService().sendSysMail(entry_3.getValue().getSellerId(), 
										MailType.SYSTEM, mailTitle, mailContent, null);
							}
						}
					}
				}
			}
		}
	}
	
}
