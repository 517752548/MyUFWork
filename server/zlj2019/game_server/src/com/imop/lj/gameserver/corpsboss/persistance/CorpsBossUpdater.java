package com.imop.lj.gameserver.corpsboss.persistance;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.corpsboss.CorpsBossRank;

public class CorpsBossUpdater implements POUpdater {
	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		final CorpsBossRank task = (CorpsBossRank)obj;
		CorpsBossDbManager.getInstance().delEntity(task, true);
	}

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final CorpsBossRank task = (CorpsBossRank)obj;
		CorpsBossDbManager.getInstance().saveEntity(task, true);
	}
}
