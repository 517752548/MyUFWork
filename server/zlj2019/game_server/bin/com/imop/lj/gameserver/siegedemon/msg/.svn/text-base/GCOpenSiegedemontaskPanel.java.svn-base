package com.imop.lj.gameserver.siegedemon.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 打开围剿魔族副本任务面板
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOpenSiegedemontaskPanel extends GCMessage{
	
	/** 任务面板信息 */
	private com.imop.lj.common.model.quest.QuestPanelInfo[] questPanelInfo;

	public GCOpenSiegedemontaskPanel (){
	}
	
	public GCOpenSiegedemontaskPanel (
			com.imop.lj.common.model.quest.QuestPanelInfo[] questPanelInfo ){
			this.questPanelInfo = questPanelInfo;
	}

	@Override
	protected boolean readImpl() {

	// 任务面板信息
	int questPanelInfoSize = readUnsignedShort();
	com.imop.lj.common.model.quest.QuestPanelInfo[] _questPanelInfo = new com.imop.lj.common.model.quest.QuestPanelInfo[questPanelInfoSize];
	int questPanelInfoIndex = 0;
	for(questPanelInfoIndex=0; questPanelInfoIndex<questPanelInfoSize; questPanelInfoIndex++){
		_questPanelInfo[questPanelInfoIndex] = new com.imop.lj.common.model.quest.QuestPanelInfo();
	// 任务类型
	int _questPanelInfo_questType = readInteger();
	//end
	_questPanelInfo[questPanelInfoIndex].setQuestType (_questPanelInfo_questType);

	// 任务等级限制
	int _questPanelInfo_questMinLevel = readInteger();
	//end
	_questPanelInfo[questPanelInfoIndex].setQuestMinLevel (_questPanelInfo_questMinLevel);

	// 今日已完成任务数
	int _questPanelInfo_finishTimes = readInteger();
	//end
	_questPanelInfo[questPanelInfoIndex].setFinishTimes (_questPanelInfo_finishTimes);

	// 总任务数
	int _questPanelInfo_totalTimes = readInteger();
	//end
	_questPanelInfo[questPanelInfoIndex].setTotalTimes (_questPanelInfo_totalTimes);
	}
	//end



		this.questPanelInfo = _questPanelInfo;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 任务面板信息
	writeShort(questPanelInfo.length);
	int questPanelInfoIndex = 0;
	int questPanelInfoSize = questPanelInfo.length;
	for(questPanelInfoIndex=0; questPanelInfoIndex<questPanelInfoSize; questPanelInfoIndex++){

	int questPanelInfo_questType = questPanelInfo[questPanelInfoIndex].getQuestType();

	// 任务类型
	writeInteger(questPanelInfo_questType);

	int questPanelInfo_questMinLevel = questPanelInfo[questPanelInfoIndex].getQuestMinLevel();

	// 任务等级限制
	writeInteger(questPanelInfo_questMinLevel);

	int questPanelInfo_finishTimes = questPanelInfo[questPanelInfoIndex].getFinishTimes();

	// 今日已完成任务数
	writeInteger(questPanelInfo_finishTimes);

	int questPanelInfo_totalTimes = questPanelInfo[questPanelInfoIndex].getTotalTimes();

	// 总任务数
	writeInteger(questPanelInfo_totalTimes);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_OPEN_SIEGEDEMONTASK_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "GC_OPEN_SIEGEDEMONTASK_PANEL";
	}

	public com.imop.lj.common.model.quest.QuestPanelInfo[] getQuestPanelInfo(){
		return questPanelInfo;
	}

	public void setQuestPanelInfo(com.imop.lj.common.model.quest.QuestPanelInfo[] questPanelInfo){
		this.questPanelInfo = questPanelInfo;
	}	
}