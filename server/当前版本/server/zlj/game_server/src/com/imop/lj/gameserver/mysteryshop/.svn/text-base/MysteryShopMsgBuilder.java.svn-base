package com.imop.lj.gameserver.mysteryshop;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.model.CurrencyInfo;
import com.imop.lj.common.model.mysteryshop.MSItemInfo;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.mysteryshop.msg.GCMysteryShopInfo;
import com.imop.lj.gameserver.mysteryshop.template.MysteryShopItemTemplate;

/**
 * 神秘商店消息生成器
 * 
 * @author xiaowei.liu
 * 
 */
public class MysteryShopMsgBuilder {
	public static GCMysteryShopInfo createGCMysteryShopInfo(MysteryShopManager manager){
		GCMysteryShopInfo resp = new GCMysteryShopInfo();
		// 神秘商店物品列表
		List<MSItem> msItemList = manager.getItemList();
		List<MSItemInfo> itemInfoList = new ArrayList<MSItemInfo>();
		for(MSItem item : msItemList){
			MysteryShopItemTemplate tmpl = Globals.getTemplateCacheService().get(item.getId(), MysteryShopItemTemplate.class);
			MSItemInfo info = new MSItemInfo();
			if(tmpl != null){
				info.setId(item.getId());
				info.setBuyState(item.getState() == null ? 0 : item.getState().getIndex());
				itemInfoList.add(info);
			}
		}
		
		resp.setMsItemInfoList(itemInfoList.toArray(new MSItemInfo[0]));
		
		// 返回需要刷新的CD = 上次刷新时间 + 默认CD时间 - 当前时间
		long cd = manager.getLastFlushTime() + Globals.getGameConstants().getMysteryShopCd() - Globals.getTimeService().now();
		cd = cd < 0 ? 0 : cd;
		resp.setCd(cd);
		
		// 刷新价格,每次刷新花费  = 2 * 已刷新次数 * 钱数
		int count = manager.getOwner().getBehaviorManager().getCount(BehaviorTypeEnum.MYSTERY_SHOP_NUM);
		//只是打开神秘商店
		if(count == 0){
			resp.setBondFlushPrice(new CurrencyInfo(Currency.BOND.index, Globals.getGameConstants().getMsBondFlushPrice()));
		}else{
			//刷新
			resp.setBondFlushPrice(new CurrencyInfo(Currency.BOND.index, Globals.getGameConstants().getMsBondFlushPrice() 
					* Globals.getGameConstants().getMsRefereshCoef()
					* count));
		}
		
		
		resp.setFreeFlushNum(manager.getOwner().getBehaviorManager().getLeftCount(BehaviorTypeEnum.MYSTERY_SHOP_NUM));
		return resp;
	}
}
