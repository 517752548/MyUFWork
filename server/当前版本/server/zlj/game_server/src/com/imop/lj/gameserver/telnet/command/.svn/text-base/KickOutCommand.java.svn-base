package com.imop.lj.gameserver.telnet.command;

import java.util.Map;

import net.sf.json.JSONObject;

import org.apache.mina.core.session.IoSession;

import com.imop.lj.common.constants.DisconnectReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.player.PlayerExitReason;
import com.imop.lj.gameserver.player.msg.GCNotifyException;

public class KickOutCommand extends LoginedTelnetCommand {

	/** 角色ID key字符串 */
	private static final String CHAR_ID_KEY = "id";
	/** passport ID key字符串 */
	private static final String PASSPORT_ID_KEY = "pid";

	public KickOutCommand() {
		super("KICKOUT");
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

		Player _onlinePlayer = Globals.getOnlinePlayerService().getPlayer(_charId);
		if (_onlinePlayer == null) {
			//玩家不在线后，缓存可能会存在，删除缓存
			Globals.getHumanCacheService().gmDelHumanCache(_charId);
			
			sendError(session, "The player found,but offline.Delete human cache.");
			return;
		}

		_onlinePlayer.sendMessage(new GCNotifyException(
				DisconnectReason.GM_KICK.code, Globals.getLangService().readSysLang(LangConstants.GM_KICK)));
		_onlinePlayer.exitReason = PlayerExitReason.GM_KICK;
		_onlinePlayer.disconnect();

		this.sendMessage(session, "Sended");

	}

}
