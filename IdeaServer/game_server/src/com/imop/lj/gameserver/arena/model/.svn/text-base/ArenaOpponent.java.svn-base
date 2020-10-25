package com.imop.lj.gameserver.arena.model;

import com.imop.lj.common.constants.RoleConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.TipsUtil;
import com.imop.lj.gameserver.pet.template.PetTemplate;

public class ArenaOpponent {
	private long roleId;
	private int tplId;
	private int rank;
	private long ownerId;
	
	private String robotName;
	private int robotLevel;
	private int robotFightPower;
	
	public ArenaOpponent(long roleId, int rank) {
		this.roleId = roleId;
		this.rank = rank;
	}
	
	public ArenaOpponent(int tplId, int rank, int robotLevel) {
		this.tplId = tplId;
		this.rank = rank;
		this.robotLevel = robotLevel;
		//战斗力，根据表算出来
		this.robotFightPower = Globals.getArenaService().randRobotFightPower(robotLevel);
		//机器人随机一个名字
		this.robotName = Globals.getLoginLogicalProcessor().randomName(
				this.tplId % 2 == 0 ? RoleConstants.MALE : RoleConstants.FEMALE);
	}
	
	public ArenaOpponent(long roleId, int tplId, int rank) {
		this.roleId = roleId;
		this.tplId = tplId;
		this.rank = rank;
	}

	public boolean isRobot() {
		return this.roleId == 0;
	}
	
	public void setRobotName(String robotName) {
		this.robotName = robotName;
	}

	public String getName() {
		if (isRobot()) {
			if (this.robotName != null && !this.robotName.isEmpty()) {
				return this.robotName;
			}
			return Globals.getTemplateCacheService().get(this.tplId, PetTemplate.class).getName();
		}
		return Globals.getOfflineDataService().getUserName(this.roleId);
	}
	
	public int getRobotLevel() {
		return robotLevel;
	}

	public int getRobotFightPower() {
		return robotFightPower;
	}

	public void setRobotLevel(int robotLevel) {
		this.robotLevel = robotLevel;
	}

	public void setRobotFightPower(int robotFightPower) {
		this.robotFightPower = robotFightPower;
	}

	public String getNameWithColor() {
		if (isRobot()) {
			return TipsUtil.getNameStrWithDefaultColor(Globals.getTemplateCacheService().get(this.tplId, PetTemplate.class).getName());
		}
		return TipsUtil.getRoleLinkStr(this.roleId);
	}
	
	public long getRoleId() {
		return roleId;
	}

	public int getTplId() {
		return tplId;
	}

	public int getRank() {
		return rank;
	}
	
	public long getOwnerId() {
		return ownerId;
	}

	public void setOwnerId(long ownerId) {
		this.ownerId = ownerId;
	}
	
	
}
