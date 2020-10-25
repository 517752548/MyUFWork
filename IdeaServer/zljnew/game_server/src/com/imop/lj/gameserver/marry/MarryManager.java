package com.imop.lj.gameserver.marry;

import com.imop.lj.gameserver.common.db.RoleDataHolder;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.JsonPropDataHolder;

/**
 * Created by fengmaogen on 15/12/28.
 */
public class MarryManager implements JsonPropDataHolder, RoleDataHolder {

    private Human human;

    public Human getOwner() {

        return human;
    }

    @Override
    public String toJsonProp() {
        return null;
    }

    @Override
    public void loadJsonProp(String value) {

    }

    @Override
    public void checkAfterRoleLoad() {

    }

    @Override
    public void checkBeforeRoleEnter() {

    }
}
