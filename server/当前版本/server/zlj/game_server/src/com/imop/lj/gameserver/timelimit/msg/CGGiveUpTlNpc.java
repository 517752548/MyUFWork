package com.imop.lj.gameserver.timelimit.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.timelimit.handler.TimelimitHandlerFactory;

/**
 * 放弃已接任务
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGiveUpTlNpc extends CGMessage{
	
	
	public CGGiveUpTlNpc (){
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
		return MessageType.CG_GIVE_UP_TL_NPC;
	}
	
	@Override
	public String getTypeName() {
		return "CG_GIVE_UP_TL_NPC";
	}


	@Override
	public void execute() {
		TimelimitHandlerFactory.getHandler().handleGiveUpTlNpc(this.getSession().getPlayer(), this);
	}
}