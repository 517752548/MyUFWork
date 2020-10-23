package com.imop.lj.gameserver.corps;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;

public class ClearCorpsWeekContributionChecker implements HeartbeatTask {

	/** 检查的时间间隔，1天 */
	private static final long CHECK_CLEAR_CORPS_WEEK_CONTRIBUTION_SPAN = TimeUtils.DAY;
	private boolean isCanceled = false;
	

	public ClearCorpsWeekContributionChecker() {
		
	}

	@Override
	public void run() {
		if (isCanceled) {
			return;
		}
		Globals.getCorpsService().clearCorpsWeekContributionChecker();
	}

	@Override
	public long getRunTimeSpan() {
		return CHECK_CLEAR_CORPS_WEEK_CONTRIBUTION_SPAN;
	}

	@Override
	public void cancel() {
		isCanceled = true;
	}

}
