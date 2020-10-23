package com.imop.lj.gameserver.wing.persistance;

import java.util.List;

import com.imop.lj.common.constants.CommonErrorLogInfo;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.core.orm.DataAccessException;
import com.imop.lj.core.util.ErrorsUtil;
import com.imop.lj.db.dao.WingDao;
import com.imop.lj.db.model.WingEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;
import com.imop.lj.gameserver.wing.Wing;
import com.imop.lj.gameserver.wing.WingManager;

public class WingDbManager {
	public static WingDbManager wingDbManager = new WingDbManager();
	private WingDbManager(){}
	
	/***
	 * 获得实体
	 */
	public static WingDbManager getInstance(){
		return wingDbManager;
	}
	
    public List<WingEntity> loadWingsFromDB(WingManager wingManager) {
        long charId = wingManager.getOwner().getCharId();
        List<WingEntity> wingList = null;

        try {
            wingList = getWingDao().getWingsByCharId(charId);

        } catch (DataAccessException e) {
            if (Loggers.wingLogger.isErrorEnabled()) {
                Loggers.wingLogger.error(ErrorsUtil.error(CommonErrorLogInfo.DB_OPERATE_FAIL, "#GS.WingDbManager.loadWingsFromDB", null), e);

            }
        }
        return wingList;
    }
	
	/***
	 * 保存
	 * @param wing
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void saveEntity(Wing wing, boolean async){
		IIoOperation _oper = new SaveObjectOperation<WingEntity, Wing>(wing, getWingDao());
		if (async) {
			Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
		} else {
			Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_oper);
		}
	}
	
	/***
	 * 删除
	 * @param wing
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void delEntity(Wing wing, boolean async) {
		final long _charId = wing.getCharId();
		WingEntity landlordEntity = wing.toEntity();
		IIoOperation _oper = new DeleteEntityOperation<WingEntity>(landlordEntity, _charId, getWingDao());
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
	private WingDao getWingDao() {
		return Globals.getDaoService().getWingDao();
	}
}
