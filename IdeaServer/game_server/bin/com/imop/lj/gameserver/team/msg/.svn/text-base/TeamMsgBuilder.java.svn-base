package com.imop.lj.gameserver.team.msg;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.model.team.TeamInfo;
import com.imop.lj.common.model.team.TeamMemberInfo;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.team.model.Team;
import com.imop.lj.gameserver.team.model.TeamMember;

public class TeamMsgBuilder {

	public static GCTeamMyTeamMemberList buildGCTeamMyTeamMemberList(Team team) {
		GCTeamMyTeamMemberList msg = new GCTeamMyTeamMemberList();
		List<TeamMemberInfo> infoList = new ArrayList<TeamMemberInfo>();
		for (TeamMember tm : team.getMemberList()) {
			infoList.add(Globals.getTeamService().buildTeamMemberInfo(tm));
		}
		msg.setTeamMemberInfos(infoList.toArray(new TeamMemberInfo[0]));
		return msg;
	}
	
	public static GCTeamMyTeamInfo buildGCTeamMyTeamInfo(Team team) {
		GCTeamMyTeamInfo msg = new GCTeamMyTeamInfo();
		msg.setTargetId(team.getTargetId());
		msg.setIsAutoMatch(team.isAutoMatch() ? 1 : 0);
		msg.setLevelMin(team.getLevelMin());
		msg.setLevelMax(team.getLevelMax());
		return msg;
	}
	
	public static GCTeamApplyList buildGCTeamApplyList(List<TeamMemberInfo> infoList) {
		return new GCTeamApplyList(infoList.toArray(new TeamMemberInfo[0]));
	}
	
	public static GCTeamShowList buildGCTeamShowList(List<TeamInfo> infoList, int waitingLeaderNum, int waitingMemberNum) {
		return new GCTeamShowList(infoList.toArray(new TeamInfo[0]), waitingLeaderNum, waitingMemberNum);
	}
	
}
