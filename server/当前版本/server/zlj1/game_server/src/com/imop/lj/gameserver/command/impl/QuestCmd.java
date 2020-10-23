package com.imop.lj.gameserver.command.impl;

import java.util.List;

import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.quest.CommonTask;
import com.imop.lj.gameserver.startup.GameClientSession;
import com.imop.lj.gameserver.task.AbstractTask;
import com.imop.lj.gameserver.task.TaskDef.QuestType;
import com.imop.lj.gameserver.task.TaskDef.TaskStatus;
import com.imop.lj.gameserver.task.template.QuestTemplate;

/**
 * 任务命令
 * 
 * @author xiaowei.liu
 * 
 */
public class QuestCmd implements IAdminCommand<ISession> {

	@SuppressWarnings("rawtypes")
	@Override
	public void execute(ISession playerSession, String[] commands) {
		if (!(playerSession instanceof GameClientSession)) {
			return;
		}
		Player player = ((GameClientSession) playerSession).getPlayer();
		Human human = player.getHuman();
		
		String cmd = commands[0];
		if("ac".equalsIgnoreCase(cmd)){
			//FIXME TODO
			int questId = Integer.parseInt(commands[1]);
			
			QuestTemplate tpl = Globals.getTemplateCacheService().get(questId, QuestTemplate.class);
			if(tpl == null){
				human.sendErrorMessage("此任务不存在");
				return;
			}
			if (tpl.getQuestTypeEnum() != QuestType.COMMON) {
				human.sendErrorMessage("只能接主线任务");
				return;
			}
			List<AbstractTask> lst = human.getCommonTaskManager().getDoingTaskList();
			if (lst == null || lst.isEmpty()) {
				human.sendErrorMessage("当前没有任务！");
				return;
			}
			CommonTask ct = (CommonTask) lst.get(0);
			ct.updateForGM(tpl, TaskStatus.INIT);
			ct.onAcceptTask();
			
			Globals.getCommonTaskService().sendCommonTaskList(human);
			
			human.sendErrorMessage("请重新登录游戏！");
		}
	}

	@Override
	public String getCommandName() {
		return CommandConstants.GM_CMD_QUEST;
	}

}
