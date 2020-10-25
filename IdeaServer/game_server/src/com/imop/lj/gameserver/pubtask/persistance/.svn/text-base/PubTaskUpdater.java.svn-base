package com.imop.lj.gameserver.pubtask.persistance;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.pubtask.PubTask;

public class PubTaskUpdater implements POUpdater {
	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		final PubTask task = (PubTask)obj;
		PubTaskDbManager.getInstance().delTaskEntity(task, true);
	}

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final PubTask task = (PubTask)obj;
		PubTaskDbManager.getInstance().saveTaskEntity(task, true);
	}
}
