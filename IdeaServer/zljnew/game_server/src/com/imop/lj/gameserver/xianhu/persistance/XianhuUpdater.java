package com.imop.lj.gameserver.xianhu.persistance;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.xianhu.model.Xianhu;

public class XianhuUpdater implements POUpdater {
	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		final Xianhu task = (Xianhu)obj;
		XianhuDbManager.getInstance().delEntity(task, true);
	}

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final Xianhu task = (Xianhu)obj;
		XianhuDbManager.getInstance().saveEntity(task, true);
	}
}
