package com.imop.lj.gameserver.command.impl;

import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.startup.GameClientSession;

/**
 * boss战的debug命令
 * 
 * 
 */

public class DbChangeCmd implements IAdminCommand<ISession> {

	@Override
	public void execute(ISession playerSession, String[] commands) {
		if (!(playerSession instanceof GameClientSession)) {
			return;
		}
		Player player = ((GameClientSession) playerSession).getPlayer();
		try {
			int status = Integer.parseInt(commands[0]);
			if(status == 0){
				Globals.getConfig().setUpgradeDbStrategy(false);
				return;
			}else{
				Globals.getConfig().setUpgradeDbStrategy(true);
				int interval = Integer.parseInt(commands[1]);
				Globals.getConfig().setDbUpdateInterval(interval * 1000);
				return;
			}
			
		} catch (Exception e) {
			e.printStackTrace();
			player.sendErrorMessage(e.getMessage());
		}

	}

	@Override
	public String getCommandName() {
		return CommandConstants.GM_DB_COME;
	}

}
