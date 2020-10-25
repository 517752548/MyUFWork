package com.imop.lj.gameserver.corpswar.model;


public class CorpsWarCorps {
	//军团id
	private long corpsId;
	//军团所在组id
	private int groupId;
	//军团总积分，军团战结束时，重新算的分数
	private int totalScore;
	//军团显示用积分，每次战斗后会更新
	private int showScore;
	//军团排名
	private int rank;
	
	public CorpsWarCorps(long corpsId, int groupId) {
		this.corpsId = corpsId;
		this.groupId = groupId;
	}

	public long getCorpsId() {
		return corpsId;
	}

	public int getGroupId() {
		return groupId;
	}

	public int getTotalScore() {
		return totalScore;
	}

	public void setTotalScore(int totalScore) {
		this.totalScore = totalScore;
	}

	public int getShowScore() {
		return showScore;
	}

	public void setShowScore(int showScore) {
		this.showScore = showScore;
	}

	public int getRank() {
		return rank;
	}

	public void setRank(int rank) {
		this.rank = rank;
	}

	@Override
	public String toString() {
		return "CorpsWarCorps [corpsId=" + corpsId + ", groupId=" + groupId + ", totalScore=" + totalScore
				+ ", showScore=" + showScore + ", rank=" + rank + "]";
	}

}
