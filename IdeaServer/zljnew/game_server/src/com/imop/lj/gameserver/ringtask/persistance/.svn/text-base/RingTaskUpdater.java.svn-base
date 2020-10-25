package com.imop.lj.gameserver.ringtask.persistance;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.ringtask.RingTask;

public class RingTaskUpdater implements POUpdater {
	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		final RingTask task = (RingTask)obj;
		RingTaskDbManager.getInstance().delTaskEntity(task, true);
	}

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final RingTask task = (RingTask)obj;
		RingTaskDbManager.getInstance().saveTaskEntity(task, true);
	}
}
