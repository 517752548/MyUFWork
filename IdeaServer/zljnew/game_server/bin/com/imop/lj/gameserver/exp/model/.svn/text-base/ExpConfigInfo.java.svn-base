package com.imop.lj.gameserver.exp.model;

import java.util.Map;

/**
 * 经验整体配置
 * 
 * @author yuanbo.gao
 * 
 */
public class ExpConfigInfo {
	/***
	 * 经验显示是否叠加显示
	 */
	private boolean isSum;

	/**
	 * 设置经验最大等级，如果为0默认level配置最大值
	 */
	private int maxLevel;

	/**
	 * 经验各个等级数值
	 */
	private Map<Integer, ExpLevelInfo> expLevelConfigs;

	public ExpConfigInfo(boolean isSum, int maxLevel) {
		this.isSum = isSum;
		this.maxLevel = maxLevel;
	}

	public boolean isSum() {
		return isSum;
	}

	public void setSum(boolean isSum) {
		this.isSum = isSum;
	}

	public int getMaxLevel() {
		return maxLevel;
	}

	public void setMaxLevel(int maxLevel) {
		this.maxLevel = maxLevel;
	}

	public Map<Integer, ExpLevelInfo> getExpLevelConfigs() {
		return expLevelConfigs;
	}

	public void setExpLevelConfigs(Map<Integer, ExpLevelInfo> expLevelConfigs) {
		this.expLevelConfigs = expLevelConfigs;
	}
}
