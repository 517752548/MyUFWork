package com.imop.lj.gameserver.mall;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.model.CurrencyInfo;
import com.imop.lj.common.model.mall.MallCatalogInfo;
import com.imop.lj.common.model.mall.MallNormalItemInfo;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.mall.msg.GCBuyItemPanelOperate;
import com.imop.lj.gameserver.mall.msg.GCMallCatalogInfoList;
import com.imop.lj.gameserver.mall.msg.GCMallItemList;
import com.imop.lj.gameserver.mall.template.MallCatalogTemplate;
import com.imop.lj.gameserver.mall.template.MallNormalItemTemplate;

/**
 * 商城消息创建
 * 
 * @author xiaowei.liu
 * 
 */
public class MallMessageBuilder {
	/**
	 * 创建标签信息列表
	 * 
	 * @param human
	 * @return
	 */
	public static GCMallCatalogInfoList createGCatalogInfoList(Human human) {
		GCMallCatalogInfoList resp = new GCMallCatalogInfoList();
		List<MallCatalogInfo> list = new ArrayList<MallCatalogInfo>();
		for(MallCatalogTemplate tmpl : Globals.getTemplateCacheService().getMallTemplateCache().getCatalogMap().values()){
			MallCatalogInfo info = new MallCatalogInfo();
			info.setCatalogId(tmpl.getId());
			info.setName(tmpl.getName());
			info.setCatalogType(tmpl.getCatalogTypeId());
			list.add(info);
		}
		
		resp.setMallCatalogInfoList(list.toArray(new MallCatalogInfo[0]));
		return resp;
	}
	
	/**
	 * 创建普通物品列表
	 * 
	 * @param human
	 * @param catalog
	 * @return
	 */
	public static GCMallItemList createGCMallItemList(Human human, MallCatalogTemplate catalog) {
		GCMallItemList resp = new GCMallItemList();
		resp.setCatalogId(catalog.getId());
		
		List<MallNormalItemInfo> list = new ArrayList<MallNormalItemInfo>();
		for(MallNormalItemTemplate tmpl : catalog.getNormalItemList()){
			MallNormalItemInfo info = new MallNormalItemInfo();
			info.setMallItemId(tmpl.getId());
//			info.setCommonItem(EquipMessageBuilder.createCommonItem(tmpl.getSellItem(), tmpl.getSellItemNum()));
			info.setOriginalPrice(tmpl.getOriginalPrice().getCurrencyInfo());
			info.setDiscountPrice(tmpl.getDiscountPrice().getCurrencyInfo());
			List<CurrencyInfo> vipList = new ArrayList<CurrencyInfo>();
//			if(Globals.getVipService().checkVipRule(human, VipTypeEnum.MALL_DISCOUNT)){
//				int discount = Globals.getVipService().getCountForVipTypeEnumOnOpen(human, VipTypeEnum.MALL_DISCOUNT);
//				if(discount > 0){
//					double num = (double)tmpl.getDiscountPrice().getNum() * discount / Globals.getGameConstants().getScale();
//					num = Math.ceil(num);
//					CurrencyInfo ci = new CurrencyInfo();
//					ci.setCurrencyType(tmpl.getDiscountPrice().getCurrencyType());
//					ci.setNum((int)num);
//					vipList.add(ci);
//				}
//			}
			info.setVipPrices(vipList.toArray(new CurrencyInfo[0]));
//			info.setHot(tmpl.isSellWell() ? ResultType.SUCC.getIndex() : ResultType.FAIL.getIndex());
			info.setMarks(tmpl.getMarks());
			list.add(info);
		}
		resp.setNormalItemInfoList(list.toArray(new MallNormalItemInfo[0]));
		return resp;
	}
	
	public static GCBuyItemPanelOperate createGcBuyItemPanelOperate(int typeId){
		GCBuyItemPanelOperate resp = new GCBuyItemPanelOperate();
		resp.setOpeType(typeId);
		return resp;
	}
}
