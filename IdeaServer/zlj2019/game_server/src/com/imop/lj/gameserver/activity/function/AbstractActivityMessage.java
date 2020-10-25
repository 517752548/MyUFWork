package com.imop.lj.gameserver.activity.function;

import java.util.Calendar;

import com.imop.lj.core.msg.SysInternalMessage;


public abstract class AbstractActivityMessage  extends SysInternalMessage{
	protected Calendar startCalendar;
	
	public void setStartCalendar(Calendar startCalendar) {
		this.startCalendar = startCalendar;
	}

	public abstract boolean isCanExecute();
}
