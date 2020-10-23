package com.imop.lj.gameserver.corpsboss.persistance;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.CorpsBossRankDao;
import com.imop.lj.db.model.CorpsBossRankEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;
import com.imop.lj.gameserver.corpsboss.CorpsBossRank;

public class CorpsBossDbManager {
	public static CorpsBossDbManager corpsBossDbManager = new CorpsBossDbManager();
	private CorpsBossDbManager(){}
	
	/***
	 * 获得实体
	 */
	public static CorpsBossDbManager getInstance(){
		return corpsBossDbManager;
	}
	
	/***
	 * 保存
	 * @param stepTask
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void saveEntity(CorpsBossRank stepTask, boolean async){
		IIoOperation _oper = new SaveObjectOperation<CorpsBossRankEntity, CorpsBossRank>(stepTask, getCorpsBossRankDao());
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
	public void delEntity(CorpsBossRank stepTask, boolean async) {
		final long _charId = stepTask.getCharId();
		CorpsBossRankEntity landlordEntity = stepTask.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<CorpsBossRankEntity>(landlordEntity, _charId, getCorpsBossRankDao());
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
	private CorpsBossRankDao getCorpsBossRankDao() {
		return Globals.getDaoService().getCorpsBossRankDao();
	}
}
