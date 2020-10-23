package com.imop.lj.gameserver.timeevent.msg;

import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;

/**
 * 定时事件服务开启消息
 *
 *
 */
public class SysTimeEventServiceStart extends SysInternalMessage {

	@Override
	public void execute() {
		Globals.getTimeQueueService().start();
	}

}
