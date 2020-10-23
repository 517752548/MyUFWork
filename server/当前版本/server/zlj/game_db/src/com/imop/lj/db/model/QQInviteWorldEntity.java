package com.imop.lj.db.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;

/**
 * qq的成功邀请数据，WorldServer使用
 * 
 */
@Entity
@Table(name = "t_qq_invite_world")
@Comment(content="数据库实体类：qq邀请关系数据")
public class QQInviteWorldEntity implements BaseEntity<Long> {
	private static final long serialVersionUID = 1L;
	
	@Comment(content="主键，自增Id ")
	private Long id;
	
	@Comment(content="玩家账号Id，被邀请者，唯一索引")
	private String openId;
	
	@Comment(content="邀请者账号Id")
	private String fromOpenId;
	
	@Comment(content="邀请者角色Id ")
	private long fromCharId;
	
	@Comment(content="邀请者角色名称")
	private String fromCharName;
	
	@Comment(content="更新时间")
	private long lastUpdateTime;
	
	@Comment(content="领取被邀请奖励的角色Id")
	private long gbrCharId;
	@Comment(content="领取被邀请奖励的第一次时间")
	private long gbrTime;

	@Id
	@Override
	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	@Column(columnDefinition = " varchar(256)")
	public String getOpenId() {
		return openId;
	}

	public void setOpenId(String openId) {
		this.openId = openId;
	}

	@Column(columnDefinition = " varchar(256)")
	public String getFromOpenId() {
		return fromOpenId;
	}

	public void setFromOpenId(String fromOpenId) {
		this.fromOpenId = fromOpenId;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getFromCharId() {
		return fromCharId;
	}

	public void setFromCharId(long fromCharId) {
		this.fromCharId = fromCharId;
	}

	@Column(columnDefinition = " varchar(256)")
	public String getFromCharName() {
		return fromCharName;
	}

	public void setFromCharName(String fromCharName) {
		this.fromCharName = fromCharName;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getLastUpdateTime() {
		return lastUpdateTime;
	}

	public void setLastUpdateTime(long lastUpdateTime) {
		this.lastUpdateTime = lastUpdateTime;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getGbrCharId() {
		return gbrCharId;
	}

	public void setGbrCharId(long gbrCharId) {
		this.gbrCharId = gbrCharId;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getGbrTime() {
		return gbrTime;
	}

	public void setGbrTime(long gbrTime) {
		this.gbrTime = gbrTime;
	}

}
