package com.imop.lj.gameserver.corpswar.persistance;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.CorpsWarRankDao;
import com.imop.lj.db.model.CorpsWarRankEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;
import com.imop.lj.gameserver.corpswar.model.CorpsWarRank;

public class CorpsWarDbManager {
	public static CorpsWarDbManager corpsWarDbManager = new CorpsWarDbManager();
	private CorpsWarDbManager(){}
	
	/***
	 * 获得实体
	 */
	public static CorpsWarDbManager getInstance(){
		return corpsWarDbManager;
	}
	
	/***
	 * 保存
	 * @param stepTask
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void saveEntity(CorpsWarRank stepTask, boolean async){
		IIoOperation _oper = new SaveObjectOperation<CorpsWarRankEntity, CorpsWarRank>(stepTask, getCorpsWarRankDao());
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
	public void delEntity(CorpsWarRank stepTask, boolean async) {
		final long _charId = stepTask.getCharId();
		CorpsWarRankEntity landlordEntity = stepTask.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<CorpsWarRankEntity>(landlordEntity, _charId, getCorpsWarRankDao());
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
	private CorpsWarRankDao getCorpsWarRankDao() {
		return Globals.getDaoService().getCorpsWarRankDao();
	}
}
