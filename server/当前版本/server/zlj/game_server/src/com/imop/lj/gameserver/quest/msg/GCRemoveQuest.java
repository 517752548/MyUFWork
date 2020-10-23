package com.imop.lj.gameserver.quest.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 删除一个任务
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCRemoveQuest extends GCMessage{
	
	/** 任务Id */
	private int questId;

	public GCRemoveQuest (){
	}
	
	public GCRemoveQuest (
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
		return MessageType.GC_REMOVE_QUEST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_REMOVE_QUEST";
	}

	public int getQuestId(){
		return questId;
	}
		
	public void setQuestId(int questId){
		this.questId = questId;
	}
}