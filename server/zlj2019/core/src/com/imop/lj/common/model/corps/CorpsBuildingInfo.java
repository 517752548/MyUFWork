package com.imop.lj.common.model.corps;

/**
 * 帮派建筑信息
 *
 */
public class CorpsBuildingInfo {
	/**帮派ID	 */
	private long corpsId;
	/** 建筑类型*/
	private int buildType;
	/**建筑名称 */
	private String buildingName;
	/**建筑功能介绍*/
	private String buildingDesc;
	/**建筑等级 */
	private int buildingLevel;
	/**当前等级升级倒计时,以毫秒为单位*/
	private long upgradeCountDownTime;
	
	public long getCorpsId() {
		return corpsId;
	}
	public void setCorpsId(long corpsId) {
		this.corpsId = corpsId;
	}
	
	public int getBuildType() {
		return buildType;
	}
	public void setBuildType(int buildType) {
		this.buildType = buildType;
	}
	public String getBuildingName() {
		return buildingName;
	}
	public void setBuildingName(String buildingName) {
		this.buildingName = buildingName;
	}
	public String getBuildingDesc() {
		return buildingDesc;
	}
	public void setBuildingDesc(String buildingDesc) {
		this.buildingDesc = buildingDesc;
	}
	public int getBuildingLevel() {
		return buildingLevel;
	}
	public void setBuildingLevel(int buildingLevel) {
		this.buildingLevel = buildingLevel;
	}
	
	public long getUpgradeCountDownTime() {
		return upgradeCountDownTime;
	}
	public void setUpgradeCountDownTime(long upgradeCountDownTime) {
		this.upgradeCountDownTime = upgradeCountDownTime;
	}
	@Override
	public String toString() {
		return "CorpsBuildingInfo [corpsId=" + corpsId + ", buildType=" + buildType + ", buildingName=" + buildingName
				+ ", buildingDesc=" + buildingDesc + ", buildingLevel=" + buildingLevel + ", upgradeCountDownTime="
				+ upgradeCountDownTime + "]";
	}

	
	
}
