package com.imop.lj.gameserver.corps;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.CorpsDao;
import com.imop.lj.db.dao.CorpsMemberDao;
import com.imop.lj.db.model.CorpsEntity;
import com.imop.lj.db.model.CorpsMemberEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;
import com.imop.lj.gameserver.corps.model.Corps;
import com.imop.lj.gameserver.corps.model.CorpsMember;

/**
 * 军团数据管理器
 * 
 * @author xiaowei.liu
 * 
 */
public class CorpsDbManager {
	private static CorpsDbManager corpsDbManager = new CorpsDbManager();

	private CorpsDbManager(){
		
	}
	/**
	 * 获取实例
	 * 
	 * @return
	 */
	public static CorpsDbManager getInstance() {
		return corpsDbManager;
	}
	
	/**
	 * 保存军团成员
	 * 
	 * @param corpsMember
	 * @param async
	 *            为true则异步保存，为false则同步保存
	 */
	public void saveCorpsMember(CorpsMember corpsMember, boolean async) {
		IIoOperation _oper = new SaveObjectOperation<CorpsMemberEntity, CorpsMember>(corpsMember, getCorpsMemberDao());
		if (async) {
			Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
		} else {
			Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_oper);
		}
	}
	
	/**
	 * 删除军团成员
	 * 
	 * @param secretary
	 * @param async
	 *            为true则异步保存，为false则同步保存
	 */
	public void delCorpsMember(CorpsMember corpsMember, boolean async) {
		final long _charId = corpsMember.getDbId();
		CorpsMemberEntity corpsMemberEntity = corpsMember.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<CorpsMemberEntity>(corpsMemberEntity, _charId, getCorpsMemberDao());
		if (async) {
			Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
		} else {
			Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_oper);
		}
	}
	
	/**
	 * 保存军团成员
	 * 
	 * @param corpsMember
	 * @param async
	 *            为true则异步保存，为false则同步保存
	 */
	public void saveCorps(Corps corps, boolean async) {
		IIoOperation _oper = new SaveObjectOperation<CorpsEntity, Corps>(corps, getCorpsDao());
		if (async) {
			Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
		} else {
			Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_oper);
		}
	}
	
	/**
	 * 删除军团成员
	 * 
	 * @param secretary
	 * @param async
	 *            为true则异步保存，为false则同步保存
	 */
	public void delCorps(Corps corps, boolean async) {
		final long _charId = corps.getDbId();
		CorpsEntity corpsEntity = corps.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<CorpsEntity>(corpsEntity, _charId, getCorpsDao());
		if (async) {
			Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
		} else {
			Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_oper);
		}
	}
	
	/**
	 * 获取军团成员Dao
	 * 
	 * @return
	 */
	private CorpsMemberDao getCorpsMemberDao(){
		return Globals.getDaoService().getCorpsMemberDao();
	}
	
	/**
	 * 获取军团Dao
	 * @return
	 */
	private CorpsDao getCorpsDao(){
		return Globals.getDaoService().getCorpsDao();
	}
}
