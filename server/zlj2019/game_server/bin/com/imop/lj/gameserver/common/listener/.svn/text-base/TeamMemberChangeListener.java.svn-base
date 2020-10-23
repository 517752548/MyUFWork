package com.imop.lj.gameserver.common.listener;

import com.imop.lj.core.event.IEventListener;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.event.TeamMemberChangeEvent;
import com.imop.lj.gameserver.team.TeamService;
import com.imop.lj.gameserver.team.model.TeamMemberChangeInfo;

public class TeamMemberChangeListener implements IEventListener<TeamMemberChangeEvent> {

	/**
	 * 队伍队员发生变化时的监听，包括增加队员，离队，暂离，解散
	 * XXX 如果是离队的情况，则队员离队之后调用，也就是在这里面调用{@link TeamService#getHumanTeam()} 会返回null
	 */
	@Override
	public void fireEvent(TeamMemberChangeEvent event) {
		TeamMemberChangeInfo info = event.getInfo();
		int teamId = info.getTeamId();
		long roleId = info.getRoleId();
		//队伍解散时，最后一个玩家退出时，为true
		boolean isLast = info.isLast();
		//队伍是否处于活动中状态
		boolean isDoing = info.isDoing();
		//离开队伍
		boolean isLeave = !info.isLeaveOrAway();
		//暂离队伍
		boolean isAway = info.isLeaveOrAway();
		//增加队员
		boolean isAdd = info.isAdd();
		//切换队长
		boolean isLeader = info.isLeader();
		
		if (!isAdd && isLeave && isDoing) {
			//绿野仙踪队员离队处理
			Globals.getWizardRaidService().onTeamMemberLeave(roleId, teamId, isLast);
			//军团战队员离队处理
			Globals.getCorpsWarService().onTeamMemberLeave(roleId, teamId, isLast);
			//围剿魔族队员离队处理
			Globals.getSiegeDemonService().onTeamMemberLeave(roleId, teamId, isLast);
		}
		
		//nvn联赛队员变化的处理
		Globals.getNvnService().onTeamMemberChanged(roleId, teamId, isAdd, isLast);
		
		//通天塔队员变化处理
		Globals.getTowerService().onTeamMemberChanged(roleId, teamId,isLeader);
		
		
	}
}
