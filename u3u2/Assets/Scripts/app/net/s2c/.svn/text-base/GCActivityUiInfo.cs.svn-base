
using System;
namespace app.net
{
/**
 * 返回活动UI面板信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCActivityUiInfo :BaseMessage
{
	/** 返回活动UI面板信息 */
	private ActivityUIInfo[] activityList;
	/** 奖励的领取情况 */
	private int[] rewardGainList;
	/** 当前总活跃值 */
	private int totalActivityVitality;

	public GCActivityUiInfo ()
	{
	}

	protected override void ReadImpl()
	{

	// 返回活动UI面板信息
	int activityListSize = ReadShort();
	ActivityUIInfo[] _activityList = new ActivityUIInfo[activityListSize];
	int activityListIndex = 0;
	ActivityUIInfo _activityListTmp = null;
	for(activityListIndex=0; activityListIndex<activityListSize; activityListIndex++){
		_activityListTmp = new ActivityUIInfo();
		_activityList[activityListIndex] = _activityListTmp;
	// 活动id
	int _activityList_activityId = ReadInt();	_activityListTmp.activityId = _activityList_activityId;
		// 活动类型
	int _activityList_activityType = ReadInt();	_activityListTmp.activityType = _activityList_activityType;
		// 当前活动次数
	int _activityList_activityTimes = ReadInt();	_activityListTmp.activityTimes = _activityList_activityTimes;
		// 特殊类型(0普通,1推荐,2节日)
	int _activityList_specialType = ReadInt();	_activityListTmp.specialType = _activityList_specialType;
		// 完成情况 0未完成,1已完成
	int _activityList_finishStatue = ReadInt();	_activityListTmp.finishStatue = _activityList_finishStatue;
		// 奖励
	RewardInfoData _activityList_rewardInfo = new RewardInfoData();
	// 奖励信息
	string _activityList_rewardInfo_rewardStr = ReadString();	_activityList_rewardInfo.rewardStr = _activityList_rewardInfo_rewardStr;
	_activityListTmp.rewardInfo = _activityList_rewardInfo;
		// 限时活动倒计时,毫秒
	long _activityList_cd = ReadLong();	_activityListTmp.cd = _activityList_cd;
		}
	//end

	// 奖励的领取情况
	int rewardGainListSize = ReadShort();
	int[] _rewardGainList = new int[rewardGainListSize];
	int rewardGainListIndex = 0;
	for(rewardGainListIndex=0; rewardGainListIndex<rewardGainListSize; rewardGainListIndex++){
		_rewardGainList[rewardGainListIndex] = ReadInt();
	}//end
	
	// 当前总活跃值
	int _totalActivityVitality = ReadInt();


		this.activityList = _activityList;
		this.rewardGainList = _rewardGainList;
		this.totalActivityVitality = _totalActivityVitality;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_ACTIVITY_UI_INFO;
	}
	
	public override string getEventType()
	{
		return ActivityuiGCHandler.GCActivityUiInfoEvent;
	}
	

	public ActivityUIInfo[] getActivityList(){
		return activityList;
	}


	public int[] getRewardGainList(){
		return rewardGainList;
	}


	public int getTotalActivityVitality(){
		return totalActivityVitality;
	}
		

}
}