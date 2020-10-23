package com.imop.lj.db.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;

/**
 * VIP实体类
 * 
 * @author xiaowei.liu
 * 
 */
@Entity
@Table(name = "t_vip")
@Comment(content="数据库实体类：VIP实体类")
public class VipEntity implements BaseEntity<Long> {
	private static final long serialVersionUID = 1L;

	/** 角色ID */
	@Comment(content="角色ID")
	private long roleId;
	/** VIP级别 */
	@Comment(content="VIP级别")
	private int level;
	/** VIP当前经验 */
	@Comment(content="VIP当前经验")
	private long exp;
	
	@Comment(content="过期时间 ")
	private long expireTime;
	@Comment(content="临时vip等级")
	private int tmpLevel;
	
	@Comment(content="类型")
	private int vType;
	
	@Comment(content="最后一次更新时间")
	private long lastUpdateTime;

	@Id
	@Override
	public Long getId() {
		return roleId;
	}

	@Override
	public void setId(Long id) {
		this.roleId = id;
	}

	
	public long getRoleId() {
		return roleId;
	}

	public void setRoleId(long roleId) {
		this.roleId = roleId;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getLevel() {
		return level;
	}

	public void setLevel(int level) {
		this.level = level;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getExp() {
		return exp;
	}

	public void setExp(long exp) {
		this.exp = exp;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getExpireTime() {
		return expireTime;
	}

	public void setExpireTime(long expireTime) {
		this.expireTime = expireTime;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getvType() {
		return vType;
	}

	public void setvType(int vType) {
		this.vType = vType;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getLastUpdateTime() {
		return lastUpdateTime;
	}

	public void setLastUpdateTime(long lastUpdateTime) {
		this.lastUpdateTime = lastUpdateTime;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getTmpLevel() {
		return tmpLevel;
	}

	public void setTmpLevel(int tmpLevel) {
		this.tmpLevel = tmpLevel;
	}

}
