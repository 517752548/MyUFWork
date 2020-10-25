package com.imop.lj.gameserver.corps;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;

public class UpgradeCorpsChecker implements HeartbeatTask {

	/** 检查的时间间隔，1秒 */
	private static final long CHECK_UPGRADE_CORPS_SPAN = TimeUtils.SECOND;
	private boolean isCanceled = false;
	

	public UpgradeCorpsChecker() {
		
	}

	@Override
	public void run() {
		if (isCanceled) {
			return;
		}
		Globals.getCorpsService().upgradeCorpsChecker();
	}

	@Override
	public long getRunTimeSpan() {
		return CHECK_UPGRADE_CORPS_SPAN;
	}

	@Override
	public void cancel() {
		isCanceled = true;
	}

}
