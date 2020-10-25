package com.imop.lj.gameserver.activityui.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回rewardInfoList
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCAcitvityUiRewardInfo extends GCMessage{
	
	/** 返回可以获得的奖励的信息 */
	private com.imop.lj.gameserver.activityui.ActivityUIRewardInfo[] activityUIRewardInfoList;

	public GCAcitvityUiRewardInfo (){
	}
	
	public GCAcitvityUiRewardInfo (
			com.imop.lj.gameserver.activityui.ActivityUIRewardInfo[] activityUIRewardInfoList ){
			this.activityUIRewardInfoList = activityUIRewardInfoList;
	}

	@Override
	protected boolean readImpl() {

	// 返回可以获得的奖励的信息
	int activityUIRewardInfoListSize = readUnsignedShort();
	com.imop.lj.gameserver.activityui.ActivityUIRewardInfo[] _activityUIRewardInfoList = new com.imop.lj.gameserver.activityui.ActivityUIRewardInfo[activityUIRewardInfoListSize];
	int activityUIRewardInfoListIndex = 0;
	for(activityUIRewardInfoListIndex=0; activityUIRewardInfoListIndex<activityUIRewardInfoListSize; activityUIRewardInfoListIndex++){
		_activityUIRewardInfoList[activityUIRewardInfoListIndex] = new com.imop.lj.gameserver.activityui.ActivityUIRewardInfo();
	// 活跃度
	int _activityUIRewardInfoList_vitalityNum = readInteger();
	//end
	_activityUIRewardInfoList[activityUIRewardInfoListIndex].setVitalityNum (_activityUIRewardInfoList_vitalityNum);
	// 奖励
	com.imop.lj.common.model.reward.RewardInfo _activityUIRewardInfoList_rewardInfo = new com.imop.lj.common.model.reward.RewardInfo();

	// 奖励信息
	String _activityUIRewardInfoList_rewardInfo_rewardStr = readString();
	//end
	_activityUIRewardInfoList_rewardInfo.setRewardStr (_activityUIRewardInfoList_rewardInfo_rewardStr);
	_activityUIRewardInfoList[activityUIRewardInfoListIndex].setRewardInfo (_activityUIRewardInfoList_rewardInfo);
	}
	//end



		this.activityUIRewardInfoList = _activityUIRewardInfoList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 返回可以获得的奖励的信息
	writeShort(activityUIRewardInfoList.length);
	int activityUIRewardInfoListIndex = 0;
	int activityUIRewardInfoListSize = activityUIRewardInfoList.length;
	for(activityUIRewardInfoListIndex=0; activityUIRewardInfoListIndex<activityUIRewardInfoListSize; activityUIRewardInfoListIndex++){

	int activityUIRewardInfoList_vitalityNum = activityUIRewardInfoList[activityUIRewardInfoListIndex].getVitalityNum();

	// 活跃度
	writeInteger(activityUIRewardInfoList_vitalityNum);

	com.imop.lj.common.model.reward.RewardInfo activityUIRewardInfoList_rewardInfo = activityUIRewardInfoList[activityUIRewardInfoListIndex].getRewardInfo();

	String activityUIRewardInfoList_rewardInfo_rewardStr = activityUIRewardInfoList_rewardInfo.getRewardStr ();

	// 奖励信息
	writeString(activityUIRewardInfoList_rewardInfo_rewardStr);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_ACITVITY_UI_REWARD_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "GC_ACITVITY_UI_REWARD_INFO";
	}

	public com.imop.lj.gameserver.activityui.ActivityUIRewardInfo[] getActivityUIRewardInfoList(){
		return activityUIRewardInfoList;
	}

	public void setActivityUIRewardInfoList(com.imop.lj.gameserver.activityui.ActivityUIRewardInfo[] activityUIRewardInfoList){
		this.activityUIRewardInfoList = activityUIRewardInfoList;
	}	
}