package com.imop.lj.gameserver.command.impl;

import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.startup.GameClientSession;

/**
 * 仙葫命令
 * 
 */
public class XianhuCmd implements IAdminCommand<ISession> {

	@Override
	public void execute(ISession playerSession, String[] commands) {
		if (!(playerSession instanceof GameClientSession)) {
			return;
		}
		Player player = ((GameClientSession) playerSession).getPlayer();
		try {
			if (commands[0].equalsIgnoreCase("cur")) {
				Globals.getXianhuService().refreshCurRank(true);
			} else if (commands[0].equalsIgnoreCase("pre")) {
				Globals.getXianhuService().refreshPreRankDaily(true, false);
			} else if (commands[0].equalsIgnoreCase("preweek")) {
				Globals.getXianhuService().refreshPreRankDaily(true, true);
			}
		} catch (Exception e) {
			e.printStackTrace();
			player.sendErrorMessage(e.getMessage());
		}

	}

	@Override
	public String getCommandName() {
		return CommandConstants.GM_CMD_XIANHU;
	}

}
