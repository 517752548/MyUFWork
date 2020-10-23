package com.imop.lj.gameserver.vip.persistance;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.VipDao;
import com.imop.lj.db.model.VipEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;
import com.imop.lj.gameserver.vip.Vip;

public class VipDbManager {
	private static VipDbManager vipDbManager = new VipDbManager();
	
	/**
	 * 获取实例
	 * 
	 * @return
	 */
	public static VipDbManager getInstance() {
		return vipDbManager;
	}
	
	/**
	 * 保存VIP
	 * 
	 * @param vip
	 * @param async
	 *            为true则异步保存，为false则同步保存
	 */
	public void saveVip(Vip vip, boolean async) {
		IIoOperation _oper = new SaveObjectOperation<VipEntity, Vip>(vip, getVipDao());
		if (async) {
			Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
		} else {
			Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_oper);
		}
	}
	
	/**
	 * 删除VIP
	 * 
	 * @param vip
	 * @param async
	 *            为true则异步保存，为false则同步保存
	 */
	public void delVip(Vip vip, boolean async) {
		final long _charId = vip.getDbId();
		VipEntity vipEntity = vip.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<VipEntity>(vipEntity, _charId, getVipDao());
		if (async) {
			Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
		} else {
			Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_oper);
		}
	}
	
	private VipDao getVipDao(){
		return Globals.getDaoService().getVipDao();
	}
}
