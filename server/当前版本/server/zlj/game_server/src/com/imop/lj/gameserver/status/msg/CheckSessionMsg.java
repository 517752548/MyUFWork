package com.imop.lj.gameserver.status.msg;

import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;

public class CheckSessionMsg  extends SysInternalMessage {

	@Override
	public void execute() {
		Globals.getCheckSessionService().checkISessions();
	}
}
