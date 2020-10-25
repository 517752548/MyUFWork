package com.imop.lj.gameserver.arena.persistance;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.ArenaMemberDao;
import com.imop.lj.db.model.ArenaSnapEntity;
import com.imop.lj.gameserver.arena.model.ArenaMember;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;

public class ArenaMemberDbManager {
	/** 竞技场数据库操作管理 */
	private static ArenaMemberDbManager arenaMemberDbManager = new ArenaMemberDbManager();

	private ArenaMemberDbManager() {

	}

	/**
	 * 获取数据库操作管理类
	 * 
	 * @return
	 */
	public static ArenaMemberDbManager getInstance() {
		return arenaMemberDbManager;
	}

	/**
	 * 保存竞技场成员
	 * 
	 * @param secretary
	 * @param async
	 *            为true则异步保存，为false则同步保存
	 */
	public void saveArenaMember(ArenaMember arenaMember, boolean async) {
		IIoOperation _oper = new SaveObjectOperation<ArenaSnapEntity, ArenaMember>(arenaMember, getArenaMemberDao());
		if (async) {
			Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
		} else {
			Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_oper);
		}
	}
	
	/**
	 * 取得员工的Dao实例
	 * 
	 * @return
	 */
	private ArenaMemberDao getArenaMemberDao() {
		return Globals.getDaoService().getArenaMemberDao();
	}
}
