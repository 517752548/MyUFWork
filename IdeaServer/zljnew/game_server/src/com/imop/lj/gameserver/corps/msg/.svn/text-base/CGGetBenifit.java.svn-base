package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corps.handler.CorpsHandlerFactory;

/**
 * 请求领取帮派福利
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGetBenifit extends CGMessage{
	
	
	public CGGetBenifit (){
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
		return MessageType.CG_GET_BENIFIT;
	}
	
	@Override
	public String getTypeName() {
		return "CG_GET_BENIFIT";
	}


	@Override
	public void execute() {
		CorpsHandlerFactory.getHandler().handleGetBenifit(this.getSession().getPlayer(), this);
	}
}