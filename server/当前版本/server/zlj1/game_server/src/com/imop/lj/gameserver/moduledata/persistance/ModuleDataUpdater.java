package com.imop.lj.gameserver.moduledata.persistance;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.moduledata.holder.ModuleData;
import com.imop.lj.gameserver.moduledata.holder.ModuleDataDbManager;

/**
 * 功能数据更新器
 * 
 * @author xiaowei.liu
 * 
 */
public class ModuleDataUpdater implements POUpdater {

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final ModuleData holder = (ModuleData)obj;
		ModuleDataDbManager.getInstance().saveEntity(holder, true);
	}

	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		final ModuleData holder = (ModuleData)obj;
		ModuleDataDbManager.getInstance().delEntity(holder, true);
	}

}
