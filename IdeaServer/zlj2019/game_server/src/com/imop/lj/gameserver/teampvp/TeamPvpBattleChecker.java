package com.imop.lj.gameserver.teampvp;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;

/**
 * 用于检测组队pvp战斗
 *
 */
public class TeamPvpBattleChecker implements HeartbeatTask {
	/** 检查的时间间隔，1秒 */
	private static final long CHECK_EXPIRED_SPAN = TimeUtils.SECOND;
	private boolean isCanceled;
	
	public TeamPvpBattleChecker() {
		
	}

	@Override
	public void run() {
		if (isCanceled) {
			return;
		}
		Globals.getTeamPvpService().checkBattleOvertime();
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
