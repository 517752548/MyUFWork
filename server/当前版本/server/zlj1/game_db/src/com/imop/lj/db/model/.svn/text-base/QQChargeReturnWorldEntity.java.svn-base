package com.imop.lj.db.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;

/**
 * qq返利数据记录表，WorldServer使用
 * 
 */
@Entity
@Table(name = "t_qq_charge_return_world")
@Comment(content="数据库实体类：qq返利数据记录表")
public class QQChargeReturnWorldEntity implements BaseEntity<Long> {
	private static final long serialVersionUID = 1L;
	
	@Comment(content="主键，自增Id ")
	private Long id;
	
	@Comment(content="邀请者账号Id，享受返利的玩家")
	private String fromOpenId;
	
	@Comment(content="被邀请者账号Id")
	private String openId;
	
	@Comment(content="被邀请者角色Id ")
	private long roleId;
	
	@Comment(content="被邀请者角色名称")
	private String charName;
	
	@Comment(content="返利的模板Id")
	private int returnTplId;
	
	@Comment(content="是否已经领取返利，0否，1是")
	private int returnFlag;
	
	@Comment(content="创建记录时间")
	private long createTime;
	
	@Comment(content="更新时间")
	private long lastUpdateTime;
	
	@Comment(content="最后一次更新的GameServer服务器Id")
	private int lastServerId;
	
	@Comment(content="领取返利的角色Id，未领取时为0")
	private long fromCharId;

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
	public long getRoleId() {
		return roleId;
	}

	public void setRoleId(long roleId) {
		this.roleId = roleId;
	}

	@Column(columnDefinition = " varchar(256)")
	public String getCharName() {
		return charName;
	}

	public void setCharName(String charName) {
		this.charName = charName;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getLastUpdateTime() {
		return lastUpdateTime;
	}

	public void setLastUpdateTime(long lastUpdateTime) {
		this.lastUpdateTime = lastUpdateTime;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getReturnTplId() {
		return returnTplId;
	}

	public void setReturnTplId(int returnTplId) {
		this.returnTplId = returnTplId;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getReturnFlag() {
		return returnFlag;
	}

	public void setReturnFlag(int returnFlag) {
		this.returnFlag = returnFlag;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getCreateTime() {
		return createTime;
	}

	public void setCreateTime(long createTime) {
		this.createTime = createTime;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getLastServerId() {
		return lastServerId;
	}

	public void setLastServerId(int lastServerId) {
		this.lastServerId = lastServerId;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getFromCharId() {
		return fromCharId;
	}

	public void setFromCharId(long fromCharId) {
		this.fromCharId = fromCharId;
	}

}
