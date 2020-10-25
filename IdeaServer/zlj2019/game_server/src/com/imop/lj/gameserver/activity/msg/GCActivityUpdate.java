package com.imop.lj.gameserver.activity.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 活动状态更新
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCActivityUpdate extends GCMessage{
	
	/** 活动开始 */
	private com.imop.lj.gameserver.activity.ActivityInfo activityList;

	public GCActivityUpdate (){
	}
	
	public GCActivityUpdate (
			com.imop.lj.gameserver.activity.ActivityInfo activityList ){
			this.activityList = activityList;
	}

	@Override
	protected boolean readImpl() {
	// 活动开始
	com.imop.lj.gameserver.activity.ActivityInfo _activityList = new com.imop.lj.gameserver.activity.ActivityInfo();

	// 活动id
	int _activityList_activityId = readInteger();
	//end
	_activityList.setActivityId (_activityList_activityId);

	// 活动名称
	String _activityList_name = readString();
	//end
	_activityList.setName (_activityList_name);

	// 活动时间描述
	String _activityList_timeDesc = readString();
	//end
	_activityList.setTimeDesc (_activityList_timeDesc);

	// 活动描述
	String _activityList_desc = readString();
	//end
	_activityList.setDesc (_activityList_desc);

	// 活动图标
	int _activityList_icon = readInteger();
	//end
	_activityList.setIcon (_activityList_icon);

	// 0活动未开启,1活动准备阶段 ,2活动开始阶段,3活动结束 ,4活动关闭
	int _activityList_state = readInteger();
	//end
	_activityList.setState (_activityList_state);

	// 0非vip,1是vip
	int _activityList_isVip = readInteger();
	//end
	_activityList.setIsVip (_activityList_isVip);



		this.activityList = _activityList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	int activityList_activityId = activityList.getActivityId ();

	// 活动id
	writeInteger(activityList_activityId);

	String activityList_name = activityList.getName ();

	// 活动名称
	writeString(activityList_name);

	String activityList_timeDesc = activityList.getTimeDesc ();

	// 活动时间描述
	writeString(activityList_timeDesc);

	String activityList_desc = activityList.getDesc ();

	// 活动描述
	writeString(activityList_desc);

	int activityList_icon = activityList.getIcon ();

	// 活动图标
	writeInteger(activityList_icon);

	int activityList_state = activityList.getState ();

	// 0活动未开启,1活动准备阶段 ,2活动开始阶段,3活动结束 ,4活动关闭
	writeInteger(activityList_state);

	int activityList_isVip = activityList.getIsVip ();

	// 0非vip,1是vip
	writeInteger(activityList_isVip);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_ACTIVITY_UPDATE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_ACTIVITY_UPDATE";
	}

	public com.imop.lj.gameserver.activity.ActivityInfo getActivityList(){
		return activityList;
	}
		
	public void setActivityList(com.imop.lj.gameserver.activity.ActivityInfo activityList){
		this.activityList = activityList;
	}
}