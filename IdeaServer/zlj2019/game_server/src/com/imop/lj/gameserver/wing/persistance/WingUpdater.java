package com.imop.lj.gameserver.wing.persistance;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.wing.Wing;

public class WingUpdater implements POUpdater {
	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		final Wing task = (Wing)obj;
		WingDbManager.getInstance().delEntity(task, true);
	}

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final Wing task = (Wing)obj;
		WingDbManager.getInstance().saveEntity(task, true);
	}
}
