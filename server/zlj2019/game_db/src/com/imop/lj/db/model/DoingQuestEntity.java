package com.imop.lj.db.model;

import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;

/**
 * 正在做的任务信息
 * 
 */
@Entity
@Table(name = "t_doing_task")
@Comment(content="数据库实体类：正在做的任务信息")
public class DoingQuestEntity implements BaseEntity<String>, CharSubEntity {

	/** */
	private static final long serialVersionUID = -6243749353854620815L;
	/** 主键 */
	@Comment(content="主键")
	private String id;
	/** 所属角色ID */
	@Comment(content="所属角色ID")
	private long charId;
	/** 任务编号 */
	@Comment(content="任务编号")
	private int questId;
	/** 任务开始时间 */
	@Comment(content="任务开始时间")
	private Timestamp startTime;
	/** 任务相关的属性 */
	@Comment(content="任务相关的属性")
	private String props;
	/** 是否开启任务追踪,1-开启,0-不开启 */
	@Comment(content="是否开启任务追踪,1-开启,0-不开启")
	private byte trace;

	@Id
	@Column(length = 36)
	@Override
	public String getId() {
		return id;
	}

	@Column
	public long getCharId() {
		return charId;
	}

	@Column
	public int getQuestId() {
		return questId;
	}

	@Column
	public Timestamp getStartTime() {
		return startTime;
	}

	@Column
	public String getProps() {
		return props;
	}

	@Column
	public byte getTrace() {
		return trace;
	}

	public void setTrace(byte trace) {
		this.trace = trace;
	}

	public void setId(String id) {
		this.id = id;
	}

	public void setQuestId(int questId) {
		this.questId = questId;
	}

	public void setStartTime(Timestamp startTime) {
		this.startTime = startTime;
	}

	public void setCharId(long charId) {
		this.charId = charId;
	}

	public void setProps(String props) {
		this.props = props;
	}
}
