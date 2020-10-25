package com.imop.lj.gameserver.telnet.command;

import java.util.Map;

import org.apache.mina.core.session.IoSession;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.goodactivity.msg.sysmsg.GmGoodActivityAvailableSysMsg;

public class GoodActivityAvailableCommand extends LoginedTelnetCommand {

	public GoodActivityAvailableCommand() {
		super("GOOD_ACTIVITY_AVAILABLE");
	}

	@Override
	protected void doExec(String command, Map<String, String> params,
			IoSession session) {
		String activityStr = getCommandParam(command);
		if(activityStr == null || activityStr.equals("")){
			sendError(session, "No param");
			return;
		}
		
		GmGoodActivityAvailableSysMsg msg = new GmGoodActivityAvailableSysMsg(activityStr);
		Globals.getSceneService().getCommonScene().putMessage(msg);
	}

}
