package com.imop.lj.gameserver.mall;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.MallDao;
import com.imop.lj.db.model.MallEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;

/**
 * 商城数据库管理
 * 
 * @author xiaowei.liu
 * 
 */
public class MallDbManager {
	private static MallDbManager mallDbManager = new MallDbManager();
	
	/**
	 * 获取实例
	 * 
	 * @return
	 */
	public static MallDbManager getInstance() {
		return mallDbManager;
	}
	
	/**
	 * 保存mall
	 * 
	 * @param mall
	 * @param async
	 *            为true则异步保存，为false则同步保存
	 */
	public void saveMall(Mall mall, boolean async) {
		IIoOperation _oper = new SaveObjectOperation<MallEntity, Mall>(mall, getMallDao());
		if (async) {
			Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
		} else {
			Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_oper);
		}
	}
	
	/**
	 * 删除mall
	 * 
	 * @param mall
	 * @param async
	 *            为true则异步保存，为false则同步保存
	 */
	public void delMall(Mall mall, boolean async) {
		final long _charId = mall.getDbId();
		MallEntity mallEntity = mall.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<MallEntity>(mallEntity, _charId, getMallDao());
		if (async) {
			Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
		} else {
			Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_oper);
		}
	}
	
	private MallDao getMallDao(){
		return Globals.getDaoService().getMallDao();
	}
}
