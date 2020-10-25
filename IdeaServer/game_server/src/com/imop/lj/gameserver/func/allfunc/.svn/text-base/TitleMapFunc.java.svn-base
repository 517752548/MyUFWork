package com.imop.lj.gameserver.func.allfunc;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.AbstractFunc;
import com.imop.lj.gameserver.func.FuncDef;
import com.imop.lj.gameserver.human.Human;

/**
 * Created by zhangzhe on 15/12/14.
 */
public class TitleMapFunc extends AbstractFunc {
    public TitleMapFunc(Human human, FuncDef.FuncTypeEnum funcType) {
        super(human, funcType);
    }

    @Override
    public boolean canOpen() {
        return Globals.getFuncService().hasOpenedFunc(getOwner(), getFuncType());
    }

    @Override
    public boolean canShowEffect() {
        return false;
    }

    @Override
    public int getShowNum() {
        return 0;
    }

    @Override
    public long getCountDownTime() {
        return 0;
    }
}
