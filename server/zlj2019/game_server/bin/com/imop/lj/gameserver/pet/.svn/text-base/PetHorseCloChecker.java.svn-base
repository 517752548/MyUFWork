package com.imop.lj.gameserver.pet;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;
import com.imop.lj.gameserver.human.Human;

public class PetHorseCloChecker implements HeartbeatTask {

	private static final long CHECK_EXPIRED_SPAN = Globals.getGameConstants().getPetHorseNotFightHour() * TimeUtils.HOUR;
	private boolean isCanceled;

	private Human owner;
	
	public PetHorseCloChecker(Human owner) {
		this.owner = owner;
		this.isCanceled = false;
	}

	@Override
	public void run() {
		if (isCanceled) {
			return;
		}
		
		Globals.getPetService().petHorseCloChecker(owner, false);
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
