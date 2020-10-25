package com.imop.lj.gameserver.overman;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.OvermanDao;
import com.imop.lj.db.model.OvermanEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;

/**
 * Created by zhangzhe on 15/12/24.
 */
public class OvermanDbManager {
    private static OvermanDbManager instance = new OvermanDbManager();

    private OvermanDbManager(){

    }
    public static OvermanDbManager getInstance() {

        return instance;
    }

    /**
     * 取得title的Dao实例
     *
     * @return
     */
    private OvermanDao getOvermanDao() {
        return Globals.getDaoService().getOvermanDao();
    }

    public void saveOvermanEntity(Overman overman, boolean async){
        IIoOperation _oper = new SaveObjectOperation<OvermanEntity, Overman>(overman, getOvermanDao());
        if (async) {
            Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
        } else {
            Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_oper);
        }
    }
    /***
     * 删除
     * @param overman
     * @param async 为true则异步保存，为false则同步保存
     */
    public void delOvermanEntity(Overman overman, boolean async) {
        final long _charId = overman.getCharId();
        OvermanEntity overmanEntity = overman.toEntity();
        IIoOperation _oper = new DeleteEntityOperation<OvermanEntity>(overmanEntity, _charId, getOvermanDao());
        if (async) {
            Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
        } else {
            Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_oper);
        }
    }

}
