package com.imop.lj.gameserver.onlinegift.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 申请每日签到奖励信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCDaliyGiftListApply extends GCMessage{
	
	/** 返回可以获得的奖励的信息 */
	private com.imop.lj.common.model.reward.RewardInfo[] rewardInfoList;

	public GCDaliyGiftListApply (){
	}
	
	public GCDaliyGiftListApply (
			com.imop.lj.common.model.reward.RewardInfo[] rewardInfoList ){
			this.rewardInfoList = rewardInfoList;
	}

	@Override
	protected boolean readImpl() {

	// 返回可以获得的奖励的信息
	int rewardInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.reward.RewardInfo[] _rewardInfoList = new com.imop.lj.common.model.reward.RewardInfo[rewardInfoListSize];
	int rewardInfoListIndex = 0;
	for(rewardInfoListIndex=0; rewardInfoListIndex<rewardInfoListSize; rewardInfoListIndex++){
		_rewardInfoList[rewardInfoListIndex] = new com.imop.lj.common.model.reward.RewardInfo();
	// 奖励信息
	String _rewardInfoList_rewardStr = readString();
	//end
	_rewardInfoList[rewardInfoListIndex].setRewardStr (_rewardInfoList_rewardStr);
	}
	//end



		this.rewardInfoList = _rewardInfoList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 返回可以获得的奖励的信息
	writeShort(rewardInfoList.length);
	int rewardInfoListIndex = 0;
	int rewardInfoListSize = rewardInfoList.length;
	for(rewardInfoListIndex=0; rewardInfoListIndex<rewardInfoListSize; rewardInfoListIndex++){

	String rewardInfoList_rewardStr = rewardInfoList[rewardInfoListIndex].getRewardStr();

	// 奖励信息
	writeString(rewardInfoList_rewardStr);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_DALIY_GIFT_LIST_APPLY;
	}
	
	@Override
	public String getTypeName() {
		return "GC_DALIY_GIFT_LIST_APPLY";
	}

	public com.imop.lj.common.model.reward.RewardInfo[] getRewardInfoList(){
		return rewardInfoList;
	}

	public void setRewardInfoList(com.imop.lj.common.model.reward.RewardInfo[] rewardInfoList){
		this.rewardInfoList = rewardInfoList;
	}	
}