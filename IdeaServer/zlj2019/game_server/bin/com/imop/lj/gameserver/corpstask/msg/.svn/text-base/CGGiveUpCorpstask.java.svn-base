package com.imop.lj.gameserver.corpstask.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corpstask.handler.CorpstaskHandlerFactory;

/**
 * 放弃已接任务
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGiveUpCorpstask extends CGMessage{
	
	
	public CGGiveUpCorpstask (){
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
		return MessageType.CG_GIVE_UP_CORPSTASK;
	}
	
	@Override
	public String getTypeName() {
		return "CG_GIVE_UP_CORPSTASK";
	}


	@Override
	public void execute() {
		CorpstaskHandlerFactory.getHandler().handleGiveUpCorpstask(this.getSession().getPlayer(), this);
	}
}