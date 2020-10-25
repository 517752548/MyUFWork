package com.imop.lj.gameserver.thesweeneytask.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.thesweeneytask.handler.ThesweeneytaskHandlerFactory;

/**
 * 接受任务
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGThesweeneytaskAccept extends CGMessage{
	
	
	public CGThesweeneytaskAccept (){
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
		return MessageType.CG_THESWEENEYTASK_ACCEPT;
	}
	
	@Override
	public String getTypeName() {
		return "CG_THESWEENEYTASK_ACCEPT";
	}


	@Override
	public void execute() {
		ThesweeneytaskHandlerFactory.getHandler().handleThesweeneytaskAccept(this.getSession().getPlayer(), this);
	}
}