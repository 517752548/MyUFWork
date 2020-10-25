package com.imop.lj.gameserver.foragetask.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.foragetask.handler.ForagetaskHandlerFactory;

/**
 * 接受任务
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGForagetaskAccept extends CGMessage{
	
	/** 任务Id */
	private int questId;
	
	public CGForagetaskAccept (){
	}
	
	public CGForagetaskAccept (
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
		return MessageType.CG_FORAGETASK_ACCEPT;
	}
	
	@Override
	public String getTypeName() {
		return "CG_FORAGETASK_ACCEPT";
	}

	public int getQuestId(){
		return questId;
	}
		
	public void setQuestId(int questId){
		this.questId = questId;
	}


	@Override
	public void execute() {
		ForagetaskHandlerFactory.getHandler().handleForagetaskAccept(this.getSession().getPlayer(), this);
	}
}