package com.imop.lj.gameserver.corpsboss.persistance;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.corpsboss.CorpsBossCountRank;

public class CorpsBossCountUpdater implements POUpdater {
	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		final CorpsBossCountRank task = (CorpsBossCountRank)obj;
		CorpsBossCountDbManager.getInstance().delEntity(task, true);
	}

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final CorpsBossCountRank task = (CorpsBossCountRank)obj;
		CorpsBossCountDbManager.getInstance().saveEntity(task, true);
	}
}
