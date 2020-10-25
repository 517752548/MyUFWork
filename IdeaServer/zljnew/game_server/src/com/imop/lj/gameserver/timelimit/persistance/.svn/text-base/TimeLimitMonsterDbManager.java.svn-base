package com.imop.lj.gameserver.timelimit.persistance;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.TimeLimitMonsterDao;
import com.imop.lj.db.model.TimeLimitMonsterEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;
import com.imop.lj.gameserver.timelimit.monster.TimeLimitMonster;

public class TimeLimitMonsterDbManager {
	public static TimeLimitMonsterDbManager corpsTaskDbManager = new TimeLimitMonsterDbManager();
	private TimeLimitMonsterDbManager(){}
	
	/***
	 * 获得实体
	 */
	public static TimeLimitMonsterDbManager getInstance(){
		return corpsTaskDbManager;
	}
	
	/***
	 * 保存
	 * @param task
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void saveTaskEntity(TimeLimitMonster task, boolean async){
		IIoOperation _oper = new SaveObjectOperation<TimeLimitMonsterEntity, TimeLimitMonster>(task, getTimeLimitMonsterDao());
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
	public void delTaskEntity(TimeLimitMonster task, boolean async) {
		final long _charId = task.getCharId();
		TimeLimitMonsterEntity landlordEntity = task.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<TimeLimitMonsterEntity>(landlordEntity, _charId, getTimeLimitMonsterDao());
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
	private TimeLimitMonsterDao getTimeLimitMonsterDao() {
		return Globals.getDaoService().getTimeLimitMonsterDao();
	}
}
