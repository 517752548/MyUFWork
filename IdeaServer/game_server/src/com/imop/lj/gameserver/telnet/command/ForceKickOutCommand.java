package com.imop.lj.gameserver.telnet.command;

import java.util.Map;

import net.sf.json.JSONObject;

import org.apache.mina.core.session.IoSession;
import org.slf4j.Logger;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;

public class ForceKickOutCommand extends LoginedTelnetCommand {

	/** 角色ID key字符串 */
	private static final String CHAR_ID_KEY = "id";
	/** passport ID key字符串 */
	private static final String PASSPORT_ID_KEY = "pid";

	public static final Logger logger = Loggers.playerLogger;

	public ForceKickOutCommand() {
		super("FORCEKICKOUT");
	}

	@Override
	protected void doExec(String command, Map<String, String> params, IoSession session) {
		String _param = getCommandParam(command);
		if (_param.length() == 0) {
			sendError(session, "No param");
			return;
		}

		JSONObject _json = JSONObject.fromObject(_param);

		long _charId = 0;
		if (_json.containsKey(CHAR_ID_KEY)) {
			String _strCharId = _json.getString(CHAR_ID_KEY);
			_charId = Long.parseLong(_strCharId);
		} else if (_json.containsKey(PASSPORT_ID_KEY)) {
			final String _pid = _json.getString(PASSPORT_ID_KEY);
			if (_pid == null || "".equalsIgnoreCase(_pid)) {
				sendError(session, "Bad Passport Id");
				return;
			}

			Player _oUser = Globals.getOnlinePlayerService().getPlayerByPassportId(_pid);
			if (_oUser != null) {
				_charId = _oUser.getRoleUUID();
			}
		}

		if (_charId <= 0) {
			sendError(session, "Bad charId");
			return;
		}

		Player player = Globals.getOnlinePlayerService().getPlayer(_charId);
		if (player == null) {
			sendError(session, "The player found,but offline");
			return;
		}

		boolean flag = Globals.getOnlinePlayerService().forceKickOutPlayer(_charId);

		if (flag) {
			this.sendMessage(session, "Sended");
		} else {
			sendError(session, "Force kick out player is faild");
		}
	}

}
