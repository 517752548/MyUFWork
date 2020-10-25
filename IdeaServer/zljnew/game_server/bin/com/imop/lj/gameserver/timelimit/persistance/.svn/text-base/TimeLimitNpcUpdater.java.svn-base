package com.imop.lj.gameserver.timelimit.persistance;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.timelimit.npc.TimeLimitNpc;

public class TimeLimitNpcUpdater implements POUpdater {
	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		final TimeLimitNpc task = (TimeLimitNpc)obj;
		TimeLimitNpcDbManager.getInstance().delTaskEntity(task, true);
	}

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final TimeLimitNpc task = (TimeLimitNpc)obj;
		TimeLimitNpcDbManager.getInstance().saveTaskEntity(task, true);
	}
}
