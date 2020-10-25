package com.imop.lj.gameserver.trade.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.trade.handler.TradeHandlerFactory;

/**
 * 申请卖出商品
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTradeSell extends CGMessage{
	
	/** 商品UUID */
	private String commodityId;
	/** 出售的货币种类 */
	private int currencyType;
	/** 出售的货币数量(单价) */
	private int currencyNum;
	/** 商品类型 */
	private int commodityType;
	/** 商品数量 */
	private int commodityNum;
	/** 摊位坐标(1-10) */
	private int boothIndex;
	
	public CGTradeSell (){
	}
	
	public CGTradeSell (
			String commodityId,
			int currencyType,
			int currencyNum,
			int commodityType,
			int commodityNum,
			int boothIndex ){
			this.commodityId = commodityId;
			this.currencyType = currencyType;
			this.currencyNum = currencyNum;
			this.commodityType = commodityType;
			this.commodityNum = commodityNum;
			this.boothIndex = boothIndex;
	}
	
	@Override
	protected boolean readImpl() {

	// 商品UUID
	String _commodityId = readString();
	//end


	// 出售的货币种类
	int _currencyType = readInteger();
	//end


	// 出售的货币数量(单价)
	int _currencyNum = readInteger();
	//end


	// 商品类型
	int _commodityType = readInteger();
	//end


	// 商品数量
	int _commodityNum = readInteger();
	//end


	// 摊位坐标(1-10)
	int _boothIndex = readInteger();
	//end



			this.commodityId = _commodityId;
			this.currencyType = _currencyType;
			this.currencyNum = _currencyNum;
			this.commodityType = _commodityType;
			this.commodityNum = _commodityNum;
			this.boothIndex = _boothIndex;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 商品UUID
	writeString(commodityId);


	// 出售的货币种类
	writeInteger(currencyType);


	// 出售的货币数量(单价)
	writeInteger(currencyNum);


	// 商品类型
	writeInteger(commodityType);


	// 商品数量
	writeInteger(commodityNum);


	// 摊位坐标(1-10)
	writeInteger(boothIndex);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_TRADE_SELL;
	}
	
	@Override
	public String getTypeName() {
		return "CG_TRADE_SELL";
	}

	public String getCommodityId(){
		return commodityId;
	}
		
	public void setCommodityId(String commodityId){
		this.commodityId = commodityId;
	}

	public int getCurrencyType(){
		return currencyType;
	}
		
	public void setCurrencyType(int currencyType){
		this.currencyType = currencyType;
	}

	public int getCurrencyNum(){
		return currencyNum;
	}
		
	public void setCurrencyNum(int currencyNum){
		this.currencyNum = currencyNum;
	}

	public int getCommodityType(){
		return commodityType;
	}
		
	public void setCommodityType(int commodityType){
		this.commodityType = commodityType;
	}

	public int getCommodityNum(){
		return commodityNum;
	}
		
	public void setCommodityNum(int commodityNum){
		this.commodityNum = commodityNum;
	}

	public int getBoothIndex(){
		return boothIndex;
	}
		
	public void setBoothIndex(int boothIndex){
		this.boothIndex = boothIndex;
	}


	@Override
	public void execute() {
		TradeHandlerFactory.getHandler().handleTradeSell(this.getSession().getPlayer(), this);
	}
}