package com.imop.lj.common.model.pet;

/**
 * 显示武将详细信息的数据结构
 * @author yue.yan
 *
 */
public class PetDetailInfo {

	/** 武将id */
	private int id;
	/** 名称 */
	private String name;
	/** 头像 */
	private int photo;
	/** 武将等级 */
	private int level;
	/** 简介 */
	private String desc;
	/** 当前兵数 */
	private int amount;
	/** 最大兵数 */
	private int maxAmount;
	/** 统属性 */
	private int leaderShip;
	/** 勇属性 */
	private int might;
	/** 智属性 */
	private int intellect;
	/** 兵种名称 */
	private String soldierTypeName;
	/** 兵种描述 */
	private String soldierTypeDesc;
	/** 士兵等级 */
	private int soldierLevel;
	/** 战法名称 */
	private String skillName;
	/** 战法描述 */
	private String skillDesc;
	/** 招募状态 */
	private int hireStatus;
	/** 招募价格 */
	private int hireCost;

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public int getPhoto() {
		return photo;
	}

	public void setPhoto(int photo) {
		this.photo = photo;
	}

	public int getLevel() {
		return level;
	}

	public void setLevel(int level) {
		this.level = level;
	}

	public String getDesc() {
		return desc;
	}

	public void setDesc(String desc) {
		this.desc = desc;
	}

	public int getAmount() {
		return amount;
	}

	public void setAmount(int amount) {
		this.amount = amount;
	}

	public int getMaxAmount() {
		return maxAmount;
	}

	public void setMaxAmount(int maxAmount) {
		this.maxAmount = maxAmount;
	}

	public int getLeaderShip() {
		return leaderShip;
	}

	public void setLeaderShip(int leaderShip) {
		this.leaderShip = leaderShip;
	}

	public int getMight() {
		return might;
	}

	public void setMight(int might) {
		this.might = might;
	}

	public int getIntellect() {
		return intellect;
	}

	public void setIntellect(int intellect) {
		this.intellect = intellect;
	}

	public String getSoldierTypeName() {
		return soldierTypeName;
	}

	public void setSoldierTypeName(String soldierTypeName) {
		this.soldierTypeName = soldierTypeName;
	}

	public int getSoldierLevel() {
		return soldierLevel;
	}

	public void setSoldierLevel(int soldierLevel) {
		this.soldierLevel = soldierLevel;
	}

	public String getSkillName() {
		return skillName;
	}

	public void setSkillName(String skillName) {
		this.skillName = skillName;
	}

	public int getHireStatus() {
		return hireStatus;
	}

	public void setHireStatus(int hireStatus) {
		this.hireStatus = hireStatus;
	}

	public int getHireCost() {
		return hireCost;
	}

	public void setHireCost(int hireCost) {
		this.hireCost = hireCost;
	}

	public String getSkillDesc() {
		return skillDesc;
	}

	public void setSkillDesc(String skillDesc) {
		this.skillDesc = skillDesc;
	}

	public String getSoldierTypeDesc() {
		return soldierTypeDesc;
	}

	public void setSoldierTypeDesc(String soldierTypeDesc) {
		this.soldierTypeDesc = soldierTypeDesc;
	}

}
