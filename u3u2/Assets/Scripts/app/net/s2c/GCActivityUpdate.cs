
using System;
namespace app.net
{
/**
 * 活动状态更新
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCActivityUpdate :BaseMessage
{
	/** 活动开始 */
	private ActivityInfoData activityList;

	public GCActivityUpdate ()
	{
	}

	protected override void ReadImpl()
	{
	// 活动开始
	ActivityInfoData _activityList = new ActivityInfoData();
	// 活动id
	int _activityList_activityId = ReadInt();	_activityList.activityId = _activityList_activityId;
	// 活动名称
	string _activityList_name = ReadString();	_activityList.name = _activityList_name;
	// 活动时间描述
	string _activityList_timeDesc = ReadString();	_activityList.timeDesc = _activityList_timeDesc;
	// 活动描述
	string _activityList_desc = ReadString();	_activityList.desc = _activityList_desc;
	// 活动图标
	int _activityList_icon = ReadInt();	_activityList.icon = _activityList_icon;
	// 0活动未开启,1活动准备阶段 ,2活动开始阶段,3活动结束 ,4活动关闭
	int _activityList_state = ReadInt();	_activityList.state = _activityList_state;
	// 0非vip,1是vip
	int _activityList_isVip = ReadInt();	_activityList.isVip = _activityList_isVip;



		this.activityList = _activityList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_ACTIVITY_UPDATE;
	}
	
	public override string getEventType()
	{
		return ActivityGCHandler.GCActivityUpdateEvent;
	}
	

	public ActivityInfoData getActivityList(){
		return activityList;
	}
		

}
}