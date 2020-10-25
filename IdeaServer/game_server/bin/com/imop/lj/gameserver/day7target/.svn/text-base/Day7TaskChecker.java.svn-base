package com.imop.lj.gameserver.day7target;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;
import com.imop.lj.gameserver.human.Human;

public class Day7TaskChecker implements HeartbeatTask {

	private static final long CHECK_EXPIRED_SPAN = 2 * TimeUtils.MIN;
	private boolean isCanceled;

	private Human human;
	
	public Day7TaskChecker(Human human) {
		this.isCanceled = false;
		this.human = human;
	}

	@Override
	public void run() {
		if (isCanceled) {
			return;
		}
		
		Globals.getDay7TargetService().acceptTaskNextDay(human);
	}

	@Override
	public long getRunTimeSpan() {
		return CHECK_EXPIRED_SPAN;
	}

	@Override
	public void cancel() {
		isCanceled = true;
	}
}
