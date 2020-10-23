package com.imop.lj.gameserver.wizardraid;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;

public class WizardRaidTeamChecker implements HeartbeatTask {

	private static final long CHECK_EXPIRED_SPAN = TimeUtils.SECOND;
	private boolean isCanceled;

	
	public WizardRaidTeamChecker() {
		this.isCanceled = false;
	}

	@Override
	public void run() {
		if (isCanceled) {
			return;
		}
		
		Globals.getWizardRaidService().checkTeamRaidHeartbeat();
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
