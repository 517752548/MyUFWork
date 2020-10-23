package com.imop.lj.gameserver.func.allfunc;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.AbstractFunc;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;

public class SiegeDemonNormalFunc extends AbstractFunc {

	public SiegeDemonNormalFunc(Human human, FuncTypeEnum funcType) {
		super(human, funcType);
	}

	@Override
	public boolean canOpen() {
		// 判断玩家是否有此功能
		boolean flag = Globals.getFuncService().hasOpenedFunc(getOwner(), getFuncType());
		return flag;
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
