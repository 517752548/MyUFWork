package com.imop.lj.gameserver.lifeskill;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;

/**
 * 玩家采集资源,检测是否满足条件
 *
 */
public class LifeSkillChecker implements HeartbeatTask {
	/**2秒钟 */
	private static final long CHECK_EXPIRED_SPAN = 2 * TimeUtils.SECOND;
	private boolean isCanceled;
	
	private LifeSkillManager lifeSkillManager;

	public LifeSkillChecker(LifeSkillManager lifeSkillManager) {
		this.lifeSkillManager = lifeSkillManager;
		this.isCanceled = false;
	}

	@Override
	public void run() {
		if (isCanceled) {
			return;
		}
		
		this.lifeSkillManager.checkTimeout();
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
