package com.imop.lj.gameserver.nvn.persistance;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.NvnRankDao;
import com.imop.lj.db.model.NvnRankEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;
import com.imop.lj.gameserver.nvn.model.NvnRank;

public class NvnDbManager {
	public static NvnDbManager corpsWarDbManager = new NvnDbManager();
	private NvnDbManager(){}
	
	/***
	 * 获得实体
	 */
	public static NvnDbManager getInstance(){
		return corpsWarDbManager;
	}
	
	/***
	 * 保存
	 * @param stepTask
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void saveEntity(NvnRank stepTask, boolean async){
		IIoOperation _oper = new SaveObjectOperation<NvnRankEntity, NvnRank>(stepTask, getNvnRankDao());
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
	public void delEntity(NvnRank stepTask, boolean async) {
		final long _charId = stepTask.getCharId();
		NvnRankEntity landlordEntity = stepTask.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<NvnRankEntity>(landlordEntity, _charId, getNvnRankDao());
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
	private NvnRankDao getNvnRankDao() {
		return Globals.getDaoService().getNvnRankDao();
	}
}
