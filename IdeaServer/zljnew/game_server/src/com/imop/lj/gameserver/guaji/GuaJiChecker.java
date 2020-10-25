package com.imop.lj.gameserver.guaji;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;

/**
 * 玩家开启挂机时,驱动遇怪
 *
 */
public class GuaJiChecker implements HeartbeatTask {
	/**1秒钟 */
	private static final long CHECK_EXPIRED_SPAN = 1 * TimeUtils.SECOND;
	private boolean isCanceled;
	
	private GuaJiManager guaJiManager;

	public GuaJiChecker(GuaJiManager guaJiManager) {
		this.guaJiManager = guaJiManager;
		this.isCanceled = false;
	}

	@Override
	public void run() {
		if (isCanceled) {
			return;
		}
		
		this.guaJiManager.checkTimeout();
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
