package com.imop.lj.gameserver.timelimit.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.timelimit.handler.TimelimitHandlerFactory;

/**
 * 完成任务
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGFinishTlMonster extends CGMessage{
	
	
	public CGFinishTlMonster (){
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
		return MessageType.CG_FINISH_TL_MONSTER;
	}
	
	@Override
	public String getTypeName() {
		return "CG_FINISH_TL_MONSTER";
	}


	@Override
	public void execute() {
		TimelimitHandlerFactory.getHandler().handleFinishTlMonster(this.getSession().getPlayer(), this);
	}
}