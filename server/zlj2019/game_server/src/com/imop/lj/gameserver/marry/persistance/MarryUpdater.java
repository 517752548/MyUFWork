package com.imop.lj.gameserver.marry.persistance;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.marry.Marry;

public class MarryUpdater implements POUpdater {
	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		final Marry task = (Marry)obj;
		MarryDbManager.getInstance().delTaskEntity(task, true);
	}

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final Marry task = (Marry)obj;
		MarryDbManager.getInstance().saveTaskEntity(task, true);
	}
}
