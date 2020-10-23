package com.imop.lj.gameserver.common.listener;

import com.imop.lj.core.event.IEventListener;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.event.ArenaRefreshEvent;

public class ArenaRefreshListener implements IEventListener<ArenaRefreshEvent> {

	@Override
	public void fireEvent(ArenaRefreshEvent event) {
		// 精彩活动
		Globals.getGoodActivityService().onTriggerEvent(event);
		
	}
}
