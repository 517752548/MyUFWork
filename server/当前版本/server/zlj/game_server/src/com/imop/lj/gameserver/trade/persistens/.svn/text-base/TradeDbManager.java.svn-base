package com.imop.lj.gameserver.trade.persistens;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.TradeDao;
import com.imop.lj.db.model.TradeEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;
import com.imop.lj.gameserver.trade.Trade;

public class TradeDbManager {
	public static TradeDbManager tradeDbManager = new TradeDbManager();
	private TradeDbManager(){}
	
	/***
	 * 获得实体
	 */
	public static TradeDbManager getInstance(){
		return tradeDbManager;
	}
	
	/***
	 * 保存
	 * @param trade
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void saveTradeEntity(Trade trade, boolean async){
		IIoOperation _oper = new SaveObjectOperation<TradeEntity, Trade>(trade, getTradeDao());
		if (async) {
			Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
		} else {
			Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_oper);
		}
	}
	
	/***
	 * 删除
	 * @param trade
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void delTradeEntity(Trade trade, boolean async) {
		final long _charId = trade.getCharId();
		TradeEntity tradeEntity = trade.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<TradeEntity>(tradeEntity, _charId, getTradeDao());
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
	private TradeDao getTradeDao() {
		return Globals.getDaoService().getTradeDao();
	}
}
