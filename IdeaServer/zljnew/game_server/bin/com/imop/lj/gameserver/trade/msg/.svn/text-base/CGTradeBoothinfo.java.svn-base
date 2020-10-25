package com.imop.lj.gameserver.trade.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.trade.handler.TradeHandlerFactory;

/**
 * 申请摊位信息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTradeBoothinfo extends CGMessage{
	
	
	public CGTradeBoothinfo (){
	}
	
	
	@Override
	protected boolean readImpl() {


		return true;
	}
	
	@Override
	protected boolean writeImpl() {

		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_TRADE_BOOTHINFO;
	}
	
	@Override
	public String getTypeName() {
		return "CG_TRADE_BOOTHINFO";
	}


	@Override
	public void execute() {
		TradeHandlerFactory.getHandler().handleTradeBoothinfo(this.getSession().getPlayer(), this);
	}
}