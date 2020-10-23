package com.imop.lj.gameserver.mysteryshop;

import java.lang.reflect.Field;
import java.util.ArrayList;
import java.util.Collection;
import java.util.List;
import java.util.Map;

import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.LogReasons.MysteryShopLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.model.CurrencyInfo;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.core.util.MathUtils;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;
import com.imop.lj.gameserver.cache.template.MysteryShopTemplateCache;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.TipsUtil;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.human.ConsumeConfirm;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.mysteryshop.confirm.BondOrNoteFlushStaticHandler;
import com.imop.lj.gameserver.mysteryshop.confirm.MSVipFlushStaticHandler;
import com.imop.lj.gameserver.mysteryshop.template.MysteryShopItemTemplate;
import com.imop.lj.gameserver.player.IStaticHandler;

public class NewMysteryShopService extends com.imop.lj.gameserver.mysteryshop.MysteryShopService {
	/**
	 * 普通刷新
	 * 
	 * @param human
	 */
	public void handleNormalFlushMystery(Human human, boolean flag){
		MysteryShopManager manager = human.getMysteryShopManager();
		// 是否可以免費刷新
		if(human.getBehaviorManager().canDo(BehaviorTypeEnum.UNKNOWN)){//FIXME
			human.getBehaviorManager().doBehavior(BehaviorTypeEnum.UNKNOWN);//FIXME
			
			manager.setLastFlushTime(Globals.getTimeService().now());
			List<MysteryShopItemTemplate> list = this.normalFlush(human);
			manager.updateItemList(list);
			manager.getOwner().setModified();
			this.handleReqMysteryShopInfo(human);
			human.sendErrorMessage(LangConstants.FLUSH_SUCC);
			
			// 记个日志吧
			String param = MysteryShopLogReason.FREE_FLUSH.getReasonText();
			Globals.getLogService().sendMysteryShopLog(human, MysteryShopLogReason.FREE_FLUSH, param, "");
			return;
		}
		
		// 元宝或珍宝票
		if(flag && !human.getConsumeConfirm(ConsumeConfirm.NULL)){//FIXME
			String bond = TipsUtil.getNumNameByCurrencyTemplate(new CurrencyInfo(Currency.BOND.index, Globals.getGameConstants().getMsBondFlushPrice()));
			
			IStaticHandler handler = new BondOrNoteFlushStaticHandler();
			human.getStaticHandlelHolder().setHandler(handler);
			human.sendOptionDialogMessage(human.getStaticHandlelHolder().getTag(), "",
					Globals.getLangService().readSysLang(LangConstants.CONFIRM_OK_TEXT), 
					Globals.getLangService().readSysLang(LangConstants.CONFIRM_CANCEL_TEXT), 
					Globals.getLangService().readSysLang(LangConstants.CONFIRM_CONFIRM_TEXT), 
					LangConstants.MS_BOND_OR_NOTE_FLUSH, bond, Globals.getGameConstants().getTreasureNoteTemplateNum(), 
					TipsUtil.getItemNameById(Globals.getGameConstants().getTreasureNoteTemplateId()));
			return;
		}
		
		// 优先扣除珍宝票
		Collection<Item> coll = human.getInventory().removeItem(Globals.getGameConstants().getTreasureNoteTemplateId(), 
				Globals.getGameConstants().getTreasureNoteTemplateNum(), 
			ItemLogReason.ACCU_COST_ACTIVITY, ItemLogReason.ACCU_COST_ACTIVITY.getReasonText());//FIXME 随便写一个不报错的 
			//ItemLogReason.MS_BOND_FLUSH_COST, ItemLogReason.MS_BOND_FLUSH_COST.getReasonText());
		if(coll != null && !coll.isEmpty()){
			manager.setLastFlushTime(Globals.getTimeService().now());
			List<MysteryShopItemTemplate> list = this.normalFlush(human);
			manager.updateItemList(list);
			manager.getOwner().setModified();
			this.handleReqMysteryShopInfo(human);
			human.sendErrorMessage(LangConstants.FLUSH_SUCC);
			
			// 日志
			String param = LogUtils.genReasonText(MysteryShopLogReason.TREASURE_NOTE_FLUSH, Globals.getGameConstants().getTreasureNoteTemplateId(), Globals.getGameConstants().getTreasureNoteTemplateNum());
			Globals.getLogService().sendMysteryShopLog(human, MysteryShopLogReason.TREASURE_NOTE_FLUSH, param, "");
			return;
		}
		
		// 扣除元宝
		if(human.costMoney(Globals.getGameConstants().getMsBondFlushPrice(), Currency.GIFT_BOND, true, 1, 
				MoneyLogReason.MS_BOND_FLUSH_COST, MoneyLogReason.MS_BOND_FLUSH_COST.getReasonText(), -1)){
			
			manager.setLastFlushTime(Globals.getTimeService().now());
			List<MysteryShopItemTemplate> list = this.normalFlush(human);
			manager.updateItemList(list);
			manager.getOwner().setModified();
			this.handleReqMysteryShopInfo(human);
			human.sendErrorMessage(LangConstants.FLUSH_SUCC);
			
			// 日志
			String param = LogUtils.genReasonText(MysteryShopLogReason.BOND_FLUSH, Globals.getGameConstants().getMsBondFlushPrice());
			Globals.getLogService().sendMysteryShopLog(human, MysteryShopLogReason.TREASURE_NOTE_FLUSH, param, "");
			return;
		}
		
		human.sendErrorMessage(LangConstants.NOTE_OR_BOND_NOT_ENOUTH);
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
		
		List<MysteryShopItemTemplate> list = this.vipFulsh(human);
		if(list == null || list.isEmpty()){
			human.sendErrorMessage(LangConstants.NOT_HAS_RECOMMEND_ITEM);
			return;
		}
		
		if(flag && !human.getConsumeConfirm(ConsumeConfirm.NULL)){		//FIXME	
			IStaticHandler handler = new MSVipFlushStaticHandler();
			human.getStaticHandlelHolder().setHandler(handler);
			human.sendOptionDialogMessage(human.getStaticHandlelHolder().getTag(), "",
					Globals.getLangService().readSysLang(LangConstants.CONFIRM_OK_TEXT), 
					Globals.getLangService().readSysLang(LangConstants.CONFIRM_CANCEL_TEXT), 
					Globals.getLangService().readSysLang(LangConstants.CONFIRM_CONFIRM_TEXT), 
					LangConstants.MS_VIP_FLUSH, Globals.getGameConstants().getMsHighlevelBondFlushPrice());
			return;
		}
		
		if(!human.costMoney(Globals.getGameConstants().getMsHighlevelBondFlushPrice(), Currency.GIFT_BOND, true, -1, 
				MoneyLogReason.MS_HIGH_LEVEL_FLUSH_COST, MoneyLogReason.MS_HIGH_LEVEL_FLUSH_COST.getReasonText(), -1)){
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
	
	public List<MysteryShopItemTemplate> normalFlush(Human human){
		Object obj = this.getObject("normalWeightMap");
		if(!(obj instanceof Map)){
			return new ArrayList<MysteryShopItemTemplate>();
		}
		
		Map map = (Map)obj;
		Object objlist = map.get(human.getLevel());
		
		if(!(objlist instanceof List)){
			return new ArrayList<MysteryShopItemTemplate>();
		}
		
		List list = (List)objlist;
		List<MysteryShopItemTemplate> result = new ArrayList<MysteryShopItemTemplate>();
		for(Object oo : list){
			if(oo instanceof MysteryShopItemTemplate){
				result.add((MysteryShopItemTemplate)oo);
			}
		}
		
		return flush(result);
	}
	
	public List<MysteryShopItemTemplate> vipFulsh(Human human){
		Object obj = this.getObject("vipWeightMap");
		if(!(obj instanceof Map)){
			return new ArrayList<MysteryShopItemTemplate>();
		}
		
		Map map = (Map)obj;
		Object objlist = map.get(human.getLevel());
		
		if(!(objlist instanceof List)){
			return new ArrayList<MysteryShopItemTemplate>();
		}
		
		List list = (List)objlist;
		List<MysteryShopItemTemplate> result = new ArrayList<MysteryShopItemTemplate>();
		for(Object oo : list){
			if(oo instanceof MysteryShopItemTemplate){
				result.add((MysteryShopItemTemplate)oo);
			}
		}
		
		return flush(result);
	}
	
	public Object getObject(String name){
		MysteryShopTemplateCache cache = Globals.getTemplateCacheService().getMysteryShopTemplateCache();
		try {
			Field field = cache.getClass().getDeclaredField(name);
			if(field == null){
				return new Object();
			}
			field.setAccessible(true);
			Object obj = field.get(cache);
			return obj;
		} catch (Exception e) {
			e.printStackTrace();
			return new Object();
		} 
		
	}
	
	public List<MysteryShopItemTemplate> flush(List<MysteryShopItemTemplate> list){
		if(list == null || list.isEmpty()){
			return null;
		}
		
		List<MysteryShopItemTemplate> tmplList = new ArrayList<MysteryShopItemTemplate>();
		tmplList.addAll(list);
		List<MysteryShopItemTemplate> result = new ArrayList<MysteryShopItemTemplate>();
		
		for(int i=0; i< 4; i++){
			if(tmplList.size() <= 0){
				break;
			}
			
			int[] weight = new int[tmplList.size()];
			for(int k=0; k<tmplList.size(); k++){
				weight[k] = tmplList.get(k).getWeight();
			}
			
			int index = MathUtils.random(weight);
			MysteryShopItemTemplate tmpl = tmplList.remove(index);
			if(tmpl != null){
				result.add(tmpl);
			}
		}
		return result;
	}
}
