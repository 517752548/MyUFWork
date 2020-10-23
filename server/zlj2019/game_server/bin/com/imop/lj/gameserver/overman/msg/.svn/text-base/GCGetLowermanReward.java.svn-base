package com.imop.lj.gameserver.overman.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 获得徒弟所有的奖励状态
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCGetLowermanReward extends GCMessage{
	
	/** 奖励信息 */
	private com.imop.lj.gameserver.overman.OvermanRewardInfo[] rewardInfo;

	public GCGetLowermanReward (){
	}
	
	public GCGetLowermanReward (
			com.imop.lj.gameserver.overman.OvermanRewardInfo[] rewardInfo ){
			this.rewardInfo = rewardInfo;
	}

	@Override
	protected boolean readImpl() {

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



		this.rewardInfo = _rewardInfo;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

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
		return MessageType.GC_GET_LOWERMAN_REWARD;
	}
	
	@Override
	public String getTypeName() {
		return "GC_GET_LOWERMAN_REWARD";
	}

	public com.imop.lj.gameserver.overman.OvermanRewardInfo[] getRewardInfo(){
		return rewardInfo;
	}

	public void setRewardInfo(com.imop.lj.gameserver.overman.OvermanRewardInfo[] rewardInfo){
		this.rewardInfo = rewardInfo;
	}	
}