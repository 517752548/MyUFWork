package com.imop.lj.gameserver.quest.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 接受任务客户端动画
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCAcceptQuest extends GCMessage{
	
	/** 任务Id */
	private int questId;

	public GCAcceptQuest (){
	}
	
	public GCAcceptQuest (
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
		return MessageType.GC_ACCEPT_QUEST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_ACCEPT_QUEST";
	}

	public int getQuestId(){
		return questId;
	}
		
	public void setQuestId(int questId){
		this.questId = questId;
	}
}