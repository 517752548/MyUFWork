package com.imop.lj.gameserver.team.model;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.offlinedata.UserSnap;
import com.imop.lj.gameserver.team.TeamDef.MemberAfterBattleStatus;
import com.imop.lj.gameserver.team.TeamDef.MemberStatus;
import com.imop.lj.gameserver.team.TeamDef.MemberType;

public class TeamMember {
	/** 所属队伍 */
	private Team team;
	/** 玩家Id */
	private long roleId;
	/** 成员类型 */
	private MemberType type;
	/** 成员状态 */
	private MemberStatus status;
	/** 位置 */
	private int position;

	private long lastOfflineTime;
	
	/** 队伍战斗结束后，需要变为的状态 */
	private MemberAfterBattleStatus afterBattleStatus;
	
	
	public TeamMember() {
		
	}
	
	public int getLevel() {
		if (Globals.getTeamService().isOnlineNow(this)) {
			return Globals.getOnlinePlayerService().getPlayer(roleId).getHuman().getLevel();
		}
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
	
	public int getTplId() {
		UserSnap userSnap = Globals.getOfflineDataService().getUserSnap(getRoleId());
		if (userSnap != null) {
			return userSnap.getHumanTplId();
		}
		return 0;
	}

	public Team getTeam() {
		return team;
	}

	public void setTeam(Team team) {
		this.team = team;
	}

	public long getRoleId() {
		return roleId;
	}

	public void setRoleId(long roleId) {
		this.roleId = roleId;
	}

	public MemberType getType() {
		return type;
	}

	public void setType(MemberType type) {
		this.type = type;
	}

	public MemberStatus getStatus() {
		return status;
	}

	public void setStatus(MemberStatus status) {
		this.status = status;
	}

	public int getPosition() {
		return position;
	}

	public void setPosition(int position) {
		this.position = position;
	}

	public long getLastOfflineTime() {
		return lastOfflineTime;
	}

	public void setLastOfflineTime(long lastOfflineTime) {
		this.lastOfflineTime = lastOfflineTime;
	}

	public MemberAfterBattleStatus getAfterBattleStatus() {
		return afterBattleStatus;
	}

	public void setAfterBattleStatus(MemberAfterBattleStatus afterBattleStatus) {
		this.afterBattleStatus = afterBattleStatus;
	}

	
	
}
