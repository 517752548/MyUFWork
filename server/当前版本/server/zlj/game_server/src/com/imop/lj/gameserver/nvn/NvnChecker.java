package com.imop.lj.gameserver.nvn;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;

public class NvnChecker implements HeartbeatTask {
	/** 2分钟检测一次战斗 */
	private static final long CHECK_EXPIRED_SPAN = 120 * TimeUtils.SECOND;
	private boolean isCanceled;

	
	public NvnChecker() {
		this.isCanceled = false;
	}

	@Override
	public void run() {
		if (isCanceled) {
			return;
		}
		
		Globals.getNvnService().checkNvn();
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
