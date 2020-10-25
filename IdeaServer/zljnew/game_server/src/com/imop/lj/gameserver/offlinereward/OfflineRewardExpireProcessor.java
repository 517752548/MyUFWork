package com.imop.lj.gameserver.offlinereward;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;

/**
 * 用于扫描奖励是否过期，并做相应处理
 *
 */
public class OfflineRewardExpireProcessor implements HeartbeatTask {
	/** 检查道具是否过期的时间间隔，30分钟 */
	private static final long CHECK_EXPIRED_SPAN = 30 * TimeUtils.MIN;
	private boolean isCanceled;
	
	private OfflineRewardManager offlineRewardManager;

	public OfflineRewardExpireProcessor(OfflineRewardManager offlineRewardManager) {
		this.offlineRewardManager = offlineRewardManager;
		this.isCanceled = false;
	}

	@Override
	public void run() {
		if (isCanceled) {
			return;
		}
		offlineRewardManager.checkExpiredReward();
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
