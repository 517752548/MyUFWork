package com.imop.lj.gameserver.foragetask.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.foragetask.handler.ForagetaskHandlerFactory;

/**
 * 完成任务
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGFinishForagetask extends CGMessage{
	
	
	public CGFinishForagetask (){
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
		return MessageType.CG_FINISH_FORAGETASK;
	}
	
	@Override
	public String getTypeName() {
		return "CG_FINISH_FORAGETASK";
	}


	@Override
	public void execute() {
		ForagetaskHandlerFactory.getHandler().handleFinishForagetask(this.getSession().getPlayer(), this);
	}
}