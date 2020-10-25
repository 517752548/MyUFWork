package com.imop.lj.common.model.arena;

/**
 * 竞技场排名奖励信息
 * @author yu.zhao
 *
 */
public class ArenaRankRewardInfo {
	private int sectionId;
	private int rankMin;
	private int rankMax;
	private int icon;
	private String desc;
	
	public ArenaRankRewardInfo() {
		
	}

	public int getSectionId() {
		return sectionId;
	}

	public void setSectionId(int sectionId) {
		this.sectionId = sectionId;
	}

	public int getIcon() {
		return icon;
	}

	public void setIcon(int icon) {
		this.icon = icon;
	}

	public String getDesc() {
		return desc;
	}

	public void setDesc(String desc) {
		this.desc = desc;
	}

	public int getRankMin() {
		return rankMin;
	}

	public void setRankMin(int rankMin) {
		this.rankMin = rankMin;
	}

	public int getRankMax() {
		return rankMax;
	}

	public void setRankMax(int rankMax) {
		this.rankMax = rankMax;
	}

	@Override
	public String toString() {
		return "ArenaRankRewardInfo [sectionId=" + sectionId + ", rankMin="
				+ rankMin + ", rankMax=" + rankMax + ", icon=" + icon
				+ ", desc=" + desc + "]";
	}

}
