package com.imop.lj.gameserver.team.model;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.offlinedata.UserSnap;

public class TeamApplyer {
	private long roleId;
	private long createTime;
	
	public TeamApplyer(long roleId) {
		this.roleId = roleId;
		this.createTime = Globals.getTimeService().now();
	}

	public int getLevel() {
		UserSnap userSnap = Globals.getOfflineDataService().getUserSnap(getRoleId());
		if (userSnap != null) {
			return userSnap.getLevel();
		}
		return 0;
	}
	
	public String getName() {
		UserSnap userSnap = Globals.getOfflineDataService().getUserSnap(getRoleId());
		if (userSnap != null) {
			return userSnap.getName();
		}
		return "";
	}
	
	public int getJobTypeId() {
		UserSnap userSnap = Globals.getOfflineDataService().getUserSnap(getRoleId());
		if (userSnap != null) {
			return userSnap.getHumanJobTypeId();
		}
		return 0;
	}
	
	public long getRoleId() {
		return roleId;
	}

	public void setRoleId(long roleId) {
		this.roleId = roleId;
	}

	public long getCreateTime() {
		return createTime;
	}

	public void setCreateTime(long createTime) {
		this.createTime = createTime;
	}
	
}
