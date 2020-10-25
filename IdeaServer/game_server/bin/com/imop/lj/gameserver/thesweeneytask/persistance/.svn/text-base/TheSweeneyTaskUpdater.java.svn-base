package com.imop.lj.gameserver.thesweeneytask.persistance;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.thesweeneytask.TheSweeneyTask;

public class TheSweeneyTaskUpdater implements POUpdater {
	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		final TheSweeneyTask task = (TheSweeneyTask)obj;
		TheSweeneyTaskDbManager.getInstance().delTaskEntity(task, true);
	}

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final TheSweeneyTask task = (TheSweeneyTask)obj;
		TheSweeneyTaskDbManager.getInstance().saveTaskEntity(task, true);
	}
}
