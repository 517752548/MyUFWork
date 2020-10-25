package com.imop.lj.gameserver.wizardraid.model;

import com.imop.lj.gameserver.common.Globals;

public class WizardRaidEnterTmp {
	private long roleId;
	private int teamId;
	private int raidId;
	private boolean agree;
	private long startTime;
	
	public WizardRaidEnterTmp(long roleId, int teamId, int raidId) {
		this.roleId = roleId;
		this.teamId = teamId;
		this.raidId = raidId;
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

	public int getRaidId() {
		return raidId;
	}

	public void setRaidId(int raidId) {
		this.raidId = raidId;
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
}
