package com.imop.lj.gameserver.func.allfunc;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.AbstractFunc;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;

/**
 * GM补偿
 * 
 * @author xiaowei.liu
 * 
 */
public class UserPrizeFunc extends AbstractFunc {
	
	public UserPrizeFunc(Human human, FuncTypeEnum funcType) {
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
		return getOwner().getPrizeNum();
	}

	@Override
	public long getCountDownTime() {
		return 0;
	}
	
	

}
