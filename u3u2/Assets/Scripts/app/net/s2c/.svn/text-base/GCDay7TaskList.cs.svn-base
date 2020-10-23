
using System;
namespace app.net
{
/**
 * 七日目标所有任务状态列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCDay7TaskList :BaseMessage
{
	/** 单个任务 */
	private QuestInfoData[] questInfo;

	public GCDay7TaskList ()
	{
	}

	protected override void ReadImpl()
	{

	// 单个任务
	int questInfoSize = ReadShort();
	QuestInfoData[] _questInfo = new QuestInfoData[questInfoSize];
	int questInfoIndex = 0;
	QuestInfoData _questInfoTmp = null;
	for(questInfoIndex=0; questInfoIndex<questInfoSize; questInfoIndex++){
		_questInfoTmp = new QuestInfoData();
		_questInfo[questInfoIndex] = _questInfoTmp;
	// 任务UUID
	string _questInfo_uuid = ReadString();	_questInfoTmp.uuid = _questInfo_uuid;
		// 任务模板Id
	int _questInfo_questId = ReadInt();	_questInfoTmp.questId = _questInfo_questId;
		// 已完成数量,分子
	int _questInfo_destGotNum = ReadInt();	_questInfoTmp.destGotNum = _questInfo_destGotNum;
		// 任务目标需求数量，分母
	int _questInfo_destReqNum = ReadInt();	_questInfoTmp.destReqNum = _questInfo_destReqNum;
		// 任务当前状态
	int _questInfo_questStatus = ReadInt();	_questInfoTmp.questStatus = _questInfo_questStatus;
		// 显示奖励信息
	string _questInfo_showRewardInfo = ReadString();	_questInfoTmp.showRewardInfo = _questInfo_showRewardInfo;
		}
	//end



		this.questInfo = _questInfo;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_DAY7_TASK_LIST;
	}
	
	public override string getEventType()
	{
		return HumanGCHandler.GCDay7TaskListEvent;
	}
	

	public QuestInfoData[] getQuestInfo(){
		return questInfo;
	}


}
}