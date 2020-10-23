package com.imop.lj.common.model.corps;

/**
 * 帮派福利信息
 *
 */
public class CorpsBenifitInfo {
	/**帮派ID	 */
	private long corpsId;
	/**上周帮贡 */
	private int lastWeekContribution;
	/** 是否可领取 ,1可以,0不可以*/
	private int canReceive;
	
	public long getCorpsId() {
		return corpsId;
	}
	public void setCorpsId(long corpsId) {
		this.corpsId = corpsId;
	}
	public int getLastWeekContribution() {
		return lastWeekContribution;
	}
	public void setLastWeekContribution(int lastWeekContribution) {
		this.lastWeekContribution = lastWeekContribution;
	}
	public int getCanReceive() {
		return canReceive;
	}
	public void setCanReceive(int canReceive) {
		this.canReceive = canReceive;
	}
	@Override
	public String toString() {
		return "CorpsBenifitInfo [corpsId=" + corpsId + ", lastWeekContribution=" + lastWeekContribution
				+ ", canReceive=" + canReceive + "]";
	}
	
}
