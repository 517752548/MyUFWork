package com.imop.lj.gameserver.foragetask.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 打开护送粮草任务面板
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOpenForagetaskPanel extends GCMessage{
	
	/** 备选任务列表 */
	private com.imop.lj.common.model.BackupForageTaskInfo[] backupForageTaskInfos;
	/** 今日已完成任务数 */
	private int finishTimes;
	/** 总任务数 */
	private int totalTimes;

	public GCOpenForagetaskPanel (){
	}
	
	public GCOpenForagetaskPanel (
			com.imop.lj.common.model.BackupForageTaskInfo[] backupForageTaskInfos,
			int finishTimes,
			int totalTimes ){
			this.backupForageTaskInfos = backupForageTaskInfos;
			this.finishTimes = finishTimes;
			this.totalTimes = totalTimes;
	}

	@Override
	protected boolean readImpl() {

	// 备选任务列表
	int backupForageTaskInfosSize = readUnsignedShort();
	com.imop.lj.common.model.BackupForageTaskInfo[] _backupForageTaskInfos = new com.imop.lj.common.model.BackupForageTaskInfo[backupForageTaskInfosSize];
	int backupForageTaskInfosIndex = 0;
	for(backupForageTaskInfosIndex=0; backupForageTaskInfosIndex<backupForageTaskInfosSize; backupForageTaskInfosIndex++){
		_backupForageTaskInfos[backupForageTaskInfosIndex] = new com.imop.lj.common.model.BackupForageTaskInfo();
	// 任务Id
	int _backupForageTaskInfos_questId = readInteger();
	//end
	_backupForageTaskInfos[backupForageTaskInfosIndex].setQuestId (_backupForageTaskInfos_questId);

	// 粮草品质
	int _backupForageTaskInfos_star = readInteger();
	//end
	_backupForageTaskInfos[backupForageTaskInfosIndex].setStar (_backupForageTaskInfos_star);

	// 任务状态
	int _backupForageTaskInfos_status = readInteger();
	//end
	_backupForageTaskInfos[backupForageTaskInfosIndex].setStatus (_backupForageTaskInfos_status);
	}
	//end


	// 今日已完成任务数
	int _finishTimes = readInteger();
	//end


	// 总任务数
	int _totalTimes = readInteger();
	//end



		this.backupForageTaskInfos = _backupForageTaskInfos;
		this.finishTimes = _finishTimes;
		this.totalTimes = _totalTimes;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 备选任务列表
	writeShort(backupForageTaskInfos.length);
	int backupForageTaskInfosIndex = 0;
	int backupForageTaskInfosSize = backupForageTaskInfos.length;
	for(backupForageTaskInfosIndex=0; backupForageTaskInfosIndex<backupForageTaskInfosSize; backupForageTaskInfosIndex++){

	int backupForageTaskInfos_questId = backupForageTaskInfos[backupForageTaskInfosIndex].getQuestId();

	// 任务Id
	writeInteger(backupForageTaskInfos_questId);

	int backupForageTaskInfos_star = backupForageTaskInfos[backupForageTaskInfosIndex].getStar();

	// 粮草品质
	writeInteger(backupForageTaskInfos_star);

	int backupForageTaskInfos_status = backupForageTaskInfos[backupForageTaskInfosIndex].getStatus();

	// 任务状态
	writeInteger(backupForageTaskInfos_status);
	}
	//end


	// 今日已完成任务数
	writeInteger(finishTimes);


	// 总任务数
	writeInteger(totalTimes);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_OPEN_FORAGETASK_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "GC_OPEN_FORAGETASK_PANEL";
	}

	public com.imop.lj.common.model.BackupForageTaskInfo[] getBackupForageTaskInfos(){
		return backupForageTaskInfos;
	}

	public void setBackupForageTaskInfos(com.imop.lj.common.model.BackupForageTaskInfo[] backupForageTaskInfos){
		this.backupForageTaskInfos = backupForageTaskInfos;
	}	

	public int getFinishTimes(){
		return finishTimes;
	}
		
	public void setFinishTimes(int finishTimes){
		this.finishTimes = finishTimes;
	}

	public int getTotalTimes(){
		return totalTimes;
	}
		
	public void setTotalTimes(int totalTimes){
		this.totalTimes = totalTimes;
	}
}