package com.imop.lj.gameserver.treasuremap.persistance;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.TreasureMapDao;
import com.imop.lj.db.model.TreasureMapEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;
import com.imop.lj.gameserver.treasuremap.TreasureMap;

public class TreasureMapDbManager {
	public static TreasureMapDbManager treasureMapDbManager = new TreasureMapDbManager();
	private TreasureMapDbManager(){}
	
	/***
	 * 获得实体
	 */
	public static TreasureMapDbManager getInstance(){
		return treasureMapDbManager;
	}
	
	/***
	 * 保存
	 * @param stepTask
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void saveTaskEntity(TreasureMap stepTask, boolean async){
		IIoOperation _oper = new SaveObjectOperation<TreasureMapEntity, TreasureMap>(stepTask, getTreasureMapDbManager());
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
	public void delTaskEntity(TreasureMap stepTask, boolean async) {
		final long _charId = stepTask.getCharId();
		TreasureMapEntity landlordEntity = stepTask.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<TreasureMapEntity>(landlordEntity, _charId, getTreasureMapDbManager());
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
	public static TreasureMapDao getTreasureMapDbManager() {
		return  Globals.getDaoService().getTreasureMapDao();
	}
}
