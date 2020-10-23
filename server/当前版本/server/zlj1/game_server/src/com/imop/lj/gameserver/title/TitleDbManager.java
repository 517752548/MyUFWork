package com.imop.lj.gameserver.title;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.dao.TitleDao;
import com.imop.lj.db.model.TitleEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;

/**
 * Created by zhangzhe on 15/12/16.
 */
public class TitleDbManager {

    private static TitleDbManager instance = new TitleDbManager();

    private TitleDbManager() {

    }

    public static TitleDbManager getInstance() {

        return instance;
    }


    /**
     * 取得title的Dao实例
     *
     * @return
     */
    private TitleDao getTitleDao() {
        return Globals.getDaoService().getTitleDao();
    }

    public void saveTitleEntity(Title title, boolean async) {
        IIoOperation _oper = new SaveObjectOperation<TitleEntity, Title>(title, getTitleDao());
        if (async) {
            Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
        } else {
            Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_oper);
        }
    }

    /***
     * 删除
     *
     * @param title
     * @param async 为true则异步保存，为false则同步保存
     */
    public void delTitleEntity(Title title, boolean async) {
        final long _charId = title.getCharId();
        TitleEntity titleEntity = title.toEntity();
        IIoOperation _oper = new DeleteEntityOperation<TitleEntity>(titleEntity, _charId, getTitleDao());
        if (async) {
            Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
        } else {
            Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_oper);
        }
    }
}
