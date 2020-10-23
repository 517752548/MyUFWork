package com.imop.lj.gameserver.func.allfunc;

import java.util.Map;

import com.imop.lj.gameserver.activity.Activity;
import com.imop.lj.gameserver.activity.function.ActivityDef.ActivityState;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.AbstractFunc;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;

public class ActivityFunc extends AbstractFunc {

	public ActivityFunc(Human human, FuncTypeEnum funcType) {
		super(human, funcType);
	}
	
	@Override
	public boolean canOpen() {
		// 判断玩家是否有此功能
		return Globals.getFuncService().hasOpenedFunc(getOwner(), getFuncType());
	}

	@Override
	public boolean canShowEffect() {
		// 需要遍历活动，根据每个活动的状态，看是否需要特效，每个活动可能还需要根据玩家当前的状态来确定
		Map<Integer, Activity> allActivityMap = Globals.getActivityService().getAllActivity();
		for (Activity activity : allActivityMap.values()) {
			if (activity.getState() != ActivityState.READY && activity.getState() != ActivityState.OPENING) {
				// 非准备阶段、开始阶段的活动，不显示特效，直接跳过
				continue;
			}
//			
//			ActivityType activityType = ActivityType.valueOf(activity.getTemplate().getActivityFunctionTemplate().getActivtyType());
//			// TODO 调用不同模块的接口，可能需要传入玩家，返回是否需要显示特效，如果其中任意功能有特效了，则直接返回true，不用再循环了
//			switch (activityType) {
//			case CORPS_WAR:
//				// TODO 暂时先随便写下，回头需要和策划对一下 XXX
//				if (activity.getState() == ActivityState.READY) {
//					return true;
//				}
//				break;
//			case BOSSWAR_WORLD:
//				// TODO
//				
//				return true;
//
//			default:
//				break;
//			}
		}
		
		return false;
	}

	@Override
	public int getShowNum() {
		// 不显示数字角标
		return 0;
	}

	@Override
	public long getCountDownTime() {
		// 没有倒计时
		return 0;
	}

}
