package com.imop.lj.gameserver.pubtask.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pubtask.handler.PubtaskHandlerFactory;

/**
 * 接受任务
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPubtaskAccept extends CGMessage{
	
	/** 任务Id */
	private int questId;
	
	public CGPubtaskAccept (){
	}
	
	public CGPubtaskAccept (
			int questId ){
			this.questId = questId;
	}
	
	@Override
	protected boolean readImpl() {

	// 任务Id
	int _questId = readInteger();
	//end



			this.questId = _questId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 任务Id
	writeInteger(questId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PUBTASK_ACCEPT;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PUBTASK_ACCEPT";
	}

	public int getQuestId(){
		return questId;
	}
		
	public void setQuestId(int questId){
		this.questId = questId;
	}


	@Override
	public void execute() {
		PubtaskHandlerFactory.getHandler().handlePubtaskAccept(this.getSession().getPlayer(), this);
	}
}