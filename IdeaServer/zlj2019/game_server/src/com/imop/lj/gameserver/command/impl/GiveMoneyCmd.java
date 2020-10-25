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

public class GiveMoneyCmd implements IAdminCommand<ISession> {

	@Override
	public void execute(ISession playerSession, String[] commands) {
		if (!(playerSession instanceof GameClientSession)) {
			return;
		}
		Player player = ((GameClientSession) playerSession).getPlayer();
		try {
			Currency currency = Currency.valueOf(Integer.parseInt(commands[0]));
			int amount = Integer.parseInt(commands[1]);
			player.getHuman().giveMoney(amount, currency, true,
					MoneyLogReason.DEBUG_CMD_GIVE, "debug");
		} catch (Exception e) {
			e.printStackTrace();
			player.sendErrorMessage(e.getMessage());
		}

	}

	@Override
	public String getCommandName() {
		return CommandConstants.GM_CMD_GIVE_MONEY;
	}

}
