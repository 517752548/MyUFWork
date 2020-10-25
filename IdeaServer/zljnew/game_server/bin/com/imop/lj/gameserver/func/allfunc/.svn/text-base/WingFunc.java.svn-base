package com.imop.lj.gameserver.func.allfunc;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.AbstractFunc;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;

/**
 * 翅膀
 * 
 */
public class WingFunc extends AbstractFunc {

	public WingFunc(Human human, FuncTypeEnum funcType) {
		super(human, funcType);
	}

	@Override
	public boolean canOpen() {
		return Globals.getFuncService().hasOpenedFunc(getOwner(), getFuncType());
	}

	@Override
	public boolean canShowEffect() {
		return Globals.getWingService().isNeedUpgrade(getOwner());
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
