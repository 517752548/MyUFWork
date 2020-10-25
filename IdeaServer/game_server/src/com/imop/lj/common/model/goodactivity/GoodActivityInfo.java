package com.imop.lj.common.model.goodactivity;


public class GoodActivityInfo {
	private long activityId;
	private int typeId;
	private int icon;
	private int nameIcon;
	private int titleIcon;
	private String name;
	private String desc;
	private String[] logList;
	
	private int isNew;
	private long startTime;
	private long endTime;
	private int hasUnGotBonus;
	private long countDownTime;
	private String countDownTimeDesc;
	private String selfInfo;
	private String targetInfo;
	private int showTargetType;
	/** 最近开启的 */
	private int isRecentOpen;
	/** 最近结束的 */
	private int isRecentClose;
	/** 是否需要隐藏 */
	private int needHide;

	public long getActivityId() {
		return activityId;
	}

	public void setActivityId(long activityId) {
		this.activityId = activityId;
	}

	public int getTypeId() {
		return typeId;
	}

	public void setTypeId(int typeId) {
		this.typeId = typeId;
	}

	public int getIcon() {
		return icon;
	}

	public void setIcon(int icon) {
		this.icon = icon;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getDesc() {
		return desc;
	}

	public void setDesc(String desc) {
		this.desc = desc;
	}

	public int getIsNew() {
		return isNew;
	}

	public void setIsNew(int isNew) {
		this.isNew = isNew;
	}

	public long getStartTime() {
		return startTime;
	}

	public void setStartTime(long startTime) {
		this.startTime = startTime;
	}

	public long getEndTime() {
		return endTime;
	}

	public void setEndTime(long endTime) {
		this.endTime = endTime;
	}

	public int getHasUnGotBonus() {
		return hasUnGotBonus;
	}

	public void setHasUnGotBonus(int hasUnGotBonus) {
		this.hasUnGotBonus = hasUnGotBonus;
	}

	public String getTargetInfo() {
		return targetInfo;
	}

	public void setTargetInfo(String targetInfo) {
		this.targetInfo = targetInfo;
	}

	public int getNameIcon() {
		return nameIcon;
	}

	public void setNameIcon(int nameIcon) {
		this.nameIcon = nameIcon;
	}

	public long getCountDownTime() {
		return countDownTime;
	}

	public void setCountDownTime(long countDownTime) {
		this.countDownTime = countDownTime;
	}

	public String getCountDownTimeDesc() {
		return countDownTimeDesc;
	}

	public void setCountDownTimeDesc(String countDownTimeDesc) {
		this.countDownTimeDesc = countDownTimeDesc;
	}

	public String getSelfInfo() {
		return selfInfo;
	}

	public void setSelfInfo(String selfInfo) {
		this.selfInfo = selfInfo;
	}

	public int getShowTargetType() {
		return showTargetType;
	}

	public void setShowTargetType(int showTargetType) {
		this.showTargetType = showTargetType;
	}

	public int getTitleIcon() {
		return titleIcon;
	}

	public void setTitleIcon(int titleIcon) {
		this.titleIcon = titleIcon;
	}

	public int getIsRecentOpen() {
		return isRecentOpen;
	}

	public void setIsRecentOpen(int isRecentOpen) {
		this.isRecentOpen = isRecentOpen;
	}

	public int getIsRecentClose() {
		return isRecentClose;
	}

	public void setIsRecentClose(int isRecentClose) {
		this.isRecentClose = isRecentClose;
	}

	public String[] getLogList() {
		return logList;
	}

	public void setLogList(String[] logList) {
		this.logList = logList;
	}

	public int getNeedHide() {
		return needHide;
	}

	public void setNeedHide(int needHide) {
		this.needHide = needHide;
	}
	
}
