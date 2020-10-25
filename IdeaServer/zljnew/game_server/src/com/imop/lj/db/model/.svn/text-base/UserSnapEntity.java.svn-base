package com.imop.lj.db.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;

/**
 * 玩家离线数据实体
 * 
 */
@Entity
@Table(name = "t_user_snap")
@Comment(content="数据库实体类：玩家离线数据实体")
public class UserSnapEntity implements BaseEntity<Long> {
	private static final long serialVersionUID = 1L;

	/** 玩家角色ID 主键 */
	@Comment(content="玩家角色ID 主键")
	private long id;
	@Comment(content="账号Id")
	private String passportId;
	/** 角色名称 */
	@Comment(content="角色名称")
	private String name;
	/** 等级 */
	@Comment(content="等级")
	private int level;
	
//	@Comment(content="心法Id")
//	private int mindId;
//	@Comment(content="心法等级")
//	private int mindLevel;
	/** 心法信息 */
	@Comment(content="心法信息")
	private String mainSkillPack;
	@Comment(content="主将自动技能Id")
	private int autoActionId;
	@Comment(content="宠物自动技能Id")
	private int petAutoActionId;
	@Comment(content="主将自动技能等级")
	private int autoSkillLevel;
	@Comment(content="主将自动技能层数")
	private int autoSkillLayer;
	@Comment(content="宠物自动技能等级")
	private int petAutoSkillLevel;

	/** 战斗部队，json格式 */
	@Comment(content="战斗部队，json格式")
	private String armies;
	/** 阵位信息 */
	@Comment(content="阵位信息")
	private String formation;
	@Comment(content="功能开启")
	private String funcPack;
	
	@Comment(content="其它属性信息")
	private String propsPack;
	
	@Comment(content="所属服务器Id，如1001")
	private int serverId;
	@Comment(content="战斗力")
	private int fightPower;
	
	@Comment(content="装备位相关信息，装备、星级、宝石")
	private String equipPack;

	@Comment(content="翅膀Id")
	private int wingId;
	@Comment(content="翅膀阶数")
	private int wingLevel;
	
	@Comment(content="通天塔阶数")
	private int towerLevel;
	
	@Id
	@Override
	public Long getId() {
		return id;
	}

	@Override
	public void setId(Long id) {
		this.id = id;
	}
	
	@Column(columnDefinition = " varchar(255) ")
	public String getPassportId() {
		return passportId;
	}

	public void setPassportId(String passportId) {
		this.passportId = passportId;
	}

	@Column(columnDefinition = " varchar(255) ")
	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getLevel() {
		return level;
	}

	public void setLevel(int level) {
		this.level = level;
	}

	@Column(columnDefinition = "text")
	public String getArmies() {
		return armies;
	}

	public void setArmies(String armies) {
		this.armies = armies;
	}

	@Column(columnDefinition = "text")
	public String getFormation() {
		return formation;
	}

	public void setFormation(String formation) {
		this.formation = formation;
	}

	@Column(columnDefinition = "text")
	public String getFuncPack() {
		return funcPack;
	}

	public void setFuncPack(String funcPack) {
		this.funcPack = funcPack;
	}

	@Column(columnDefinition = "text")
	public String getPropsPack() {
		return propsPack;
	}

	public void setPropsPack(String propsPack) {
		this.propsPack = propsPack;
	}
	
	@Column(columnDefinition = " int default 0", nullable = false)
	public int getServerId() {
		return serverId;
	}

	public void setServerId(int serverId) {
		this.serverId = serverId;
	}

//	@Column(columnDefinition = " int default 0", nullable = false)
//	public int getMindId() {
//		return mindId;
//	}
//
//	public void setMindId(int mindId) {
//		this.mindId = mindId;
//	}
//
//	@Column(columnDefinition = " int default 0", nullable = false)
//	public int getMindLevel() {
//		return mindLevel;
//	}
//
//	public void setMindLevel(int mindLevel) {
//		this.mindLevel = mindLevel;
//	}
	
	@Column(columnDefinition = "TEXT")
	public String getMainSkillPack() {
		return mainSkillPack;
	}

	public void setMainSkillPack(String mainSkillPack) {
		this.mainSkillPack = mainSkillPack;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getAutoActionId() {
		return autoActionId;
	}

	public void setAutoActionId(int autoActionId) {
		this.autoActionId = autoActionId;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getPetAutoActionId() {
		return petAutoActionId;
	}

	public void setPetAutoActionId(int petAutoActionId) {
		this.petAutoActionId = petAutoActionId;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getAutoSkillLevel() {
		return autoSkillLevel;
	}

	public void setAutoSkillLevel(int autoSkillLevel) {
		this.autoSkillLevel = autoSkillLevel;
	}
	
	@Column(columnDefinition = " int default 0", nullable = false)
	public int getAutoSkillLayer() {
		return autoSkillLayer;
	}

	public void setAutoSkillLayer(int autoSkillLayer) {
		this.autoSkillLayer = autoSkillLayer;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getPetAutoSkillLevel() {
		return petAutoSkillLevel;
	}

	public void setPetAutoSkillLevel(int petAutoSkillLevel) {
		this.petAutoSkillLevel = petAutoSkillLevel;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getFightPower() {
		return fightPower;
	}

	public void setFightPower(int fightPower) {
		this.fightPower = fightPower;
	}

	@Column(columnDefinition = "text")
	public String getEquipPack() {
		return equipPack;
	}

	public void setEquipPack(String equipPack) {
		this.equipPack = equipPack;
	}
	
	@Column(columnDefinition = " int default 0", nullable = false)
	public int getWingId() {
		return wingId;
	}

	public void setWingId(int wingId) {
		this.wingId = wingId;
	}
	
	@Column(columnDefinition = " int default 0", nullable = false)
	public int getWingLevel() {
		return wingLevel;
	}

	public void setWingLevel(int wingLevel) {
		this.wingLevel = wingLevel;
	}
	
	@Column(columnDefinition = " int default 0", nullable = false)
	public int getTowerLevel() {
		return towerLevel;
	}
	
	public void setTowerLevel(int towerLevel) {
		this.towerLevel = towerLevel;
	}

}
