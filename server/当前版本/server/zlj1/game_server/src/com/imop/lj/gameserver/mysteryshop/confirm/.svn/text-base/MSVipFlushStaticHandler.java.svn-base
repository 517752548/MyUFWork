package com.imop.lj.gameserver.mysteryshop.confirm;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.ConsumeConfirm;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.IStaticHandler;

/**
 * 高级刷新
 * 
 * @author xiaowei.liu
 * 
 */
public class MSVipFlushStaticHandler extends IStaticHandler {

	@Override
	public void exec(Human human, boolean isOk) {
		if(isOk){
			Globals.getMysteryShopService().handleVipFlushMystery(human, false);
		}

	}

	@Override
	public ConsumeConfirm getConsumeConfirm() {
		return ConsumeConfirm.NULL;//FIXME
	}

}
