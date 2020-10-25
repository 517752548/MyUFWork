package com.imop.lj.gameserver.nvn.model;

import com.imop.lj.gameserver.nvn.NvnDef.NvnTeamStatus;

public class NvnTeam {
	//队伍id
	private int teamId;
	//队伍状态
	private NvnTeamStatus status = NvnTeamStatus.IDLE;
	
	//队伍积分，队员/队员积分变化时，会重新计算
	private int score;
	//队伍排名，每次匹配时需要排序，这时会刷新排名
	private int rank;
	
	public NvnTeam(int teamId) {
		this.teamId = teamId;
	}

	public int getTeamId() {
		return teamId;
	}

	public void setTeamId(int teamId) {
		this.teamId = teamId;
	}

	public NvnTeamStatus getStatus() {
		return status;
	}

	public void setStatus(NvnTeamStatus status) {
		this.status = status;
	}

	public int getScore() {
		return score;
	}

	public void setScore(int score) {
		this.score = score;
	}

	public int getRank() {
		return rank;
	}

	public void setRank(int rank) {
		this.rank = rank;
	}

	@Override
	public String toString() {
		return "NvnTeam [teamId=" + teamId + ", status=" + status + ", score="
				+ score + ", rank=" + rank + "]";
	}

}
