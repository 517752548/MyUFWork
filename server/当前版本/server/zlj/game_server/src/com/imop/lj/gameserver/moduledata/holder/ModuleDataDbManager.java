package com.imop.lj.gameserver.moduledata.holder;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.ModuleDataDao;
import com.imop.lj.db.model.ModuleDataEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;

public class ModuleDataDbManager {
	public static ModuleDataDbManager moduleDataDbManager = new ModuleDataDbManager();

	public static ModuleDataDbManager getInstance() {
		return moduleDataDbManager;
	}

	/***
	 * 保存
	 * 
	 * @param po
	 * @param async
	 *            为true则异步保存，为false则同步保存
	 */
	public void saveEntity(ModuleData po, boolean async) {
		IIoOperation _oper = new SaveObjectOperation<ModuleDataEntity, ModuleData>(po, getModuleDataDao());
		if (async) {
			Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
		} else {
			Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_oper);
		}
	}

	/***
	 * 删除
	 * 
	 * @param po
	 * @param async
	 *            为true则异步保存，为false则同步保存
	 */
	public void delEntity(ModuleData po, boolean async) {
		final long _charId = po.getDbId();
		ModuleDataEntity moduleDataEntity = po.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<ModuleDataEntity>(moduleDataEntity, _charId, getModuleDataDao());
		if (async) {
			Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
		} else {
			Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_oper);
		}
	}

	/**
	 * 取得Dao实例
	 * 
	 * @return
	 */
	private ModuleDataDao getModuleDataDao() {
		return Globals.getDaoService().getModuleDataDao();
	}
}
