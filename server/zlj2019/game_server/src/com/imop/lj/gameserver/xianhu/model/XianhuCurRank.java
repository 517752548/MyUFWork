package com.imop.lj.gameserver.xianhu.model;

public class XianhuCurRank {
	/** 排行类型 */
	private int rankType;
	/** 排名 */
	private int rank;
	/** 所属角色 */
	private long roleId;
	/** 次数 */
	private int targetCount;
	/** 最后一次更新时间 */
	private long lastTime;
	
	public XianhuCurRank() {
		
	}

	public int getRankType() {
		return rankType;
	}

	public void setRankType(int rankType) {
		this.rankType = rankType;
	}

	public int getRank() {
		return rank;
	}

	public void setRank(int rank) {
		this.rank = rank;
	}

	public long getRoleId() {
		return roleId;
	}

	public void setRoleId(long charId) {
		this.roleId = charId;
	}

	public int getTargetCount() {
		return targetCount;
	}

	public void setTargetCount(int targetCount) {
		this.targetCount = targetCount;
	}

	public long getLastTime() {
		return lastTime;
	}

	public void setLastTime(long lastTime) {
		this.lastTime = lastTime;
	}
	
}
