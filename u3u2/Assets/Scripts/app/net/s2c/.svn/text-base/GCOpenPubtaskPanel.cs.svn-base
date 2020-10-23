
using System;
namespace app.net
{
/**
 * 打开酒馆任务面板
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOpenPubtaskPanel :BaseMessage
{
	/** 备选任务列表 */
	private BackupPubTaskInfo[] backupPubTaskInfos;
	/** 今日已完成任务数 */
	private int finishTimes;
	/** 总任务数 */
	private int totalTimes;

	public GCOpenPubtaskPanel ()
	{
	}

	protected override void ReadImpl()
	{

	// 备选任务列表
	int backupPubTaskInfosSize = ReadShort();
	BackupPubTaskInfo[] _backupPubTaskInfos = new BackupPubTaskInfo[backupPubTaskInfosSize];
	int backupPubTaskInfosIndex = 0;
	BackupPubTaskInfo _backupPubTaskInfosTmp = null;
	for(backupPubTaskInfosIndex=0; backupPubTaskInfosIndex<backupPubTaskInfosSize; backupPubTaskInfosIndex++){
		_backupPubTaskInfosTmp = new BackupPubTaskInfo();
		_backupPubTaskInfos[backupPubTaskInfosIndex] = _backupPubTaskInfosTmp;
	// 任务模板Id
	int _backupPubTaskInfos_questId = ReadInt();	_backupPubTaskInfosTmp.questId = _backupPubTaskInfos_questId;
		// 任务星数
	int _backupPubTaskInfos_star = ReadInt();	_backupPubTaskInfosTmp.star = _backupPubTaskInfos_star;
		// 任务状态
	int _backupPubTaskInfos_status = ReadInt();	_backupPubTaskInfosTmp.status = _backupPubTaskInfos_status;
		// 任务奖励信息
	RewardInfoData _backupPubTaskInfos_rewardInfo = new RewardInfoData();
	// 奖励信息
	string _backupPubTaskInfos_rewardInfo_rewardStr = ReadString();	_backupPubTaskInfos_rewardInfo.rewardStr = _backupPubTaskInfos_rewardInfo_rewardStr;
	_backupPubTaskInfosTmp.rewardInfo = _backupPubTaskInfos_rewardInfo;
		}
	//end

	// 今日已完成任务数
	int _finishTimes = ReadInt();
	// 总任务数
	int _totalTimes = ReadInt();


		this.backupPubTaskInfos = _backupPubTaskInfos;
		this.finishTimes = _finishTimes;
		this.totalTimes = _totalTimes;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_OPEN_PUBTASK_PANEL;
	}
	
	public override string getEventType()
	{
		return PubtaskGCHandler.GCOpenPubtaskPanelEvent;
	}
	

	public BackupPubTaskInfo[] getBackupPubTaskInfos(){
		return backupPubTaskInfos;
	}


	public int getFinishTimes(){
		return finishTimes;
	}
		

	public int getTotalTimes(){
		return totalTimes;
	}
		

}
}