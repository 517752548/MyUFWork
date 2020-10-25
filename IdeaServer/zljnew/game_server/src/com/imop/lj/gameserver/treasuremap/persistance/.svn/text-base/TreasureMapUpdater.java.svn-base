package com.imop.lj.gameserver.treasuremap.persistance;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.treasuremap.TreasureMap;

public class TreasureMapUpdater implements POUpdater {
	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		final TreasureMap task = (TreasureMap)obj;
		TreasureMapDbManager.getInstance().delTaskEntity(task, true);
	}

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final TreasureMap task = (TreasureMap)obj;
		TreasureMapDbManager.getInstance().saveTaskEntity(task, true);
	}
}
