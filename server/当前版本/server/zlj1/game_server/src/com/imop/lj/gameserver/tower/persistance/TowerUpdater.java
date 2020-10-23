package com.imop.lj.gameserver.tower.persistance;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.tower.Tower;

public class TowerUpdater implements POUpdater {
	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		final Tower task = (Tower)obj;
		TowerDbManager.getInstance().delEntity(task, true);
	}

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final Tower task = (Tower)obj;
		TowerDbManager.getInstance().saveEntity(task, true);
	}
}
