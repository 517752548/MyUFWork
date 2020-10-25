package com.imop.lj.gameserver.func.allfunc;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.AbstractFunc;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;

public class PetFunc extends AbstractFunc {

	public PetFunc(Human human, FuncTypeEnum funcType) {
		super(human, funcType);
	}
	
	@Override
	public boolean canOpen() {
		// 判断玩家是否有此功能
		return Globals.getFuncService().hasOpenedFunc(getOwner(), getFuncType());
	}

	@Override
	public boolean canShowEffect() {
		// 没有特效
		return false;
	}

	@Override
	public int getShowNum() {
		// 不显示数字角标
		return 0;
	}

	@Override
	public long getCountDownTime() {
		// 没有倒计时
		return 0;
	}

}
