package com.imop.lj.gameserver.teampvp;

import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.common.exception.BattleCreateException;
import com.imop.lj.gameserver.battle.core.BattleDef.BattleType;
import com.imop.lj.gameserver.battle.core.Fighter;
import com.imop.lj.gameserver.team.TeamBattleProcess;
import com.imop.lj.gameserver.team.model.Team;

public class TeamPvpBattleProcess extends TeamBattleProcess {
	private Team attackerTeam;
	private Team defenderTeam;
	
	public TeamPvpBattleProcess(long attackerId, BattleType type,
			Fighter<?> attacker, Fighter<?> defender)
			throws BattleCreateException {
		super(attackerId, type, attacker, defender);
	}
	
	public TeamPvpBattleProcess(long attackerId, BattleType type,
			Fighter<?> attacker, Fighter<?> defender, boolean genReport)
			throws BattleCreateException {
		super(attackerId, type, attacker, defender, genReport);
	}

	public Team getAttackerTeam() {
		return attackerTeam;
	}

	public void setAttackerTeam(Team attackerTeam) {
		this.attackerTeam = attackerTeam;
	}

	public Team getDefenderTeam() {
		return defenderTeam;
	}

	public void setDefenderTeam(Team defenderTeam) {
		this.defenderTeam = defenderTeam;
	}
	
	@Override
	public int getTeamId(long roleId) {
		int teamId = 0;
		if (attackerTeam != null && attackerTeam.hasMember(roleId)) {
			teamId = attackerTeam.getId();
		} else if (defenderTeam != null && defenderTeam.hasMember(roleId)) {
			teamId = defenderTeam.getId();
		}
		return teamId;
	}
	
	@Override
	public int getSpeed() {
		//team pvp不能加速
		return SharedConstants.REPORT_SPEED_DEFAULT;
	}
}
