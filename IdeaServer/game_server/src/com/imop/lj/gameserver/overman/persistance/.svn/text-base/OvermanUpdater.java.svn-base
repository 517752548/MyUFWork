package com.imop.lj.gameserver.overman.persistance;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.overman.Overman;
import com.imop.lj.gameserver.overman.OvermanDbManager;

/**
 * Created by zhangzhe on 15/12/25.
 */
public class OvermanUpdater implements POUpdater {
    @Override
    public void save(PersistanceObject<?, ?> obj) {
        final Overman overman = (Overman) obj;
        OvermanDbManager.getInstance().saveOvermanEntity(overman, true);
    }

    @Override
    public void delete(PersistanceObject<?, ?> obj) {
        final Overman overman = (Overman) obj;
        OvermanDbManager.getInstance().delOvermanEntity(overman,true);
    }
}
