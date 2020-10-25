package com.imop.lj.gameserver.offlinedata;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;

public class UserOfflineDataUpdater implements POUpdater {

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final UserOfflineData ud = (UserOfflineData)obj;
		UserOfflineDataDbManager.getInstance().saveEntity(ud, true);
	}

	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		final UserOfflineData ud = (UserOfflineData)obj;
		UserOfflineDataDbManager.getInstance().delEntity(ud, true);
	}

}
