package com.imop.lj.gameserver.common.listener;

import com.imop.lj.core.event.IEventListener;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.event.GoodActivityFinishTargetEvent;

public class GoodActivityFinishTargetListener implements IEventListener<GoodActivityFinishTargetEvent> {

	@Override
	public void fireEvent(GoodActivityFinishTargetEvent event) {
		// 精彩活动
		Globals.getGoodActivityService().onFinishTarget(event.getRoleId(), event.getGoodActivityId(), event.getTargetId());
	}
	
}
