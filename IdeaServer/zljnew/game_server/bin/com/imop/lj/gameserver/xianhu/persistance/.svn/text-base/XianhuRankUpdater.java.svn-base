package com.imop.lj.gameserver.xianhu.persistance;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.xianhu.model.XianhuRank;

public class XianhuRankUpdater implements POUpdater {
	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		final XianhuRank task = (XianhuRank)obj;
		XianhuRankDbManager.getInstance().delEntity(task, true);
	}

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final XianhuRank task = (XianhuRank)obj;
		XianhuRankDbManager.getInstance().saveEntity(task, true);
	}
}
