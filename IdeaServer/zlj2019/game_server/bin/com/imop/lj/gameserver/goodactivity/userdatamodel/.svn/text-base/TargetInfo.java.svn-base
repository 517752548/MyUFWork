package com.imop.lj.gameserver.goodactivity.userdatamodel;

import com.imop.lj.gameserver.common.Globals;

/**
 * 精彩活动目标对象
 * 用于记录目标已达成次数和领取奖励次数，已经对应的最后一次更新时间
 * 
 * @author yu.zhao
 *
 */
public class TargetInfo {
	/** 目标Id */
	private int targetId;
	/** 达到条件的次数 */
	private int reachNum;
	/** 已领取奖励的次数 */
	private int giveBonusNum;
	/** 最后一次更新reachNum的时间 */
	private long lastUpdateReachNumTime;
	/** 最后一次更新giveBonusNum的时间 */
	private long lastUpdateGiveBonusNumTime;
	
	public TargetInfo(int targetId) {
		this.targetId = targetId;
	}
	
	public TargetInfo(int targetId, int reachNum, int giveBonusNum) {
		this.targetId = targetId;
		this.reachNum = reachNum;
		this.giveBonusNum = giveBonusNum;
	}

	public int getTargetId() {
		return targetId;
	}

	public void setTargetId(int targetId) {
		this.targetId = targetId;
	}

	public int getReachNum() {
		return reachNum;
	}

	public void setReachNum(int reachNum) {
		this.reachNum = reachNum;
		setLastUpdateReachNumTime(Globals.getTimeService().now());
	}

	public int getGiveBonusNum() {
		return giveBonusNum;
	}

	public void setGiveBonusNum(int giveBonusNum) {
		this.giveBonusNum = giveBonusNum;
		setLastUpdateGiveBonusNumTime(Globals.getTimeService().now());
	}

	public long getLastUpdateReachNumTime() {
		return lastUpdateReachNumTime;
	}

	public void setLastUpdateReachNumTime(long lastUpdateReachNumTime) {
		this.lastUpdateReachNumTime = lastUpdateReachNumTime;
	}

	public long getLastUpdateGiveBonusNumTime() {
		return lastUpdateGiveBonusNumTime;
	}

	public void setLastUpdateGiveBonusNumTime(long lastUpdateGiveBonusNumTime) {
		this.lastUpdateGiveBonusNumTime = lastUpdateGiveBonusNumTime;
	}

}
