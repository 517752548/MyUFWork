package com.imop.lj.gameserver.corps;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.corps.model.CorpsMember;

/**
 * 军团成员更新器
 * 
 * @author xiaowei.liu
 * 
 */
public class CorpsMemberUpdater implements POUpdater {

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final CorpsMember corpsMember = (CorpsMember)obj;
		CorpsDbManager.getInstance().saveCorpsMember(corpsMember, true);
	}

	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		final CorpsMember corpsMember = (CorpsMember)obj;
		CorpsDbManager.getInstance().delCorpsMember(corpsMember, true);
	}

}
