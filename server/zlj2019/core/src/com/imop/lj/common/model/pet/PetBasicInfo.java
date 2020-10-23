package com.imop.lj.common.model.pet;

/**
 * 沒有实例的武将基础信息，与客户端通信使用
 * 
 * @author xiaowei.liu
 * 
 */
public class PetBasicInfo {
	/** 武将ID */
	private long petId;
	/** 武将模版ID */
	private int petTempId;
	/** 武将品质 */
	private int quality;
	/** 武将头像ID */
	private int photoId;
	/** 武将姓名 */
	private String petName;
	/** 武将等级 */
	private int level;
	/** 武将描述 */
	private String desc;
	/** 武将类型 */
	private int jobType;
	/** 力量 */
	private int strength;
	/** 敏捷 */
	private int agility;
	/** 智力 */
	private int intellect;
	/** 生命 */
	private int life;
	/** 力量成长率 */
	private int strengthGrowthRate;
	/** 敏捷成长率 */
	private int agilityGrowthRate;
	/** 智力成长率 */
	private int intellectGrowthRate;
	/** 生命成长率 */
	private int lifeGrowthRate;
	/** 技能名称 */
	private String skillName;
	/** 技能描述 */
	private String skillDesc;
	/** 天赋名称 */
	private String talentName;
	/** 天赋描述 */
	private String talentDesc;
	/** 资源id 2013-11-27+*/
	private int resId;
	/** 位置 2013-11-27+*/
	private int positionType;

	public long getPetId() {
		return petId;
	}

	public void setPetId(long petId) {
		this.petId = petId;
	}

	public int getPetTempId() {
		return petTempId;
	}

	public void setPetTempId(int petTempId) {
		this.petTempId = petTempId;
	}

	public String getPetName() {
		return petName;
	}

	public void setPetName(String petName) {
		this.petName = petName;
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

	public int getJobType() {
		return jobType;
	}

	public void setJobType(int jobType) {
		this.jobType = jobType;
	}

	public String getSkillName() {
		return skillName;
	}

	public void setSkillName(String skillName) {
		this.skillName = skillName;
	}

	public String getSkillDesc() {
		return skillDesc;
	}

	public void setSkillDesc(String skillDesc) {
		this.skillDesc = skillDesc;
	}

	public String getTalentName() {
		return talentName;
	}

	public void setTalentName(String talentName) {
		this.talentName = talentName;
	}

	public String getTalentDesc() {
		return talentDesc;
	}

	public void setTalentDesc(String talentDesc) {
		this.talentDesc = talentDesc;
	}

	public int getStrength() {
		return strength;
	}

	public void setStrength(int strength) {
		this.strength = strength;
	}

	public int getAgility() {
		return agility;
	}

	public void setAgility(int agility) {
		this.agility = agility;
	}

	public int getIntellect() {
		return intellect;
	}

	public void setIntellect(int intellect) {
		this.intellect = intellect;
	}

	public int getLife() {
		return life;
	}

	public void setLife(int life) {
		this.life = life;
	}

	public int getStrengthGrowthRate() {
		return strengthGrowthRate;
	}

	public void setStrengthGrowthRate(int strengthGrowthRate) {
		this.strengthGrowthRate = strengthGrowthRate;
	}

	public int getAgilityGrowthRate() {
		return agilityGrowthRate;
	}

	public void setAgilityGrowthRate(int agilityGrowthRate) {
		this.agilityGrowthRate = agilityGrowthRate;
	}

	public int getIntellectGrowthRate() {
		return intellectGrowthRate;
	}

	public void setIntellectGrowthRate(int intellectGrowthRate) {
		this.intellectGrowthRate = intellectGrowthRate;
	}

	public int getLifeGrowthRate() {
		return lifeGrowthRate;
	}

	public void setLifeGrowthRate(int lifeGrowthRate) {
		this.lifeGrowthRate = lifeGrowthRate;
	}

	public int getPhotoId() {
		return photoId;
	}

	public void setPhotoId(int photoId) {
		this.photoId = photoId;
	}

	public int getQuality() {
		return quality;
	}

	public void setQuality(int quality) {
		this.quality = quality;
	}

	public int getResId() {
		return resId;
	}

	public void setResId(int resId) {
		this.resId = resId;
	}

	public int getPositionType() {
		return positionType;
	}

	public void setPositionType(int positionType) {
		this.positionType = positionType;
	}
	
}
