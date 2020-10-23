package com.imop.lj.gameserver.mall;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;

/**
 * 商城更新器
 * 
 * @author xiaowei.liu
 * 
 */
public class MallUpdater implements POUpdater {

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		Mall mall = (Mall)obj;
		MallDbManager.getInstance().saveMall(mall, true);
	}

	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		Mall mall = (Mall)obj;
		MallDbManager.getInstance().delMall(mall, true);
	}

}
