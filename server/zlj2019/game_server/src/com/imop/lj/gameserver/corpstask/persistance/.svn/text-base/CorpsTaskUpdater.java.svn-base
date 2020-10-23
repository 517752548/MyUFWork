package com.imop.lj.gameserver.corpstask.persistance;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.corpstask.CorpsTask;

public class CorpsTaskUpdater implements POUpdater {
	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		final CorpsTask task = (CorpsTask)obj;
		CorpsTaskDbManager.getInstance().delTaskEntity(task, true);
	}

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final CorpsTask task = (CorpsTask)obj;
		CorpsTaskDbManager.getInstance().saveTaskEntity(task, true);
	}
}
