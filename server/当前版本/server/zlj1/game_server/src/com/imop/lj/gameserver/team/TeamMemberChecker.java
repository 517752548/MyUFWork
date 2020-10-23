package com.imop.lj.gameserver.team;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;
import com.imop.lj.gameserver.human.HumanCacheService;

/**
 * 用于检测组队队员情况情况
 *
 */
public class TeamMemberChecker implements HeartbeatTask {
	/** 检查的时间间隔，60秒 */
	private static final long CHECK_EXPIRED_SPAN = 60 * TimeUtils.SECOND;
	private boolean isCanceled;
	
	public TeamMemberChecker() {
		
	}

	@Override
	public void run() {
		if (isCanceled) {
			return;
		}
		
		if (HumanCacheService.isOpen()) {
			Globals.getHumanCacheService().checkDel();
		} else {
			Globals.getTeamService().checkTeamMemberAway();
		}
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
