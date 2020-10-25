package com.imop.lj.gameserver.nvn.persistance;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.nvn.model.NvnRank;

public class NvnUpdater implements POUpdater {
	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		final NvnRank task = (NvnRank)obj;
		NvnDbManager.getInstance().delEntity(task, true);
	}

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final NvnRank task = (NvnRank)obj;
		NvnDbManager.getInstance().saveEntity(task, true);
	}
}
