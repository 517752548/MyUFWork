package com.imop.lj.gameserver.ringtask.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.ringtask.handler.RingtaskHandlerFactory;

/**
 * 完成任务
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGFinishRingtask extends CGMessage{
	
	
	public CGFinishRingtask (){
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
		return MessageType.CG_FINISH_RINGTASK;
	}
	
	@Override
	public String getTypeName() {
		return "CG_FINISH_RINGTASK";
	}


	@Override
	public void execute() {
		RingtaskHandlerFactory.getHandler().handleFinishRingtask(this.getSession().getPlayer(), this);
	}
}