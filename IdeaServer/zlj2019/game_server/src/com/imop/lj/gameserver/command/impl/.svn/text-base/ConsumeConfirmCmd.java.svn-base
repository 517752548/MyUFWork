package com.imop.lj.gameserver.command.impl;

import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.human.ConsumeConfirm;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.startup.GameClientSession;

/**
 * 二次确认框
 * 
 */

public class ConsumeConfirmCmd implements IAdminCommand<ISession> {

	@Override
	public void execute(ISession playerSession, String[] commands) {
		if (!(playerSession instanceof GameClientSession)) {
			return;
		}
		Player player = ((GameClientSession) playerSession).getPlayer();
		Human human = player.getHuman();
		try {
			boolean flag = false;
			if (commands[0].equalsIgnoreCase("open")) {
				
			} else if (commands[0].equalsIgnoreCase("close")) {
				flag = true;
			} else if (commands[0].equalsIgnoreCase("sms")){
				human.getSmsCheckCodeManager().clearForGM();
				player.sendErrorMessage("clear phone num ok!");
			}
			
			ConsumeConfirm[] all = ConsumeConfirm.values();
			for (int i = 0; i < all.length; i++) {
				human.getConsumeConfirmManager().setConfirmStatus(all[i], flag);
			}
		} catch (Exception e) {
			e.printStackTrace();
			player.sendErrorMessage(e.getMessage());
		}

	}

	@Override
	public String getCommandName() {
		return CommandConstants.GM_CMD_CONSUME_CONFIRM;
	}

}
