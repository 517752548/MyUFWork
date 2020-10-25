package com.imop.lj.gameserver.pubtask.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 打开酒馆任务面板
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOpenPubtaskPanel extends GCMessage{
	
	/** 备选任务列表 */
	private com.imop.lj.common.model.BackupPubTaskInfo[] backupPubTaskInfos;
	/** 今日已完成任务数 */
	private int finishTimes;
	/** 总任务数 */
	private int totalTimes;

	public GCOpenPubtaskPanel (){
	}
	
	public GCOpenPubtaskPanel (
			com.imop.lj.common.model.BackupPubTaskInfo[] backupPubTaskInfos,
			int finishTimes,
			int totalTimes ){
			this.backupPubTaskInfos = backupPubTaskInfos;
			this.finishTimes = finishTimes;
			this.totalTimes = totalTimes;
	}

	@Override
	protected boolean readImpl() {

	// 备选任务列表
	int backupPubTaskInfosSize = readUnsignedShort();
	com.imop.lj.common.model.BackupPubTaskInfo[] _backupPubTaskInfos = new com.imop.lj.common.model.BackupPubTaskInfo[backupPubTaskInfosSize];
	int backupPubTaskInfosIndex = 0;
	for(backupPubTaskInfosIndex=0; backupPubTaskInfosIndex<backupPubTaskInfosSize; backupPubTaskInfosIndex++){
		_backupPubTaskInfos[backupPubTaskInfosIndex] = new com.imop.lj.common.model.BackupPubTaskInfo();
	// 任务模板Id
	int _backupPubTaskInfos_questId = readInteger();
	//end
	_backupPubTaskInfos[backupPubTaskInfosIndex].setQuestId (_backupPubTaskInfos_questId);

	// 任务星数
	int _backupPubTaskInfos_star = readInteger();
	//end
	_backupPubTaskInfos[backupPubTaskInfosIndex].setStar (_backupPubTaskInfos_star);

	// 任务状态
	int _backupPubTaskInfos_status = readInteger();
	//end
	_backupPubTaskInfos[backupPubTaskInfosIndex].setStatus (_backupPubTaskInfos_status);
	// 任务奖励信息
	com.imop.lj.common.model.reward.RewardInfo _backupPubTaskInfos_rewardInfo = new com.imop.lj.common.model.reward.RewardInfo();

	// 奖励信息
	String _backupPubTaskInfos_rewardInfo_rewardStr = readString();
	//end
	_backupPubTaskInfos_rewardInfo.setRewardStr (_backupPubTaskInfos_rewardInfo_rewardStr);
	_backupPubTaskInfos[backupPubTaskInfosIndex].setRewardInfo (_backupPubTaskInfos_rewardInfo);
	}
	//end


	// 今日已完成任务数
	int _finishTimes = readInteger();
	//end


	// 总任务数
	int _totalTimes = readInteger();
	//end



		this.backupPubTaskInfos = _backupPubTaskInfos;
		this.finishTimes = _finishTimes;
		this.totalTimes = _totalTimes;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 备选任务列表
	writeShort(backupPubTaskInfos.length);
	int backupPubTaskInfosIndex = 0;
	int backupPubTaskInfosSize = backupPubTaskInfos.length;
	for(backupPubTaskInfosIndex=0; backupPubTaskInfosIndex<backupPubTaskInfosSize; backupPubTaskInfosIndex++){

	int backupPubTaskInfos_questId = backupPubTaskInfos[backupPubTaskInfosIndex].getQuestId();

	// 任务模板Id
	writeInteger(backupPubTaskInfos_questId);

	int backupPubTaskInfos_star = backupPubTaskInfos[backupPubTaskInfosIndex].getStar();

	// 任务星数
	writeInteger(backupPubTaskInfos_star);

	int backupPubTaskInfos_status = backupPubTaskInfos[backupPubTaskInfosIndex].getStatus();

	// 任务状态
	writeInteger(backupPubTaskInfos_status);

	com.imop.lj.common.model.reward.RewardInfo backupPubTaskInfos_rewardInfo = backupPubTaskInfos[backupPubTaskInfosIndex].getRewardInfo();

	String backupPubTaskInfos_rewardInfo_rewardStr = backupPubTaskInfos_rewardInfo.getRewardStr ();

	// 奖励信息
	writeString(backupPubTaskInfos_rewardInfo_rewardStr);
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
		return MessageType.GC_OPEN_PUBTASK_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "GC_OPEN_PUBTASK_PANEL";
	}

	public com.imop.lj.common.model.BackupPubTaskInfo[] getBackupPubTaskInfos(){
		return backupPubTaskInfos;
	}

	public void setBackupPubTaskInfos(com.imop.lj.common.model.BackupPubTaskInfo[] backupPubTaskInfos){
		this.backupPubTaskInfos = backupPubTaskInfos;
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