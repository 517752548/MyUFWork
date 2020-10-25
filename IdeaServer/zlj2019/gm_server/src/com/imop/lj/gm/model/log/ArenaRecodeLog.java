package com.imop.lj.gm.model.log;

import java.util.List;

public class ArenaRecodeLog extends BaseLog {
	private String battleResult;//战斗结果
	private long attackerId;//攻击者id
	private int attackerBeforeCwinTimes;//攻击者战斗前连胜数
	private int attackerAfterCwinTimes;//攻击者战斗后连胜数
	private int attackerBeforeRank;//攻击者战斗前名次
	private int attackerAfterRank;//攻击者战斗后名次
	private long defenderId;//防御方id
	private int defenderBeforeCwinTimes;//防御方战斗前连胜数
	private int defenderAfterCwinTimes;//防御方战斗后连胜数
	private int defenderBeforeRank;//防御方战斗前名次
	private int defenderAfterRank;//防御方战斗后名次
	public String getBattleResult() {
		return battleResult;
	}
	public void setBattleResult(String battleResult) {
		this.battleResult = battleResult;
	}
	public long getAttackerId() {
		return attackerId;
	}
	public void setAttackerId(long attackerId) {
		this.attackerId = attackerId;
	}
	public int getAttackerBeforeCwinTimes() {
		return attackerBeforeCwinTimes;
	}
	public void setAttackerBeforeCwinTimes(int attackerBeforeCwinTimes) {
		this.attackerBeforeCwinTimes = attackerBeforeCwinTimes;
	}
	public int getAttackerAfterCwinTimes() {
		return attackerAfterCwinTimes;
	}
	public void setAttackerAfterCwinTimes(int attackerAfterCwinTimes) {
		this.attackerAfterCwinTimes = attackerAfterCwinTimes;
	}
	public int getAttackerBeforeRank() {
		return attackerBeforeRank;
	}
	public void setAttackerBeforeRank(int attackerBeforeRank) {
		this.attackerBeforeRank = attackerBeforeRank;
	}
	public int getAttackerAfterRank() {
		return attackerAfterRank;
	}
	public void setAttackerAfterRank(int attackerAfterRank) {
		this.attackerAfterRank = attackerAfterRank;
	}
	public long getDefenderId() {
		return defenderId;
	}
	public void setDefenderId(long defenderId) {
		this.defenderId = defenderId;
	}
	public int getDefenderBeforeCwinTimes() {
		return defenderBeforeCwinTimes;
	}
	public void setDefenderBeforeCwinTimes(int defenderBeforeCwinTimes) {
		this.defenderBeforeCwinTimes = defenderBeforeCwinTimes;
	}
	public int getDefenderAfterCwinTimes() {
		return defenderAfterCwinTimes;
	}
	public void setDefenderAfterCwinTimes(int defenderAfterCwinTimes) {
		this.defenderAfterCwinTimes = defenderAfterCwinTimes;
	}
	public int getDefenderBeforeRank() {
		return defenderBeforeRank;
	}
	public void setDefenderBeforeRank(int defenderBeforeRank) {
		this.defenderBeforeRank = defenderBeforeRank;
	}
	public int getDefenderAfterRank() {
		return defenderAfterRank;
	}
	public void setDefenderAfterRank(int defenderAfterRank) {
		this.defenderAfterRank = defenderAfterRank;
	}
	@SuppressWarnings("unchecked")
	@Override
	public List toList(){
		List list = super.toList();
		list.add(battleResult);
		list.add(attackerId);
		list.add(attackerBeforeCwinTimes);
		list.add(attackerAfterCwinTimes);
		list.add(attackerBeforeRank);
		list.add(attackerAfterRank);
		list.add(defenderId);
		list.add(defenderBeforeCwinTimes);
		list.add(defenderAfterCwinTimes);
		list.add(defenderBeforeRank);
		list.add(defenderAfterRank);

		return list;
	}
}
