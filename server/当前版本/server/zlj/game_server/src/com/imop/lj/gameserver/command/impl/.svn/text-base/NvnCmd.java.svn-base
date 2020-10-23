package com.imop.lj.gameserver.command.impl;

import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.activity.function.ActivityDef.ActivityState;
import com.imop.lj.gameserver.activity.template.ActivityTemplate;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.nvn.activity.NvnEndMessage;
import com.imop.lj.gameserver.nvn.activity.NvnReadyMessage;
import com.imop.lj.gameserver.nvn.activity.NvnStartMessage;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.startup.GameClientSession;

public class NvnCmd implements IAdminCommand<ISession> {

	@Override
	public void execute(ISession playerSession, String[] commands) {
		if (!(playerSession instanceof GameClientSession)) {
			return;
		}
		Player player = ((GameClientSession) playerSession).getPlayer();
		Human human = player.getHuman();
		
		try {
			// 活动开关
			int activityId = Integer.parseInt(commands[0]);
			ActivityState state = ActivityState.valueOf(Integer.parseInt(commands[1]));
			ActivityTemplate activityTtpl = Globals.getTemplateCacheService().get(activityId, ActivityTemplate.class);
			if(activityTtpl == null) {
				player.sendErrorMessage("activityId is wrong!");
				return;
			}
			NvnReadyMessage readyMsg = new NvnReadyMessage(activityTtpl);
			NvnStartMessage startMsg = new NvnStartMessage(activityTtpl);
			NvnEndMessage endMsg = new NvnEndMessage(activityTtpl);
			switch (state) {
			case READY:
				readyMsg.execute();
				human.sendErrorMessage("activity("+activityId+") is ready!");
				break;
			case OPENING:
//				readyMsg.execute();
				startMsg.execute();
				human.sendErrorMessage("activity("+activityId+") is opening!");
				break;
			case FINISHED:
//				readyMsg.execute();
//				startMsg.execute();
				endMsg.execute();
				human.sendErrorMessage("activity("+activityId+") is end!");
				break;

			default:
				break;
			}
		} catch (Exception e) {
			e.printStackTrace();
			player.sendErrorMessage(e.getMessage());
		}

		try {
			if (commands[0].equalsIgnoreCase("rrm")) {
				Globals.getNvnService().refreshNvnRankMonthly("gm cmd");
			}
		} catch (Exception e) {
			e.printStackTrace();
			player.sendErrorMessage(e.getMessage());
		}
		
	}

	@Override
	public String getCommandName() {
		return CommandConstants.GM_CMD_NVN;
	}

}
