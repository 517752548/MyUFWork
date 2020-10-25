package com.imop.lj.gameserver.corpstask.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corpstask.handler.CorpstaskHandlerFactory;

/**
 * 完成任务
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGFinishCorpstask extends CGMessage{
	
	
	public CGFinishCorpstask (){
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
		return MessageType.CG_FINISH_CORPSTASK;
	}
	
	@Override
	public String getTypeName() {
		return "CG_FINISH_CORPSTASK";
	}


	@Override
	public void execute() {
		CorpstaskHandlerFactory.getHandler().handleFinishCorpstask(this.getSession().getPlayer(), this);
	}
}