package com.imop.lj.gameserver.quest.persistance;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.quest.CommonTask;

public class CommonTaskUpdater implements POUpdater {
	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		final CommonTask task = (CommonTask)obj;
		CommonTaskDbManager.getInstance().delCommonTaskEntity(task, true);
	}

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final CommonTask task = (CommonTask)obj;
		CommonTaskDbManager.getInstance().saveCommonTaskEntity(task, true);
	}
}
