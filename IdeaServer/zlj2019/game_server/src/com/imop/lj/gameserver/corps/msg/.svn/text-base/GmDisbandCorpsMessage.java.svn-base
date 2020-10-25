package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;

public class GmDisbandCorpsMessage extends SysInternalMessage {
	private long corpsId;
	
	public GmDisbandCorpsMessage(long corpsId){
		this.corpsId = corpsId;
	}
	@Override
	public void execute() {
		Globals.getCorpsService().gmDisband(corpsId);
	}

}
