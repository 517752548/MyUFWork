package com.imop.lj.gameserver.corps.persistance;

import java.util.LinkedHashMap;
import java.util.Map;

import com.imop.lj.core.annotation.NotThreadSafe;
import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.core.persistance.AbstractSceneDataUpdater;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.corps.CorpsMemberUpdater;
import com.imop.lj.gameserver.corps.CorpsUpdater;
import com.imop.lj.gameserver.corps.model.Corps;
import com.imop.lj.gameserver.corps.model.CorpsMember;

/**
 * 军团数据更新
 * 
 * @author xiaowei.liu
 * 
 */
@NotThreadSafe
public class CorpsDataUpdater extends AbstractSceneDataUpdater {
	private static Map<Class<? extends PersistanceObject<?, ?>>, POUpdater> operationDbMap = new LinkedHashMap<Class<? extends PersistanceObject<?, ?>>, POUpdater>();

	static{
		operationDbMap.put(CorpsMember.class, new CorpsMemberUpdater());
		operationDbMap.put(Corps.class, new CorpsUpdater());
	}
	
	public CorpsDataUpdater(){
		super();
	}
	
	@Override
	protected void doUpdate(LifeCycle lc) {
		if (!lc.isActive()) {
			throw new IllegalStateException(
					"Only the live object can be updated.");

		}
		PersistanceObject<?, ?> po = lc.getPO();
		POUpdater poUpdater = operationDbMap.get(po.getClass());
		poUpdater.save(po);

	}

	@Override
	protected void doDel(LifeCycle lc) {
		if (!lc.isDestroyed()) {
			throw new IllegalStateException(
					"Only the destroyed object can be deleted.");
		}
		PersistanceObject<?, ?> po = lc.getPO();
		operationDbMap.get(po.getClass()).delete(po);

	}

}
