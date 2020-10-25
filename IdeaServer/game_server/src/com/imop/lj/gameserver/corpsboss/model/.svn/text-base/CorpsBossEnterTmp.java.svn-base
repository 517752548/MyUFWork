package com.imop.lj.gameserver.corpsboss.model;

import com.imop.lj.gameserver.common.Globals;

public class CorpsBossEnterTmp {
	private long roleId;
	private int teamId;
	private int bossLevel;
	private boolean agree;
	private long startTime;
	
	public CorpsBossEnterTmp(long roleId, int teamId, int bossLevel) {
		this.roleId = roleId;
		this.teamId = teamId;
		this.bossLevel = bossLevel;
		this.startTime = Globals.getTimeService().now();
	}

	public long getRoleId() {
		return roleId;
	}

	public void setRoleId(long roleId) {
		this.roleId = roleId;
	}

	public int getTeamId() {
		return teamId;
	}

	public void setTeamId(int teamId) {
		this.teamId = teamId;
	}

	public int getBossLevel() {
		return bossLevel;
	}

	public void setBossLevel(int bossLevel) {
		this.bossLevel = bossLevel;
	}

	public boolean isAgree() {
		return agree;
	}

	public void setAgree(boolean agree) {
		this.agree = agree;
	}

	public long getStartTime() {
		return startTime;
	}

	public void setStartTime(long startTime) {
		this.startTime = startTime;
	}

	@Override
	public String toString() {
		return "CorpsBossEnterTmp [roleId=" + roleId + ", teamId=" + teamId + ", bossLevel=" + bossLevel + ", agree="
				+ agree + ", startTime=" + startTime + "]";
	}
}
