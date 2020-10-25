package com.imop.lj.gameserver.offlinedata;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.UserSnapDao;
import com.imop.lj.db.model.UserSnapEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;

public class UserSnapDbManager {
	public static UserSnapDbManager userSnapDbManager = new UserSnapDbManager();
	private UserSnapDbManager(){}
	
	/***
	 * 获得实体
	 */
	public static UserSnapDbManager getInstance(){
		return userSnapDbManager;
	}
	
	/***
	 * 保存战报
	 * @param userSnap
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void saveUserSnapEntity(UserSnap userSnap, boolean async){
		IIoOperation _oper = new SaveObjectOperation<UserSnapEntity, UserSnap>(userSnap, getUserSnapDao());
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
	public void delUserSnapEntity(UserSnap UserSnap, boolean async) {
		final long _charId = UserSnap.getDbId();
		UserSnapEntity UserSnapEntity = UserSnap.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<UserSnapEntity>(UserSnapEntity, _charId, getUserSnapDao());
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
	private UserSnapDao getUserSnapDao() {
		return Globals.getDaoService().getUserSnapDao();
	}
}
