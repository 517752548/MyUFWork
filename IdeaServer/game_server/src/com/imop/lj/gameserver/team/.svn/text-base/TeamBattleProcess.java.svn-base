package com.imop.lj.gameserver.team;

import java.util.Map;

import com.google.common.collect.Maps;
import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.common.exception.BattleCreateException;
import com.imop.lj.gameserver.battle.BattleProcess;
import com.imop.lj.gameserver.battle.core.BattleDef.BattleType;
import com.imop.lj.gameserver.battle.core.Fighter;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.team.model.Team;
import com.imop.lj.gameserver.team.model.TeamPlayerBattleInfo;

public class TeamBattleProcess extends BattleProcess {
	private Team team;
	private Map<Long, TeamPlayerBattleInfo> battleInfoMap = Maps.newHashMap();
	
	public TeamBattleProcess(long attackerId, BattleType type,
			Fighter<?> attacker, Fighter<?> defender)
			throws BattleCreateException {
		super(attackerId, type, attacker, defender);
	}
	
	public TeamBattleProcess(long attackerId, BattleType type,
			Fighter<?> attacker, Fighter<?> defender, boolean genReport)
			throws BattleCreateException {
		super(attackerId, type, attacker, defender, genReport);
	}
	
	public int getTeamId(long roleId) {
		return team != null ? team.getId() : 0;
	}

	public Team getTeam() {
		return team;
	}

	public void setTeam(Team team) {
		this.team = team;
	}

	public Map<Long, TeamPlayerBattleInfo> getBattleInfoMap() {
		return battleInfoMap;
	}

	public void setBattleInfoMap(Map<Long, TeamPlayerBattleInfo> battleInfoMap) {
		this.battleInfoMap = battleInfoMap;
	}
	
	public void removeBattleInfo(long roleId) {
		this.battleInfoMap.remove(roleId);
	}
	
	public int getBattleInfoNum() {
		return battleInfoMap.size();
	}

	@Override
	public TeamPlayerBattleInfo getPlayerInfo(long roleId) {
		return battleInfoMap.get(roleId);
	}
	
	@Override
	public boolean isAllSet() {
		boolean flag = true;
		for (TeamPlayerBattleInfo info : battleInfoMap.values()) {
			flag &= info.isLastSetFlag();
			if (!flag) {
				break;
			}
		}
		return flag;
	}
	
	@Override
	public boolean isAllReadLast() {
		boolean flag = true;
		for (TeamPlayerBattleInfo info : battleInfoMap.values()) {
			flag &= info.isReadLast();
			if (!flag) {
				break;
			}
		}
		return flag;
	}
	
	@Override
	public int getSpeed() {
		//组队pve的速度取队长的
		int speed = SharedConstants.REPORT_SPEED_DEFAULT;
		if (team != null && team.getLeader() != null) {
			speed = Globals.getBattleService().getBattleSpeedByRoleId(team.getLeader().getRoleId());
		}
		return speed;
	}
	
}
