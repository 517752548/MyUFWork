package com.imop.lj.gameserver.telnet.command;

import java.util.Map;

import org.apache.mina.core.session.IoSession;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;

public class ChargeNoticeCommand extends LoginedTelnetCommand {

	public ChargeNoticeCommand() {
		super("PAYBACK");
	}

	@Override
	protected void doExec(String command, Map<String, String> params, IoSession session) {
		String _param = getCommandParam(command);
		if (_param.length() == 0) {
			sendError(session, "No param");
			return;
		}

		long _charId = 0;
		try {
			_charId = Long.parseLong(_param);
		} catch (Exception e) {
			e.printStackTrace();
			Loggers.gameLogger.error("no charId", e);
		}

		if (_charId <= 0) {
			sendError(session, "Bad charId");
			return;
		}

		final Player player = Globals.getOnlinePlayerService().getPlayer(_charId);
		if (player == null || player.getHuman() == null) {
			sendError(session, "player offline");
			return;
		}
		
		Loggers.gameLogger.info("ChargeNoticeCommand will check user charge _charId=" + _charId);
		
		// 直冲充值检查
		if (Globals.getServerConfig().isZhichongFlag() && Globals.getServerConfig().isTurnOnLocalInterface()) {
			player.putMessage(new SysInternalMessage() {
				@Override
				public void execute() {
					Globals.getChargeLogicalProcessor().iosAndroidCharge(player);
				}
			});
		}

	}

}
