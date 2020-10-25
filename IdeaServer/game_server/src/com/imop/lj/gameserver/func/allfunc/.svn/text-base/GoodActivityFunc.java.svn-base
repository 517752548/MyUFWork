package com.imop.lj.gameserver.func.allfunc;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.AbstractFunc;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;

public class GoodActivityFunc extends AbstractFunc {

	public GoodActivityFunc(Human human, FuncTypeEnum funcType) {
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
		// 是否有可领取的奖励
		return Globals.getGoodActivityService().hasBonus(getOwner(), getFuncType());
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
