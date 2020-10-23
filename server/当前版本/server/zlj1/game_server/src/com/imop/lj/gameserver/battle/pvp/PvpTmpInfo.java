package com.imop.lj.gameserver.battle.pvp;

public class PvpTmpInfo {
	private long attackerId;
	private long defenderId;
	private long startTime;
	
	public PvpTmpInfo(long attackerId, long defenderId, long startTime) {
		this.attackerId = attackerId;
		this.defenderId = defenderId;
		this.startTime = startTime;
	}
	
	public long getAttackerId() {
		return attackerId;
	}
	public void setAttackerId(long attackerId) {
		this.attackerId = attackerId;
	}
	public long getDefenderId() {
		return defenderId;
	}
	public void setDefenderId(long defenderId) {
		this.defenderId = defenderId;
	}
	public long getStartTime() {
		return startTime;
	}
	public void setStartTime(long startTime) {
		this.startTime = startTime;
	}
	
}
