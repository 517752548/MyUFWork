package com.imop.lj.gameserver.telnet.command;

import java.util.Map;

import org.apache.mina.core.session.IoSession;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.dirtywords.DirtyWordsRefreshSysMessage;

public class DirtyWordsRefreshCommand extends LoginedTelnetCommand {

	public DirtyWordsRefreshCommand() {
		//dirtyWorldsRefrash
		super("DIRTYWORLDSREFRASH");
	}

	@Override
	protected void doExec(String command, Map<String, String> params,
			IoSession session) {
		DirtyWordsRefreshSysMessage msg = new DirtyWordsRefreshSysMessage();
		Globals.getSceneService().getCommonScene().putMessage(msg);
	}

}
