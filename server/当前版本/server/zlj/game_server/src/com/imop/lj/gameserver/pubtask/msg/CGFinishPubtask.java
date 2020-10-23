package com.imop.lj.gameserver.pubtask.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pubtask.handler.PubtaskHandlerFactory;

/**
 * 完成任务
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGFinishPubtask extends CGMessage{
	
	
	public CGFinishPubtask (){
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
		return MessageType.CG_FINISH_PUBTASK;
	}
	
	@Override
	public String getTypeName() {
		return "CG_FINISH_PUBTASK";
	}


	@Override
	public void execute() {
		PubtaskHandlerFactory.getHandler().handleFinishPubtask(this.getSession().getPlayer(), this);
	}
}