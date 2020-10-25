package com.imop.lj.db.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;

@Entity
@Table(name = "t_activity_allocate")
@Comment(content="数据库实体类：红包 ")
public class AllocateActivityStorageEntity implements BaseEntity<Long>{
	private static final long serialVersionUID = 1L;

	/** 主键 UUID */
	@Comment(content="主键 UUID")
	private long id;
	
	/** 活动类型 */
	@Comment(content="活动类型")
	private int activityType;
	/** 所属帮派Id*/
	@Comment(content="所属帮派Id")
	private long corpsId;

	/** 分配物品信息*/
	@Comment(content="分配物品信息")
	private String allocateInfo;


	@Id
	@Override
	@Column(length = 36)
	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getActivityType() {
		return activityType;
	}

	public void setActivityType(int activityType) {
		this.activityType = activityType;
	}

	@Column(columnDefinition = "bigint(20) default 0")
	public long getCorpsId() {
		return corpsId;
	}

	public void setCorpsId(long corpsId) {
		this.corpsId = corpsId;
	}

	@Column(columnDefinition = "LONGTEXT")
	public String getAllocateInfo() {
		return allocateInfo;
	}

	public void setAllocateInfo(String allocateInfo) {
		this.allocateInfo = allocateInfo;
	}


}
