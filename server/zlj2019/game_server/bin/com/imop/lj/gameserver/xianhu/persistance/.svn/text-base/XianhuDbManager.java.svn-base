package com.imop.lj.gameserver.xianhu.persistance;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.XianhuDao;
import com.imop.lj.db.model.XianhuEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;
import com.imop.lj.gameserver.xianhu.model.Xianhu;

public class XianhuDbManager {
	public static XianhuDbManager corpsWarDbManager = new XianhuDbManager();
	private XianhuDbManager(){}
	
	/***
	 * 获得实体
	 */
	public static XianhuDbManager getInstance(){
		return corpsWarDbManager;
	}
	
	/***
	 * 保存
	 * @param stepTask
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void saveEntity(Xianhu stepTask, boolean async){
		IIoOperation _oper = new SaveObjectOperation<XianhuEntity, Xianhu>(stepTask, getXianhuDao());
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
	public void delEntity(Xianhu stepTask, boolean async) {
		final long _charId = stepTask.getCharId();
		XianhuEntity landlordEntity = stepTask.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<XianhuEntity>(landlordEntity, _charId, getXianhuDao());
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
	private XianhuDao getXianhuDao() {
		return Globals.getDaoService().getXianhuDao();
	}
}
