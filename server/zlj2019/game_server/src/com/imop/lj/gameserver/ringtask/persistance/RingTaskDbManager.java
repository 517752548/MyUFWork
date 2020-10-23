package com.imop.lj.gameserver.ringtask.persistance;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.RingTaskDao;
import com.imop.lj.db.model.RingTaskEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;
import com.imop.lj.gameserver.ringtask.RingTask;

public class RingTaskDbManager {
	public static RingTaskDbManager ringTaskDbManager = new RingTaskDbManager();
	private RingTaskDbManager(){}
	
	/***
	 * 获得实体
	 */
	public static RingTaskDbManager getInstance(){
		return ringTaskDbManager;
	}
	
	/***
	 * 保存
	 * @param stepTask
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void saveTaskEntity(RingTask stepTask, boolean async){
		IIoOperation _oper = new SaveObjectOperation<RingTaskEntity, RingTask>(stepTask, getRingTaskDao());
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
	public void delTaskEntity(RingTask stepTask, boolean async) {
		final long _charId = stepTask.getCharId();
		RingTaskEntity landlordEntity = stepTask.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<RingTaskEntity>(landlordEntity, _charId, getRingTaskDao());
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
	private RingTaskDao getRingTaskDao() {
		return Globals.getDaoService().getRingTaskDao();
	}
}
