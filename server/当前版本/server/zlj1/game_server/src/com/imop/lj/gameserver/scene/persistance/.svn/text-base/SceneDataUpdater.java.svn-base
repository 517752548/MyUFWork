package com.imop.lj.gameserver.scene.persistance;

import java.util.LinkedHashMap;
import java.util.Map;

import com.imop.lj.core.annotation.NotThreadSafe;
import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.core.persistance.AbstractDataUpdater;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.scene.CityScene;
import com.imop.lj.gameserver.scene.SceneUpdater;

/**
 * 场景更新接口
 *
 * @author haijiang.jin
 *
 */
@NotThreadSafe
public class SceneDataUpdater extends AbstractDataUpdater{

	private static Map<Class<? extends PersistanceObject<?, ?>>, POUpdater> operationDbMap = new LinkedHashMap<Class<? extends PersistanceObject<?, ?>>, POUpdater>();

	static {
		operationDbMap.put(CityScene.class, new SceneUpdater());
//		operationDbMap.put(FarmScene.class, new SceneUpdater());
//		operationDbMap.put(SilveroreScene.class, new SceneUpdater());
//		operationDbMap.put(SilveroreGrid.class, new SilveroreUpdater());
//		operationDbMap.put(FarmGrid.class, new FarmUpdater());
	}

	public SceneDataUpdater() {
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