package com.imop.lj.gameserver.goodactivity.persistance;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;

public class GoodActivityUserUpdater implements POUpdater {
	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		final GoodActivityUserPO goodActivityUserPO = (GoodActivityUserPO)obj;
		GoodActivityUserDbManager.getInstance().delEntity(goodActivityUserPO, true);
	}

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final GoodActivityUserPO goodActivityUserPO = (GoodActivityUserPO)obj;
		GoodActivityUserDbManager.getInstance().saveEntity(goodActivityUserPO, true);
	}
}
