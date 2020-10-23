package com.imop.lj.gameserver.corps.confirm;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.ConsumeConfirm;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.IStaticHandler;

/**
 * 退出军团二次提示
 * 
 * @author xiaowei.liu
 * 
 */
public class ExitCorpsStatefulHandler extends IStaticHandler {

	@Override
	public void exec(Human human, boolean isOk) {
		if (isOk) {
			Globals.getCorpsService().exitCorpsOnly(human);
		}
	}

	@Override
	public ConsumeConfirm getConsumeConfirm() {
		return ConsumeConfirm.CORPS_EXIT;
	}

}
