package com.imop.lj.gameserver.telnet.command;

import java.util.Map;

import net.sf.json.JSONObject;

import org.apache.mina.core.session.IoSession;


/**
 * 游戏内部活动控制，像boss战等
 *
 * @author wenpin.qian
 *
 */
public class ActivityCommand extends LoginedTelnetCommand {

	public ActivityCommand() {
		super("activity");
	}

	@Override
	protected void doExec(String command, Map<String, String> params,
			IoSession session) {

		String _param = getCommandParam(command);
		if (_param.length() == 0) {
			sendError(session, "No param");
			return;
		}

		JSONObject _json = JSONObject.fromObject(_param);
		String open = _json.getString("open");
		String activityId = _json.getString("activityId");
//		String _param = params.get("open");
//
//		if (open.trim().equals("true")) {
//			Globals.getActivityService().gm_setActivity(true,Integer.parseInt(activityId));
////			//刷新活动
////			Globals.getActivityService().init();
//			sendMessage(session, "ok");
//		} else if (open.trim().equals("false")) {
//			Globals.getActivityService().gm_setActivity(false,Integer.parseInt(activityId));
//			sendMessage(session, "ok");
//		}
	}

}
