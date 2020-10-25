package com.imop.lj.gameserver.redenvelope.persistance;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.RedEnvelopeDao;
import com.imop.lj.db.model.RedEnvelopeEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;
import com.imop.lj.gameserver.redenvelope.RedEnvelope;

public class RedEnvelopeDbManager {
	public static RedEnvelopeDbManager redEnvelopeDbManager = new RedEnvelopeDbManager();
	private RedEnvelopeDbManager(){}
	
	/***
	 * 获得实体
	 */
	public static RedEnvelopeDbManager getInstance() {
		return redEnvelopeDbManager;
	}
	
	/***
	 * 保存
	 * @param redEnvelope
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void saveEntity(RedEnvelope redEnvelope, boolean async){
		IIoOperation _oper = new SaveObjectOperation<RedEnvelopeEntity, RedEnvelope>(redEnvelope, getRedEnvelopeDao());
		if (async) {
			Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
		} else {
			Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_oper);
		}
	}
	
	/***
	 * 删除
	 * @param redEnvelope
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void delEntity(RedEnvelope redEnvelope, boolean async) {
		final long _charId = redEnvelope.getCharId();
		RedEnvelopeEntity landlordEntity = redEnvelope.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<RedEnvelopeEntity>(landlordEntity, _charId, getRedEnvelopeDao());
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
	private RedEnvelopeDao getRedEnvelopeDao() {
		return Globals.getDaoService().getRedEnvelopeDao();
	}
}
