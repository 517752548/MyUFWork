package com.imop.lj.gameserver.common.listener;

import com.imop.lj.core.event.IEventListener;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.event.FightPowerChangeEvent;
import com.imop.lj.gameserver.human.Human;

public class FightPowerChangeListener implements IEventListener<FightPowerChangeEvent> {

	@Override
	public void fireEvent(FightPowerChangeEvent event) {
		Human human = event.getInfo();
		int old = event.getOld();
		int cur = event.getCur();
		
		// 精彩活动
		Globals.getGoodActivityService().onPlayerDoSth(human, event);
	}
}
