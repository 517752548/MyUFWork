package com.imop.lj.gameserver.func.allfunc;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.AbstractFunc;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;

/**
 * 帮派建设
 * 
 */
public class CorpsBuildFunc extends AbstractFunc {

	public CorpsBuildFunc(Human human, FuncTypeEnum funcType) {
		super(human, funcType);
	}

	@Override
	public boolean canOpen() {
		return Globals.getFuncService().hasOpenedFunc(getOwner(), getFuncType());
	}

	@Override
	public boolean canShowEffect() {
		return Globals.getCorpsService().isNeedBuild(getOwner());
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
