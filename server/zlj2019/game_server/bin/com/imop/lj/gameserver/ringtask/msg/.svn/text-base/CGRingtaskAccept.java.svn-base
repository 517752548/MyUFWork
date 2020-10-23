package com.imop.lj.gameserver.ringtask.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.ringtask.handler.RingtaskHandlerFactory;

/**
 * 接受任务
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGRingtaskAccept extends CGMessage{
	
	
	public CGRingtaskAccept (){
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
		return MessageType.CG_RINGTASK_ACCEPT;
	}
	
	@Override
	public String getTypeName() {
		return "CG_RINGTASK_ACCEPT";
	}


	@Override
	public void execute() {
		RingtaskHandlerFactory.getHandler().handleRingtaskAccept(this.getSession().getPlayer(), this);
	}
}