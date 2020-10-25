package com.imop.lj.gameserver.foragetask.confirm;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.ConsumeConfirm;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.IStaticHandler;

/**
 * 护送粮草押金银票不足，提示用剩余银子抵用
 * 
 */
public class DepositNotEnoughForageTaskHandler extends IStaticHandler {

	@Override
	public void exec(Human human, boolean isOk) {
		if (isOk) {
			Globals.getForageTaskService().depositWithOtherCurrency(human);
		}
	}

	@Override
	public ConsumeConfirm getConsumeConfirm() {
		return ConsumeConfirm.FORAGE_NOT_ENOUGH;
	}

}
