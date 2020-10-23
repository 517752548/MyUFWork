package com.imop.lj.gameserver.wizardraid.model;

import java.util.Map;

import com.google.common.collect.Maps;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.map.model.WizardRaidMap;
import com.imop.lj.gameserver.wizardraid.WizardRaidDef.WRMonsterType;
import com.imop.lj.gameserver.wizardraid.WizardRaidDef.WizardRaidType;
import com.imop.lj.gameserver.wizardraid.template.WizardRaidTemplate;

public abstract class WizardRaidRecordBase {
	/** 副本类型 */
	protected WizardRaidType type;
	
	/** 副本id */
	protected int raidId;
	
	/** 进入副本的时间 */
	protected long enterTime;
	
	/** 当前波数 */
	protected int curWave;
	/** 怪物集合，key为uuid */
	protected Map<String, WizardRaidMonster> monsterMap = Maps.newHashMap();
	/** 战胜的怪物数量（含boss） */
	protected int winMonsterNum;
	/** 战胜的boss数量 */
	protected int winBossNum;
	
	/** 已经刷出的普通怪个数 */
	protected int genNormalMonsterNum;

	/** 副本地图 */
	protected WizardRaidMap map;
	
	public WizardRaidRecordBase() {
		map = new WizardRaidMap();
	}
	
	public abstract void giveFinalReward();
	
	public abstract void giveBossReward(int rewardId);
	
	public abstract void exitRaid();
	
	public abstract void onEndRaidNotice();
	
	public abstract void noticeMonster(int npcId, WRMonsterType type);
	
	/**
	 * 进入副本后，流逝（过去）的时间
	 * @return
	 */
	public abstract long getPassTimeUntilNow();
	
	public WizardRaidTemplate getTpl() {
		return Globals.getTemplateCacheService().get(this.raidId, WizardRaidTemplate.class);
	}
	
	public int getCurMonsterNum() {
		return monsterMap.size();
	}

	public WizardRaidMonster getMonster(String uuid) {
		return monsterMap.get(uuid);
	}
	
	public WizardRaidType getType() {
		return type;
	}

	public void setType(WizardRaidType type) {
		this.type = type;
	}

	public int getRaidId() {
		return raidId;
	}

	public void setRaidId(int raidId) {
		this.raidId = raidId;
	}

	public long getEnterTime() {
		return enterTime;
	}

	public void setEnterTime(long enterTime) {
		this.enterTime = enterTime;
	}

	public int getCurWave() {
		return curWave;
	}

	public void setCurWave(int curWave) {
		this.curWave = curWave;
	}

	public Map<String, WizardRaidMonster> getMonsterMap() {
		return monsterMap;
	}

	public void setMonsterMap(Map<String, WizardRaidMonster> monsterMap) {
		this.monsterMap = monsterMap;
	}

	public int getWinMonsterNum() {
		return winMonsterNum;
	}

	public void setWinMonsterNum(int winMonsterNum) {
		this.winMonsterNum = winMonsterNum;
	}

	public int getWinBossNum() {
		return winBossNum;
	}

	public void setWinBossNum(int winBossNum) {
		this.winBossNum = winBossNum;
	}

	public WizardRaidMap getMap() {
		return map;
	}

	public int getGenNormalMonsterNum() {
		return genNormalMonsterNum;
	}

	public void setGenNormalMonsterNum(int genNormalMonsterNum) {
		this.genNormalMonsterNum = genNormalMonsterNum;
	}

	@Override
	public String toString() {
		return "WizardRaidRecordBase [type=" + type + ", raidId=" + raidId
				+ ", enterTime=" + enterTime + ", curWave=" + curWave
				+ ", winMonsterNum=" + winMonsterNum + "]";
	}

}
