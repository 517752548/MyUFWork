package com.imop.lj.gameserver.trade.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.trade.handler.TradeHandlerFactory;

/**
 * 商品查询
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTradeSearch extends CGMessage{
	
	/** 商品查询条件 */
	private String conditions;
	
	public CGTradeSearch (){
	}
	
	public CGTradeSearch (
			String conditions ){
			this.conditions = conditions;
	}
	
	@Override
	protected boolean readImpl() {

	// 商品查询条件
	String _conditions = readString();
	//end



			this.conditions = _conditions;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 商品查询条件
	writeString(conditions);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_TRADE_SEARCH;
	}
	
	@Override
	public String getTypeName() {
		return "CG_TRADE_SEARCH";
	}

	public String getConditions(){
		return conditions;
	}
		
	public void setConditions(String conditions){
		this.conditions = conditions;
	}


	@Override
	public void execute() {
		TradeHandlerFactory.getHandler().handleTradeSearch(this.getSession().getPlayer(), this);
	}
}