package com.imop.lj.gameserver.telnet.command;

import java.util.Map;

import org.apache.mina.core.session.IoSession;


/**
 * 得到活动的状态，像boss战等 id name 状态
 *
 * @author wenpin.qian
 *
 */
public class ActivityStatusCommand extends LoginedTelnetCommand {

	public ActivityStatusCommand() {
		super("activitystatus");
	}

	@Override
	protected void doExec(String command, Map<String, String> params,
			IoSession session) {
		//String _param = params.get("open");
//		String activitys = Globals.getActivityService().gm_setActivityStatus();
//		sendMessage(session,activitys);
	}

}
