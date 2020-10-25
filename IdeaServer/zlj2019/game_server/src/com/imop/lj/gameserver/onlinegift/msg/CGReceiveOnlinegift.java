package com.imop.lj.gameserver.onlinegift.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.onlinegift.handler.OnlinegiftHandlerFactory;

/**
 * 领取在线礼包
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGReceiveOnlinegift extends CGMessage{
	
	
	public CGReceiveOnlinegift (){
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
		return MessageType.CG_RECEIVE_ONLINEGIFT;
	}
	
	@Override
	public String getTypeName() {
		return "CG_RECEIVE_ONLINEGIFT";
	}


	@Override
	public void execute() {
		OnlinegiftHandlerFactory.getHandler().handleReceiveOnlinegift(this.getSession().getPlayer(), this);
	}
}