package com.imop.lj.gameserver.map;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;

/**
 * 用于检测超时消失
 * 目前用于 野外封妖和混世魔王
 *
 */
public class SealDemonAndDevilChecker implements HeartbeatTask {
	/** 检查的时间间隔，1分钟 */
	private static final long CHECK_EXPIRED_SPAN = 1 * TimeUtils.MIN;
	private boolean isCanceled;
	
	public SealDemonAndDevilChecker() {
		
	}

	@Override
	public void run() {
		if (isCanceled) {
			return;
		}
		Globals.getSealDemonService().checkNpcTimeOut();
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
