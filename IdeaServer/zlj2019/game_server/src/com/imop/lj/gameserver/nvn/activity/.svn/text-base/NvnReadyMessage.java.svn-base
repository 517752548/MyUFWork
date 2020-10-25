package com.imop.lj.gameserver.nvn.activity;

import com.imop.lj.gameserver.activity.ActivityService;
import com.imop.lj.gameserver.activity.function.AbstractActivityMessage;
import com.imop.lj.gameserver.activity.function.ActivityDef.ActivityState;
import com.imop.lj.gameserver.activity.template.ActivityTemplate;
import com.imop.lj.gameserver.common.Globals;

public class NvnReadyMessage extends AbstractActivityMessage {
	
	private ActivityTemplate template;
	
	public NvnReadyMessage(ActivityTemplate template){
		this.template = template;
	}

	@Override
	public void execute() {
		if(!isCanExecute()) {
			return;
		}
		int activityId = template.getId();
		ActivityService activityService = Globals.getActivityService();
		if(activityService.setActivityState(activityId, ActivityState.READY)) {
			// 准备阶段的处理
			Globals.getNvnService().handleActivityReadyMsg(activityService.getActivity(activityId));
		}
	}

	@Override
	public boolean isCanExecute() {
		// 如果活动是关闭状态，则直接返回
		ActivityState activityState = Globals.getActivityService().getActivity(template.getId()).getState();
		if (activityState == ActivityState.CLOSE) {
			return false;
		}
		//周几限制是否满足条件
		if (!this.template.isWeekLimitOK()) {
			return false;
		}
		return true;
	}
}
