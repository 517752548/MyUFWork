package com.imop.lj.gameserver.trade;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;

public class OverDueTradeChecker implements HeartbeatTask {

	/** 检查的时间间隔，600秒 */
	private static final long CHECK_OVER_DUE_SPAN = 600 * TimeUtils.SECOND;
	private boolean isCanceled = false;
	

	public OverDueTradeChecker() {
		
	}

	@Override
	public void run() {
		if (isCanceled) {
			return;
		}
		Globals.getTradeService().overDueTest();
	}

	@Override
	public long getRunTimeSpan() {
		return CHECK_OVER_DUE_SPAN;
	}

	@Override
	public void cancel() {
		isCanceled = true;
	}

}
