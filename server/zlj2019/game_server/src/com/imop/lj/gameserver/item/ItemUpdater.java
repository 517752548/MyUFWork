package com.imop.lj.gameserver.item;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.dao.ItemDao;
import com.imop.lj.db.model.ItemEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;

/**
 * 物品数据管理
 *
 */
public class ItemUpdater implements POUpdater {

	@Override
	public void save(PersistanceObject<?,?> obj) {
		ItemDao itemDao = Globals.getDaoService().getItemDao();
		IIoOperation _oper = new SaveObjectOperation<ItemEntity, Item>((Item) obj, itemDao);
		Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
	}

	@Override
	public void delete(PersistanceObject<?,?> obj) {
		ItemDao itemDao = Globals.getDaoService().getItemDao();
		ItemEntity item = (ItemEntity) obj.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<ItemEntity>(item, item
				.getCharId(), itemDao);
		Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
	}

}
