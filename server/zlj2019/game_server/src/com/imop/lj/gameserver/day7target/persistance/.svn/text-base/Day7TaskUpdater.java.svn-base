package com.imop.lj.gameserver.day7target.persistance;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.day7target.Day7Task;

public class Day7TaskUpdater implements POUpdater {
	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		final Day7Task task = (Day7Task)obj;
		Day7TaskDbManager.getInstance().delTaskEntity(task, true);
	}

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final Day7Task task = (Day7Task)obj;
		Day7TaskDbManager.getInstance().saveTaskEntity(task, true);
	}
}
