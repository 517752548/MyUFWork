package com.imop.lj.gameserver.timeevent.msg;

import com.imop.lj.core.msg.sys.ScheduledMessage;

public class TimeEventTaskMsg extends ScheduledMessage {

	private Runnable run;

	public TimeEventTaskMsg(long createTime, Runnable run) {
		super(createTime);
		this.run = run;
	}

	@Override
	public void execute() {
		this.run.run();
	}

}
