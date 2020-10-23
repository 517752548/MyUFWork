package com.imop.lj.gameserver.trade.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.trade.handler.TradeHandlerFactory;

/**
 * 申请下架物品
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTradeTakeOff extends CGMessage{
	
	/** 商品类型 */
	private int commodityType;
	/** 摊位坐标(1-10) */
	private int boothIndex;
	
	public CGTradeTakeOff (){
	}
	
	public CGTradeTakeOff (
			int commodityType,
			int boothIndex ){
			this.commodityType = commodityType;
			this.boothIndex = boothIndex;
	}
	
	@Override
	protected boolean readImpl() {

	// 商品类型
	int _commodityType = readInteger();
	//end


	// 摊位坐标(1-10)
	int _boothIndex = readInteger();
	//end



			this.commodityType = _commodityType;
			this.boothIndex = _boothIndex;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 商品类型
	writeInteger(commodityType);


	// 摊位坐标(1-10)
	writeInteger(boothIndex);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_TRADE_TAKE_OFF;
	}
	
	@Override
	public String getTypeName() {
		return "CG_TRADE_TAKE_OFF";
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


	@Override
	public void execute() {
		TradeHandlerFactory.getHandler().handleTradeTakeOff(this.getSession().getPlayer(), this);
	}
}