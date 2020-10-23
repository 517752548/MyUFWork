package com.imop.lj.gameserver.common.listener;

import com.imop.lj.core.event.IEventListener;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.event.CostMoneyEvent;
import com.imop.lj.gameserver.human.Human;

public class CostMoneyListener implements IEventListener<CostMoneyEvent> {

	@Override
	public void fireEvent(CostMoneyEvent event) {
		Human human = event.getInfo();
		
		// 精彩活动
		Globals.getGoodActivityService().onPlayerDoSth(human, event);
		
	}
}
