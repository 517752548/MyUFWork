package com.imop.lj.gameserver.corpswar.persistance;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.corpswar.model.CorpsWarRank;

public class CorpsWarUpdater implements POUpdater {
	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		final CorpsWarRank task = (CorpsWarRank)obj;
		CorpsWarDbManager.getInstance().delEntity(task, true);
	}

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final CorpsWarRank task = (CorpsWarRank)obj;
		CorpsWarDbManager.getInstance().saveEntity(task, true);
	}
}
