package com.imop.lj.gameserver.func.allfunc;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.AbstractFunc;
import com.imop.lj.gameserver.func.FuncDef;
import com.imop.lj.gameserver.human.Human;

public class CorpsWarFunc extends AbstractFunc {
	
    public CorpsWarFunc(Human human, FuncDef.FuncTypeEnum funcType) {
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
