package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 七日目标所有任务状态列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCDay7TaskList extends GCMessage{
	
	/** 单个任务 */
	private com.imop.lj.common.model.quest.QuestInfo[] questInfo;

	public GCDay7TaskList (){
	}
	
	public GCDay7TaskList (
			com.imop.lj.common.model.quest.QuestInfo[] questInfo ){
			this.questInfo = questInfo;
	}

	@Override
	protected boolean readImpl() {

	// 单个任务
	int questInfoSize = readUnsignedShort();
	com.imop.lj.common.model.quest.QuestInfo[] _questInfo = new com.imop.lj.common.model.quest.QuestInfo[questInfoSize];
	int questInfoIndex = 0;
	for(questInfoIndex=0; questInfoIndex<questInfoSize; questInfoIndex++){
		_questInfo[questInfoIndex] = new com.imop.lj.common.model.quest.QuestInfo();
	// 任务UUID
	String _questInfo_uuid = readString();
	//end
	_questInfo[questInfoIndex].setUuid (_questInfo_uuid);

	// 任务模板Id
	int _questInfo_questId = readInteger();
	//end
	_questInfo[questInfoIndex].setQuestId (_questInfo_questId);

	// 已完成数量,分子
	int _questInfo_destGotNum = readInteger();
	//end
	_questInfo[questInfoIndex].setDestGotNum (_questInfo_destGotNum);

	// 任务目标需求数量，分母
	int _questInfo_destReqNum = readInteger();
	//end
	_questInfo[questInfoIndex].setDestReqNum (_questInfo_destReqNum);

	// 任务当前状态
	int _questInfo_questStatus = readInteger();
	//end
	_questInfo[questInfoIndex].setQuestStatus (_questInfo_questStatus);

	// 显示奖励信息
	String _questInfo_showRewardInfo = readString();
	//end
	_questInfo[questInfoIndex].setShowRewardInfo (_questInfo_showRewardInfo);
	}
	//end



		this.questInfo = _questInfo;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 单个任务
	writeShort(questInfo.length);
	int questInfoIndex = 0;
	int questInfoSize = questInfo.length;
	for(questInfoIndex=0; questInfoIndex<questInfoSize; questInfoIndex++){

	String questInfo_uuid = questInfo[questInfoIndex].getUuid();

	// 任务UUID
	writeString(questInfo_uuid);

	int questInfo_questId = questInfo[questInfoIndex].getQuestId();

	// 任务模板Id
	writeInteger(questInfo_questId);

	int questInfo_destGotNum = questInfo[questInfoIndex].getDestGotNum();

	// 已完成数量,分子
	writeInteger(questInfo_destGotNum);

	int questInfo_destReqNum = questInfo[questInfoIndex].getDestReqNum();

	// 任务目标需求数量，分母
	writeInteger(questInfo_destReqNum);

	int questInfo_questStatus = questInfo[questInfoIndex].getQuestStatus();

	// 任务当前状态
	writeInteger(questInfo_questStatus);

	String questInfo_showRewardInfo = questInfo[questInfoIndex].getShowRewardInfo();

	// 显示奖励信息
	writeString(questInfo_showRewardInfo);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_DAY7_TASK_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_DAY7_TASK_LIST";
	}

	public com.imop.lj.common.model.quest.QuestInfo[] getQuestInfo(){
		return questInfo;
	}

	public void setQuestInfo(com.imop.lj.common.model.quest.QuestInfo[] questInfo){
		this.questInfo = questInfo;
	}	
}