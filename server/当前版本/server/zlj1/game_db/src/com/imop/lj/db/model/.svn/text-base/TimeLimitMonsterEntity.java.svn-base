package com.imop.lj.db.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;

/**
 *限时杀怪表
 * 
 */
@Entity
@Table(name = "t_timelimit_monster")
@Comment(content="数据库实体类：限时杀怪表")
public class TimeLimitMonsterEntity implements BaseEntity<String>, CharSubEntity {
	/** */
	private static final long serialVersionUID = 1L;
	/** 主键 */
	@Comment(content="主键")
	private String id;
	/** 所属角色Id */
	@Comment(content="所属角色Id")
	private long charId;
	/** 任务模板Id */
	@Comment(content="任务模板Id")
	private int questId;
	/** 任务状态 */
	@Comment(content="任务状态")
	private int status;
	/** 任务相关的计数 */
	@Comment(content="任务相关的计数")
	private String props;
	/** 任务开始时间 */
	@Comment(content="任务开始时间")
	private long startTime;
	/** 任务最后更新时间 */
	@Comment(content="任务最后更新时间 ")
	private long lastUpdateTime;
	
	@Id
	@Column(length = 36)
	@Override
	public String getId() {
		return id;
	}

	@Override
	public void setId(String id) {
		this.id = id;
	}
	
	@Override
	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getCharId() {
		return charId;
	}
	
	@Column(columnDefinition = " int default 0", nullable = false)
	public int getQuestId() {
		return questId;
	}
	
	@Column(columnDefinition = " int default 0", nullable = false)
	public int getStatus() {
		return status;
	}

	@Column(columnDefinition = " varchar(512) default ''", nullable = false)
	public String getProps() {
		return props;
	}
	
	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getStartTime() {
		return startTime;
	}
	
	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getLastUpdateTime() {
		return lastUpdateTime;
	}
	
	public void setQuestId(int questId) {
		this.questId = questId;
	}
	
	public void setStatus(int status) {
		this.status = status;
	}

	public void setStartTime(long startTime) {
		this.startTime = startTime;
	}

	public void setCharId(long charId) {
		this.charId = charId;
	}

	public void setProps(String props) {
		this.props = props;
	}

	public void setLastUpdateTime(long lastUpdateTime) {
		this.lastUpdateTime = lastUpdateTime;
	}

}
