package com.imop.lj.gameserver.wizardraid.model;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.wizardraid.WizardRaidDef.WRMonsterType;

public class WizardRaidRecordTeam extends WizardRaidRecordBase {
	/** 队伍Id */
	private int teamId;
	
	public WizardRaidRecordTeam() {
		super();
	}

	@Override
	public void giveFinalReward() {
		Globals.getWizardRaidService().giveRewardTeam(this, getTpl().getRewardId(), true);
	}
	
	@Override
	public void giveBossReward(int rewardId) {
		Globals.getWizardRaidService().giveRewardTeam(this, rewardId, false);
	}
	
	@Override
	public void exitRaid() {
		Globals.getWizardRaidService().exitRaid(this);
	}
	
	@Override
	public void onEndRaidNotice() {
		Globals.getWizardRaidService().onEndRaidNotice(this);
	}
	
	@Override
	public void noticeMonster(int npcId, WRMonsterType type) {
		Globals.getWizardRaidService().noticeMonster(this, npcId, type);
	}
	
	@Override
	public long getPassTimeUntilNow() {
		return Globals.getTimeService().now() - getEnterTime();
	}
	
	public int getTeamId() {
		return teamId;
	}

	public void setTeamId(int teamId) {
		this.teamId = teamId;
	}

}
