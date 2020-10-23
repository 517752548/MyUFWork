
package com.imop.lj.gameserver.func.allfunc;

import com.imop.lj.gameserver.func.AbstractFunc;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;

/**
 * 在线礼包功能
 * 
 * @author xiaowei.liu
 * 
 */
public class OnlineGiftFunc extends AbstractFunc {

	public OnlineGiftFunc(Human human, FuncTypeEnum funcType) {
		super(human, funcType);
	}

	@Override
	public boolean canOpen() {

//		return Globals.getFuncService().hasOpenedFunc(getOwner(), getFuncType());
		return this.getOwner().getOnlineGiftManager().isOpening();
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
//		if(getOwner().getOnlineGiftManager().isOpening()){
//			return getOwner().getOnlineGiftManager().getCd();
//		}else{
//			return 0;
//		}
	}

}
