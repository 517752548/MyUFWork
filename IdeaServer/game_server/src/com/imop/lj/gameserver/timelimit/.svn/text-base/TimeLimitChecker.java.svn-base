package com.imop.lj.gameserver.timelimit;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;

/**
 * 用于推送玩家的限时活动是否超时，并做相应处理
 *
 */
public class TimeLimitChecker implements HeartbeatTask {
	/** 检查道具是否过期的时间间隔，1分钟 */
	private static final long CHECK_EXPIRED_SPAN = 1 * TimeUtils.MIN;
	private boolean isCanceled;
	
	private TimeLimitManager timeLimitManager;

	public TimeLimitChecker(TimeLimitManager timeLimitManager) {
		this.timeLimitManager = timeLimitManager;
		this.isCanceled = false;
	}

	@Override
	public void run() {
		if (isCanceled) {
			return;
		}
		timeLimitManager.checkTimeout();
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
