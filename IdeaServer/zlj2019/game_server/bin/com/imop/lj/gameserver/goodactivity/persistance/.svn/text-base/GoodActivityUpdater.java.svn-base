package com.imop.lj.gameserver.goodactivity.persistance;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;

public class GoodActivityUpdater implements POUpdater {
	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		final GoodActivityPO goodActivityPO = (GoodActivityPO)obj;
		GoodActivityDbManager.getInstance().delEntity(goodActivityPO, true);
	}

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final GoodActivityPO goodActivityPO = (GoodActivityPO)obj;
		GoodActivityDbManager.getInstance().saveEntity(goodActivityPO, true);
	}
}
