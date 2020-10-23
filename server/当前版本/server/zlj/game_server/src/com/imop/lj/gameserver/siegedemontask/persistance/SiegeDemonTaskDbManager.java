package com.imop.lj.gameserver.siegedemontask.persistance;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.SiegeDemonTaskDao;
import com.imop.lj.db.model.SiegeDemonTaskEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;
import com.imop.lj.gameserver.siegedemontask.SiegeDemonTask;

public class SiegeDemonTaskDbManager {
	public static SiegeDemonTaskDbManager corpsTaskDbManager = new SiegeDemonTaskDbManager();
	private SiegeDemonTaskDbManager(){}
	
	/***
	 * 获得实体
	 */
	public static SiegeDemonTaskDbManager getInstance(){
		return corpsTaskDbManager;
	}
	
	/***
	 * 保存
	 * @param task
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void saveTaskEntity(SiegeDemonTask task, boolean async){
		IIoOperation _oper = new SaveObjectOperation<SiegeDemonTaskEntity, SiegeDemonTask>(task, getSiegeDemonTaskDao());
		if (async) {
			Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
		} else {
			Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_oper);
		}
	}
	
	/***
	 * 删除
	 * @param task
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void delTaskEntity(SiegeDemonTask task, boolean async) {
		final long _charId = task.getCharId();
		SiegeDemonTaskEntity landlordEntity = task.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<SiegeDemonTaskEntity>(landlordEntity, _charId, getSiegeDemonTaskDao());
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
	private SiegeDemonTaskDao getSiegeDemonTaskDao() {
		return Globals.getDaoService().getSiegeDemonTaskDao();
	}
}
