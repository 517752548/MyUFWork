package com.imop.lj.gameserver.telnet.command;

import java.util.Map;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

import org.apache.mina.core.session.IoSession;

import com.imop.lj.gameserver.common.Globals;

/**
 * 取得Game Server列表的状态
 *
 *
 */
public class GSListCommand extends LoginedTelnetCommand {
	public GSListCommand() {
		super("GS_LIST");
	}

	@Override
	protected void doExec(String command, Map<String, String> params,
			IoSession session) {
		JSONArray _gameServersArray = new JSONArray();
		JSONObject _svr = new JSONObject();
		_svr.put("id", Globals.getServerConfig().getServerId());
		_svr.put("name", Globals.getServerConfig().getServerName());
		_gameServersArray.add(_svr);
		sendMessage(session, _gameServersArray.toString());
	}
}
