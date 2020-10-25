package com.imop.lj.gameserver.offlinereward;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.dao.OfflineRewardDao;
import com.imop.lj.db.model.OfflineRewardEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;

public class OfflineRewardUpdater implements POUpdater  {
	
	@Override
	public void save(PersistanceObject<?, ?> obj) {
		OfflineRewardDao offlineRewardDao = Globals.getDaoService().getOfflineRewardDao();
		IIoOperation _oper = new SaveObjectOperation<OfflineRewardEntity, OfflineReward>((OfflineReward) obj, offlineRewardDao);
		Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);	
	}

	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		OfflineRewardDao offlineRewardDao = Globals.getDaoService().getOfflineRewardDao();
		OfflineRewardEntity offlineRewardEntity = (OfflineRewardEntity) obj.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<OfflineRewardEntity>(offlineRewardEntity, offlineRewardEntity.getCharId(), offlineRewardDao);
		Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
	}

}
