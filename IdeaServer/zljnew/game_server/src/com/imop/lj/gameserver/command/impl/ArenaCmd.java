package com.imop.lj.gameserver.command.impl;

import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.startup.GameClientSession;

/**
 * 竞技场命令
 * 
 * 
 */

public class ArenaCmd implements IAdminCommand<ISession> {

	@Override
	public void execute(ISession playerSession, String[] commands) {
		if (!(playerSession instanceof GameClientSession)) {
			return;
		}
		Player player = ((GameClientSession) playerSession).getPlayer();
		try {
			// 竞技场刷新
			if (commands[0].equalsIgnoreCase("refresh")) {
				Globals.getArenaService().refreshArena("gm");
			} else if (commands[0].equalsIgnoreCase("usersnap")) {
				// 更新离线数据
				Globals.getOfflineDataService().sendRebuildUserSnapMsg(player.getHuman());
			}
		} catch (Exception e) {
			e.printStackTrace();
			player.sendErrorMessage(e.getMessage());
		}

	}

	@Override
	public String getCommandName() {
		return CommandConstants.GM_CMD_ARENA;
	}

}
