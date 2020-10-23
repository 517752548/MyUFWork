package com.imop.lj.gameserver.offlinedata;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;

public class UserSnapUpdater implements POUpdater{
	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		
		final UserSnap UserSnap = (UserSnap)obj;
		UserSnapDbManager.getInstance().delUserSnapEntity(UserSnap, true);
	}

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final UserSnap UserSnap = (UserSnap)obj;
		UserSnapDbManager.getInstance().saveUserSnapEntity(UserSnap, true);
	}
}
