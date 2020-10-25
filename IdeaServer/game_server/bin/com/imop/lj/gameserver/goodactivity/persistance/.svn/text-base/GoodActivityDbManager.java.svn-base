package com.imop.lj.gameserver.goodactivity.persistance;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.GoodActivityDao;
import com.imop.lj.db.model.GoodActivityEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;

public class GoodActivityDbManager {
	public static GoodActivityDbManager goodActivityDbManager = new GoodActivityDbManager();
	private GoodActivityDbManager(){}
	
	/***
	 * 获得实体
	 */
	public static GoodActivityDbManager getInstance(){
		return goodActivityDbManager;
	}
	
	/***
	 * 保存
	 * @param goodActivityPO
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void saveEntity(GoodActivityPO goodActivityPO, boolean async){
		IIoOperation _oper = new SaveObjectOperation<GoodActivityEntity, GoodActivityPO>(goodActivityPO, getGoodActivityDao());
		if (async) {
			Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
		} else {
			Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_oper);
		}
	}
	
	/***
	 * 删除
	 * @param goodActivityPO
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void delEntity(GoodActivityPO goodActivityPO, boolean async) {
		final long _charId = goodActivityPO.getDbId();
		GoodActivityEntity landlordEntity = goodActivityPO.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<GoodActivityEntity>(landlordEntity, _charId, getGoodActivityDao());
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
	private GoodActivityDao getGoodActivityDao() {
		return Globals.getDaoService().getGoodActivityDao();
	}
}
