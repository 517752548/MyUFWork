package com.imop.lj.gameserver.pubtask.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pubtask.handler.PubtaskHandlerFactory;

/**
 * 放弃已接任务
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGiveUpPubtask extends CGMessage{
	
	
	public CGGiveUpPubtask (){
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
		return MessageType.CG_GIVE_UP_PUBTASK;
	}
	
	@Override
	public String getTypeName() {
		return "CG_GIVE_UP_PUBTASK";
	}


	@Override
	public void execute() {
		PubtaskHandlerFactory.getHandler().handleGiveUpPubtask(this.getSession().getPlayer(), this);
	}
}