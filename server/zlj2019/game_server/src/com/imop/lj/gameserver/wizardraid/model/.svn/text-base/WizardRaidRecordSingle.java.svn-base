package com.imop.lj.gameserver.wizardraid.model;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.wizardraid.WizardRaidDef.WRMonsterType;

public class WizardRaidRecordSingle extends WizardRaidRecordBase {
	/** 玩家Id */
	private long roleId;

	/** 最近一次登录开始计时时间 */
	private long lastStartTime;
	/** 计时后已过去的时间 */
	private long totalPassTime;
	
	
	public WizardRaidRecordSingle() {
		super();
	}
	
	/**
	 * 获取进入副本后，流逝的时间
	 * @return
	 */
	@Override
	public long getPassTimeUntilNow() {
		long passTime = totalPassTime;
		if (lastStartTime > 0) {
			long thisPassTime = Globals.getTimeService().now() - lastStartTime;
			if (thisPassTime < 0) {
				thisPassTime = 0;
			}
			passTime = totalPassTime + thisPassTime;
		}
		return passTime;
	}
	
	@Override
	public void giveFinalReward() {
		Globals.getWizardRaidService().giveRewardSingle(this, getTpl().getRewardId(), true);
	}
	
	@Override
	public void giveBossReward(int rewardId) {
		Globals.getWizardRaidService().giveRewardSingle(this, rewardId, false);
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

	public long getRoleId() {
		return roleId;
	}

	public void setRoleId(long roleId) {
		this.roleId = roleId;
	}

	public long getTotalPassTime() {
		return totalPassTime;
	}

	public void setTotalPassTime(long totalPassTime) {
		this.totalPassTime = totalPassTime;
	}

	public long getLastStartTime() {
		return lastStartTime;
	}

	public void setLastStartTime(long lastStartTime) {
		this.lastStartTime = lastStartTime;
	}

	@Override
	public String toString() {
		return "WizardRaidRecordSingle [roleId=" + roleId + ", lastStartTime="
				+ lastStartTime + ", totalPassTime=" + totalPassTime + "]";
	}

}
