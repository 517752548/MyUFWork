package com.imop.lj.db.model;

import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.SoftDeleteEntity;

/**
 * 玩家的精彩活动数据实体
 *
 */
@Entity
@Table(name = "t_good_activity_user")
@Comment(content="数据库实体类：玩家的精彩活动数据实体")
public class GoodActivityUserEntity implements SoftDeleteEntity<Long> {
	private static final long serialVersionUID = 1L;
	
	/** 主键 */
	@Comment(content="主键")
	private long id;
	
	/** 玩家uuid */
	@Comment(content="玩家uuid")
	private long charId;
	/** 活动Id */
	@Comment(content="活动Id")
	private long activityId;
	
	/** 玩家活动数据 */
	@Comment(content="玩家活动数据")
	private String activityData;
	
	/** 创建时间 */
	@Comment(content="创建时间")
	private long createTime;
	/** 最后一次更新时间 */
	@Comment(content="最后一次更新时间")
	private long lastUpdateTime;
	
	/** 是否已删除 */
	private int deleted;
	/** 删除时间 */
	private Timestamp deleteDate;
	
	@Id
	@Override
	public Long getId() {
		return id;
	}

	@Override
	public void setId(Long id) {
		this.id = id ;
	}

	@Column(columnDefinition = " bigint(20) default 0")
	public long getCharId() {
		return charId;
	}

	public void setCharId(long charId) {
		this.charId = charId;
	}

	@Column(columnDefinition = " bigint(20) default 0")
	public long getActivityId() {
		return activityId;
	}

	public void setActivityId(long activityId) {
		this.activityId = activityId;
	}

	@Column(columnDefinition = "LONGTEXT")
	public String getActivityData() {
		return activityData;
	}

	public void setActivityData(String activityData) {
		this.activityData = activityData;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getCreateTime() {
		return createTime;
	}

	public void setCreateTime(long createTime) {
		this.createTime = createTime;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getLastUpdateTime() {
		return lastUpdateTime;
	}

	public void setLastUpdateTime(long lastUpdateTime) {
		this.lastUpdateTime = lastUpdateTime;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getDeleted() {
		return deleted;
	}

	public void setDeleted(int deleted) {
		this.deleted = deleted;
	}

	@Column
	public Timestamp getDeleteDate() {
		return deleteDate;
	}

	public void setDeleteDate(Timestamp deleteDate) {
		this.deleteDate = deleteDate;
	}
}
