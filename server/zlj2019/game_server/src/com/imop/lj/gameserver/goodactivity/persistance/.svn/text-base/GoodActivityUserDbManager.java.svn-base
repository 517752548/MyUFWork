package com.imop.lj.gameserver.goodactivity.persistance;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.GoodActivityUserDao;
import com.imop.lj.db.model.GoodActivityUserEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;

public class GoodActivityUserDbManager {
	public static GoodActivityUserDbManager goodActivityUserDbManager = new GoodActivityUserDbManager();
	private GoodActivityUserDbManager(){}
	
	/***
	 * 获得实体
	 */
	public static GoodActivityUserDbManager getInstance(){
		return goodActivityUserDbManager;
	}
	
	/***
	 * 保存
	 * @param goodActivityUserPO
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void saveEntity(GoodActivityUserPO goodActivityUserPO, boolean async){
		IIoOperation _oper = new SaveObjectOperation<GoodActivityUserEntity, GoodActivityUserPO>(goodActivityUserPO, getGoodActivityUserDao());
		if (async) {
			Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
		} else {
			Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_oper);
		}
	}
	
	/***
	 * 删除
	 * @param goodActivityUserPO
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void delEntity(GoodActivityUserPO goodActivityUserPO, boolean async) {
		final Long _charId = goodActivityUserPO.getDbId();
		GoodActivityUserEntity landlordEntity = goodActivityUserPO.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<GoodActivityUserEntity>(landlordEntity, _charId, getGoodActivityUserDao());
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
	private GoodActivityUserDao getGoodActivityUserDao() {
		return Globals.getDaoService().getGoodActivityUserDao();
	}
}
