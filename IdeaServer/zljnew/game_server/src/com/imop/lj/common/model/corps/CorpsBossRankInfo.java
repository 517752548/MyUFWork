package com.imop.lj.common.model.corps;

public class CorpsBossRankInfo {
	private long corpsId;
	private String name;
	private int rank;
	private String replay;
	private int bossLevel;
	private int round;

	public long getCorpsId() {
		return corpsId;
	}

	public void setCorpsId(long corpsId) {
		this.corpsId = corpsId;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public int getRank() {
		return rank;
	}

	public void setRank(int rank) {
		this.rank = rank;
	}

	public String getReplay() {
		return replay;
	}

	public void setReplay(String replay) {
		this.replay = replay;
	}

	public int getBossLevel() {
		return bossLevel;
	}

	public void setBossLevel(int bossLevel) {
		this.bossLevel = bossLevel;
	}

	public int getRound() {
		return round;
	}

	public void setRound(int round) {
		this.round = round;
	}

	@Override
	public String toString() {
		return "CorpsBossRankInfo [corpsId=" + corpsId + ", name=" + name + ", rank=" + rank + ", replay=" + replay
				+ ", bossLevel=" + bossLevel + ", round=" + round + "]";
	}

}
