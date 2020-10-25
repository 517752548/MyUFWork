package com.imop.lj.gameserver.team.task;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.quest.msg.GCQuestUpdate;
import com.imop.lj.gameserver.task.AbstractTask;
import com.imop.lj.gameserver.task.TaskDef.TaskStatus;
import com.imop.lj.gameserver.task.template.QuestTemplate;
import com.imop.lj.gameserver.team.TeamDef.MemberStatus;
import com.imop.lj.gameserver.team.model.Team;
import com.imop.lj.gameserver.team.model.TeamMember;

/**
 * 队伍任务对象
 * @author yu.zhao
 *
 */
public class TeamTask extends AbstractTask<Team> {
	
	public TeamTask(Team owner, QuestTemplate template) {
		super(owner, template);
	}
	
	@Override
	public void updateStatusImpl(TaskStatus taskStatus) {
		return;
	}
	
	@Override
	public boolean onAcceptTaskImpl() {
		boolean flag = Globals.getTeamService().onAcceptTask(getOwner(), this);
		return flag;
	}
	
	@Override
	protected void giveTaskReward() {
		//给正常状态的队员奖励
		for (TeamMember tm : getOwner().getMemberMap().values()) {
			if (tm.getStatus() != MemberStatus.NORMAL) {
				continue;
			}
			//1.基本奖励
			giveBaseReward(tm.getRoleId());
			//2.条件奖励 
			giveConditionReward(tm.getRoleId());
		}
	}
	
	@Override
	protected boolean onFinishTaskImpl() {
		//检查是否自动接取后边的任务
		Globals.getTeamService().checkAfterFinishTask(getOwner(), getQuestId());
		return true;
	}
	
	@Override
	protected void onUpdateRecordMap() {
		// 通知前台，任务变化
		getOwner().noticeTeamMember(new GCQuestUpdate(buildQuestInfo()), true, true);
	}
	
	

}
