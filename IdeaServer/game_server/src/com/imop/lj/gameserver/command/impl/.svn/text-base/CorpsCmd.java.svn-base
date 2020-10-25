package com.imop.lj.gameserver.command.impl;

import com.imop.lj.common.LogReasons.CorpsLogReason;
import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.startup.GameClientSession;

/**
 * 帮派相关命令
 * 
 * 
 */

public class CorpsCmd implements IAdminCommand<ISession> {

	@Override
	public void execute(ISession playerSession, String[] commands) {
		if (!(playerSession instanceof GameClientSession)) {
			return;
		}
		Player player = ((GameClientSession) playerSession).getPlayer();
		Human human = player.getHuman();
		if(commands.length!=2){
			human.sendErrorMessage("参数数量不正确!");
			return;
		}
		try {
			String type = String.valueOf(commands[0]);
			int count = Integer.parseInt(commands[1]);
			switch(type){
			case "exp":
				Globals.getCorpsService().addCorpsExp(human, count, CorpsLogReason.CORPS_ADD_EXP_GM, true);
				break;
			case "fund":
				Globals.getCorpsService().addCorpsFund(human, count, CorpsLogReason.CORPS_ADD_FUND_GM, true);
				break;
			case "contri":
				Globals.getCorpsService().addCorpsContribution(human, count, CorpsLogReason.CORPS_ADD_CONTRIBUTION_GM,
						true);
				break;
			default:
				break;
			}
		} catch (Exception e) {
			e.printStackTrace();
			player.sendErrorMessage(e.getMessage());
		}

	}

	@Override
	public String getCommandName() {
		return CommandConstants.GM_CMD_CORPS;
	}

}
