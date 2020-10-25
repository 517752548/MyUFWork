package com.imop.lj.gameserver.broadcast;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;

/**
 * 用于定时检测发送全局广播
 *
 */
public class BroadcastHeartBeatChecker implements HeartbeatTask {
	/** 检查的时间间隔，1秒 */
	private static long CHECK_EXPIRED_SPAN = 1 * TimeUtils.SECOND;
	private boolean isCanceled;
	
	public BroadcastHeartBeatChecker() {
		
	}

	@Override
	public void run() {
		if (isCanceled) {
			return;
		}
		Globals.getBroadcastService().checkWorldBroadcast();
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
