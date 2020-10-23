package com.imop.lj.gameserver.mail;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.dao.MailDao;
import com.imop.lj.db.model.MailEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;

public class MailUpdater implements POUpdater  {
	
	@Override
	public void save(PersistanceObject<?, ?> obj) {
		MailDao mailDao = Globals.getDaoService().getMailDao();
		IIoOperation _oper = new SaveObjectOperation<MailEntity, MailInstance>((MailInstance) obj, mailDao);
		Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);	
	}

	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		MailDao mailDao = Globals.getDaoService().getMailDao();
		MailEntity mail = (MailEntity) obj.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<MailEntity>(mail, mail
				.getCharId(), mailDao);
		Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
	}

}
