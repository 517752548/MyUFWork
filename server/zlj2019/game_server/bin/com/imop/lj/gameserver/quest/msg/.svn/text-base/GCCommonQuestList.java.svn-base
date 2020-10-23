package com.imop.lj.gameserver.quest.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回成长任务列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCCommonQuestList extends GCMessage{
	
	/** 任务列表 */
	private com.imop.lj.common.model.quest.QuestInfo[] questInfos;

	public GCCommonQuestList (){
	}
	
	public GCCommonQuestList (
			com.imop.lj.common.model.quest.QuestInfo[] questInfos ){
			this.questInfos = questInfos;
	}

	@Override
	protected boolean readImpl() {

	// 任务列表
	int questInfosSize = readUnsignedShort();
	com.imop.lj.common.model.quest.QuestInfo[] _questInfos = new com.imop.lj.common.model.quest.QuestInfo[questInfosSize];
	int questInfosIndex = 0;
	for(questInfosIndex=0; questInfosIndex<questInfosSize; questInfosIndex++){
		_questInfos[questInfosIndex] = new com.imop.lj.common.model.quest.QuestInfo();
	// 任务UUID
	String _questInfos_uuid = readString();
	//end
	_questInfos[questInfosIndex].setUuid (_questInfos_uuid);

	// 任务模板Id
	int _questInfos_questId = readInteger();
	//end
	_questInfos[questInfosIndex].setQuestId (_questInfos_questId);

	// 已完成数量,分子
	int _questInfos_destGotNum = readInteger();
	//end
	_questInfos[questInfosIndex].setDestGotNum (_questInfos_destGotNum);

	// 任务目标需求数量，分母
	int _questInfos_destReqNum = readInteger();
	//end
	_questInfos[questInfosIndex].setDestReqNum (_questInfos_destReqNum);

	// 任务当前状态
	int _questInfos_questStatus = readInteger();
	//end
	_questInfos[questInfosIndex].setQuestStatus (_questInfos_questStatus);

	// 显示奖励信息
	String _questInfos_showRewardInfo = readString();
	//end
	_questInfos[questInfosIndex].setShowRewardInfo (_questInfos_showRewardInfo);
	}
	//end



		this.questInfos = _questInfos;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 任务列表
	writeShort(questInfos.length);
	int questInfosIndex = 0;
	int questInfosSize = questInfos.length;
	for(questInfosIndex=0; questInfosIndex<questInfosSize; questInfosIndex++){

	String questInfos_uuid = questInfos[questInfosIndex].getUuid();

	// 任务UUID
	writeString(questInfos_uuid);

	int questInfos_questId = questInfos[questInfosIndex].getQuestId();

	// 任务模板Id
	writeInteger(questInfos_questId);

	int questInfos_destGotNum = questInfos[questInfosIndex].getDestGotNum();

	// 已完成数量,分子
	writeInteger(questInfos_destGotNum);

	int questInfos_destReqNum = questInfos[questInfosIndex].getDestReqNum();

	// 任务目标需求数量，分母
	writeInteger(questInfos_destReqNum);

	int questInfos_questStatus = questInfos[questInfosIndex].getQuestStatus();

	// 任务当前状态
	writeInteger(questInfos_questStatus);

	String questInfos_showRewardInfo = questInfos[questInfosIndex].getShowRewardInfo();

	// 显示奖励信息
	writeString(questInfos_showRewardInfo);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_COMMON_QUEST_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_COMMON_QUEST_LIST";
	}

	public com.imop.lj.common.model.quest.QuestInfo[] getQuestInfos(){
		return questInfos;
	}

	public void setQuestInfos(com.imop.lj.common.model.quest.QuestInfo[] questInfos){
		this.questInfos = questInfos;
	}	
	public boolean isCompress() {
		return true;
	}
}