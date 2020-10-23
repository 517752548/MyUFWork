
using System;
namespace app.net
{
/**
 * 打开护送粮草任务面板
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOpenForagetaskPanel :BaseMessage
{
	/** 备选任务列表 */
	private BackupForageTaskInfoData[] backupForageTaskInfos;
	/** 今日已完成任务数 */
	private int finishTimes;
	/** 总任务数 */
	private int totalTimes;

	public GCOpenForagetaskPanel ()
	{
	}

	protected override void ReadImpl()
	{

	// 备选任务列表
	int backupForageTaskInfosSize = ReadShort();
	BackupForageTaskInfoData[] _backupForageTaskInfos = new BackupForageTaskInfoData[backupForageTaskInfosSize];
	int backupForageTaskInfosIndex = 0;
	BackupForageTaskInfoData _backupForageTaskInfosTmp = null;
	for(backupForageTaskInfosIndex=0; backupForageTaskInfosIndex<backupForageTaskInfosSize; backupForageTaskInfosIndex++){
		_backupForageTaskInfosTmp = new BackupForageTaskInfoData();
		_backupForageTaskInfos[backupForageTaskInfosIndex] = _backupForageTaskInfosTmp;
	// 任务Id
	int _backupForageTaskInfos_questId = ReadInt();	_backupForageTaskInfosTmp.questId = _backupForageTaskInfos_questId;
		// 粮草品质
	int _backupForageTaskInfos_star = ReadInt();	_backupForageTaskInfosTmp.star = _backupForageTaskInfos_star;
		// 任务状态
	int _backupForageTaskInfos_status = ReadInt();	_backupForageTaskInfosTmp.status = _backupForageTaskInfos_status;
		}
	//end

	// 今日已完成任务数
	int _finishTimes = ReadInt();
	// 总任务数
	int _totalTimes = ReadInt();


		this.backupForageTaskInfos = _backupForageTaskInfos;
		this.finishTimes = _finishTimes;
		this.totalTimes = _totalTimes;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_OPEN_FORAGETASK_PANEL;
	}
	
	public override string getEventType()
	{
		return ForagetaskGCHandler.GCOpenForagetaskPanelEvent;
	}
	

	public BackupForageTaskInfoData[] getBackupForageTaskInfos(){
		return backupForageTaskInfos;
	}


	public int getFinishTimes(){
		return finishTimes;
	}
		

	public int getTotalTimes(){
		return totalTimes;
	}
		

}
}