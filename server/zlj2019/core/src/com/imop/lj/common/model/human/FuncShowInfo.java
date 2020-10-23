package com.imop.lj.common.model.human;

public class FuncShowInfo {
	private int funcType;
	private int ownerFuncType;
	private int isOpened;
	private String icon;
	private int effect;
	private String name;
	private String desc;
	private int showNum;
	private Long countDownTime;
	private int position;
	private int order;
	private long totalCountDownTime;
	private String menuDesc;
	private int groupID;
	/** 是否第一次开启 */
	private int isFirstOpen;

	public FuncShowInfo() {

	}

	public int getFuncType() {
		return funcType;
	}

	public void setFuncType(int funcType) {
		this.funcType = funcType;
	}

	public int getOwnerFuncType() {
		return ownerFuncType;
	}

	public void setOwnerFuncType(int ownerFuncType) {
		this.ownerFuncType = ownerFuncType;
	}

	public int getIsOpened() {
		return isOpened;
	}

	public void setIsOpened(int isOpened) {
		this.isOpened = isOpened;
	}

	public String getIcon() {
		return icon;
	}

	public void setIcon(String icon) {
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

	public int getEffect() {
		return effect;
	}

	public void setEffect(int effect) {
		this.effect = effect;
	}

	public int getShowNum() {
		return showNum;
	}

	public void setShowNum(int showNum) {
		this.showNum = showNum;
	}

	public Long getCountDownTime() {
		return countDownTime;
	}

	public void setCountDownTime(Long countDownTime) {
		this.countDownTime = countDownTime;
	}

	public int getPosition() {
		return position;
	}

	public void setPosition(int position) {
		this.position = position;
	}

	public int getOrder() {
		return order;
	}

	public void setOrder(int order) {
		this.order = order;
	}

	public int getIsFirstOpen() {
		return isFirstOpen;
	}

	public void setIsFirstOpen(int isFirstOpen) {
		this.isFirstOpen = isFirstOpen;
	}

	public long getTotalCountDownTime() {
		return totalCountDownTime;
	}

	public void setTotalCountDownTime(long totalCountDownTime) {
		this.totalCountDownTime = totalCountDownTime;
	}

	public String getMenuDesc() {
		return menuDesc;
	}

	public void setMenuDesc(String menuDesc) {
		this.menuDesc = menuDesc;
	}
	
	public int getGroupID() {
		return groupID;
	}

	public void setGroupID(int groupID) {
		this.groupID = groupID;
	}

	@Override
	public String toString() {
		return "FuncShowInfo [funcType=" + funcType + ", ownerFuncType="
				+ ownerFuncType + ", isOpened=" + isOpened + ", icon=" + icon
				+ ", effect=" + effect + ", name=" + name + ", desc=" + desc
				+ ", showNum=" + showNum + ", countDownTime=" + countDownTime
				+ ", position=" + position + ", order=" + order
				+ ", isFirstOpen=" + isFirstOpen + "]";
	}

}
