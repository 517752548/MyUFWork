package com.imop.lj.gameserver.player.msg;

import org.slf4j.Logger;

import com.imop.lj.common.LogReasons;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.player.PlayerExitReason;
import com.imop.lj.gameserver.player.PlayerState;

public class PlayerOfflineMessage extends SysInternalMessage {
	
	protected Logger logoutLogger = Loggers.logoutLogger;

	protected final Player player;

	public PlayerOfflineMessage(final Player player) {
		this.player = player;
	}

	@Override
	public void execute() {
		if (player.getState() != PlayerState.logouting) {
			logoutLogger.info("8、Player logout offlineMsg.execute " + " player passportId" + player.getPassportId() + " player state"
					+ player.getState().name());
			
			if(player.getHuman()!=null){
				long now = Globals.getTimeService().now();
				Globals.getLogService().sendPlayerLoginLog(player.getHuman(), LogReasons.PlayerLoginLogReason.PLAYER_LOGOUT_INITIATIVE, "", player.getCurrTerminalType().getSource(), now, player.getSource());
			}
			
			Globals.getOnlinePlayerService().offlinePlayer(player, player.exitReason == null ? PlayerExitReason.LOGOUT : player.exitReason);
		} else {
			logoutLogger.info("7、Player logout offlineMsg.execute " + " player passportId" + player.getPassportId() + " player state"
					+ player.getState().name());
		}
	}
}
