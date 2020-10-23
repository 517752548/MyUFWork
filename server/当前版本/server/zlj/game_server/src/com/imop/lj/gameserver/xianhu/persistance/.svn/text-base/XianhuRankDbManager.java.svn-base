package com.imop.lj.gameserver.xianhu.persistance;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.XianhuRankDao;
import com.imop.lj.db.model.XianhuRankEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;
import com.imop.lj.gameserver.xianhu.model.XianhuRank;

public class XianhuRankDbManager {
	public static XianhuRankDbManager corpsWarDbManager = new XianhuRankDbManager();
	private XianhuRankDbManager(){}
	
	/***
	 * 获得实体
	 */
	public static XianhuRankDbManager getInstance(){
		return corpsWarDbManager;
	}
	
	/***
	 * 保存
	 * @param stepTask
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void saveEntity(XianhuRank stepTask, boolean async){
		IIoOperation _oper = new SaveObjectOperation<XianhuRankEntity, XianhuRank>(stepTask, getXianhuRankDao());
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
	public void delEntity(XianhuRank stepTask, boolean async) {
		final long _charId = stepTask.getCharId();
		XianhuRankEntity landlordEntity = stepTask.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<XianhuRankEntity>(landlordEntity, _charId, getXianhuRankDao());
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
	private XianhuRankDao getXianhuRankDao() {
		return Globals.getDaoService().getXianhuRankDao();
	}
}
