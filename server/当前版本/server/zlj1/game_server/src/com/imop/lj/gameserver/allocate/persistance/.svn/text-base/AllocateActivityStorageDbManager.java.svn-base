package com.imop.lj.gameserver.allocate.persistance;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.AllocateActivityStorageDao;
import com.imop.lj.db.model.AllocateActivityStorageEntity;
import com.imop.lj.gameserver.allocate.model.AllocateActivityStorage;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;

public class AllocateActivityStorageDbManager {
	public static AllocateActivityStorageDbManager allocateActivityStorageDbManager = new AllocateActivityStorageDbManager();
	private AllocateActivityStorageDbManager(){}
	
	/***
	 * 获得实体
	 */
	public static AllocateActivityStorageDbManager getInstance() {
		return allocateActivityStorageDbManager;
	}
	
	/***
	 * 保存
	 * @param allocateActivityStorage
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void saveEntity(AllocateActivityStorage allocateActivityStorage, boolean async){
		IIoOperation _oper = new SaveObjectOperation<AllocateActivityStorageEntity, AllocateActivityStorage>(allocateActivityStorage, getAllocateActivityStorageDao());
		if (async) {
			Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
		} else {
			Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_oper);
		}
	}
	
	/***
	 * 删除
	 * @param allocateActivityStorage
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void delEntity(AllocateActivityStorage allocateActivityStorage, boolean async) {
		final long _charId = allocateActivityStorage.getCharId();
		AllocateActivityStorageEntity landlordEntity = allocateActivityStorage.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<AllocateActivityStorageEntity>(landlordEntity, _charId, getAllocateActivityStorageDao());
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
	private AllocateActivityStorageDao getAllocateActivityStorageDao() {
		return Globals.getDaoService().getAllocateActivityStorageDao();
	}
}
