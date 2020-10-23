package com.imop.lj.gameserver.corps;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.corps.model.Corps;

/**
 * 军团更新器
 * 
 * @author xiaowei.liu
 * 
 */
public class CorpsUpdater implements POUpdater {

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final Corps corps = (Corps)obj;
		CorpsDbManager.getInstance().saveCorps(corps, true);
	}

	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		final Corps corps = (Corps)obj;
		CorpsDbManager.getInstance().delCorps(corps, true);
	}

}
