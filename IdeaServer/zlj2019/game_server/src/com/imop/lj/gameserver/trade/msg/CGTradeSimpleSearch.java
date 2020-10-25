package com.imop.lj.gameserver.trade.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.trade.handler.TradeHandlerFactory;

/**
 * 简单商品查询
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTradeSimpleSearch extends CGMessage{
	
	/** 商品类别 */
	private int commodityType;
	/** 商品二级标签 */
	private int subTagId;
	/** 排序字段 */
	private int sortField;
	/** 1升序,2降序 */
	private int sortOrder;
	/** 装备颜色,0则显示全部 */
	private int equipColor;
	/** 装备等级 */
	private int equipLevel;
	/** 宝石等级 */
	private int gemLevel;
	/** 页数 */
	private int pageNum;
	
	public CGTradeSimpleSearch (){
	}
	
	public CGTradeSimpleSearch (
			int commodityType,
			int subTagId,
			int sortField,
			int sortOrder,
			int equipColor,
			int equipLevel,
			int gemLevel,
			int pageNum ){
			this.commodityType = commodityType;
			this.subTagId = subTagId;
			this.sortField = sortField;
			this.sortOrder = sortOrder;
			this.equipColor = equipColor;
			this.equipLevel = equipLevel;
			this.gemLevel = gemLevel;
			this.pageNum = pageNum;
	}
	
	@Override
	protected boolean readImpl() {

	// 商品类别
	int _commodityType = readInteger();
	//end


	// 商品二级标签
	int _subTagId = readInteger();
	//end


	// 排序字段
	int _sortField = readInteger();
	//end


	// 1升序,2降序
	int _sortOrder = readInteger();
	//end


	// 装备颜色,0则显示全部
	int _equipColor = readInteger();
	//end


	// 装备等级
	int _equipLevel = readInteger();
	//end


	// 宝石等级
	int _gemLevel = readInteger();
	//end


	// 页数
	int _pageNum = readInteger();
	//end



			this.commodityType = _commodityType;
			this.subTagId = _subTagId;
			this.sortField = _sortField;
			this.sortOrder = _sortOrder;
			this.equipColor = _equipColor;
			this.equipLevel = _equipLevel;
			this.gemLevel = _gemLevel;
			this.pageNum = _pageNum;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 商品类别
	writeInteger(commodityType);


	// 商品二级标签
	writeInteger(subTagId);


	// 排序字段
	writeInteger(sortField);


	// 1升序,2降序
	writeInteger(sortOrder);


	// 装备颜色,0则显示全部
	writeInteger(equipColor);


	// 装备等级
	writeInteger(equipLevel);


	// 宝石等级
	writeInteger(gemLevel);


	// 页数
	writeInteger(pageNum);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_TRADE_SIMPLE_SEARCH;
	}
	
	@Override
	public String getTypeName() {
		return "CG_TRADE_SIMPLE_SEARCH";
	}

	public int getCommodityType(){
		return commodityType;
	}
		
	public void setCommodityType(int commodityType){
		this.commodityType = commodityType;
	}

	public int getSubTagId(){
		return subTagId;
	}
		
	public void setSubTagId(int subTagId){
		this.subTagId = subTagId;
	}

	public int getSortField(){
		return sortField;
	}
		
	public void setSortField(int sortField){
		this.sortField = sortField;
	}

	public int getSortOrder(){
		return sortOrder;
	}
		
	public void setSortOrder(int sortOrder){
		this.sortOrder = sortOrder;
	}

	public int getEquipColor(){
		return equipColor;
	}
		
	public void setEquipColor(int equipColor){
		this.equipColor = equipColor;
	}

	public int getEquipLevel(){
		return equipLevel;
	}
		
	public void setEquipLevel(int equipLevel){
		this.equipLevel = equipLevel;
	}

	public int getGemLevel(){
		return gemLevel;
	}
		
	public void setGemLevel(int gemLevel){
		this.gemLevel = gemLevel;
	}

	public int getPageNum(){
		return pageNum;
	}
		
	public void setPageNum(int pageNum){
		this.pageNum = pageNum;
	}


	@Override
	public void execute() {
		TradeHandlerFactory.getHandler().handleTradeSimpleSearch(this.getSession().getPlayer(), this);
	}
}