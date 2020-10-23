package com.imop.lj.gameserver.telnet.command;

import java.util.Map;

import org.apache.mina.core.session.IoSession;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.dirtywords.DirtyWordsSetSysMessage;

public class DirtyWordsSetCommand extends LoginedTelnetCommand {

	public DirtyWordsSetCommand() {
		//dirtyWorldsSet
		super("DIRTYWORLDSSET");
	}

	@Override
	protected void doExec(String command, Map<String, String> params,
			IoSession session) {
		String activityStr = getCommandParam(command);
		if(activityStr==null || activityStr.equals("")){
			sendError(session, "No param");
			return;
		}
		
		DirtyWordsSetSysMessage msg = new DirtyWordsSetSysMessage(activityStr);
		Globals.getSceneService().getCommonScene().putMessage(msg);
	}

}