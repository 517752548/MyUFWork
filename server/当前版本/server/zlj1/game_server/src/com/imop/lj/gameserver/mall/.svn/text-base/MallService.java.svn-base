package com.imop.lj.gameserver.mall;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.List;
import java.util.Map.Entry;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons;
import com.imop.lj.common.LogReasons.ItemGenLogReason;
import com.imop.lj.common.LogReasons.MallLogReason;
import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.model.mall.MallTimeLimitItemInfo;
import com.imop.lj.core.msg.property.IllegalValueException;
import com.imop.lj.core.util.KeyUtil;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.db.model.MallEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.TipsUtil;
import com.imop.lj.gameserver.common.event.MallBuyItemEvent;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.ItemParam;
import com.imop.lj.gameserver.mall.MallDef.CatalogType;
import com.imop.lj.gameserver.mall.msg.GCMallCatalogInfoList;
import com.imop.lj.gameserver.mall.msg.GCMallItemList;
import com.imop.lj.gameserver.mall.msg.GCNextQueueCd;
import com.imop.lj.gameserver.mall.msg.GCTimeLimitItemList;
import com.imop.lj.gameserver.mall.template.MallCatalogTemplate;
import com.imop.lj.gameserver.mall.template.MallEndBoradcastTimeTemplate;
import com.imop.lj.gameserver.mall.template.MallNormalItemTemplate;
import com.imop.lj.gameserver.mall.template.MallTimeLimitItemTemplate;
import com.imop.lj.gameserver.mall.template.MallTimeLimitQueueTemplate;
import com.imop.lj.gameserver.moneyreport.CurrencyCostDetail;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.task.TaskDef;

/**
 * 商城服务
 * 
 * @author xiaowei.liu
 * 
 */
public class MallService implements InitializeRequired {
	protected static boolean OPEN = true;
	
	public static long MALL_ID = 1;
	// 商城数据
	protected Mall mall;
	
	@Override
	public void init() {
		MallEntity mallEntity = Globals.getDaoService().getMallDao().getMallByCharId(MALL_ID);
		if(mallEntity == null){
			return;
		}
		
		// 加载数据
		mall = new Mall();
		mall.fromEntity(mallEntity);
		this.mall.getLifeCycle().activate();
		
		// 验证队列是否存在
		Iterator<Integer> it = mall.getTimeLimitQueue().iterator();
		int index = 1;
		boolean reset = false;
		while(it.hasNext()){
			Integer queueId = it.next();
			MallTimeLimitQueueTemplate queueTmpl = Globals.getTemplateCacheService().get(queueId, MallTimeLimitQueueTemplate.class);
			if(queueTmpl == null){
				throw new IllegalValueException("MallService.init time limit queue id = " + queueId + " does not exist!!!");
			}
			
			if(!queueTmpl.isEffective()){
				it.remove();
				if(index == 1){
					reset = true;
				}
				Loggers.mallLogger.error("MallService.init time limit queue id = " + queueId + " is not effective!!!");
			}
			
			index ++;
		}
		
		// 验证当前库存是否正确
		Iterator<Entry<Integer, Integer>> stockIt = this.mall.getStock().entrySet().iterator();
		while(stockIt.hasNext()){
			Entry<Integer, Integer> entry = stockIt.next();
			MallTimeLimitItemTemplate itemTmpl = Globals.getTemplateCacheService().get(entry.getKey(), MallTimeLimitItemTemplate.class);
			if(itemTmpl == null){
				stockIt.remove();
			}
			
			if(entry.getValue() > itemTmpl.getInitStockNum()){
				entry.setValue(itemTmpl.getInitStockNum());
			}
		}
		
		// 如果第一个被删除，将当前队列置为限时队列第一个
		if(reset){
			this.setQueueToFirst();
		}
		
		if(!mall.getTimeLimitQueue().isEmpty()){
			MallTimeLimitQueueTemplate queue = Globals.getTemplateCacheService().get(mall.getTimeLimitQueue().getFirst(), MallTimeLimitQueueTemplate.class);
			for(MallTimeLimitItemTemplate tmpl : queue.getItemMap().values()){
				if(this.mall.getStock().get(tmpl.getId()) == null){
					this.mall.getStock().put(tmpl.getId(), tmpl.getInitStockNum());
				}
			}
		}
		
		this.flushMall();
		// 设置公告列表
		this.setBroadcastList();
		// 记日志
		this.sendMallLog(null, MallLogReason.SERVER_INIT, "");
	}
	
	public static boolean isOpen() {
		return OPEN;
	}
	
	/**
	 * 设置当前列队为当前限时队列第一个，此时开始时间与限时队列已有数据,且队列内数据检测正常
	 */
	public void setQueueToFirst() {
		if(this.mall == null){
			return;
		}
		
		if(this.mall.getTimeLimitQueue().isEmpty()){
			return;
		}
		
		int queueId = this.mall.getTimeLimitQueue().getFirst();
		MallTimeLimitQueueTemplate tmpl = Globals.getTemplateCacheService().get(queueId, MallTimeLimitQueueTemplate.class);
		
		// 设置当前队列的UUID
		this.mall.setCurrQueueUUID(KeyUtil.UUIDKey());
		// 设置当前队列的模版ID
		this.mall.setCurrQueueId(queueId);
		
		// 重置库存
		this.mall.getStock().clear();
		for(MallTimeLimitItemTemplate mallItem : tmpl.getItemMap().values()){
			this.mall.getStock().put(mallItem.getId(), mallItem.getInitStockNum());
		}
		
		// 设置公告列表
		this.setBroadcastList();
	}
	
	/**
	 * 设置公告列表
	 */
	public void setBroadcastList(){
		this.mall.getEndBroadcastList().clear();
		MallTimeLimitQueueTemplate queueTmpl = Globals.getTemplateCacheService().get(this.mall.getCurrQueueId(), MallTimeLimitQueueTemplate.class);
		if(queueTmpl == null){
			return;
		}
		
		if(queueTmpl.getEndBroadCastId() <= 0){
			return;
		}
		
		long now = Globals.getTimeService().now();
		long toEndTime = this.mall.getCurrStartTime() + queueTmpl.getTotalPeriodTime() - now;
		for(MallEndBoradcastTimeTemplate tmpl : Globals.getTemplateCacheService().getAll(MallEndBoradcastTimeTemplate.class).values()){
			if(tmpl.getEndTime() < toEndTime){
				this.mall.getEndBroadcastList().add(tmpl.getId());
			}
		}
	}
	
	/**
	 * 刷新商城,根据当前开始时间和当前限时队列刷新商城进度
	 * 
	 */
	public void flushMall(){
		if(this.mall == null){
			return;
		}
		
		if(this.mall.getTimeLimitQueue().isEmpty()){
			return;
		}
		
		long now = Globals.getTimeService().now();
		if(this.mall.getCurrStartTime() > now){
			return;
		}
		
		MallTimeLimitQueueTemplate tmpl = Globals.getTemplateCacheService().get(this.mall.getCurrQueueId(), MallTimeLimitQueueTemplate.class);
		if(this.mall.getCurrStartTime() + tmpl.getTotalPeriodTime() > now){
			this.sendBoradcast(tmpl);
			return;
		}
		
		LinkedList<MallTimeLimitQueueTemplate> list = new LinkedList<MallTimeLimitQueueTemplate>();
		for(int queueId : this.mall.getTimeLimitQueue()){
			MallTimeLimitQueueTemplate queue = Globals.getTemplateCacheService().get(queueId, MallTimeLimitQueueTemplate.class);
			list.add(queue);
		}
		
		long diff = now - this.mall.getCurrStartTime();
		long allTotalTime = this.getTotalTime(list);
		
		if(diff >= allTotalTime){
			diff = diff - allTotalTime;
			this.removeUnloop(list);
		}
		
		if(list.isEmpty()){
			this.mall.getTimeLimitQueue().clear();
			this.mall.getStock().clear();
			this.mall.setModified();
			
			// 记个日志
			this.sendMallLog(null, MallLogReason.FLUSH_MALL, "");
			return;
		}
		
		long totalTime = this.getTotalTime(list);
		
		diff = diff % totalTime;
		long recentStartTime = now - diff;
		int size = list.size();
		
		for (int i = 0; i < size; i++) {
			if(list.isEmpty()){
				break;
			}
			
			MallTimeLimitQueueTemplate queueTmpl = list.getFirst();
			if(recentStartTime + queueTmpl.getTotalPeriodTime() > now){
				break;
			}
			
			recentStartTime += queueTmpl.getTotalPeriodTime();
			list.removeFirst();
			if(queueTmpl.isLoop()){
				list.addLast(queueTmpl);
			}
		}
		
		LinkedList<Integer> timeLimitQueue = new LinkedList<Integer>();
		for(MallTimeLimitQueueTemplate queueTmpl : list){
			timeLimitQueue.add(queueTmpl.getId());
		}
		
		this.mall.setCurrStartTime(recentStartTime);
		this.mall.setTimeLimitQueue(timeLimitQueue);
		
		this.setQueueToFirst();
		this.mall.setModified();
		
		// 记个日志
		this.sendMallLog(null, MallLogReason.FLUSH_MALL, "");
	}
	
	/**
	 * 发送公告
	 */
	public void sendBoradcast(MallTimeLimitQueueTemplate tmpl){
		long now = Globals.getTimeService().now();
		if(this.mall.getCurrStartTime() + tmpl.getDelayTime() > now){
			return;
		}
		long toEndTime = this.mall.getCurrStartTime() + tmpl.getTotalPeriodTime() - now;
		if(toEndTime > Globals.getTemplateCacheService().getMallTemplateCache().getMaxEndTime()){
			if(tmpl.getStartBroadcastId() <= 0){
				return;
			}
			// 播放开始公告
			long interval = now - this.mall.getLastStartBroadcastTime();
			if(interval >= tmpl.getIntervalTime()){
				Globals.getBroadcastService().broadcastWorldMessage(tmpl.getStartBroadcastId());
				this.mall.setLastStartBroadcastTime(now);
			}
		}else{
			if(this.mall.getEndBroadcastList().isEmpty()){
				return;
			}
			
			if(tmpl.getEndBroadCastId() <= 0){
				return;
			}
			
			Iterator<Integer> it = this.mall.getEndBroadcastList().iterator();
			while(it.hasNext()){
				Integer next = it.next();
				MallEndBoradcastTimeTemplate endTmpl = Globals.getTemplateCacheService().get(next, MallEndBoradcastTimeTemplate.class);
				if(endTmpl == null){
					it.remove();
				}
				
				if(endTmpl.getEndTime() > toEndTime){
					// 播放结束公告
					Globals.getBroadcastService().broadcastWorldMessage(tmpl.getEndBroadCastId(), endTmpl.getTimeStr());
					it.remove();
				}
			}
		}
	}
	
	/**
	 * 更新基准时间和限时队列
	 * 
	 * @param startTime
	 * @param timeLimitQueueStr
	 * @param queue
	 * @return
	 */
	public String changeStartTimeAndQueue(long startTime, String timeLimitQueueStr, LinkedList<Integer> timeLimitQueue){
		String result = this.checkStartAndQueue(startTime, timeLimitQueueStr, timeLimitQueue);
		if(result != null){
			return result;
		}
		
		if(this.mall == null){
			this.mall = new Mall();
			this.mall.setId(MALL_ID);
			this.mall.getLifeCycle().activate();
		}
		
		this.mall.setStartConfigTime(startTime);
		this.mall.setQueueConfig(timeLimitQueueStr);
		this.mall.setCurrStartTime(startTime);
		this.mall.setTimeLimitQueue(timeLimitQueue);
		this.setQueueToFirst();
		
		// 初始日志，记录修改数据
		if(this.mall != null){
			Globals.getLogService().sendMallLog(null, MallLogReason.GM_CHANGE_INIT, "", this.mall.toCurrQueueConfig(), this.mall.getCurrQueueUUID(), this.mall.getCurrQueueId(), this.mall.getCurrStartTime(), this.mall.toStockPack());
		}
		// 刷新
		this.flushMall();
		// 刷新后
		this.sendMallLog(null, MallLogReason.GM_CHANGE_AFTER_FLUSH, "");
		this.mall.setModified();
		return null;
	}
	
	/**
	 * 检查数值合法性
	 * 
	 * @param startTime
	 * @param timeLimitQueueStr
	 * @param timeLimitQueue
	 * @return
	 */
	public String checkStartAndQueue(long startTime, String timeLimitQueueStr, LinkedList<Integer> timeLimitQueue){
		if(timeLimitQueue == null || timeLimitQueue.isEmpty()){
			return "time limit queue is empty";
		}
		
		if(startTime <= 0){
			return "start time <= 0";
		}
		
		LinkedList<MallTimeLimitQueueTemplate> list = new LinkedList<MallTimeLimitQueueTemplate>();
		for(int queueId : timeLimitQueue){
			MallTimeLimitQueueTemplate tmpl = Globals.getTemplateCacheService().get(queueId, MallTimeLimitQueueTemplate.class);
			if(tmpl == null){
				return "queue id = " + queueId + " does not exist";
			}
			
			if(!tmpl.isEffective()){
				return "queue id = " + queueId + " is not effective";
			}
			
			list.add(tmpl);
		}
		
		return null;
	}
	
	public void removeUnloop(List<MallTimeLimitQueueTemplate> list){
		Iterator<MallTimeLimitQueueTemplate> it = list.iterator();
		while(it.hasNext()){
			MallTimeLimitQueueTemplate tmpl = it.next();
			if(!tmpl.isLoop()){
				it.remove();
			}
		}
	}
	
	public long getTotalTime(List<MallTimeLimitQueueTemplate> list){
		long totalTime = 0;
		for(MallTimeLimitQueueTemplate tmpl : list){
			totalTime += tmpl.getTotalPeriodTime();
		}
		return totalTime;
	}
	
	/**
	 * 心跳处理
	 */
	public void onHeartBeat(){
		if(this.mall == null || this.mall.getTimeLimitQueue().isEmpty()){
			return;
		}
		
		this.flushMall();
	}
	
	public void onPlayerLogin(long humanId){
		Player player = Globals.getOnlinePlayerService().getPlayer(humanId);
		if(player == null){
			return;
		}
		
		Human human = player.getHuman();
		if(human == null){
			return;
		}
		GCMallCatalogInfoList resp = MallMessageBuilder.createGCatalogInfoList(human);
		human.sendMessage(resp);
	}
	
	//----------------------------------------前端消息处理----------------------------------
	/**
	 * 请求标签内物品
	 * 
	 * @param human
	 * @param catalogId
	 */
	public void handleItemListByCatalogid(Human human, int catalogId){
		MallCatalogTemplate catalog = Globals.getTemplateCacheService().getMallTemplateCache().getMallCatalogTemplateById(catalogId);
		if(catalog == null){
			Loggers.mallLogger.error("MallService.handleItemListByCatalogId human id = " + human.getUUID() + ", catalogId = " + catalogId + " does not exist");
			return;
		}
		
		// 发送普通商品列表
		GCMallItemList mallItemList = MallMessageBuilder.createGCMallItemList(human, catalog);
		human.sendMessage(mallItemList);
		
		if(catalog.getCatalogType() == CatalogType.TIME_LIMIT){
			this.sendTimeLimitQueueInfo(human);
		}
	}
	
	/**
	 * 发送限时队列信息
	 * 
	 * @param human
	 */
	public void sendTimeLimitQueueInfo(Human human){
		if(this.mall == null){
			return;
		}
		
		if(mall.getTimeLimitQueue().isEmpty()){
			return;
		}
		
		// 生成限时队列
		String queueUUID = mall.getCurrQueueUUID();
		long startTime = mall.getCurrStartTime();
		int currQueueId = mall.getCurrQueueId();
		long now = Globals.getTimeService().now();
		
		MallTimeLimitQueueTemplate queue = Globals.getTemplateCacheService().get(currQueueId, MallTimeLimitQueueTemplate.class);
		if(startTime > now){
			return;
		}
		if(startTime + queue.getDelayTime() > now){
			// 当前未开始显示供不倒计时
			GCNextQueueCd cdResp = new GCNextQueueCd();
			cdResp.setCd(startTime + queue.getDelayTime() - now);
			human.sendMessage(cdResp);
		}else if(startTime + queue.getTotalPeriodTime() > now){
			GCTimeLimitItemList timeLimitItemList = new GCTimeLimitItemList();
			timeLimitItemList.setQueueUUID(queueUUID);
			List<MallTimeLimitItemInfo> list = new ArrayList<MallTimeLimitItemInfo>();
			
			for(MallTimeLimitItemTemplate tmpl : queue.getItemMap().values()){
				long validPeriod = startTime + queue.getDelayTime() + tmpl.getValidPeriod() - now;
				if(validPeriod <= 0){
					// 过有效期的不传给前台
					continue;
				}
				
				MallTimeLimitItemInfo info = new MallTimeLimitItemInfo();
				info.setMallItemId(tmpl.getId());
//				info.setCommonItem(EquipMessageBuilder.createCommonItem(tmpl.getSellItem(), tmpl.getSellItemNum()));
				info.setPrice(tmpl.getPrice().getCurrencyInfo());
				info.setValidPeriod(validPeriod);
//				info.setLimitStock(tmpl.isLimitStock() ? ResultType.SUCC.getIndex() : ResultType.FAIL.getIndex());
				info.setStock(mall.getStock().get(tmpl.getId()));
//				info.setLimitPurchase(tmpl.isLimitPurchase() ? ResultType.SUCC.getIndex() : ResultType.FAIL.getIndex());
				
				int num = human.getMallManager().getNum(queueUUID, tmpl.getId());
				if(tmpl.getLimitPurchaseNum() >= num){
					info.setLimitPurchaseNum(tmpl.getLimitPurchaseNum() - num);
				}else{
					info.setLimitPurchaseNum(0);
				}
				
				info.setMarks(tmpl.getMarks());
				list.add(info);
			}
			
			timeLimitItemList.setTimeLimitItemInfoList(list.toArray(new MallTimeLimitItemInfo[0]));
			
			human.sendMessage(timeLimitItemList);
		}
	}
	
	/**
	 * 购买商城普通物品
	 * 
	 * @param human
	 * @param mallItemId
	 */
	public void handleBuyNormalItem(Human human, int mallItemId, int count, boolean flag){
		MallNormalItemTemplate mallItem = Globals.getTemplateCacheService().get(mallItemId, MallNormalItemTemplate.class);
		if(mallItem == null){
			// 购买物品不存在
			Loggers.mallLogger.error("MallService.handleBuyNormalItem mallItemId = " + mallItemId + " does not exist!!");
			return;
		}
		
		//商品是否已下架
		if (!mallItem.isOnSale()) {
			Loggers.mallLogger.warn("MallService.handleBuyNormalItem mallItemId = " + mallItemId + " is not sale!");
			return;
		}
		
		// 判断可购买数量
		if(count <= 0){
			Loggers.mallLogger.error("MallService.handleBuyNormalItem human id = " + human.getUUID() + ", purchase quantity <= 0, count = " + count);
			return;
		}
		
		if(count > Globals.getGameConstants().getSinglePurchaseQuantityMax()){
			Loggers.mallLogger.warn("MallService.handleBuyNormalItem human id = " + human.getUUID() + ", purchase quantity > max, count = " + count);
			return;
		}
		
		long num = mallItem.getDiscountPrice().getNum();
//		if(Globals.getVipService().checkVipRule(human, VipTypeEnum.MALL_DISCOUNT)){
//			int discount = Globals.getVipService().getCountForVipTypeEnumOnOpen(human, VipTypeEnum.MALL_DISCOUNT);
//			if(discount <= 0){
//				Loggers.mallLogger.error("MallService.handleBuyNormalItem discount <= 0");
//				return;
//			}else{
//				double result = (double)num * discount / Globals.getGameConstants().getScale();
//				num = (int)Math.ceil(result);
//			}
//		}
		
		// 背包空间不足
		int buyCount = count * mallItem.getSellItemNum();
		num = num * count;
		
		ItemParam ip = new ItemParam(mallItem.getSellItem().getId(), buyCount);
		List<ItemParam> ipList = new ArrayList<ItemParam>();
		ipList.add(ip);
		if(!human.getInventory().checkSpace(ipList, false)){
			human.sendBoxMessage(LangConstants.MS_BAG_IS_NOT_ENOUGH);
			this.sendCloseBuyItemPanel(human);
			return;
		}
		
		// 扣除货币
		Currency currency = Currency.valueOf(mallItem.getDiscountPrice().getCurrencyType());
		if(!human.hasEnoughMoney(num, currency, true)){
			this.sendCloseBuyItemPanel(human);
			return;
		}
				
//		if(flag && !human.getConsumeConfirm(ConsumeConfirm.MALL_BUY_ITEM)){
//			String bond = TipsUtil.getNumNameByCurrencyTemplate(new CurrencyInfo(mallItem.getDiscountPrice().getCurrencyType(), num));
//			String str = TipsUtil.getItemNameByTemp(mallItem.getSellItem());
//			IStaticHandler handler = new MallBuyItemStaticHandler(false, "", mallItemId);		
//			human.getStaticHandlelHolder().setHandler(handler);
//			human.sendOptionDialogMessage(human.getStaticHandlelHolder().getTag(), "",
//					Globals.getLangService().readSysLang(LangConstants.CONFIRM_OK_TEXT), 
//					Globals.getLangService().readSysLang(LangConstants.CONFIRM_CANCEL_TEXT), 
//					Globals.getLangService().readSysLang(LangConstants.CONFIRM_CONFIRM_TEXT), 
//					LangConstants.MALL_BUY_ITEM, bond, str, mallItem.getSellItemNum());
//			return;
//		}
		
		// 获得需要消耗金钱细节
		CurrencyCostDetail costDetail = human.getCurrencyCostDetail(num, currency);
		
		// 扣除货币
		if(!human.costMoney(num, currency, true, -1, MoneyLogReason.MALL_BUY_ITEM_COST, MoneyLogReason.MALL_BUY_ITEM_COST.getReasonText(), -1)){
			human.sendErrorMessage(LangConstants.COMMON_BASE, TipsUtil.getNameByCurrencyTemplate(currency));
			this.sendCloseBuyItemPanel(human);
			return;
		}
		
		// 给东西
		if (null != costDetail) {
			human.getInventory().addItem(mallItem.getSellItem().getId(), buyCount, ItemGenLogReason.MALL_BUY_ITEM, ItemGenLogReason.MALL_BUY_ITEM.getReasonText(), true, true, 
				currency, costDetail.getTotalCost(), costDetail.getActualCost());
		} else {
			human.getInventory().addItem(mallItem.getSellItem().getId(), buyCount, ItemGenLogReason.MALL_BUY_ITEM, ItemGenLogReason.MALL_BUY_ITEM.getReasonText(), true);
		}

		this.sendCloseBuyItemPanel(human);
		// 记日志
		String param = LogUtils.genReasonText(MallLogReason.BUY_NORMAL_ITEM, currency.getIndex(), num, count, mallItemId, mallItem.getSellItem().getId(), buyCount);
		this.sendMallLog(human, MallLogReason.BUY_NORMAL_ITEM, param);
		
		// 加监听--商城购买物品任务
		Globals.getEventService().fireEvent(new MallBuyItemEvent(human, mallItem.getSellItem().getId(), buyCount));
		
		if(mallItem.getCatalogId() == MallDef.CatalogType.ARENA.getIndex()){
			//任务监听
			human.getTaskListener().onNumRecordDest(TaskDef.NumRecordType.BUY_ITEM_IN_ARENA_SHOP, 0, 1);
		}
		
		//汇报dataEye
		if (currency == Currency.BOND || currency == Currency.SYS_BOND) {
			Globals.getDataEyeService().buyItemLog(human.getPlayer(), mallItem.getSellItem().getId(), buyCount, currency, (int)num, ItemGenLogReason.MALL_BUY_ITEM.getReasonText());
		}
	}
	
	/**
	 * 购买限时队列商品
	 * 
	 * @param human
	 * @param queueUUID
	 * @param mallItemId
	 */
	public void handleBuyTimeLimitItem(Human human, String queueUUID, int mallItemId, int count, boolean flag){
		if(this.mall == null || this.mall.getTimeLimitQueue().isEmpty()){
			Loggers.mallLogger.error("MallService.handleBuyTimeLimitItem humanId = "+human.getUUID()+" mall = null or timeLimitQueue is empty");
			return;
		}
		
		MallTimeLimitQueueTemplate tmpl = Globals.getTemplateCacheService().get(this.mall.getCurrQueueId(), MallTimeLimitQueueTemplate.class);
		MallTimeLimitItemTemplate item = tmpl.getItemMap().get(mallItemId);
		if(item == null){
			Loggers.mallLogger.error("MallService.handleBuyTimeLimitItem humanId = " + human.getUUID() + ",mallItemId = " + mallItemId + " does not exist!!");
			return;
		}
		
		long now = Globals.getTimeService().now();
		// 当前队列是否开启
		if(this.mall.getCurrStartTime() + tmpl.getDelayTime() > now){
			Loggers.mallLogger.error("MallService.handleBuyTimeLimitItem queue is not open");
			return;
		}
		
		// 当前物品是否过期
		if(this.mall.getCurrStartTime() + tmpl.getDelayTime() + item.getValidPeriod() < now){
			Loggers.mallLogger.error("MallService.handleBuyTimeLimitItem item is invalid");
			human.sendErrorMessage(LangConstants.MALL_ITEM_IS_DOWN);
			return;
		}
		
		//判断可购买数量
		if (count <= 0) {
			Loggers.mallLogger.error("MallService.handleBuyNormalItem human id = " + human.getUUID() + ", purchase quantity <= 0, count = " + count);
			return;
		}

		if (count > Globals.getGameConstants().getSinglePurchaseQuantityMax()) {
			Loggers.mallLogger.error("MallService.handleBuyNormalItem human id = " + human.getUUID() + ", purchase quantity > max, count = " + count);
			return;
		}
		
		if(item.isLimitStock()){
			Integer stock = this.mall.getStock().get(mallItemId);
			// 库存是否存在
			if(stock == null){
				Loggers.mallLogger.error("MallService.handleBuyTimeLimitItem item id = " + mallItemId + ", stock = null");
				return;
			}
			
			// 是否还有库存
			if(stock < count){
				this.sendTimeLimitQueueInfo(human);
				human.sendErrorMessage(LangConstants.MALL_STOCK_IS_EMPTY);
				this.sendFlushBuyItemPanel(human);
				return;
			}
		}
		
		// 是否达到个人购买上限
		if(item.isLimitPurchase()){
			int purchaseNum = human.getMallManager().getNum(queueUUID, mallItemId);
			if(purchaseNum + count > item.getLimitPurchaseNum()){
				this.sendTimeLimitQueueInfo(human);
				human.sendErrorMessage(LangConstants.MALL_PURCHASE_REACH_UPPER);
				this.sendFlushBuyItemPanel(human);
				return;
			}
		}
		
		// 货币是否足够
		Currency currency = Currency.valueOf(item.getPrice().getCurrencyType());
		long price = item.getPrice().getNum() * count;
		
		if(!human.hasEnoughMoney(price, currency, false)){
			this.sendCloseBuyItemPanel(human);
			human.sendBoxMessage(LangConstants.CURRENCY_IS_NOT_ENOUGH, TipsUtil.getNameByCurrencyTemplate(currency));
			return;
		}
		
		// 背包空间不足
		int buyCount = item.getSellItemNum() * count;
		
		ItemParam ip = new ItemParam(item.getSellItem().getId(), buyCount);
		List<ItemParam> ipList = new ArrayList<ItemParam>();
		ipList.add(ip);
		if(!human.getInventory().checkSpace(ipList, false)){
			this.sendCloseBuyItemPanel(human);
			human.sendBoxMessage(LangConstants.MS_BAG_IS_NOT_ENOUGH);
			return;
		}
		
//		if(flag && !human.getConsumeConfirm(ConsumeConfirm.MALL_BUY_ITEM)){
//			String bond = TipsUtil.getNumNameByCurrencyTemplate(item.getPrice().getCurrencyInfo());
//			String str = TipsUtil.getItemNameByTemp(item.getSellItem());
//			IStaticHandler handler = new MallBuyItemStaticHandler(true, this.mall.getCurrQueueUUID(), mallItemId);		
//			human.getStaticHandlelHolder().setHandler(handler);
//			human.sendOptionDialogMessage(human.getStaticHandlelHolder().getTag(), "",
//					Globals.getLangService().readSysLang(LangConstants.CONFIRM_OK_TEXT), 
//					Globals.getLangService().readSysLang(LangConstants.CONFIRM_CANCEL_TEXT), 
//					Globals.getLangService().readSysLang(LangConstants.CONFIRM_CONFIRM_TEXT), 
//					LangConstants.MALL_BUY_ITEM, bond, str, item.getSellItemNum());
//			return;
//		}
		
		// 获得需要消耗金钱细节
		CurrencyCostDetail costDetail = human.getCurrencyCostDetail(price, currency);
				
		// 扣除货币，减少库存，增加个人购买
		if(!human.costMoney(price, currency, true, 1, MoneyLogReason.MALL_BUY_ITEM_COST, MoneyLogReason.MALL_BUY_ITEM_COST.getReasonText(), -1)){
			this.sendCloseBuyItemPanel(human);
			return;
		}
		
		if(item.isLimitStock()){
			Integer stock = this.mall.getStock().get(mallItemId);
			// 库存是否存在 
			if(stock == null){
				Loggers.mallLogger.error("MallService.handleBuyTimeLimitItem item id = " + mallItemId + ", stock = null");
				return;
			}
			
			// 是否还有库存
			if(stock < count){
				this.sendTimeLimitQueueInfo(human);
				Loggers.mallLogger.error("MallService.handleBuyTimeLimitItem reduce stock error, stock <= 0 ");
				human.sendErrorMessage(LangConstants.MALL_STOCK_IS_EMPTY);
				this.sendFlushBuyItemPanel(human);
				return;
			}
			
			stock = stock - count;
			this.mall.getStock().put(mallItemId, stock);
			this.mall.setModified();
		}
		
		if(item.isLimitPurchase()){
			int purchaseNum = human.getMallManager().getNum(queueUUID, mallItemId);
			if(purchaseNum + count > item.getLimitPurchaseNum()){
				this.sendTimeLimitQueueInfo(human);
				human.sendErrorMessage(LangConstants.MALL_PURCHASE_REACH_UPPER);
				Loggers.mallLogger.error("MallService.handleBuyTimeLimitItem increase purchase num error, reach upper");
				this.sendCloseBuyItemPanel(human);
				return;
			}
			
			human.getMallManager().increaseNum(queueUUID, mallItemId, count);
		}
		
		// 给东西
		if (null != costDetail) {
			human.getInventory().addItem(item.getSellItem().getId(), buyCount, ItemGenLogReason.MALL_BUY_ITEM, ItemGenLogReason.MALL_BUY_ITEM.getReasonText(), true, true, 
				currency, costDetail.getTotalCost(), costDetail.getActualCost());
		} else {
			human.getInventory().addItem(item.getSellItem().getId(), buyCount, ItemGenLogReason.MALL_BUY_ITEM, ItemGenLogReason.MALL_BUY_ITEM.getReasonText(), true);
		}
		
		this.sendCloseBuyItemPanel(human);
		this.sendTimeLimitQueueInfo(human);
		// 记日志
		String param = LogUtils.genReasonText(MallLogReason.BUY_TIME_LIMIT_ITEM, currency.getIndex(), price, count, mallItemId, item.getSellItem().getId(), buyCount, human.getMallManager().toJsonProp());
		this.sendMallLog(human, MallLogReason.BUY_TIME_LIMIT_ITEM, param);
		
		// 加监听--商城购买物品任务
		Globals.getEventService().fireEvent(new MallBuyItemEvent(human, mallItemId, buyCount));
		
		//汇报dataEye
		if (currency == Currency.BOND || currency == Currency.SYS_BOND) {
			Globals.getDataEyeService().buyItemLog(human.getPlayer(), item.getSellItem().getId(), buyCount, currency, (int)price, ItemGenLogReason.MALL_BUY_ITEM.getReasonText());
		}
	}
	
	/**
	 * 发送日志 
	 * 
	 * @param human
	 * @param reason
	 * @param param
	 */
	public void sendMallLog(Human human, LogReasons.MallLogReason reason, String param){
		if(this.mall != null){
			Globals.getLogService().sendMallLog(human, reason, param, this.mall.toCurrQueueConfig(), this.mall.getCurrQueueUUID(), this.mall.getCurrQueueId(), this.mall.getCurrStartTime(), this.mall.toStockPack());
		}else{
			Globals.getLogService().sendMallLog(human, reason, param, "", "", 0, 0, "");
		}		
		
	}
	
	public void sendCloseBuyItemPanel(Human human){
		human.sendMessage(MallMessageBuilder.createGcBuyItemPanelOperate(1));
	}
	
	public void sendFlushBuyItemPanel(Human human){
		human.sendMessage(MallMessageBuilder.createGcBuyItemPanelOperate(2));
	}
}
