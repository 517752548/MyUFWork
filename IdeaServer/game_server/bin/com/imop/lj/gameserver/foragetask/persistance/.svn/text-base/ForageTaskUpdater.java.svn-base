package com.imop.lj.gameserver.foragetask.persistance;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.foragetask.ForageTask;

public class ForageTaskUpdater implements POUpdater {
	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		final ForageTask task = (ForageTask)obj;
		ForageTaskDbManager.getInstance().delTaskEntity(task, true);
	}

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final ForageTask task = (ForageTask)obj;
		ForageTaskDbManager.getInstance().saveTaskEntity(task, true);
	}
}
