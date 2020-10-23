package com.imop.lj.gameserver.wizardraid.model;

import com.imop.lj.gameserver.wizardraid.WizardRaidDef.WRMonsterType;

public class WizardRaidMonster {
	private String uuid;
	
	private WRMonsterType type;
	
	private int npcId;
	
	/** 怪物刷出时的绝对时间 */
	private long startTime;
	/** 怪物刷出时的相对时间 */
	private long startPassTime;
	
	private boolean isDead;
	
	private long deadTime;
	
	public WizardRaidMonster() {
		
	}
	
	public boolean isBoss() {
		return type == WRMonsterType.BOSS;
	}

	public String getUuid() {
		return uuid;
	}

	public void setUuid(String uuid) {
		this.uuid = uuid;
	}

	public WRMonsterType getType() {
		return type;
	}

	public void setType(WRMonsterType type) {
		this.type = type;
	}

	public int getNpcId() {
		return npcId;
	}

	public void setNpcId(int npcId) {
		this.npcId = npcId;
	}

	public long getStartTime() {
		return startTime;
	}

	public void setStartTime(long startTime) {
		this.startTime = startTime;
	}

	public long getStartPassTime() {
		return startPassTime;
	}

	public void setStartPassTime(long startPassTime) {
		this.startPassTime = startPassTime;
	}

	public boolean isDead() {
		return isDead;
	}

	public void setDead(boolean isDead) {
		this.isDead = isDead;
	}

	public long getDeadTime() {
		return deadTime;
	}

	public void setDeadTime(long deadTime) {
		this.deadTime = deadTime;
	}

}
