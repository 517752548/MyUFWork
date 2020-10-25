package com.imop.lj.gameserver.corps;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;

/**
 * 用于检测弹劾
 *
 */
public class ImpeachPresidentChecker implements HeartbeatTask {
	/** 检查的时间间隔，2小时 */
	private static final long CHECK_EXPIRED_SPAN = 2 * TimeUtils.HOUR;
	private boolean isCanceled;
	
	public ImpeachPresidentChecker() {
		
	}

	@Override
	public void run() {
		if (isCanceled) {
			return;
		}
		Globals.getCorpsService().checkImpeachPresident();
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
