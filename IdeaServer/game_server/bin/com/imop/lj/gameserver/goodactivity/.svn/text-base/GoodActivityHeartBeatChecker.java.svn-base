package com.imop.lj.gameserver.goodactivity;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;

/**
 * 用于定时检测活动开始、关闭及周期奖励结算
 *
 */
public class GoodActivityHeartBeatChecker implements HeartbeatTask {
	/** 检查的时间间隔，30秒 */
	private static long CHECK_EXPIRED_SPAN = 30 * TimeUtils.SECOND;
	private boolean isCanceled;
	
	public GoodActivityHeartBeatChecker() {
		
	}

	@Override
	public void run() {
		if (isCanceled) {
			return;
		}
		Globals.getGoodActivityService().checkActivity();
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
