package com.imop.lj.gameserver.activityui.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回活动UI面板信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCActivityUiInfo extends GCMessage{
	
	/** 返回活动UI面板信息 */
	private com.imop.lj.gameserver.activityui.ActivityUIInfo[] activityList;
	/** 奖励的领取情况 */
	private int[] rewardGainList;
	/** 当前总活跃值 */
	private int totalActivityVitality;

	public GCActivityUiInfo (){
	}
	
	public GCActivityUiInfo (
			com.imop.lj.gameserver.activityui.ActivityUIInfo[] activityList,
			int[] rewardGainList,
			int totalActivityVitality ){
			this.activityList = activityList;
			this.rewardGainList = rewardGainList;
			this.totalActivityVitality = totalActivityVitality;
	}

	@Override
	protected boolean readImpl() {

	// 返回活动UI面板信息
	int activityListSize = readUnsignedShort();
	com.imop.lj.gameserver.activityui.ActivityUIInfo[] _activityList = new com.imop.lj.gameserver.activityui.ActivityUIInfo[activityListSize];
	int activityListIndex = 0;
	for(activityListIndex=0; activityListIndex<activityListSize; activityListIndex++){
		_activityList[activityListIndex] = new com.imop.lj.gameserver.activityui.ActivityUIInfo();
	// 活动id
	int _activityList_activityId = readInteger();
	//end
	_activityList[activityListIndex].setActivityId (_activityList_activityId);

	// 活动类型
	int _activityList_activityType = readInteger();
	//end
	_activityList[activityListIndex].setActivityType (_activityList_activityType);

	// 当前活动次数
	int _activityList_activityTimes = readInteger();
	//end
	_activityList[activityListIndex].setActivityTimes (_activityList_activityTimes);

	// 特殊类型(0普通,1推荐,2节日)
	int _activityList_specialType = readInteger();
	//end
	_activityList[activityListIndex].setSpecialType (_activityList_specialType);

	// 完成情况 0未完成,1已完成
	int _activityList_finishStatue = readInteger();
	//end
	_activityList[activityListIndex].setFinishStatue (_activityList_finishStatue);
	// 奖励
	com.imop.lj.common.model.reward.RewardInfo _activityList_rewardInfo = new com.imop.lj.common.model.reward.RewardInfo();

	// 奖励信息
	String _activityList_rewardInfo_rewardStr = readString();
	//end
	_activityList_rewardInfo.setRewardStr (_activityList_rewardInfo_rewardStr);
	_activityList[activityListIndex].setRewardInfo (_activityList_rewardInfo);

	// 限时活动倒计时,毫秒
	long _activityList_cd = readLong();
	//end
	_activityList[activityListIndex].setCd (_activityList_cd);
	}
	//end


	// 奖励的领取情况
	int rewardGainListSize = readUnsignedShort();
	int[] _rewardGainList = new int[rewardGainListSize];
	int rewardGainListIndex = 0;
	for(rewardGainListIndex=0; rewardGainListIndex<rewardGainListSize; rewardGainListIndex++){
		_rewardGainList[rewardGainListIndex] = readInteger();
	}//end


	// 当前总活跃值
	int _totalActivityVitality = readInteger();
	//end



		this.activityList = _activityList;
		this.rewardGainList = _rewardGainList;
		this.totalActivityVitality = _totalActivityVitality;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 返回活动UI面板信息
	writeShort(activityList.length);
	int activityListIndex = 0;
	int activityListSize = activityList.length;
	for(activityListIndex=0; activityListIndex<activityListSize; activityListIndex++){

	int activityList_activityId = activityList[activityListIndex].getActivityId();

	// 活动id
	writeInteger(activityList_activityId);

	int activityList_activityType = activityList[activityListIndex].getActivityType();

	// 活动类型
	writeInteger(activityList_activityType);

	int activityList_activityTimes = activityList[activityListIndex].getActivityTimes();

	// 当前活动次数
	writeInteger(activityList_activityTimes);

	int activityList_specialType = activityList[activityListIndex].getSpecialType();

	// 特殊类型(0普通,1推荐,2节日)
	writeInteger(activityList_specialType);

	int activityList_finishStatue = activityList[activityListIndex].getFinishStatue();

	// 完成情况 0未完成,1已完成
	writeInteger(activityList_finishStatue);

	com.imop.lj.common.model.reward.RewardInfo activityList_rewardInfo = activityList[activityListIndex].getRewardInfo();

	String activityList_rewardInfo_rewardStr = activityList_rewardInfo.getRewardStr ();

	// 奖励信息
	writeString(activityList_rewardInfo_rewardStr);

	long activityList_cd = activityList[activityListIndex].getCd();

	// 限时活动倒计时,毫秒
	writeLong(activityList_cd);
	}
	//end


	// 奖励的领取情况
	writeShort(rewardGainList.length);
	int rewardGainListSize = rewardGainList.length;
	int rewardGainListIndex = 0;
	for(rewardGainListIndex=0; rewardGainListIndex<rewardGainListSize; rewardGainListIndex++){
		writeInteger(rewardGainList [ rewardGainListIndex ]);
	}//end


	// 当前总活跃值
	writeInteger(totalActivityVitality);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_ACTIVITY_UI_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "GC_ACTIVITY_UI_INFO";
	}

	public com.imop.lj.gameserver.activityui.ActivityUIInfo[] getActivityList(){
		return activityList;
	}

	public void setActivityList(com.imop.lj.gameserver.activityui.ActivityUIInfo[] activityList){
		this.activityList = activityList;
	}	

	public int[] getRewardGainList(){
		return rewardGainList;
	}

	public void setRewardGainList(int[] rewardGainList){
		this.rewardGainList = rewardGainList;
	}	

	public int getTotalActivityVitality(){
		return totalActivityVitality;
	}
		
	public void setTotalActivityVitality(int totalActivityVitality){
		this.totalActivityVitality = totalActivityVitality;
	}
}