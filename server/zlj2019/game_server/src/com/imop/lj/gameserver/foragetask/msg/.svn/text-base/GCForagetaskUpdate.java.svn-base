package com.imop.lj.gameserver.foragetask.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 护送粮草任务更新消息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCForagetaskUpdate extends GCMessage{
	
	/** 单个任务 */
	private com.imop.lj.common.model.quest.QuestInfo questInfo;

	public GCForagetaskUpdate (){
	}
	
	public GCForagetaskUpdate (
			com.imop.lj.common.model.quest.QuestInfo questInfo ){
			this.questInfo = questInfo;
	}

	@Override
	protected boolean readImpl() {
	// 单个任务
	com.imop.lj.common.model.quest.QuestInfo _questInfo = new com.imop.lj.common.model.quest.QuestInfo();

	// 任务UUID
	String _questInfo_uuid = readString();
	//end
	_questInfo.setUuid (_questInfo_uuid);

	// 任务模板Id
	int _questInfo_questId = readInteger();
	//end
	_questInfo.setQuestId (_questInfo_questId);

	// 已完成数量,分子
	int _questInfo_destGotNum = readInteger();
	//end
	_questInfo.setDestGotNum (_questInfo_destGotNum);

	// 任务目标需求数量，分母
	int _questInfo_destReqNum = readInteger();
	//end
	_questInfo.setDestReqNum (_questInfo_destReqNum);

	// 任务当前状态
	int _questInfo_questStatus = readInteger();
	//end
	_questInfo.setQuestStatus (_questInfo_questStatus);

	// 显示奖励信息
	String _questInfo_showRewardInfo = readString();
	//end
	_questInfo.setShowRewardInfo (_questInfo_showRewardInfo);



		this.questInfo = _questInfo;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	String questInfo_uuid = questInfo.getUuid ();

	// 任务UUID
	writeString(questInfo_uuid);

	int questInfo_questId = questInfo.getQuestId ();

	// 任务模板Id
	writeInteger(questInfo_questId);

	int questInfo_destGotNum = questInfo.getDestGotNum ();

	// 已完成数量,分子
	writeInteger(questInfo_destGotNum);

	int questInfo_destReqNum = questInfo.getDestReqNum ();

	// 任务目标需求数量，分母
	writeInteger(questInfo_destReqNum);

	int questInfo_questStatus = questInfo.getQuestStatus ();

	// 任务当前状态
	writeInteger(questInfo_questStatus);

	String questInfo_showRewardInfo = questInfo.getShowRewardInfo ();

	// 显示奖励信息
	writeString(questInfo_showRewardInfo);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_FORAGETASK_UPDATE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_FORAGETASK_UPDATE";
	}

	public com.imop.lj.common.model.quest.QuestInfo getQuestInfo(){
		return questInfo;
	}
		
	public void setQuestInfo(com.imop.lj.common.model.quest.QuestInfo questInfo){
		this.questInfo = questInfo;
	}
}