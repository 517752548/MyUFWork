package com.imop.lj.gameserver.pubtask.persistance;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.PubTaskDao;
import com.imop.lj.db.model.PubTaskEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;
import com.imop.lj.gameserver.pubtask.PubTask;

public class PubTaskDbManager {
	public static PubTaskDbManager pubTaskDbManager = new PubTaskDbManager();
	private PubTaskDbManager(){}
	
	/***
	 * 获得实体
	 */
	public static PubTaskDbManager getInstance(){
		return pubTaskDbManager;
	}
	
	/***
	 * 保存
	 * @param stepTask
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void saveTaskEntity(PubTask stepTask, boolean async){
		IIoOperation _oper = new SaveObjectOperation<PubTaskEntity, PubTask>(stepTask, getPubTaskDao());
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
	public void delTaskEntity(PubTask stepTask, boolean async) {
		final long _charId = stepTask.getCharId();
		PubTaskEntity landlordEntity = stepTask.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<PubTaskEntity>(landlordEntity, _charId, getPubTaskDao());
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
	private PubTaskDao getPubTaskDao() {
		return Globals.getDaoService().getPubTaskDao();
	}
}
