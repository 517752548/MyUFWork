package com.imop.lj.gameserver.command.impl;

import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.guide.GuideDef.GuideType;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.startup.GameClientSession;

/**
 * 新手引导命令
 * 
 */

public class GuideCmd implements IAdminCommand<ISession> {

	@Override
	public void execute(ISession playerSession, String[] commands) {
		if (!(playerSession instanceof GameClientSession)) {
			return;
		}
		Player player = ((GameClientSession) playerSession).getPlayer();
		try {
			if (commands[0].equalsIgnoreCase("clear")) {
				player.getHuman().getGuideManager().clearAllGuide();
				player.sendErrorMessage("clear ok!");
			} else if (commands[0].equalsIgnoreCase("show")) {
				Integer guideTypeId = Integer.parseInt(commands[1]);
				GuideType guideType = GuideType.valueOf(guideTypeId);
				if (null != guideType) {
					Globals.getGuideService().gmShowGuideInfo(player.getHuman(), guideType);
				}
			}
		} catch (Exception e) {
			e.printStackTrace();
			player.sendErrorMessage(e.getMessage());
		}

	}

	@Override
	public String getCommandName() {
		return CommandConstants.GM_CMD_GUIDE;
	}

}
