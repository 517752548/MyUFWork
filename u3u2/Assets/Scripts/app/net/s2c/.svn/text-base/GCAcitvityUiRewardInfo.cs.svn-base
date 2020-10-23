
using System;
namespace app.net
{
/**
 * 返回rewardInfoList
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCAcitvityUiRewardInfo :BaseMessage
{
	/** 返回可以获得的奖励的信息 */
	private ActivityUIRewardInfo[] activityUIRewardInfoList;

	public GCAcitvityUiRewardInfo ()
	{
	}

	protected override void ReadImpl()
	{

	// 返回可以获得的奖励的信息
	int activityUIRewardInfoListSize = ReadShort();
	ActivityUIRewardInfo[] _activityUIRewardInfoList = new ActivityUIRewardInfo[activityUIRewardInfoListSize];
	int activityUIRewardInfoListIndex = 0;
	ActivityUIRewardInfo _activityUIRewardInfoListTmp = null;
	for(activityUIRewardInfoListIndex=0; activityUIRewardInfoListIndex<activityUIRewardInfoListSize; activityUIRewardInfoListIndex++){
		_activityUIRewardInfoListTmp = new ActivityUIRewardInfo();
		_activityUIRewardInfoList[activityUIRewardInfoListIndex] = _activityUIRewardInfoListTmp;
	// 活跃度
	int _activityUIRewardInfoList_vitalityNum = ReadInt();	_activityUIRewardInfoListTmp.vitalityNum = _activityUIRewardInfoList_vitalityNum;
		// 奖励
	RewardInfoData _activityUIRewardInfoList_rewardInfo = new RewardInfoData();
	// 奖励信息
	string _activityUIRewardInfoList_rewardInfo_rewardStr = ReadString();	_activityUIRewardInfoList_rewardInfo.rewardStr = _activityUIRewardInfoList_rewardInfo_rewardStr;
	_activityUIRewardInfoListTmp.rewardInfo = _activityUIRewardInfoList_rewardInfo;
		}
	//end



		this.activityUIRewardInfoList = _activityUIRewardInfoList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_ACITVITY_UI_REWARD_INFO;
	}
	
	public override string getEventType()
	{
		return ActivityuiGCHandler.GCAcitvityUiRewardInfoEvent;
	}
	

	public ActivityUIRewardInfo[] getActivityUIRewardInfoList(){
		return activityUIRewardInfoList;
	}


}
}