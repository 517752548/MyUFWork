package com.imop.lj.gameserver.arena.persistance;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.arena.model.ArenaMember;
import com.imop.lj.gameserver.common.db.POUpdater;

/**
 * 竞技场更新器
 *
 */
public class ArenaMemberUpdater implements POUpdater {

	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		throw new UnsupportedOperationException();
	}

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final ArenaMember arenaMember = (ArenaMember)obj;
		ArenaMemberDbManager.getInstance().saveArenaMember(arenaMember, true);
	}
}
