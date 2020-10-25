package com.imop.lj.gameserver.nvn.msg;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.model.nvn.NvnRankInfo;
import com.imop.lj.common.model.team.TeamMemberInfo;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.nvn.model.NvnRank;
import com.imop.lj.gameserver.nvn.model.NvnTeam;
import com.imop.lj.gameserver.team.model.Team;
import com.imop.lj.gameserver.team.model.TeamMember;

public class NvnMsgBuilder {
	
	public static GCNvnMyInfo buildGCNvnMyInfo(long roleId, NvnTeam nt, NvnRank nr, List<String> logList) {
		GCNvnMyInfo info = new GCNvnMyInfo();
		info.setRank(nr.getRank());
		info.setConWinNum(nr.getConWin());
		info.setScore(nr.getScore());
		info.setTeamScore(nt.getScore());
		info.setTeamStatus(nt.getStatus().getIndex());
		info.setMyLog(logList.toArray(new String[0]));
		return info;
	}

	public static GCNvnRankList buildGCNvnRankList(List<NvnRankInfo> infoList, NvnRank nr) {
		GCNvnRankList msg = new GCNvnRankList();
		if (nr != null) {
			msg.setMyRank(nr.getRank());
			msg.setMyScore(nr.getScore());
			msg.setMyConWinNum(nr.getConWin());
		}
		
		msg.setNvnRankInfoList(infoList.toArray(new NvnRankInfo[0]));
		return msg;
	}
	
	public static GCNvnMatchedTeamInfo buildGCNvnMatchedTeamInfo(Team team, NvnTeam nt) {
		GCNvnMatchedTeamInfo msg = new GCNvnMatchedTeamInfo();
		msg.setTeamScore(nt.getScore());
		List<TeamMemberInfo> infoList = new ArrayList<TeamMemberInfo>();
		for (TeamMember tm : team.getMemberList()) {
			infoList.add(Globals.getTeamService().buildTeamMemberInfo(tm));
		}
		msg.setTeamMemberInfos(infoList.toArray(new TeamMemberInfo[0]));
		return msg;
	}
	
	public static GCNvnMatchStatus buildGCNvnMatchStatus(int status) {
		return new GCNvnMatchStatus(status);
	}
	
}
