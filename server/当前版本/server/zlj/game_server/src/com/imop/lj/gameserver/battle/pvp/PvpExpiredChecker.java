package com.imop.lj.gameserver.battle.pvp;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;

/**
 * 用于检测Pvp战斗是否过期
 *
 */
public class PvpExpiredChecker implements HeartbeatTask {
	/** 检查的时间间隔，1秒 */
	private static final long CHECK_EXPIRED_SPAN = TimeUtils.SECOND;
	private boolean isCanceled;
	
	public PvpExpiredChecker() {
		
	}

	@Override
	public void run() {
		if (isCanceled) {
			return;
		}
		Globals.getPvpService().checkBattleOvertime();
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
