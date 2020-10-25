package com.imop.lj.gameserver.activityui;

import com.imop.lj.common.model.reward.RewardInfo;

public class ActivityUIRewardInfo {
	
	private int vitalityNum;
	private RewardInfo rewardInfo;
	
	public ActivityUIRewardInfo() {
		super();
	}
	public ActivityUIRewardInfo(int vitalityNum, RewardInfo rewardInfo) {
		super();
		this.vitalityNum = vitalityNum;
		this.rewardInfo = rewardInfo;
	}
	public int getVitalityNum() {
		return vitalityNum;
	}
	public void setVitalityNum(int vitalityNum) {
		this.vitalityNum = vitalityNum;
	}
	public RewardInfo getRewardInfo() {
		return rewardInfo;
	}
	public void setRewardInfo(RewardInfo rewardInfo) {
		this.rewardInfo = rewardInfo;
	}
	
}
