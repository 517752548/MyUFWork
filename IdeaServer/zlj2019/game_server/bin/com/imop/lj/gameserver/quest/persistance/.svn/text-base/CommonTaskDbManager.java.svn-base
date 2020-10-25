package com.imop.lj.gameserver.quest.persistance;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.CommonTaskDao;
import com.imop.lj.db.model.CommonTaskEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;
import com.imop.lj.gameserver.quest.CommonTask;

public class CommonTaskDbManager {
	public static CommonTaskDbManager stepTaskDbManager = new CommonTaskDbManager();
	private CommonTaskDbManager(){}
	
	/***
	 * 获得实体
	 */
	public static CommonTaskDbManager getInstance(){
		return stepTaskDbManager;
	}
	
	/***
	 * 保存
	 * @param stepTask
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void saveCommonTaskEntity(CommonTask stepTask, boolean async){
		IIoOperation _oper = new SaveObjectOperation<CommonTaskEntity, CommonTask>(stepTask, getCommonTaskDao());
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
	public void delCommonTaskEntity(CommonTask stepTask, boolean async) {
		final long _charId = stepTask.getCharId();
		CommonTaskEntity landlordEntity = stepTask.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<CommonTaskEntity>(landlordEntity, _charId, getCommonTaskDao());
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
	private CommonTaskDao getCommonTaskDao() {
		return Globals.getDaoService().getCommonTaskDao();
	}
}
