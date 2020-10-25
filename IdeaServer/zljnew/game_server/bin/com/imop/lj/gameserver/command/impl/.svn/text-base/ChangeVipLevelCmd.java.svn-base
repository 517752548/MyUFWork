package com.imop.lj.gameserver.command.impl;

import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.startup.GameClientSession;

public class ChangeVipLevelCmd implements IAdminCommand<ISession> {

	@Override
	public void execute(ISession playerSession, String[] commands) {
		if (!(playerSession instanceof GameClientSession)) {
			return;
		}
		Player player = ((GameClientSession) playerSession).getPlayer();
		try {
//			int vipLevel = Integer.parseInt(commands[0]);			
//			player.getHuman().getVipManager().setVipLevel(vipLevel);
			
		} catch (Exception e) {
			e.printStackTrace();
			player.sendErrorMessage(e.getMessage());
		}
	}

	@Override
	public String getCommandName() {
		return CommandConstants.GM_CMD_CHANGE_VIPLEVEL;
	}

}
