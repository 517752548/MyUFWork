package com.imop.lj.gameserver.timelimit.persistance;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.TimeLimitNpcDao;
import com.imop.lj.db.model.TimeLimitNpcEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;
import com.imop.lj.gameserver.timelimit.npc.TimeLimitNpc;

public class TimeLimitNpcDbManager {
	public static TimeLimitNpcDbManager corpsTaskDbManager = new TimeLimitNpcDbManager();
	private TimeLimitNpcDbManager(){}
	
	/***
	 * 获得实体
	 */
	public static TimeLimitNpcDbManager getInstance(){
		return corpsTaskDbManager;
	}
	
	/***
	 * 保存
	 * @param task
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void saveTaskEntity(TimeLimitNpc task, boolean async){
		IIoOperation _oper = new SaveObjectOperation<TimeLimitNpcEntity, TimeLimitNpc>(task, getTimeLimitNpcDao());
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
	public void delTaskEntity(TimeLimitNpc task, boolean async) {
		final long _charId = task.getCharId();
		TimeLimitNpcEntity landlordEntity = task.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<TimeLimitNpcEntity>(landlordEntity, _charId, getTimeLimitNpcDao());
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
	private TimeLimitNpcDao getTimeLimitNpcDao() {
		return Globals.getDaoService().getTimeLimitNpcDao();
	}
}
