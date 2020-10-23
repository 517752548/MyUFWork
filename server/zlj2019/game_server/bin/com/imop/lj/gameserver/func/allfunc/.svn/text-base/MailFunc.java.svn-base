package com.imop.lj.gameserver.func.allfunc;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.AbstractFunc;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;

public class MailFunc extends AbstractFunc {

	public MailFunc(Human human, FuncTypeEnum funcType) {
		super(human, funcType);
	}
	
	@Override
	public boolean canOpen() {
		// 判断玩家是否有此功能
		return Globals.getFuncService().hasOpenedFunc(getOwner(), getFuncType());
	}

	@Override
	public boolean canShowEffect() {
		//是否有未读邮件
		boolean flag = false;
		if (null != getOwner() && null != getOwner().getMailbox()) {
			flag = getOwner().getMailbox().hasNewMail();
		}
		return flag;
	}

	@Override
	public int getShowNum() {
//		// 未读邮件数量
//		int num = 0;
//		if (null != getOwner() && null != getOwner().getMailbox()) {
//			num = getOwner().getMailbox().getUnReadMailNum();
//		}
//		return num;
		return 0;
	}

	@Override
	public long getCountDownTime() {
		// 没有倒计时
		return 0;
	}

}
