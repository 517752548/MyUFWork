package com.imop.lj.gameserver.pet;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;
import com.imop.lj.gameserver.human.Human;

/**
 * 用于检测玩家体验骑宠是否过期
 *
 */
public class PetHorseExpiredProcessor implements HeartbeatTask {
	/** 检查的时间间隔，10分钟 */
	private static final long CHECK_EXPIRED_SPAN = 10 * TimeUtils.MIN;
	private boolean isCanceled;
	
	private Human owner;
	
	public PetHorseExpiredProcessor(Human owner) {
		this.owner = owner;
	}

	@Override
	public void run() {
		if (isCanceled) {
			return;
		}
		
		Globals.getPetService().checkPetHorseExpired(owner);
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
