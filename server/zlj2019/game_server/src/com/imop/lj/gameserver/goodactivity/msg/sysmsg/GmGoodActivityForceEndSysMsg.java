package com.imop.lj.gameserver.goodactivity.msg.sysmsg;

import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;

public class GmGoodActivityForceEndSysMsg extends SysInternalMessage {
	private String goodActivityStr;
	
	public GmGoodActivityForceEndSysMsg(String goodActivityStr){
		this.goodActivityStr = goodActivityStr;
	}
	
	@Override
	public void execute() {
		Globals.getGoodActivityService().gmGoodActivityForceEnd(goodActivityStr);
	}
}