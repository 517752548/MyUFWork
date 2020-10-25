package com.imop.lj.gameserver.quest.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.quest.handler.QuestHandlerFactory;

/**
 * 放弃已接任务
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGiveUpQuest extends CGMessage{
	
	/** 任务Id */
	private int questId;
	
	public CGGiveUpQuest (){
	}
	
	public CGGiveUpQuest (
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
		return MessageType.CG_GIVE_UP_QUEST;
	}
	
	@Override
	public String getTypeName() {
		return "CG_GIVE_UP_QUEST";
	}

	public int getQuestId(){
		return questId;
	}
		
	public void setQuestId(int questId){
		this.questId = questId;
	}


	@Override
	public void execute() {
		QuestHandlerFactory.getHandler().handleGiveUpQuest(this.getSession().getPlayer(), this);
	}
}