package com.imop.lj.gameserver.command.impl;

import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.startup.GameClientSession;

/**
 * 护送粮草任务命令
 * 
 */
public class ForageTaskCmd implements IAdminCommand<ISession> {

	@Override
	public void execute(ISession playerSession, String[] commands) {
		if (!(playerSession instanceof GameClientSession)) {
			return;
		}
		Player player = ((GameClientSession) playerSession).getPlayer();
		Human human = player.getHuman();
		
		String cmd = commands[0].toLowerCase();
		switch (cmd) {
		case "open":
			Globals.getForageTaskService().onOpenFunc(human, FuncTypeEnum.FORAGE);
			break;
		case "refresh":
			Globals.getForageTaskService().gmRefreshTask(human);
			break;

		default:
			break;
		}
		
	}

	@Override
	public String getCommandName() {
		return CommandConstants.GM_CMD_FORAGE_TASK;
	}

}
