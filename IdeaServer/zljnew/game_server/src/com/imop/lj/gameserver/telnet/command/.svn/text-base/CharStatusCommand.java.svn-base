package com.imop.lj.gameserver.telnet.command;

import java.util.Map;

import net.sf.json.JSONObject;

import org.apache.mina.core.session.IoSession;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.OnlinePlayerService;
import com.imop.lj.gameserver.player.Player;

public class CharStatusCommand extends LoginedTelnetCommand {
	/** 玩家在线服务 */
	private OnlinePlayerService onlinePlayerService = Globals.getOnlinePlayerService();

	public CharStatusCommand() {
		super("CHAR_STATUS");
	}

	@Override
	protected void doExec(String command, Map<String, String> params,
			IoSession session) {
		String jsonParam = getCommandParam(command);
		JSONObject param = JSONObject.fromObject(jsonParam);
		long roleUUId = Long.parseLong(param.getString("id"));
		// 玩家是否在线
		boolean isOnline = playerIsOnline(roleUUId);

		if (isOnline) {
			sendMessage(session, "online");
		} else {
			sendMessage(session, null);
		}
	}

	/**
	 * 判断玩家是否在线
	 * @param roleUUId
	 * @return
	 */
	public boolean playerIsOnline(long roleUUId) {
		boolean result = true;
		Player player = onlinePlayerService.getPlayer(roleUUId);

		if (player == null) {
			result = false;
		}

		return result;
	}
}
