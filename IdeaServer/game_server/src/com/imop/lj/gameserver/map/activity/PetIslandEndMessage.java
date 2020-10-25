package com.imop.lj.gameserver.map.activity;

import com.imop.lj.gameserver.activity.ActivityService;
import com.imop.lj.gameserver.activity.function.AbstractActivityMessage;
import com.imop.lj.gameserver.activity.function.ActivityDef.ActivityState;
import com.imop.lj.gameserver.activity.template.ActivityTemplate;
import com.imop.lj.gameserver.common.Globals;

public class PetIslandEndMessage extends AbstractActivityMessage {
	
	private ActivityTemplate template;
	
	public PetIslandEndMessage(ActivityTemplate template){
		this.template = template;
	}

	@Override
	public void execute() {
		if(!isCanExecute()) {
			return;
		}
		int activityId = template.getId();
		ActivityService activityService = Globals.getActivityService();
		if(activityService.setActivityState(activityId, ActivityState.FINISHED)) {
			// 结束阶段的处理
			Globals.getPetIslandService().handleActivityEndMsg();
		}
	}

	@Override
	public boolean isCanExecute() {
		ActivityState activityState = Globals.getActivityService().getActivity(template.getId()).getState();
		// 如果活动不是开始状态，则直接返回
		if (activityState != ActivityState.OPENING) {
			return false;
		}
		//周几限制是否满足条件
		if (!this.template.isWeekLimitOK()) {
			return false;
		}
		return true;
	}
}
