package com.imop.lj.gameserver.activity;

import java.util.Calendar;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.activity.function.ActivityDef.ActivityState;
import com.imop.lj.gameserver.activity.template.ActivityTemplate;
import com.imop.lj.gameserver.common.Globals;

public class Activity {
	
	private int activityId;
	
	private ActivityTemplate template;
	
	private ActivityState state = ActivityState.NOT_OPEN;

	public int getActivityId() {
		return activityId;
	}

	public void setActivityId(int activityId) {
		this.activityId = activityId;
	}

	public ActivityState getState() {
		return state;
	}

	public void setState(ActivityState state) {
		this.state = state;
	}

	public ActivityTemplate getTemplate() {
		return template;
	}

	public void setTemplate(ActivityTemplate template) {
		this.template = template;
	}
	
	/**
	 * 获取活动今日准备时间
	 * @return Calendar
	 */
	public long getTodayReadyTime() {
		Calendar nowCal = Calendar.getInstance();
		nowCal.setTimeInMillis(Globals.getTimeService().now());
		Calendar date = TimeUtils.mergeDateAndTime(nowCal, template.getReadyTimeCalendar());
		return date.getTimeInMillis();
	}
	
	/**
	 * 获取活动今日开始时间
	 * @return
	 */
	public long getTodayStartTime() {
		Calendar nowCal = Calendar.getInstance();
		nowCal.setTimeInMillis(Globals.getTimeService().now());
		Calendar date = TimeUtils.mergeDateAndTime(nowCal, template.getStartTimeCalendar());
		return date.getTimeInMillis();
	}
	
	/**
	 * 获取活动今日结束时间
	 * @return
	 */
	public long getTodayEndTime() {
		Calendar nowCal = Calendar.getInstance();
		nowCal.setTimeInMillis(Globals.getTimeService().now());
		Calendar date = TimeUtils.mergeDateAndTime(nowCal, template.getEndTimeCalendar());
		return date.getTimeInMillis();
	}
	
	public ActivityInfo buildActivityInfo(){
		ActivityInfo activityInfo = new ActivityInfo();
		activityInfo.setActivityId(activityId);
		activityInfo.setState(this.state.index);
		activityInfo.setDesc(this.template.getDesc());
		activityInfo.setIsVip(0);
		activityInfo.setName(this.template.getName());
		activityInfo.setTimeDesc(this.template.getTimeDesc());
		activityInfo.setIcon(this.template.getIcon());
		return activityInfo;
	}
}
