package com.imop.lj.gameserver.moneyreport.updater;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.model.ItemCostRecordEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;

public class ItemCostRecordUpdater implements POUpdater {

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final ItemCostRecord itemCostRecord = (ItemCostRecord)obj;
		saveItemCostRecordData(itemCostRecord, true);
	}

	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		final ItemCostRecord itemCostRecord = (ItemCostRecord)obj;
		delItemCostRecordData(itemCostRecord, true);
	}
	
	
	/***
	 * 保存玩家消耗物品记录
	 * @param periodLottery
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void saveItemCostRecordData(ItemCostRecord itemCostRecord, boolean async){
		IIoOperation _oper = new SaveObjectOperation<ItemCostRecordEntity, ItemCostRecord>(itemCostRecord, Globals.getDaoService().getItemCostRecordDao());
		if (async) {
			Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
		} else {
			Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_oper);
		}
	}
	
	/***
	 * 删除玩家消耗物品记录
	 * @param periodLottery
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void delItemCostRecordData(ItemCostRecord itemCostRecord, boolean async) {
		final long _charId = itemCostRecord.getDbId();
		ItemCostRecordEntity itemCostEntity = itemCostRecord.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<ItemCostRecordEntity>(itemCostEntity, _charId, Globals.getDaoService().getItemCostRecordDao());
		if (async) {
			Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
		} else {
			Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_oper);
		}
	}

}
