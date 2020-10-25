package com.imop.lj.gameserver.title.persistance;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.title.Title;
import com.imop.lj.gameserver.title.TitleDbManager;

/**
 * Created by zhangzhe on 15/12/17.
 */
public class TitleUpdater implements POUpdater {
    @Override
    public void save(PersistanceObject<?, ?> obj) {
        final Title task = (Title)obj;
        TitleDbManager.getInstance().saveTitleEntity(task, true);
    }

    @Override
    public void delete(PersistanceObject<?, ?> obj) {
        final Title title = (Title)obj;
        TitleDbManager.getInstance().delTitleEntity(title, true);
    }
}
