package com.imop.lj.gameserver.siegedemontask.persistance;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.siegedemontask.SiegeDemonTask;

public class SiegeDemonTaskUpdater implements POUpdater {
	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		final SiegeDemonTask task = (SiegeDemonTask)obj;
		SiegeDemonTaskDbManager.getInstance().delTaskEntity(task, true);
	}

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final SiegeDemonTask task = (SiegeDemonTask)obj;
		SiegeDemonTaskDbManager.getInstance().saveTaskEntity(task, true);
	}
}
