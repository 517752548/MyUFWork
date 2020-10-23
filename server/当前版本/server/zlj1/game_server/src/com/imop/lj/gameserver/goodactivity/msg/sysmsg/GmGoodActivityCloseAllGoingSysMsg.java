package com.imop.lj.gameserver.goodactivity.msg.sysmsg;

import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;

public class GmGoodActivityCloseAllGoingSysMsg extends SysInternalMessage {
	
	public GmGoodActivityCloseAllGoingSysMsg(){
		
	}
	
	@Override
	public void execute() {
		Globals.getGoodActivityService().gmCloseAllActivity();
	}
}
