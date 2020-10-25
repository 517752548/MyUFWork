package com.imop.lj.gameserver.wizardraid;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;
import com.imop.lj.gameserver.human.Human;

public class WizardRaidSingleChecker implements HeartbeatTask {

	private static final long CHECK_EXPIRED_SPAN = TimeUtils.SECOND;
	private boolean isCanceled;

	private Human human;
	
	public WizardRaidSingleChecker(Human human) {
		this.isCanceled = false;
		this.human = human;
	}

	@Override
	public void run() {
		if (isCanceled) {
			return;
		}
		
		Globals.getWizardRaidService().checkSingleRaidHeartbeat(human);
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
