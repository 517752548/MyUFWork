package com.imop.lj.gameserver.status;

import com.imop.lj.core.msg.sys.ScheduledMessage;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.status.msg.CheckSessionMsg;

public class ScheduleCheckISessions extends ScheduledMessage{
	
	public ScheduleCheckISessions(long createTime) {
		super(createTime);	
	}

	@Override
	public void execute() {
		CheckSessionMsg msg = new CheckSessionMsg();
		Globals.getMessageProcessor().put(msg);
	}
}
