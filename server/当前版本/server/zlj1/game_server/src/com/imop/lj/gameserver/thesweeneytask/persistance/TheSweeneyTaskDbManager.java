package com.imop.lj.gameserver.thesweeneytask.persistance;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.TheSweeneyTaskDao;
import com.imop.lj.db.model.TheSweeneyTaskEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;
import com.imop.lj.gameserver.thesweeneytask.TheSweeneyTask;

public class TheSweeneyTaskDbManager {
	public static TheSweeneyTaskDbManager theSweeneyTaskDbManager = new TheSweeneyTaskDbManager();
	private TheSweeneyTaskDbManager(){}
	
	/***
	 * 获得实体
	 */
	public static TheSweeneyTaskDbManager getInstance(){
		return theSweeneyTaskDbManager;
	}
	
	/***
	 * 保存
	 * @param stepTask
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void saveTaskEntity(TheSweeneyTask stepTask, boolean async){
		IIoOperation _oper = new SaveObjectOperation<TheSweeneyTaskEntity, TheSweeneyTask>(stepTask, getTheSweeneyTaskDao());
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
	public void delTaskEntity(TheSweeneyTask stepTask, boolean async) {
		final long _charId = stepTask.getCharId();
		TheSweeneyTaskEntity landlordEntity = stepTask.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<TheSweeneyTaskEntity>(landlordEntity, _charId, getTheSweeneyTaskDao());
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
	private TheSweeneyTaskDao getTheSweeneyTaskDao() {
		return Globals.getDaoService().getTheSweeneyTaskDao();
	}
}
