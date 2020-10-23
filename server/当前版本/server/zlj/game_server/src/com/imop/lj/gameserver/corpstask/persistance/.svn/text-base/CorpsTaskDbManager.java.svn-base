package com.imop.lj.gameserver.corpstask.persistance;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.CorpsTaskDao;
import com.imop.lj.db.model.CorpsTaskEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;
import com.imop.lj.gameserver.corpstask.CorpsTask;

public class CorpsTaskDbManager {
	public static CorpsTaskDbManager corpsTaskDbManager = new CorpsTaskDbManager();
	private CorpsTaskDbManager(){}
	
	/***
	 * 获得实体
	 */
	public static CorpsTaskDbManager getInstance(){
		return corpsTaskDbManager;
	}
	
	/***
	 * 保存
	 * @param stepTask
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void saveTaskEntity(CorpsTask stepTask, boolean async){
		IIoOperation _oper = new SaveObjectOperation<CorpsTaskEntity, CorpsTask>(stepTask, getCorpsTaskDao());
		if (async) {
			Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
		} else {
			Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_oper);
		}
	}
	
	/***
	 * 删除
	 * @param stepTask
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void delTaskEntity(CorpsTask stepTask, boolean async) {
		final long _charId = stepTask.getCharId();
		CorpsTaskEntity landlordEntity = stepTask.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<CorpsTaskEntity>(landlordEntity, _charId, getCorpsTaskDao());
		if (async) {
			Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
		} else {
			Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_oper);
		}
	}
	
	/**
	 * 取得Dao实例
	 * @return
	 */
	private CorpsTaskDao getCorpsTaskDao() {
		return Globals.getDaoService().getCorpsTaskDao();
	}
}
