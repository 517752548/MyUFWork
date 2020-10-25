package com.imop.lj.gameserver.exp.model;

/**
 * 加完经验以后等级
 * 
 * @author yuanbo.gao
 * 
 */
public class ExpResultInfo {
	/**
	 * 加完经验等级
	 */
	private int level;
	/**
	 * 加完经验
	 */
	private long currencyExp;
	/**
	 * 最大经验
	 */
	private long maxExp;

	/**
	 * 下一等级,如果为0表示最大经验
	 */
	private int nextLevel;

	/**
	 * 如果升级到下一等级所需经验,如果为0表示最大经验
	 */
	private long nextLevelRequire;

	/**
	 * 原始等级
	 */
	private int originalLevel;

	/**
	 * 原始经验
	 */
	private long originalExp;

	public int getLevel() {
		return level;
	}

	public void setLevel(int level) {
		this.level = level;
	}

	public long getCurrencyExp() {
		return currencyExp;
	}

	public void setCurrencyExp(long currencyExp) {
		this.currencyExp = currencyExp;
	}

	public long getMaxExp() {
		return maxExp;
	}

	public void setMaxExp(long maxExp) {
		this.maxExp = maxExp;
	}

	public int getNextLevel() {
		return nextLevel;
	}

	public void setNextLevel(int nextLevel) {
		this.nextLevel = nextLevel;
	}

	public long getNextLevelRequire() {
		return nextLevelRequire;
	}

	public void setNextLevelRequire(long nextLevelRequire) {
		this.nextLevelRequire = nextLevelRequire;
	}

	public int getOriginalLevel() {
		return originalLevel;
	}

	public void setOriginalLevel(int originalLevel) {
		this.originalLevel = originalLevel;
	}

	public long getOriginalExp() {
		return originalExp;
	}

	public void setOriginalExp(long originalExp) {
		this.originalExp = originalExp;
	}
	
	/**
	 * 获得需要升级到下一个等级所需要经验
	 * 
	 * @return
	 */
	public long getRequireExp(){
		long requireExp = this.maxExp - this.currencyExp;
		if(requireExp < 0){
			return 0;
		}
		return requireExp;
	}
	
	/**
	 * 是否达到最大级
	 * 
	 * @return
	 */
	public boolean isMaxLevel(){
		return this.nextLevel == 0;
	}
	
	/**
	 * 等级是否发生变化
	 * 
	 * @return
	 */
	public boolean isChangeLevel(){
		return this.originalLevel != this.level;
	}
	
	/**
	 * 等级或经验是否发生了变化
	 * @return
	 */
	public boolean isChanged() {
		return (this.originalLevel != this.level || this.originalExp != this.currencyExp);
	}

	@Override
	public String toString() {
		return "ExpResultInfo [level=" + level + ", currencyExp=" + currencyExp + ", maxExp=" + maxExp + ", nextLevel=" + nextLevel
				+ ", nextLevelRequire=" + nextLevelRequire + ", originalLevel=" + originalLevel + ", originalExp=" + originalExp + "]";
	}
}
