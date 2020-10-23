package com.imop.lj.common.model.human;

import com.imop.lj.common.model.reward.RewardInfo;

public class SevenSigninDayInfo {
	private int day;
	private int hasGetReward;
	private int canGetReward;
	private RewardInfo rewardInfo;
	
	public SevenSigninDayInfo() {
		
	}

	public int getDay() {
		return day;
	}

	public void setDay(int day) {
		this.day = day;
	}

	public int getHasGetReward() {
		return hasGetReward;
	}

	public void setHasGetReward(int hasGetReward) {
		this.hasGetReward = hasGetReward;
	}

	public int getCanGetReward() {
		return canGetReward;
	}

	public void setCanGetReward(int canGetReward) {
		this.canGetReward = canGetReward;
	}

	public RewardInfo getRewardInfo() {
		return rewardInfo;
	}

	public void setRewardInfo(RewardInfo rewardInfo) {
		this.rewardInfo = rewardInfo;
	}
	
}
