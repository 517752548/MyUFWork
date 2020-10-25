package com.imop.lj.gameserver.command.impl;

import com.imop.lj.common.LogReasons.PubExpLogReason;
import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.pubtask.PubTaskDef.RefreshType;
import com.imop.lj.gameserver.startup.GameClientSession;

/**
 * 酒馆任务命令
 * 
 */
public class PubTaskCmd implements IAdminCommand<ISession> {

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
			Globals.getPubTaskService().onOpenFunc(human, FuncTypeEnum.PUB);
			break;
		case "exp":
			int addExp = Integer.parseInt(commands[1]);
			if (addExp > 0) {
				Globals.getPubTaskService().addPubExp(human, addExp, PubExpLogReason.GM_GIVE, PubExpLogReason.GM_GIVE.getReasonText(), true);
			}
			break;
		case "refresh":
			Globals.getPubTaskService().gmRefreshTask(human, RefreshType.NORMAL.getIndex());
			break;
		case "refreshbond":
			Globals.getPubTaskService().gmRefreshTask(human, RefreshType.BOND.getIndex());
			break;
		default:
			break;
		}
		
	}

	@Override
	public String getCommandName() {
		return CommandConstants.GM_CMD_PUB_TASK;
	}

}
