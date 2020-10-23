package com.imop.lj.gameserver.timelimit.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.timelimit.handler.TimelimitHandlerFactory;

/**
 * 接受任务
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTlMonsterAccept extends CGMessage{
	
	
	public CGTlMonsterAccept (){
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
		return MessageType.CG_TL_MONSTER_ACCEPT;
	}
	
	@Override
	public String getTypeName() {
		return "CG_TL_MONSTER_ACCEPT";
	}


	@Override
	public void execute() {
		TimelimitHandlerFactory.getHandler().handleTlMonsterAccept(this.getSession().getPlayer(), this);
	}
}