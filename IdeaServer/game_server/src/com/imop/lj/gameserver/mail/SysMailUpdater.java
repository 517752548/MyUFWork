package com.imop.lj.gameserver.mail;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;

public class SysMailUpdater implements POUpdater{
	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		
		final SysMailInstance sysMail = (SysMailInstance)obj;
		SysMailDbManager.getInstance().delSysMailEntity(sysMail, true);
	}

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final SysMailInstance sysMail = (SysMailInstance)obj;
		SysMailDbManager.getInstance().saveSysMailEntity(sysMail, true);
	}
}
