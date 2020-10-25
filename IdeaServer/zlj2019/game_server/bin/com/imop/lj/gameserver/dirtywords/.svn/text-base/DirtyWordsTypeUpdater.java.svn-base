package com.imop.lj.gameserver.dirtywords;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.dao.DirtyWordsTypeDao;
import com.imop.lj.db.model.DirtyWordsTypeEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;

public class DirtyWordsTypeUpdater implements POUpdater{

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		DirtyWordsTypeDao dirtyWorldsTypeDao = Globals.getDaoService().getDirtyWordsTypeDao();
		IIoOperation _oper = new SaveObjectOperation<DirtyWordsTypeEntity, DirtyWordsType>((DirtyWordsType) obj, dirtyWorldsTypeDao);
		Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
	}

	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		DirtyWordsTypeDao dirtyWorldsTypeDao = Globals.getDaoService().getDirtyWordsTypeDao();
		DirtyWordsTypeEntity entity = (DirtyWordsTypeEntity) obj.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<DirtyWordsTypeEntity>(entity, entity.getId(), dirtyWorldsTypeDao);
		Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
	}

}
