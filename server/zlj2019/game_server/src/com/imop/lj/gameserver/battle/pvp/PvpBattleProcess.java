package com.imop.lj.gameserver.battle.pvp;

import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.common.exception.BattleCreateException;
import com.imop.lj.gameserver.battle.BattleProcess;
import com.imop.lj.gameserver.battle.core.BattleDef.BattleType;
import com.imop.lj.gameserver.battle.core.Fighter;

public class PvpBattleProcess extends BattleProcess {
	
	private PvpPlayerInfo attackerInfo;
	private PvpPlayerInfo defenderInfo;
	
	private boolean isPlayerTrigger;

	public PvpBattleProcess(long attackerId, BattleType type,
			Fighter<?> attacker, Fighter<?> defender)
			throws BattleCreateException {
		super(attackerId, type, attacker, defender);
	}
	
	public PvpBattleProcess(long attackerId, BattleType type,
			Fighter<?> attacker, Fighter<?> defender, boolean genReport)
			throws BattleCreateException {
		super(attackerId, type, attacker, defender, genReport);
	}

	public PvpPlayerInfo getAttackerInfo() {
		return attackerInfo;
	}

	public void setAttackerInfo(PvpPlayerInfo attackerInfo) {
		this.attackerInfo = attackerInfo;
	}

	public PvpPlayerInfo getDefenderInfo() {
		return defenderInfo;
	}

	public void setDefenderInfo(PvpPlayerInfo defenderInfo) {
		this.defenderInfo = defenderInfo;
	}

	public boolean isPlayerTrigger() {
		return isPlayerTrigger;
	}

	public void setPlayerTrigger(boolean isPlayerTrigger) {
		this.isPlayerTrigger = isPlayerTrigger;
	}

	public PvpPlayerInfo getPlayerInfo(long humanId) {
		if (attackerInfo.getHumanId() == humanId) {
			return getAttackerInfo();
		}
		if (defenderInfo.getHumanId() == humanId) {
			return getDefenderInfo();
		}
		return null;
	}

	@Override
	public boolean isAllSet() {
		return attackerInfo.isLastSetFlag() && defenderInfo.isLastSetFlag();
	}
	
	@Override
	public boolean isAllReadLast() {
		return attackerInfo.isReadLast() && defenderInfo.isReadLast();
	}
	
	@Override
	public int getSpeed() {
		//pvp不能加速
		return SharedConstants.REPORT_SPEED_DEFAULT;
	}

	@Override
	public String toString() {
		return "PvpBattleProcess [attackerInfo=" + attackerInfo
				+ ", defenderInfo=" + defenderInfo + ", isPlayerTrigger="
				+ isPlayerTrigger + "]";
	}
	
}
