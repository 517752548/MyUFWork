package com.imop.lj.gameserver.foragetask.persistance;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.ForageTaskDao;
import com.imop.lj.db.model.ForageTaskEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;
import com.imop.lj.gameserver.foragetask.ForageTask;

public class ForageTaskDbManager {
	public static ForageTaskDbManager forageTaskDbManager = new ForageTaskDbManager();
	private ForageTaskDbManager(){}
	
	/***
	 * 获得实体
	 */
	public static ForageTaskDbManager getInstance(){
		return forageTaskDbManager;
	}
	
	/***
	 * 保存
	 * @param stepTask
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void saveTaskEntity(ForageTask stepTask, boolean async){
		IIoOperation _oper = new SaveObjectOperation<ForageTaskEntity, ForageTask>(stepTask, getForageTaskDao());
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
	public void delTaskEntity(ForageTask stepTask, boolean async) {
		final long _charId = stepTask.getCharId();
		ForageTaskEntity landlordEntity = stepTask.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<ForageTaskEntity>(landlordEntity, _charId, getForageTaskDao());
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
	private ForageTaskDao getForageTaskDao() {
		return Globals.getDaoService().getForageTaskDao();
	}
}
