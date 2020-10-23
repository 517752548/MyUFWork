package com.imop.lj.gameserver.map;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;

/**
 * 用于检测是否到刷怪时间了
 *
 */
public class PetIslandChecker implements HeartbeatTask {
	/** 检查的时间间隔，10秒 */
	private static final long CHECK_EXPIRED_SPAN = 10 * TimeUtils.SECOND;
	private boolean isCanceled;
	
	public PetIslandChecker() {
		
	}

	@Override
	public void run() {
		if (isCanceled) {
			return;
		}
		Globals.getPetIslandService().checkRefresh();
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
