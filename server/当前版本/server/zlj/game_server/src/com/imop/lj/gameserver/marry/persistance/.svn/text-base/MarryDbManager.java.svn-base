package com.imop.lj.gameserver.marry.persistance;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.MarryDao;
import com.imop.lj.db.model.MarryEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;
import com.imop.lj.gameserver.marry.Marry;

public class MarryDbManager {
	public static MarryDbManager marryDbManager = new MarryDbManager();
	private MarryDbManager(){}
	
	/***
	 * 获得实体
	 */
	public static MarryDbManager getInstance(){
		return marryDbManager;
	}
	
	/***
	 * 保存
	 * @param marry
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void saveTaskEntity(Marry marry, boolean async){
		IIoOperation _oper = new SaveObjectOperation<MarryEntity, Marry>(marry, getMarryDao());
		if (async) {
			Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
		} else {
			Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_oper);
		}
	}
	
	/***
	 * 删除
	 * @param marry
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void delTaskEntity(Marry marry, boolean async) {
		final long _charId = marry.getCharId();
		MarryEntity landlordEntity = marry.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<MarryEntity>(landlordEntity, _charId, getMarryDao());
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
	private MarryDao getMarryDao() {
		return Globals.getDaoService().getMarryDao();
	}
}
