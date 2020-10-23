
using System;
namespace app.net
{
/**
 * 跑环任务更新消息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCRingtaskUpdate :BaseMessage
{
	/** 单个任务 */
	private QuestInfoData questInfo;

	public GCRingtaskUpdate ()
	{
	}

	protected override void ReadImpl()
	{
	// 单个任务
	QuestInfoData _questInfo = new QuestInfoData();
	// 任务UUID
	string _questInfo_uuid = ReadString();	_questInfo.uuid = _questInfo_uuid;
	// 任务模板Id
	int _questInfo_questId = ReadInt();	_questInfo.questId = _questInfo_questId;
	// 已完成数量,分子
	int _questInfo_destGotNum = ReadInt();	_questInfo.destGotNum = _questInfo_destGotNum;
	// 任务目标需求数量，分母
	int _questInfo_destReqNum = ReadInt();	_questInfo.destReqNum = _questInfo_destReqNum;
	// 任务当前状态
	int _questInfo_questStatus = ReadInt();	_questInfo.questStatus = _questInfo_questStatus;
	// 显示奖励信息
	string _questInfo_showRewardInfo = ReadString();	_questInfo.showRewardInfo = _questInfo_showRewardInfo;



		this.questInfo = _questInfo;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_RINGTASK_UPDATE;
	}
	
	public override string getEventType()
	{
		return RingtaskGCHandler.GCRingtaskUpdateEvent;
	}
	

	public QuestInfoData getQuestInfo(){
		return questInfo;
	}
		

}
}