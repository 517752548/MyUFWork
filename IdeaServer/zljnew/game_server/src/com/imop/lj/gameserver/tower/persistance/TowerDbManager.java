package com.imop.lj.gameserver.tower.persistance;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.TowerDao;
import com.imop.lj.db.model.TowerEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;
import com.imop.lj.gameserver.tower.Tower;

public class TowerDbManager {
	public static TowerDbManager towerDbManager = new TowerDbManager();
	private TowerDbManager(){}
	
	/***
	 * 获得实体
	 */
	public static TowerDbManager getInstance(){
		return towerDbManager;
	}
	
	/***
	 * 保存
	 * @param wing
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void saveEntity(Tower tower, boolean async){
		IIoOperation _oper = new SaveObjectOperation<TowerEntity, Tower>(tower, getTowerDao());
		if (async) {
			Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
		} else {
			Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_oper);
		}
	}
	
	/***
	 * 删除
	 * @param tower
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void delEntity(Tower tower, boolean async) {
		final long _charId = tower.getCharId();
		TowerEntity landlordEntity = tower.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<TowerEntity>(landlordEntity, _charId, getTowerDao());
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
	private TowerDao getTowerDao() {
		return Globals.getDaoService().getTowerDao();
	}
}