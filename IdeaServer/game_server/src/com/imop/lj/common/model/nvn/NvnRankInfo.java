package com.imop.lj.common.model.nvn;

public class NvnRankInfo {
	/** 玩家id */
	private long roleId;
	/** 玩家模板id */
	private int tplId;
	/** 玩家名称 */
	private String name;
	/** 排名 */
	private int rank;
	/** 积分 */
	private int score;
	/** 连胜数 */
	private int conWinNum;
	
	public NvnRankInfo() {
		
	}

	public long getRoleId() {
		return roleId;
	}

	public void setRoleId(long roleId) {
		this.roleId = roleId;
	}

	public int getTplId() {
		return tplId;
	}

	public void setTplId(int tplId) {
		this.tplId = tplId;
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

	public int getScore() {
		return score;
	}

	public void setScore(int score) {
		this.score = score;
	}

	public int getConWinNum() {
		return conWinNum;
	}

	public void setConWinNum(int conWinNum) {
		this.conWinNum = conWinNum;
	}
	
}
