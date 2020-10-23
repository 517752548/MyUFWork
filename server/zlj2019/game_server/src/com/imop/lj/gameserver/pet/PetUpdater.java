package com.imop.lj.gameserver.pet;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.dao.PetDao;
import com.imop.lj.db.model.PetEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;

/**
 * 武将数据更新器
 * 
 */
public class PetUpdater implements POUpdater {

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		PetDao petDao = Globals.getDaoService().getPetDao();
		IIoOperation _oper = new SaveObjectOperation<PetEntity, Pet>((Pet) obj, petDao);
		Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
	}

	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		final Pet pet = (Pet)obj;
		PetEntity petEntity = pet.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<PetEntity>(petEntity, pet.getCharId(), Globals.getDaoService().getPetDao());
		Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
	}

}
