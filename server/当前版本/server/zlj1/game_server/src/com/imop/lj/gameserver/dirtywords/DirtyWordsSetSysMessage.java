package com.imop.lj.gameserver.dirtywords;

import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;

public class DirtyWordsSetSysMessage extends SysInternalMessage {
	private String mobileActivityStr;
	public DirtyWordsSetSysMessage(String mobileActivityStr){
		this.mobileActivityStr = mobileActivityStr;
	}
	@Override
	public void execute() {
		Globals.getDirtFilterService().dirtyWorldsGM(mobileActivityStr);
	}
}
