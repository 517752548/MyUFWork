package com.imop.lj.gameserver.func.allfunc;

import com.imop.lj.gameserver.func.AbstractFunc;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;

public class QuestFunc extends AbstractFunc {

	public QuestFunc(Human human, FuncTypeEnum funcType) {
		super(human, funcType);
	}
	
	@Override
	public boolean canOpen() {
		// 任务功能写死，必须有此功能
		return true;
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
