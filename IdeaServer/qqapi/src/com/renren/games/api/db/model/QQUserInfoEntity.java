package com.renren.games.api.db.model;

import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.renren.games.api.annotation.Comment;
import com.renren.games.api.db.SoftDeleteEntity;

/**
 * 数据库实体类：角色信息，暂时先放在这儿
 *
 */
@Entity
@Table(name = "t_qquser_info")
@Comment(content="qq用户信息")
public class QQUserInfoEntity implements SoftDeleteEntity<String> {
	/** */
	private static final long serialVersionUID = 1L;
	/** 玩家角色ID 主键 */
	@Comment(content="openId")
	private String id;
	
	@Comment(content="创建时间 ")
	private long createDate;
	
	@Comment(content="最近登录时间 ")
	private long lastLoginDate;
	
	@Comment(content="是否已删除")
	private int deleted;
	
	@Comment(content="删除时间 ")
	private Timestamp deleteDate;
	
	@Comment(content="appid")
	private String appid;
	
	@Comment(content="params")
	private String params;
	
	@Comment(content="锁定,被锁定的玩家不能上线")
	private int locked;
	
	@Comment(content="锁定结束时间")
	private long lockEndTime;
	
	@Comment(content="锁定理由")
	private String lockReason;
	
	@Comment(content="禁言,被禁言的玩家不能说话")
	private int forbidTalked;
	
	@Comment(content="锁定结束时间")
	private long forbidTalkTime;
	
	@Comment(content="锁定理由")
	private String forbidTalkReason;
	
	public long getLastLoginDate() {
		return lastLoginDate;
	}

	public void setLastLoginDate(long lastLoginDate) {
		this.lastLoginDate = lastLoginDate;
	}

	@Id
	@Override
	@Column(columnDefinition = "VARCHAR(255)")
	public String getId() {
		return id;
	}

	@Override
	public void setId(String id) {
		this.id = id;
	}


	@Column(columnDefinition = "TEXT")
	public String getParams() {
		return params;
	}

	public void setParams(String params) {
		this.params = params;
	}

	@Override
	@Column(columnDefinition = " int default 0", nullable = false)
	public int getDeleted() {
		return deleted;
	}

	public void setDeleted(int deleted) {
		this.deleted = deleted;
	}

	@Override
	public Timestamp getDeleteDate() {
		return deleteDate;
	}

	public void setDeleteDate(Timestamp deleteDate) {
		this.deleteDate = deleteDate;
	}
	
	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getCreateDate() {
		return createDate;
	}

	public void setCreateDate(long createDate) {
		this.createDate = createDate;
	}
	
	@Column(columnDefinition = "VARCHAR(255)")
	public String getAppid() {
		return appid;
	}

	public void setAppid(String appid) {
		this.appid = appid;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getLocked() {
		return locked;
	}

	public void setLocked(int locked) {
		this.locked = locked;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getLockEndTime() {
		return lockEndTime;
	}

	public void setLockEndTime(long lockEndTime) {
		this.lockEndTime = lockEndTime;
	}

	@Column(columnDefinition = "VARCHAR(255)")
	public String getLockReason() {
		return lockReason;
	}

	public void setLockReason(String lockReason) {
		this.lockReason = lockReason;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getForbidTalked() {
		return forbidTalked;
	}

	public void setForbidTalked(int forbidTalked) {
		this.forbidTalked = forbidTalked;
	}

	@Column(columnDefinition = " bigint(20) ", nullable = false)
	public long getForbidTalkTime() {
		return forbidTalkTime;
	}

	public void setForbidTalkTime(long forbidTalkTime) {
		this.forbidTalkTime = forbidTalkTime;
	}

	@Column(columnDefinition = "VARCHAR(255)")
	public String getForbidTalkReason() {
		return forbidTalkReason;
	}

	public void setForbidTalkReason(String forbidTalkReason) {
		this.forbidTalkReason = forbidTalkReason;
	}
}
