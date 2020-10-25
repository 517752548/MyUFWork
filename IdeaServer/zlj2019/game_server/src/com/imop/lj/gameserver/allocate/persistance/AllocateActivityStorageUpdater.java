package com.imop.lj.gameserver.allocate.persistance;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.allocate.model.AllocateActivityStorage;
import com.imop.lj.gameserver.common.db.POUpdater;

public class AllocateActivityStorageUpdater implements POUpdater  {
	
	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		final AllocateActivityStorage task = (AllocateActivityStorage)obj;
		AllocateActivityStorageDbManager.getInstance().delEntity(task, true);
	}

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final AllocateActivityStorage task = (AllocateActivityStorage)obj;
		AllocateActivityStorageDbManager.getInstance().saveEntity(task, true);
	}

}
