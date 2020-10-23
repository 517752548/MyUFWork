package com.imop.lj.db.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;

/**
 * 玩家离线数据2实体
 * 
 */
@Entity
@Table(name = "t_user_offline")
@Comment(content="数据库实体类：玩家离线数据2实体")
public class UserOfflineDataEntity implements BaseEntity<Long> {
	private static final long serialVersionUID = 1L;

	/** 玩家角色ID 主键 */
	@Comment(content="玩家角色ID 主键")
	private long id;
	@Comment(content="账号Id")
	private String passportId;

	@Comment(content="血池")
	private long hpPool;
	@Comment(content="蓝池")
	private long mpPool;
	@Comment(content="寿命池")
	private long lifePool;
	
	@Comment(content="出战宠物Id")
	private long fightPetId;
	@Comment(content="出战骑宠Id")
	private long fightPetHorseId;
	
	@Comment(content="当前使用的阵法索引 ")
	private int curArrayIndex;
	@Comment(content="伙伴阵容信息")
	private String friendArray;
	
	@Comment(content="宠物数据")
	private String petPack;
	@Comment(content="骑宠数据")
	private String petHorsePack;
	
	@Comment(content="当前双倍经验点数 ")
	private int curDoublePoint;
	
	@Comment(content="是否已开启双倍经验，1：已开启，0：未开启")
	private int isOpenDouble;
	
	@Comment(content="当前帮派boss挑战进度")
	private int curCorpsBossLevel;
	
	@Comment(content="帮派boss数据")
	private String corpsBossPack;
	
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

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getHpPool() {
		return hpPool;
	}

	public void setHpPool(long hpPool) {
		this.hpPool = hpPool;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getMpPool() {
		return mpPool;
	}

	public void setMpPool(long mpPool) {
		this.mpPool = mpPool;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getLifePool() {
		return lifePool;
	}

	public void setLifePool(long lifePool) {
		this.lifePool = lifePool;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getFightPetId() {
		return fightPetId;
	}

	public void setFightPetId(long fightPetId) {
		this.fightPetId = fightPetId;
	}
	
	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getFightPetHorseId() {
		return fightPetHorseId;
	}
	
	public void setFightPetHorseId(long fightPetId) {
		this.fightPetHorseId = fightPetId;
	}

	@Column(columnDefinition = " varchar(1024) default ''", nullable = false)
	public String getFriendArray() {
		return friendArray;
	}

	public void setFriendArray(String friendArray) {
		this.friendArray = friendArray;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getCurArrayIndex() {
		return curArrayIndex;
	}

	public void setCurArrayIndex(int curArrayIndex) {
		this.curArrayIndex = curArrayIndex;
	}

	@Column(columnDefinition = "TEXT")
	public String getPetPack() {
		return petPack;
	}

	public void setPetPack(String petPack) {
		this.petPack = petPack;
	}
	
	@Column(columnDefinition = "TEXT")
	public String getPetHorsePack() {
		return petHorsePack;
	}
	
	public void setPetHorsePack(String petPack) {
		this.petHorsePack = petPack;
	}
	
	@Column(columnDefinition = " int default 0", nullable = false)
	public int getCurDoublePoint() {
		return curDoublePoint;
	}

	public void setCurDoublePoint(int curDoublePoint) {
		this.curDoublePoint = curDoublePoint;
	}
	
	@Column(columnDefinition = " int default 0", nullable = false)
	public int getIsOpenDouble() {
		return isOpenDouble;
	}

	public void setIsOpenDouble(int isOpenDouble) {
		this.isOpenDouble = isOpenDouble;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getCurCorpsBossLevel() {
		return curCorpsBossLevel;
	}

	public void setCurCorpsBossLevel(int curCorpsBossLevel) {
		this.curCorpsBossLevel = curCorpsBossLevel;
	}
	
	@Column(columnDefinition = "TEXT")
	public String getCorpsBossPack() {
		return corpsBossPack;
	}

	public void setCorpsBossPack(String corpsBossPack) {
		this.corpsBossPack = corpsBossPack;
	}
	
}
