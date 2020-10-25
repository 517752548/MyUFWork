package com.imop.lj.common.model;

import com.imop.lj.common.model.reward.RewardInfo;

/**
 * @author Administrator
 *
 */
public class BackupPubTaskInfo {
	private int questId;
	private int star;
	private int status;
	private RewardInfo rewardInfo = new RewardInfo();
	
	public int getQuestId() {
		return questId;
	}
	public void setQuestId(int questId) {
		this.questId = questId;
	}
	public int getStar() {
		return star;
	}
	public void setStar(int star) {
		this.star = star;
	}
	public int getStatus() {
		return status;
	}
	public void setStatus(int status) {
		this.status = status;
	}
	public RewardInfo getRewardInfo() {
		return rewardInfo;
	}
	public void setRewardInfo(RewardInfo rewardInfo) {
		this.rewardInfo = rewardInfo;
	}
	
	@Override
	public String toString() {
		return "BackupPubTaskInfo [questId=" + questId + ", star=" + star + ", status=" + status + ", rewardInfo="
				+ rewardInfo + "]";
	}
	
}
