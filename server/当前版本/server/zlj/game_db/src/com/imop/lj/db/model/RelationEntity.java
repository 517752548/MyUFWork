package com.imop.lj.db.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;

/**
 * 关系信息
 * 
 */
@Entity
@Table(name = "t_relation_info")
@Comment(content="数据库实体类：关系信息")
public class RelationEntity implements BaseEntity<String> {
	private static final long serialVersionUID = 1L;
	
	/** 主键 */
	@Comment(content="主键")
	private String id;
	/** 所属角色ID */
	@Comment(content="所属角色ID")
	private long charId;
	/** 关联角色ID */
	@Comment(content="关联角色ID")
	private long targetCharId;
	/** 关联关系类型 */
	@Comment(content="关联关系类型")
	private int relationType;
	/** 创建时间 */
	@Comment(content="创建时间")
	private long createTime;
	
	@Id
	@Column
	@Override
	public String getId() {
		return this.id;
	}

	@Override
	public void setId(String id) {
		this.id = id;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getCharId() {
		return charId;
	}

	public void setCharId(long charId) {
		this.charId = charId;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getTargetCharId() {
		return targetCharId;
	}

	public void setTargetCharId(long targetCharId) {
		this.targetCharId = targetCharId;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getRelationType() {
		return relationType;
	}

	public void setRelationType(int relationType) {
		this.relationType = relationType;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getCreateTime() {
		return createTime;
	}

	public void setCreateTime(long createTime) {
		this.createTime = createTime;
	}

}