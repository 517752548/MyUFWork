package com.imop.lj.gameserver.onlinegift.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回在线礼包信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOnlinegiftInfo extends GCMessage{
	
	/** 该领取到的id */
	private int rewardId;
	/** 计时开始的时间 */
	private long cdTime;
	/** 礼包信息 */
	private com.imop.lj.common.model.reward.RewardInfo[] rewardInfo;

	public GCOnlinegiftInfo (){
	}
	
	public GCOnlinegiftInfo (
			int rewardId,
			long cdTime,
			com.imop.lj.common.model.reward.RewardInfo[] rewardInfo ){
			this.rewardId = rewardId;
			this.cdTime = cdTime;
			this.rewardInfo = rewardInfo;
	}

	@Override
	protected boolean readImpl() {

	// 该领取到的id
	int _rewardId = readInteger();
	//end


	// 计时开始的时间
	long _cdTime = readLong();
	//end


	// 礼包信息
	int rewardInfoSize = readUnsignedShort();
	com.imop.lj.common.model.reward.RewardInfo[] _rewardInfo = new com.imop.lj.common.model.reward.RewardInfo[rewardInfoSize];
	int rewardInfoIndex = 0;
	for(rewardInfoIndex=0; rewardInfoIndex<rewardInfoSize; rewardInfoIndex++){
		_rewardInfo[rewardInfoIndex] = new com.imop.lj.common.model.reward.RewardInfo();
	// 奖励信息
	String _rewardInfo_rewardStr = readString();
	//end
	_rewardInfo[rewardInfoIndex].setRewardStr (_rewardInfo_rewardStr);
	}
	//end



		this.rewardId = _rewardId;
		this.cdTime = _cdTime;
		this.rewardInfo = _rewardInfo;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 该领取到的id
	writeInteger(rewardId);


	// 计时开始的时间
	writeLong(cdTime);


	// 礼包信息
	writeShort(rewardInfo.length);
	int rewardInfoIndex = 0;
	int rewardInfoSize = rewardInfo.length;
	for(rewardInfoIndex=0; rewardInfoIndex<rewardInfoSize; rewardInfoIndex++){

	String rewardInfo_rewardStr = rewardInfo[rewardInfoIndex].getRewardStr();

	// 奖励信息
	writeString(rewardInfo_rewardStr);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_ONLINEGIFT_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "GC_ONLINEGIFT_INFO";
	}

	public int getRewardId(){
		return rewardId;
	}
		
	public void setRewardId(int rewardId){
		this.rewardId = rewardId;
	}

	public long getCdTime(){
		return cdTime;
	}
		
	public void setCdTime(long cdTime){
		this.cdTime = cdTime;
	}

	public com.imop.lj.common.model.reward.RewardInfo[] getRewardInfo(){
		return rewardInfo;
	}

	public void setRewardInfo(com.imop.lj.common.model.reward.RewardInfo[] rewardInfo){
		this.rewardInfo = rewardInfo;
	}	
}