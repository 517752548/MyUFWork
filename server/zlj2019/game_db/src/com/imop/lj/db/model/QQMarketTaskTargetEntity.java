package com.imop.lj.db.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;

/**
 * qq集市任务完成条件实体
 *
 */
@Entity
@Table(name = "t_qq_markettask_target")
@Comment(content="数据库实体类：qq集市任务条件实体")
public class QQMarketTaskTargetEntity implements BaseEntity<Integer> {
	private static final long serialVersionUID = 1L;
	
	@Comment(content="唯一Id 主键")
	private int id;

	@Comment(content="任务步骤的完成条件")
	private String stepTarget;
	
	@Comment(content="最后一次更新时间")
	private long lastUpdateTime;


	@Id
	@Override
	public Integer getId() {
		return id;
	}
	
	@Override
	public void setId(Integer id) {
		this.id = id;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getLastUpdateTime() {
		return lastUpdateTime;
	}

	public void setLastUpdateTime(long lastUpdateTime) {
		this.lastUpdateTime = lastUpdateTime;
	}

	@Column(columnDefinition = "TEXT")
	public String getStepTarget() {
		return stepTarget;
	}

	public void setStepTarget(String stepTarget) {
		this.stepTarget = stepTarget;
	}
	
}
