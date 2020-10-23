package com.imop.lj.gameserver.offlinedata;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.UserOfflineDao;
import com.imop.lj.db.model.UserOfflineDataEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;

public class UserOfflineDataDbManager {
	public static UserOfflineDataDbManager userOfflineDataDbManager = new UserOfflineDataDbManager();
	private UserOfflineDataDbManager(){}
	
	/***
	 * 获得实体
	 */
	public static UserOfflineDataDbManager getInstance(){
		return userOfflineDataDbManager;
	}
	
	/***
	 * 保存战报
	 * @param userSnap
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void saveEntity(UserOfflineData userSnap, boolean async){
		IIoOperation _oper = new SaveObjectOperation<UserOfflineDataEntity, UserOfflineData>(userSnap, getUserOfflineDataDao());
		if (async) {
			Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
		} else {
			Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_oper);
		}
	}
	
	/***
	 * 删除 战报
	 * @param UserSnap
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void delEntity(UserOfflineData UserSnap, boolean async) {
		final long _charId = UserSnap.getDbId();
		UserOfflineDataEntity UserSnapEntity = UserSnap.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<UserOfflineDataEntity>(UserSnapEntity, _charId, getUserOfflineDataDao());
		if (async) {
			Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
		} else {
			Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_oper);
		}
	}
	
	/**
	 * 取得玩家离线数据的Dao实例
	 * @return
	 */
	private UserOfflineDao getUserOfflineDataDao() {
		return Globals.getDaoService().getUserOfflineDao();
	}
}
