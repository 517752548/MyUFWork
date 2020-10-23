package com.imop.lj.gameserver.telnet.command;

import java.util.Map;

import org.apache.mina.core.session.IoSession;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.goodactivity.msg.sysmsg.GmGoodActivityForceEndSysMsg;

public class GoodActivityForceEndCommand extends LoginedTelnetCommand {

	public GoodActivityForceEndCommand() {
		super("GOOD_ACTIVITY_FORCE_END");
	}

	@Override
	protected void doExec(String command, Map<String, String> params,
			IoSession session) {
		String activityStr = getCommandParam(command);
		if(activityStr==null || activityStr.equals("")){
			sendError(session, "No param");
			return;
		}
		
		GmGoodActivityForceEndSysMsg msg = new GmGoodActivityForceEndSysMsg(activityStr);
		Globals.getSceneService().getCommonScene().putMessage(msg);
	}

}
