package com.imop.lj.gameserver.telnet.command;

import java.util.Map;

import org.apache.mina.core.session.IoSession;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.goodactivity.msg.sysmsg.GmGoodActivityUpdateSysMsg;

public class GoodActivityUpdateCommand extends LoginedTelnetCommand {

	public GoodActivityUpdateCommand() {
		super("GOOD_ACTIVITY_UPDATE");
	}

	@Override
	protected void doExec(String command, Map<String, String> params,
			IoSession session) {
		String activityStr = getCommandParam(command);
		if(activityStr==null || activityStr.equals("")){
			sendError(session, "No param");
			return;
		}
		
		GmGoodActivityUpdateSysMsg msg = new GmGoodActivityUpdateSysMsg(activityStr);
		Globals.getSceneService().getCommonScene().putMessage(msg);
	}

}
