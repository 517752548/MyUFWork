package com.imop.lj.gameserver.vip.persistance;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.vip.Vip;

/**
 * Vip更新器
 * 
 * @author xiaowei.liu
 * 
 */
public class VipUpdater implements POUpdater {

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final Vip vip = (Vip)obj;
		VipDbManager.getInstance().saveVip(vip, true);
	}

	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		final Vip vip = (Vip)obj;
		VipDbManager.getInstance().delVip(vip, true);
	}

}
