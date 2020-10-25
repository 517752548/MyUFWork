package com.imop.lj.common.model.corps;

public class CorpsBossCountRankInfo {
	private long corpsId;
	private String name;
	private int rank;
	private int count;
	private String presidentName;
	private int curMemberCount;
	private int maxMemberCount;
	
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

	public int getCount() {
		return count;
	}

	public void setCount(int count) {
		this.count = count;
	}

	public String getPresidentName() {
		return presidentName;
	}

	public void setPresidentName(String presidentName) {
		this.presidentName = presidentName;
	}

	public int getCurMemberCount() {
		return curMemberCount;
	}

	public void setCurMemberCount(int curMemberCount) {
		this.curMemberCount = curMemberCount;
	}

	public int getMaxMemberCount() {
		return maxMemberCount;
	}

	public void setMaxMemberCount(int maxMemberCount) {
		this.maxMemberCount = maxMemberCount;
	}

	@Override
	public String toString() {
		return "CorpsBossCountRankInfo [corpsId=" + corpsId + ", name=" + name + ", rank=" + rank + ", count=" + count
				+ ", presidentName=" + presidentName + ", curMemberCount=" + curMemberCount + ", maxMemberCount="
				+ maxMemberCount + "]";
	}
}
