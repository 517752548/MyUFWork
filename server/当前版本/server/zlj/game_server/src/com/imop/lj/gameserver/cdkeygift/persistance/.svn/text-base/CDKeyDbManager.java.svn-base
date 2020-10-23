package com.imop.lj.gameserver.cdkeygift.persistance;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.CDKeyDao;
import com.imop.lj.db.model.CDKeyEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月25日 下午4:22:19
 * @version 1.0
 */

public class CDKeyDbManager {
	
	public static CDKeyDbManager cdkeyDbManager = new CDKeyDbManager();
	
	private CDKeyDbManager(){}
	
	/***
	 * 获得实体
	 */
	public static CDKeyDbManager getInstance(){
		return cdkeyDbManager;
	}
	
	/***
	 * 保存
	 * @param po
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void saveEntity(CDKeyPO po, boolean async){
		IIoOperation _oper = new SaveObjectOperation<CDKeyEntity, CDKeyPO>(po, getCDKeyDao());
		if (async) {
			Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
		} else {
			Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_oper);
		}
	}
	
	/**
	 * 取得Dao实例
	 * @return
	 */
	private CDKeyDao getCDKeyDao() {
		return Globals.getDaoService().getCDKeyDao();
	}
}
