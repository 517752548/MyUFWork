package com.imop.lj.gameserver.xianhu;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;

public class XianhuCurRankChecker implements HeartbeatTask {

	private static final long CHECK_EXPIRED_SPAN = 30 * TimeUtils.MIN;
	private boolean isCanceled;

	
	public XianhuCurRankChecker() {
		this.isCanceled = false;
	}

	@Override
	public void run() {
		if (isCanceled) {
			return;
		}
		
		Globals.getXianhuService().refreshCurRank(false);
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
