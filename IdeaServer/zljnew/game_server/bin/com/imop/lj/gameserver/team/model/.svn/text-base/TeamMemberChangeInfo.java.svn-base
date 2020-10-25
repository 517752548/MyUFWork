package com.imop.lj.gameserver.team.model;

public class TeamMemberChangeInfo {
	private long roleId;
	private int teamId;
	/** 是否最后一个离队的队员 */
	private boolean isLast;
	/** 是否添加队员 */
	private boolean isAdd;
	/** false离队，true暂离 */
	private boolean leaveOrAway;
	/** 队伍是否处于活动中状态 */
	private boolean isDoing;
	/** 是否切换队长 */
	private boolean isLeader;
	
	public TeamMemberChangeInfo(long roleId, int teamId, 
			boolean isAdd, boolean leaveOrAway, boolean isLast, boolean isDoing, boolean isLeader) {
		this.roleId = roleId;
		this.teamId = teamId;
		this.isLast = isLast;
		this.isAdd = isAdd;
		this.leaveOrAway = leaveOrAway;
		this.isDoing = isDoing;
		this.isLeader = isLeader;
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

	public boolean isLast() {
		return isLast;
	}

	public void setLast(boolean isLast) {
		this.isLast = isLast;
	}

	public boolean isAdd() {
		return isAdd;
	}

	public void setAdd(boolean isAdd) {
		this.isAdd = isAdd;
	}

	public boolean isLeaveOrAway() {
		return leaveOrAway;
	}

	public void setLeaveOrAway(boolean leaveOrAway) {
		this.leaveOrAway = leaveOrAway;
	}

	public boolean isDoing() {
		return isDoing;
	}

	public void setDoing(boolean isDoing) {
		this.isDoing = isDoing;
	}

	public boolean isLeader() {
		return isLeader;
	}

	public void setLeader(boolean isLeader) {
		this.isLeader = isLeader;
	}

}
