package com.imop.lj.gameserver.telnet.command;

import java.util.Map;

import org.apache.mina.core.session.IoSession;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.goodactivity.msg.sysmsg.GmGoodActivityCloseAllGoingSysMsg;

public class GoodActivityCloseAllGoingCommand extends LoginedTelnetCommand {

	public GoodActivityCloseAllGoingCommand() {
		super("GOOD_ACTIVITY_CLOSE_ALL_GOING");
	}

	@Override
	protected void doExec(String command, Map<String, String> params,
			IoSession session) {
//		String activityStr = getCommandParam(command);
//		if(activityStr==null || activityStr.equals("")){
//			sendError(session, "No param");
//			return;
//		}
		
		GmGoodActivityCloseAllGoingSysMsg msg = new GmGoodActivityCloseAllGoingSysMsg();
		Globals.getSceneService().getCommonScene().putMessage(msg);
	}

}
