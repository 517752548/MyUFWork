package com.imop.lj.gameserver.trade.persistens;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.trade.Trade;

public class TradeUpdater implements POUpdater {
	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		final Trade trade = (Trade)obj;
		TradeDbManager.getInstance().delTradeEntity(trade, true);
	}

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final Trade trade = (Trade)obj;
		TradeDbManager.getInstance().saveTradeEntity(trade, true);
	}
}
