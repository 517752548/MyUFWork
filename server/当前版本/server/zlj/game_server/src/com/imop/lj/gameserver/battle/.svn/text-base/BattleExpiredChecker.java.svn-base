package com.imop.lj.gameserver.battle;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;

/**
 * 用于检测战斗是否过期
 *
 */
public class BattleExpiredChecker implements HeartbeatTask {
	/** 检查的时间间隔，60秒 */
	private static final long CHECK_EXPIRED_SPAN = 60 * TimeUtils.SECOND;
	private boolean isCanceled;
	
	public BattleExpiredChecker() {
		
	}

	@Override
	public void run() {
		if (isCanceled) {
			return;
		}
		Globals.getBattleService().checkBattleOvertime();
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
