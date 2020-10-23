package com.imop.lj.gameserver.corps.confirm;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.ConsumeConfirm;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.IStaticHandler;

/**
 * 准备解散军团二次提示
 * 
 * @author xiaowei.liu
 * 
 */
public class ReadyDisbandCorpsStatefulHandler extends IStaticHandler {

	@Override
	public void exec(Human human, boolean isOk) {
		if(isOk){
			Globals.getCorpsService().readyDisbandCorps(human);
		}
	}

	@Override
	public ConsumeConfirm getConsumeConfirm() {
		return ConsumeConfirm.CORPS_DISBAND;
	}
}
