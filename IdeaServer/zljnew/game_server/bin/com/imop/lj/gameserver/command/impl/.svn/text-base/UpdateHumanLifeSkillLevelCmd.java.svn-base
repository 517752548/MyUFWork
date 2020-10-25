package com.imop.lj.gameserver.command.impl;

import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.startup.GameClientSession;

/**
 * 给金钱的debug命令
 * 
 * 
 */

public class UpdateHumanLifeSkillLevelCmd implements IAdminCommand<ISession> {

	@Override
	public void execute(ISession playerSession, String[] commands) {
		if (!(playerSession instanceof GameClientSession)) {
			return;
		}
		Player player = ((GameClientSession) playerSession).getPlayer();
		try {
			if(Integer.parseInt(commands[0]) <= 0 ){
				return ;
			}
			player.getHuman().setMineLevel(Integer.parseInt(commands[0]));
		} catch (Exception e) {
			e.printStackTrace();
			player.sendErrorMessage(e.getMessage());
		}

	}

	@Override
	public String getCommandName() {
		return CommandConstants.GM_CMD_MINE;
	}

}
