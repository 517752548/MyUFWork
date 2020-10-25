package com.imop.lj.gameserver.trade.search;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.item.ItemDef.Rarity;
import com.imop.lj.gameserver.trade.TradeDef.CommodityType;
import com.imop.lj.gameserver.trade.TradeDef.MainTagType;
import com.imop.lj.gameserver.trade.TradeDef.TradeOrderType;
import com.imop.lj.gameserver.trade.TradeDef.TradeSortableFieldType;
import com.imop.lj.gameserver.trade.msg.CGTradeSimpleSearch;
import com.imop.lj.gameserver.trade.template.TradeCommodityTypeTemplate;
import com.imop.lj.gameserver.trade.template.TradeMainTagTemplate;
import com.imop.lj.gameserver.trade.template.TradeSortableFieldTemplate;
import com.imop.lj.gameserver.trade.template.TradeSubTagTemplate;

public class SimpleSearchInfo {
	/** 商品类别 */
	private int commodityType;
	/** 商品二级标签 */
	private int subTagId;
	/** 排序字段 */
	private int sortField;
	/** 1升序,2降序 */
	private int sortOrder;
	/** 装备颜色 */
	private int equipColor;
	/** 装备等级 */
	private int equipLevel;
	/** 宝石等级 */
	private int gemLevel;
	/** 页数 */
	private int pageNum;
	public SimpleSearchInfo() {
		super();
	}
	
	public SimpleSearchInfo(CGTradeSimpleSearch message) {
		super();
		this.commodityType = message.getCommodityType();
		this.subTagId = message.getSubTagId();
		this.sortField = message.getSortField();
		this.sortOrder = message.getSortOrder();
		this.equipColor = message.getEquipColor();
		this.equipLevel = message.getEquipLevel();
		this.gemLevel = message.getGemLevel();
		this.pageNum = message.getPageNum();
	}
	
	public SimpleSearchInfo(int commodityType, int subTagId, int sortField,
			int sortOrder, int equipColor, int equipLevel, int gemLevel, int pageNum) {
		super();
		this.commodityType = commodityType;
		this.subTagId = subTagId;
		this.sortField = sortField;
		this.sortOrder = sortOrder;
		this.equipColor = equipColor;
		this.equipLevel = equipLevel;
		this.gemLevel = gemLevel;
		this.pageNum = pageNum;
	}

	public int getCommodityType() {
		return commodityType;
	}

	public void setCommodityType(int commodityType) {
		this.commodityType = commodityType;
	}

	public int getSubTagId() {
		return subTagId;
	}

	public void setSubTagId(int subTagId) {
		this.subTagId = subTagId;
	}

	public int getSortField() {
		return sortField;
	}

	public void setSortField(int sortField) {
		this.sortField = sortField;
	}

	public int getSortOrder() {
		return sortOrder;
	}

	public void setSortOrder(int sortOrder) {
		this.sortOrder = sortOrder;
	}

	public int getEquipColor() {
		return equipColor;
	}

	public void setEquipColor(int equipColor) {
		this.equipColor = equipColor;
	}

	public int getEquipLevel() {
		return equipLevel;
	}

	public void setEquipLevel(int equipLevel) {
		this.equipLevel = equipLevel;
	}

	public int getGemLevel() {
		return gemLevel;
	}

	public void setGemLevel(int gemLevel) {
		this.gemLevel = gemLevel;
	}
	
	public int getPageNum() {
		return pageNum;
	}

	public void setPageNum(int pageNum) {
		this.pageNum = pageNum;
	}

	public boolean isValid(){
		if(null == Globals.getTemplateCacheService().get(commodityType, TradeCommodityTypeTemplate.class)){
			return false;
		}
		if(null == CommodityType.valueOf(commodityType) || CommodityType.valueOf(commodityType) == CommodityType.NULL){
			return false;
		}
		if(null == Globals.getTemplateCacheService().get(subTagId, TradeSubTagTemplate.class)){
			return false;
		}
		if(null == Globals.getTemplateCacheService().get(sortField, TradeSortableFieldTemplate.class)){
			return false;
		}
		if(null == TradeOrderType.valueOf(sortOrder) || TradeOrderType.valueOf(sortOrder) == TradeOrderType.NULL){
			return false;
		}
		if(null == TradeSortableFieldType.valueOf(sortField)){
			return false;
		}
		Integer mainTagId = Globals.getTemplateCacheService().get(subTagId, TradeSubTagTemplate.class).getMainTagId();
		Integer commodityTypeInt = Globals.getTemplateCacheService().get(mainTagId, TradeMainTagTemplate.class).getCommodityType();
		if(commodityTypeInt != commodityType){
			return false;
		}
		if(MainTagType.valueOf(mainTagId) == null || MainTagType.valueOf(mainTagId) == MainTagType.NULL){
			return false;
		}
		if(MainTagType.valueOf(mainTagId).getCommodityType().index != commodityType){
			return false;
		}
		if(MainTagType.valueOf(mainTagId).getCommodityType() == CommodityType.ITEM && MainTagType.valueOf(mainTagId) == MainTagType.EQUIP){
			//增加一个全部显示的条件 0
			if(equipColor > Rarity.values().length){
				return false;
			}
		}
		if(MainTagType.valueOf(mainTagId).getCommodityType() == CommodityType.ITEM && MainTagType.valueOf(mainTagId) == MainTagType.GEM){
			if(gemLevel > Globals.getGameConstants().getGemMaxLevel()){
				return false;
			}
		}
		return true;
	}
}
