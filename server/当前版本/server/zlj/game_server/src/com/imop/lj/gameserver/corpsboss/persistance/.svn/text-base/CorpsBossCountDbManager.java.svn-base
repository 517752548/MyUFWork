package com.imop.lj.gameserver.corpsboss.persistance;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.CorpsBossCountRankDao;
import com.imop.lj.db.model.CorpsBossCountRankEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;
import com.imop.lj.gameserver.corpsboss.CorpsBossCountRank;

public class CorpsBossCountDbManager {
	public static CorpsBossCountDbManager corpsBossCountDbManager = new CorpsBossCountDbManager();
	private CorpsBossCountDbManager(){}
	
	/***
	 * 获得实体
	 */
	public static CorpsBossCountDbManager getInstance(){
		return corpsBossCountDbManager;
	}
	
	/***
	 * 保存
	 * @param stepTask
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void saveEntity(CorpsBossCountRank stepTask, boolean async){
		IIoOperation _oper = new SaveObjectOperation<CorpsBossCountRankEntity, CorpsBossCountRank>(stepTask, getCorpsBossCountRankDao());
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
	public void delEntity(CorpsBossCountRank stepTask, boolean async) {
		final long _charId = stepTask.getCharId();
		CorpsBossCountRankEntity landlordEntity = stepTask.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<CorpsBossCountRankEntity>(landlordEntity, _charId, getCorpsBossCountRankDao());
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
	private CorpsBossCountRankDao getCorpsBossCountRankDao() {
		return Globals.getDaoService().getCorpsBossCountRankDao();
	}
}
