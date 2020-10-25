package com.imop.lj.gameserver.command.impl;

import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.activity.function.ActivityDef.ActivityState;
import com.imop.lj.gameserver.activity.template.ActivityTemplate;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.exam.activity.ExamEndMessage;
import com.imop.lj.gameserver.exam.activity.ExamReadyMessage;
import com.imop.lj.gameserver.exam.activity.ExamStartMessage;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.startup.GameClientSession;

public class ExamCmd implements IAdminCommand<ISession> {

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
			ExamReadyMessage readyMsg = new ExamReadyMessage(activityTtpl);
			ExamStartMessage startMsg = new ExamStartMessage(activityTtpl);
			ExamEndMessage endMsg = new ExamEndMessage(activityTtpl);
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
			
//			//给客户端发消息，通知变化
//			human.sendErrorMessage("update exam success!");
		} catch (Exception e) {
			e.printStackTrace();
			player.sendErrorMessage(e.getMessage());
		}

	}

	@Override
	public String getCommandName() {
		return CommandConstants.EXAM;
	}

}
