
using System;
namespace app.net
{
/**
 * 打开活动列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCActivityList :BaseMessage
{
	/** 打开活动列表 */
	private ActivityInfoData[] activityList;

	public GCActivityList ()
	{
	}

	protected override void ReadImpl()
	{

	// 打开活动列表
	int activityListSize = ReadShort();
	ActivityInfoData[] _activityList = new ActivityInfoData[activityListSize];
	int activityListIndex = 0;
	ActivityInfoData _activityListTmp = null;
	for(activityListIndex=0; activityListIndex<activityListSize; activityListIndex++){
		_activityListTmp = new ActivityInfoData();
		_activityList[activityListIndex] = _activityListTmp;
	// 活动id
	int _activityList_activityId = ReadInt();	_activityListTmp.activityId = _activityList_activityId;
		// 活动名称
	string _activityList_name = ReadString();	_activityListTmp.name = _activityList_name;
		// 活动时间描述
	string _activityList_timeDesc = ReadString();	_activityListTmp.timeDesc = _activityList_timeDesc;
		// 活动描述
	string _activityList_desc = ReadString();	_activityListTmp.desc = _activityList_desc;
		// 活动图标
	int _activityList_icon = ReadInt();	_activityListTmp.icon = _activityList_icon;
		// 0活动未开启,1活动准备阶段 ,2活动开始阶段,3活动结束 ,4活动关闭
	int _activityList_state = ReadInt();	_activityListTmp.state = _activityList_state;
		// 0非vip,1是vip
	int _activityList_isVip = ReadInt();	_activityListTmp.isVip = _activityList_isVip;
		}
	//end



		this.activityList = _activityList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_ACTIVITY_LIST;
	}
	
	public override string getEventType()
	{
		return ActivityGCHandler.GCActivityListEvent;
	}
	

	public ActivityInfoData[] getActivityList(){
		return activityList;
	}


}
}