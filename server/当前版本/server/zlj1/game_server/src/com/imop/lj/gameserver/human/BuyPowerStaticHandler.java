package com.imop.lj.gameserver.human;

import com.imop.lj.gameserver.human.handler.HumanHandlerFactory;
import com.imop.lj.gameserver.player.IStaticHandler;

/**
 * 购买体力二次确认框
 * 
 */
public class BuyPowerStaticHandler extends IStaticHandler {
	
	public BuyPowerStaticHandler() {
		
	}

	@Override
	public void exec(Human human, boolean isOk) {
		if(isOk){
			// 确认
			HumanHandlerFactory.getHandler().buyPowerConfirm(human);
		}
	}

	@Override
	public ConsumeConfirm getConsumeConfirm() {
		return ConsumeConfirm.BUY_POWER_NUM;
	}
}
