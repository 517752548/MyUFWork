package com.imop.lj.gameserver.cdkeygift.persistance;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月25日 下午4:21:05
 * @version 1.0
 */

public class CDKeyDataUpdater implements POUpdater {

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final CDKeyPO po = (CDKeyPO)obj;
		CDKeyDbManager.getInstance().saveEntity(po, true);
	}

	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		
	}
}
