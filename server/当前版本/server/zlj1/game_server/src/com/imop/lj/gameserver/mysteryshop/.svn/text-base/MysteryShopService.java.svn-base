package com.imop.lj.gameserver.mysteryshop;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons.ItemGenLogReason;
import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.LogReasons.MysteryShopLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.model.CurrencyInfo;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.TipsUtil;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.ConsumeConfirm;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemParam;
import com.imop.lj.gameserver.moneyreport.CurrencyCostDetail;
import com.imop.lj.gameserver.mysteryshop.MysteryShopDef.BuyState;
import com.imop.lj.gameserver.mysteryshop.MysteryShopDef.FlushType;
import com.imop.lj.gameserver.mysteryshop.confirm.MSVipFlushStaticHandler;
import com.imop.lj.gameserver.mysteryshop.template.MysteryShopItemTemplate;
import com.imop.lj.gameserver.player.IStaticHandler;

/**
 * 神秘商店
 * 
 * @author xiaowei.liu
 * 
 */
public class MysteryShopService implements InitializeRequired {
	/** 该活动是否开启的全局状态位 */
	protected static boolean OPEN = true;
	
	@Override
	public void init() {
		
	}
	
	public void handleFuncOpen(Human human, FuncTypeEnum funcType){
		if(funcType != FuncTypeEnum.MYSTERY_SHOP){
			return;
		}
		MysteryShopManager manager = human.getMysteryShopManager();
		manager.setLastFlushTime(Globals.getTimeService().now());
		List<MysteryShopItemTemplate> list = Globals.getTemplateCacheService().getMysteryShopTemplateCache().normalFlush(manager.getOwner());
		manager.updateItemList(list);
		manager.getOwner().setModified();
		
		// 记个日志吧
		String param = MysteryShopLogReason.FUNC_OPEN.getReasonText();
		Globals.getLogService().sendMysteryShopLog(human, MysteryShopLogReason.FUNC_OPEN, param, "");
	}

	/**
	 * 请求神秘商店信息
	 * 
	 * @param human
	 */
	public void handleReqMysteryShopInfo(Human human) {
		MysteryShopManager manager = human.getMysteryShopManager();
		this.checkExpireAndReset(manager);
		human.sendMessage(MysteryShopMsgBuilder.createGCMysteryShopInfo(manager));
	}
	
	/**
	 * 刷新
	 * 
	 * @param human
	 * @param flushType
	 */
	public void handleFlushMystery(Human human, int flushType, boolean flag){
		if(flushType == FlushType.NORMAL.getIndex()){
			this.handleNormalFlushMystery(human, true);
		}
//		else if(flushType == FlushType.VIP.getIndex()){
//			this.handleVipFlushMystery(human, true);
//		}
	}
	
	/**
	 * 普通刷新
	 * 
	 * @param human
	 */
	public void handleNormalFlushMystery(Human human, boolean flag){
		MysteryShopManager manager = human.getMysteryShopManager();
		// 是否可以免費刷新 
		if(!human.getBehaviorManager().canDo(BehaviorTypeEnum.MYSTERY_SHOP_NUM)){
			human.sendErrorMessage(LangConstants.MS_FLUSH_NOT_ENOUGH);
			return;
		}
		//是否有足够的元宝
		if(!human.hasEnoughMoney(Globals.getGameConstants().getMsBondFlushPrice(), Currency.BOND, false)){
			human.sendBoxMessage(LangConstants.MS_BOND_IS_NOT_ENOUGH);
			return;
		}
		// 扣除元宝
		// 刷新价格,每次刷新花费  = 2 * 已刷新次数 * 钱数
		int count = manager.getOwner().getBehaviorManager().getCount(BehaviorTypeEnum.MYSTERY_SHOP_NUM);
		long amount = 0L;
		//只是打开神秘商店
		if(count == 0){
			amount = Globals.getGameConstants().getMsBondFlushPrice();
		}else{
			//刷新
			amount = Globals.getGameConstants().getMsBondFlushPrice() 
					* Globals.getGameConstants().getMsRefereshCoef()
					* count;
		}
		if(!human.costMoney(amount, Currency.BOND, true, 1, 
				MoneyLogReason.MS_BOND_FLUSH_COST, MoneyLogReason.MS_BOND_FLUSH_COST.getReasonText(), -1)){
			return;
		}
		
		//扣除次数
		human.getBehaviorManager().doBehavior(BehaviorTypeEnum.MYSTERY_SHOP_NUM);
		//设置刷新时间
		manager.setLastFlushTime(Globals.getTimeService().now());
		List<MysteryShopItemTemplate> list = Globals.getTemplateCacheService().getMysteryShopTemplateCache().normalFlush(human);
		manager.updateItemList(list);
		manager.getOwner().setModified();
		this.handleReqMysteryShopInfo(human);
		human.sendErrorMessage(LangConstants.FLUSH_SUCC);
		
		// 记个日志吧
		String param = MysteryShopLogReason.FREE_FLUSH.getReasonText();
		Globals.getLogService().sendMysteryShopLog(human, MysteryShopLogReason.FREE_FLUSH, param, "");
		
		
	}
	
	/**
	 * VIP刷新
	 * 
	 * @param human
	 */
	public void handleVipFlushMystery(Human human, boolean flag){
		MysteryShopManager manager = human.getMysteryShopManager();
//		if(!Globals.getVipService().checkVipRule(human, VipTypeEnum.MYSTERY_SHOP_VIP_FLUSH)){
//			return;
//		}
		
		List<MysteryShopItemTemplate> vipList = Globals.getTemplateCacheService().getMysteryShopTemplateCache().getVipWeightMap().get(human.getLevel());
		if(vipList == null || vipList.isEmpty()){
			human.sendErrorMessage(LangConstants.NOT_HAS_RECOMMEND_ITEM);
			return;
		}
		
		if(flag && !human.getConsumeConfirm(ConsumeConfirm.NULL)){//FIXME
			String bond = TipsUtil.getNumNameByCurrencyTemplate(new CurrencyInfo(Currency.BOND.index, Globals.getGameConstants().getMsHighlevelBondFlushPrice()));
			IStaticHandler handler = new MSVipFlushStaticHandler();
			human.getStaticHandlelHolder().setHandler(handler);
			human.sendOptionDialogMessage(human.getStaticHandlelHolder().getTag(), "",
					Globals.getLangService().readSysLang(LangConstants.CONFIRM_OK_TEXT), 
					Globals.getLangService().readSysLang(LangConstants.CONFIRM_CANCEL_TEXT), 
					Globals.getLangService().readSysLang(LangConstants.CONFIRM_CONFIRM_TEXT), 
					LangConstants.MS_VIP_FLUSH, bond);
			return;
		}
		
		List<MysteryShopItemTemplate> list = Globals.getTemplateCacheService().getMysteryShopTemplateCache().vipFlush(human);
		if(list == null || list.isEmpty()){
			human.sendErrorMessage(LangConstants.NOT_HAS_RECOMMEND_ITEM);
			return;
		}
		
		if(!human.costMoney(Globals.getGameConstants().getMsHighlevelBondFlushPrice(), Currency.GIFT_BOND, true, -1, 
				MoneyLogReason.MS_HIGH_LEVEL_FLUSH_COST, MoneyLogReason.MS_HIGH_LEVEL_FLUSH_COST.getReasonText(), -1)){
			human.sendErrorMessage(LangConstants.COMMON_NOT_ENOUGH, Globals.getLangService().readSysLang(Currency.BOND.getNameKey()));
			return;
		}
		
		manager.setLastFlushTime(Globals.getTimeService().now());
		manager.updateItemList(list);
		manager.getOwner().setModified();
		this.handleReqMysteryShopInfo(human);
		human.sendErrorMessage(LangConstants.FLUSH_SUCC);
		
		// 日志
		String param = LogUtils.genReasonText(MysteryShopLogReason.VIP_FLUSH, Globals.getGameConstants().getMsHighlevelBondFlushPrice());
		Globals.getLogService().sendMysteryShopLog(human, MysteryShopLogReason.VIP_FLUSH, param, "");
	}
	
	
	/**
	 * 购买神秘商店物品
	 * 
	 * @param human
	 * @param msItemId
	 */
	public void handleBuyMsItem(Human human, int msItemId, boolean flag) {
		MysteryShopManager manager = human.getMysteryShopManager();
		if(this.checkExpireAndReset(manager)){
			human.sendErrorMessage(LangConstants.MS_ITEM_EXPIRE);
			this.handleReqMysteryShopInfo(human);
			return;
		}
		
		MysteryShopItemTemplate tmpl = Globals.getTemplateCacheService().get(msItemId, MysteryShopItemTemplate.class);
		if(tmpl == null){
			// 物品不存在
			Loggers.mysteryShopLogger.error("MysteryShopService.handleBuyMsItem for tmpl, msitemId = " + msItemId + " does not exist");
			return;
		}
		
		MSItem msItem = manager.getMSItem(msItemId);
		
		if(msItem == null){
			Loggers.mysteryShopLogger.error("MysteryShopService.handleBuyMsItem for manager msitemId = " + msItemId + " does not exist");
			return;
		}
		
		if(msItem.getState() == BuyState.HAVE_BUY){
			Loggers.mysteryShopLogger.error("MysteryShopService.handleBuyMsItem  msitemId = " + msItemId + " has buyed");
			return;
		}
		
		List<ItemParam> list = new ArrayList<ItemParam>();
		list.add(new ItemParam(tmpl.getItem().getId(), tmpl.getNum()));
		if(!human.getInventory().checkSpace(list, false)){
			human.sendBoxMessage(LangConstants.MS_BAG_IS_NOT_ENOUGH);
			return;
		}
		
		Currency currency = Currency.valueOf(tmpl.getPrice().getCurrencyType());
		long cost = tmpl.getPrice().getNum();
		
		if(!human.hasEnoughMoney(cost, currency, false)){
			human.sendBoxMessage(LangConstants.MS_CURRENCY_IS_NOT_ENOUGH, Globals.getLangService().readSysLang(currency.getNameKey()));
			return;
		}
		
		// 获得需要消耗金钱细节
		CurrencyCostDetail costDetail = human.getCurrencyCostDetail(cost, currency);
				
		if(!human.costMoney(cost, currency, true, -1, 
				MoneyLogReason.MS_BUY_ITEM_COST, MoneyLogReason.MS_BUY_ITEM_COST.getReasonText(), -1)){
			human.sendBoxMessage(LangConstants.MS_BOND_IS_NOT_ENOUGH);
			return;
		}
		
		msItem.setState(BuyState.HAVE_BUY);
		manager.getOwner().setModified();
		//直接显示售罄,不会再补充上去
		this.handleReqMysteryShopInfo(human);
		
		Collection<Item> coll = new ArrayList<Item>();
		if (null != costDetail) {
			coll = human.getInventory().addItem(tmpl.getItem().getId(), tmpl.getNum(), ItemGenLogReason.MS_BUY_ITEM, ItemGenLogReason.MS_BUY_ITEM.getReasonText(), true, true, 
				currency, costDetail.getTotalCost(), costDetail.getActualCost());
		} else {
			coll = human.getInventory().addItem(tmpl.getItem().getId(), tmpl.getNum(), ItemGenLogReason.MS_BUY_ITEM, ItemGenLogReason.MS_BUY_ITEM.getReasonText(), true);
		}
		
		// 日志
		String param = LogUtils.genReasonText(MysteryShopLogReason.BUY_ITEM, tmpl.getPrice().getCurrencyType(), tmpl.getPrice().getNum(), tmpl.getId(), tmpl.getItem().getId(), tmpl.getNum());
		Globals.getLogService().sendMysteryShopLog(human, MysteryShopLogReason.BUY_ITEM, param, "");
		
		//汇报dataEye
		if (currency == Currency.BOND || currency == Currency.SYS_BOND) {
			Globals.getDataEyeService().buyItemLog(human.getPlayer(), tmpl.getItem().getId(), tmpl.getNum(), currency, (int)cost, ItemGenLogReason.MS_BUY_ITEM.getReasonText());
		}
	}
	
	/**
	 * 检查是否过期，过期返回True并重置CD，否则返回false
	 * 
	 * @param manager
	 * @return
	 */
	protected boolean checkExpireAndReset(MysteryShopManager manager){
		long lastFlushTime = manager.getLastFlushTime();
		long now = Globals.getTimeService().now();
		
		if(lastFlushTime + Globals.getGameConstants().getMysteryShopCd() > now){
			return false;
		}
		
		//取得当前时间的整点:比如当前时间为10:59,则为10:00
		manager.setLastFlushTime(now - (now - lastFlushTime) % Globals.getGameConstants().getMysteryShopCd());
		List<MysteryShopItemTemplate> list = Globals.getTemplateCacheService().getMysteryShopTemplateCache().normalFlush(manager.getOwner());
		manager.updateItemList(list);
		manager.getOwner().setModified();
		
		// 日志
		Globals.getLogService().sendMysteryShopLog(manager.getOwner(), MysteryShopLogReason.FLUSH_CD_OVER, MysteryShopLogReason.FLUSH_CD_OVER.reasonText, "");
		return true;
	}

	public boolean isOpening() {
		return OPEN;
	}
}
