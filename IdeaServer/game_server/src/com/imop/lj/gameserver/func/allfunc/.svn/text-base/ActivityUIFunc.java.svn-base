package com.imop.lj.gameserver.func.allfunc;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.AbstractFunc;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;

public class ActivityUIFunc extends AbstractFunc {

	public ActivityUIFunc(Human human, FuncTypeEnum funcType) {
		super(human, funcType);
	}

	@Override
	public boolean canOpen() {
		return Globals.getFuncService().hasOpenedFunc(getOwner(), getFuncType());
	}

	@Override
	public boolean canShowEffect() {
		//当有未领取的活跃值奖励，活动按钮右上角显示红色圆点提示
		return Globals.getActivityUIService().canGetActivityUIReward(getOwner());
	}

	@Override
	public int getShowNum() {
		// 不显示数字角标
		return 0;
	}

	@Override
	public long getCountDownTime() {
		//没有倒计时
		return 0;
	}

}
