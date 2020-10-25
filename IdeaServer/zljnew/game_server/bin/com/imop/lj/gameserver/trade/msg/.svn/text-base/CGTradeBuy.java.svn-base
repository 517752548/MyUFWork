package com.imop.lj.gameserver.trade.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.trade.handler.TradeHandlerFactory;

/**
 * 购买物品
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTradeBuy extends CGMessage{
	
	/** 卖家Id */
	private long sellerId;
	/** 商品类型 */
	private int commodityType;
	/** 摊位坐标(1-10) */
	private int boothIndex;
	/** 商品uuid */
	private String commodityId;
	
	public CGTradeBuy (){
	}
	
	public CGTradeBuy (
			long sellerId,
			int commodityType,
			int boothIndex,
			String commodityId ){
			this.sellerId = sellerId;
			this.commodityType = commodityType;
			this.boothIndex = boothIndex;
			this.commodityId = commodityId;
	}
	
	@Override
	protected boolean readImpl() {

	// 卖家Id
	long _sellerId = readLong();
	//end


	// 商品类型
	int _commodityType = readInteger();
	//end


	// 摊位坐标(1-10)
	int _boothIndex = readInteger();
	//end


	// 商品uuid
	String _commodityId = readString();
	//end



			this.sellerId = _sellerId;
			this.commodityType = _commodityType;
			this.boothIndex = _boothIndex;
			this.commodityId = _commodityId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 卖家Id
	writeLong(sellerId);


	// 商品类型
	writeInteger(commodityType);


	// 摊位坐标(1-10)
	writeInteger(boothIndex);


	// 商品uuid
	writeString(commodityId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_TRADE_BUY;
	}
	
	@Override
	public String getTypeName() {
		return "CG_TRADE_BUY";
	}

	public long getSellerId(){
		return sellerId;
	}
		
	public void setSellerId(long sellerId){
		this.sellerId = sellerId;
	}

	public int getCommodityType(){
		return commodityType;
	}
		
	public void setCommodityType(int commodityType){
		this.commodityType = commodityType;
	}

	public int getBoothIndex(){
		return boothIndex;
	}
		
	public void setBoothIndex(int boothIndex){
		this.boothIndex = boothIndex;
	}

	public String getCommodityId(){
		return commodityId;
	}
		
	public void setCommodityId(String commodityId){
		this.commodityId = commodityId;
	}


	@Override
	public void execute() {
		TradeHandlerFactory.getHandler().handleTradeBuy(this.getSession().getPlayer(), this);
	}
}