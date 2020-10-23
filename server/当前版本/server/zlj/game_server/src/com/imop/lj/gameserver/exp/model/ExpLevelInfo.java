package com.imop.lj.gameserver.exp.model;

public class ExpLevelInfo {

	/**
	 * 当前等级
	 */
	private int level;

	/**
	 * 升级到下一等级所需等级
	 * 
	 */
	private long requireExp;

	/**
	 * 
	 * 从最低级到此等级所需全部经验
	 * 假设最高级是10级,第8级sumExp是9级之前的经验总和
	 * 假设最高级是10级,第9级sumExp是10级之前的经验总和
	 * 假设最高级是10级,第10级sumExp是10级之前的经验总和
	 * 
	 */
	private long sumExp;

	public int getLevel() {
		return level;
	}

	public void setLevel(int level) {
		this.level = level;
	}

	public long getRequireExp() {
		return requireExp;
	}

	public void setRequireExp(long requireExp) {
		this.requireExp = requireExp;
	}

	public long getSumExp() {
		return sumExp;
	}

	public void setSumExp(long sumExp) {
		this.sumExp = sumExp;
	}

	@Override
	public String toString() {
		return "ExpLevelInfo [level=" + level + ", requireExp=" + requireExp + ", sumExp=" + sumExp + "]";
	}

}
