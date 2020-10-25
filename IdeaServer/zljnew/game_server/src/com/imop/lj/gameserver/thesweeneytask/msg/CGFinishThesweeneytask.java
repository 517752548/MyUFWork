package com.imop.lj.gameserver.thesweeneytask.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.thesweeneytask.handler.ThesweeneytaskHandlerFactory;

/**
 * 完成任务
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGFinishThesweeneytask extends CGMessage{
	
	
	public CGFinishThesweeneytask (){
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
		return MessageType.CG_FINISH_THESWEENEYTASK;
	}
	
	@Override
	public String getTypeName() {
		return "CG_FINISH_THESWEENEYTASK";
	}


	@Override
	public void execute() {
		ThesweeneytaskHandlerFactory.getHandler().handleFinishThesweeneytask(this.getSession().getPlayer(), this);
	}
}