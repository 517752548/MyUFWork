package com.imop.lj.gameserver.mail;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.SysMailDao;
import com.imop.lj.db.model.SysMailEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;

public class SysMailDbManager {
	public static SysMailDbManager sysMailDbManager = new SysMailDbManager();
	private SysMailDbManager(){}
	
	/***
	 * 获得实体
	 */
	public static SysMailDbManager getInstance() {
		return sysMailDbManager;
	}
	
	/***
	 * 保存
	 * @param sysMailInstance
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void saveSysMailEntity(SysMailInstance sysMailInstance, boolean async){
		IIoOperation _oper = new SaveObjectOperation<SysMailEntity, SysMailInstance>(sysMailInstance, getSysMailDao());
		if (async) {
			Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
		} else {
			Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_oper);
		}
	}
	
	/***
	 * 删除
	 * @param sysMailInstance
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void delSysMailEntity(SysMailInstance sysMailInstance, boolean async) {
		final long _charId = sysMailInstance.getDbId();
		SysMailEntity moneyTreeEntity = sysMailInstance.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<SysMailEntity>(moneyTreeEntity, _charId, getSysMailDao());
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
	private SysMailDao getSysMailDao() {
		return Globals.getDaoService().getSysMailDao();
	}
}
