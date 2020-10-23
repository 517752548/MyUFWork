package com.imop.lj.gameserver.day7target.persistance;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.Day7TaskDao;
import com.imop.lj.db.model.Day7TaskEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;
import com.imop.lj.gameserver.day7target.Day7Task;

public class Day7TaskDbManager {
	public static Day7TaskDbManager day7TaskDbManager = new Day7TaskDbManager();
	private Day7TaskDbManager(){}
	
	/***
	 * 获得实体
	 */
	public static Day7TaskDbManager getInstance(){
		return day7TaskDbManager;
	}
	
	/***
	 * 保存
	 * @param stepTask
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void saveTaskEntity(Day7Task stepTask, boolean async){
		IIoOperation _oper = new SaveObjectOperation<Day7TaskEntity, Day7Task>(stepTask, getDay7TaskDao());
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
	public void delTaskEntity(Day7Task stepTask, boolean async) {
		final long _charId = stepTask.getCharId();
		Day7TaskEntity landlordEntity = stepTask.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<Day7TaskEntity>(landlordEntity, _charId, getDay7TaskDao());
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
	private Day7TaskDao getDay7TaskDao() {
		return Globals.getDaoService().getDay7TaskDao();
	}
}
