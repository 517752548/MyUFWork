package com.imop.lj.gameserver.prize;

public class UserPrizeItemTipInfo {
	/** 数量*/
	private int num;
	/** 名称 */
	private String name;
	/** 颜色*/
	private String color;
	/** 如果是金钱，则有此属性，物品此属性值为-1*/
	private int moneyType;
	
	public UserPrizeItemTipInfo() {
		super();
	}
	public UserPrizeItemTipInfo(int num, String name, String color, int moneyType) {
		super();
		this.num = num;
		this.name = name;
		this.color = color;
		this.moneyType = moneyType;
	}
	public int getNum() {
		return num;
	}
	public void setNum(int num) {
		this.num = num;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public String getColor() {
		return color;
	}
	public void setColor(String color) {
		this.color = color;
	}
	public int getMoneyType() {
		return moneyType;
	}
	public void setMoneyType(int moneyType) {
		this.moneyType = moneyType;
	}
	
}
