package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.human.handler.HumanHandlerFactory;

/**
 * 七日目标任务领取奖励
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGDay7TaskFinish extends CGMessage{
	
	/** 任务Id */
	private int questId;
	
	public CGDay7TaskFinish (){
	}
	
	public CGDay7TaskFinish (
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
		return MessageType.CG_DAY7_TASK_FINISH;
	}
	
	@Override
	public String getTypeName() {
		return "CG_DAY7_TASK_FINISH";
	}

	public int getQuestId(){
		return questId;
	}
		
	public void setQuestId(int questId){
		this.questId = questId;
	}


	@Override
	public void execute() {
		HumanHandlerFactory.getHandler().handleDay7TaskFinish(this.getSession().getPlayer(), this);
	}
}