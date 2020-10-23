
using System;
namespace app.net
{
/**
 * 返回成长任务列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCCommonQuestList :BaseMessage
{
	/** 任务列表 */
	private QuestInfoData[] questInfos;

	public GCCommonQuestList ()
	{
	}

	protected override void ReadImpl()
	{

	// 任务列表
	int questInfosSize = ReadShort();
	QuestInfoData[] _questInfos = new QuestInfoData[questInfosSize];
	int questInfosIndex = 0;
	QuestInfoData _questInfosTmp = null;
	for(questInfosIndex=0; questInfosIndex<questInfosSize; questInfosIndex++){
		_questInfosTmp = new QuestInfoData();
		_questInfos[questInfosIndex] = _questInfosTmp;
	// 任务UUID
	string _questInfos_uuid = ReadString();	_questInfosTmp.uuid = _questInfos_uuid;
		// 任务模板Id
	int _questInfos_questId = ReadInt();	_questInfosTmp.questId = _questInfos_questId;
		// 已完成数量,分子
	int _questInfos_destGotNum = ReadInt();	_questInfosTmp.destGotNum = _questInfos_destGotNum;
		// 任务目标需求数量，分母
	int _questInfos_destReqNum = ReadInt();	_questInfosTmp.destReqNum = _questInfos_destReqNum;
		// 任务当前状态
	int _questInfos_questStatus = ReadInt();	_questInfosTmp.questStatus = _questInfos_questStatus;
		// 显示奖励信息
	string _questInfos_showRewardInfo = ReadString();	_questInfosTmp.showRewardInfo = _questInfos_showRewardInfo;
		}
	//end



		this.questInfos = _questInfos;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_COMMON_QUEST_LIST;
	}
	
	public override string getEventType()
	{
		return QuestGCHandler.GCCommonQuestListEvent;
	}
	

	public QuestInfoData[] getQuestInfos(){
		return questInfos;
	}


	public override bool isCompress() {
		return true;
	}
}
}