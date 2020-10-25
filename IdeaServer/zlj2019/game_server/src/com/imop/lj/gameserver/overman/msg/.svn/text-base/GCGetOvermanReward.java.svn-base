package com.imop.lj.gameserver.overman.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 师傅在这个徒弟身上所有奖励的状态
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCGetOvermanReward extends GCMessage{
	
	/** 徒弟的id */
	private long lowermanCharId;
	/** 奖励信息 */
	private com.imop.lj.gameserver.overman.OvermanRewardInfo[] rewardInfo;

	public GCGetOvermanReward (){
	}
	
	public GCGetOvermanReward (
			long lowermanCharId,
			com.imop.lj.gameserver.overman.OvermanRewardInfo[] rewardInfo ){
			this.lowermanCharId = lowermanCharId;
			this.rewardInfo = rewardInfo;
	}

	@Override
	protected boolean readImpl() {

	// 徒弟的id
	long _lowermanCharId = readLong();
	//end


	// 奖励信息
	int rewardInfoSize = readUnsignedShort();
	com.imop.lj.gameserver.overman.OvermanRewardInfo[] _rewardInfo = new com.imop.lj.gameserver.overman.OvermanRewardInfo[rewardInfoSize];
	int rewardInfoIndex = 0;
	for(rewardInfoIndex=0; rewardInfoIndex<rewardInfoSize; rewardInfoIndex++){
		_rewardInfo[rewardInfoIndex] = new com.imop.lj.gameserver.overman.OvermanRewardInfo();
	// 奖励索引
	int _rewardInfo_index = readInteger();
	//end
	_rewardInfo[rewardInfoIndex].setIndex (_rewardInfo_index);

	// 是否领取,1领取,0未领取
	int _rewardInfo_hadget = readInteger();
	//end
	_rewardInfo[rewardInfoIndex].setHadget (_rewardInfo_hadget);
	}
	//end



		this.lowermanCharId = _lowermanCharId;
		this.rewardInfo = _rewardInfo;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 徒弟的id
	writeLong(lowermanCharId);


	// 奖励信息
	writeShort(rewardInfo.length);
	int rewardInfoIndex = 0;
	int rewardInfoSize = rewardInfo.length;
	for(rewardInfoIndex=0; rewardInfoIndex<rewardInfoSize; rewardInfoIndex++){

	int rewardInfo_index = rewardInfo[rewardInfoIndex].getIndex();

	// 奖励索引
	writeInteger(rewardInfo_index);

	int rewardInfo_hadget = rewardInfo[rewardInfoIndex].getHadget();

	// 是否领取,1领取,0未领取
	writeInteger(rewardInfo_hadget);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_GET_OVERMAN_REWARD;
	}
	
	@Override
	public String getTypeName() {
		return "GC_GET_OVERMAN_REWARD";
	}

	public long getLowermanCharId(){
		return lowermanCharId;
	}
		
	public void setLowermanCharId(long lowermanCharId){
		this.lowermanCharId = lowermanCharId;
	}

	public com.imop.lj.gameserver.overman.OvermanRewardInfo[] getRewardInfo(){
		return rewardInfo;
	}

	public void setRewardInfo(com.imop.lj.gameserver.overman.OvermanRewardInfo[] rewardInfo){
		this.rewardInfo = rewardInfo;
	}	
}