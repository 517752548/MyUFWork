package com.imop.lj.common.model.allocate;

import java.util.Arrays;

public class AllocateMemberInfo {
	//玩家id
	private long roleId;
	//玩家姓名
	private String playerName;
	//玩家军团id
	private long corpsId;
	//玩家积分
	private int score;
	//玩家等级
	private int playerLevel;
	//玩家战力
	private int playerPower;
	//玩家帮派职务
	private int corpsJob;
	//已被分配到的奖励内容
	private AllocateItemInfo[] afterAllocateItemInfos;
	
	public long getRoleId() {
		return roleId;
	}


	public void setRoleId(long roleId) {
		this.roleId = roleId;
	}


	public String getPlayerName() {
		return playerName;
	}


	public void setPlayerName(String playerName) {
		this.playerName = playerName;
	}


	public long getCorpsId() {
		return corpsId;
	}


	public void setCorpsId(long corpsId) {
		this.corpsId = corpsId;
	}


	public int getScore() {
		return score;
	}


	public void setScore(int score) {
		this.score = score;
	}


	public int getPlayerLevel() {
		return playerLevel;
	}


	public void setPlayerLevel(int playerLevel) {
		this.playerLevel = playerLevel;
	}


	public int getPlayerPower() {
		return playerPower;
	}


	public void setPlayerPower(int playerPower) {
		this.playerPower = playerPower;
	}


	public int getCorpsJob() {
		return corpsJob;
	}


	public void setCorpsJob(int corpsJob) {
		this.corpsJob = corpsJob;
	}

	public AllocateItemInfo[] getAfterAllocateItemInfos() {
		return afterAllocateItemInfos;
	}


	public void setAfterAllocateItemInfos(AllocateItemInfo[] afterAllocateItemInfos) {
		this.afterAllocateItemInfos = afterAllocateItemInfos;
	}


	@Override
	public String toString() {
		return "AllocateMemberInfo [roleId=" + roleId + ", playerName=" + playerName + ", corpsId=" + corpsId
				+ ", score=" + score + ", playerLevel=" + playerLevel + ", playerPower=" + playerPower + ", corpsJob="
				+ corpsJob + ", afterAllocateItemInfos=" + Arrays.toString(afterAllocateItemInfos) + "]";
	}

}
