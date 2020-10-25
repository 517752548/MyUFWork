package com.imop.lj.db.model;

import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;

/**
 * 已完成的任务信息
 * 
 */
@Entity
@Table(name = "t_finished_quest")
@Comment(content="数据库实体类：已完成的任务信息")
public class FinishedQuestEntity implements BaseEntity<String>, CharSubEntity {

	/** */
	private static final long serialVersionUID = -5440513168906155133L;
	/** 主键 */
	@Comment(content="主键")
	private String id;
	/** 所属角色ID */
	@Comment(content="所属角色ID")
	private long charId;
	/** 任务ID */
	@Comment(content="任务ID")
	private int questId;
	/** 任务开始时间 */
	@Comment(content="任务开始时间")
	private Timestamp startTime;
	/** 任务结束时间 */
	@Comment(content="任务结束时间")
	private Timestamp endTime;
	/** 任务每天完成次数 */
	@Comment(content="任务每天完成次数")
	private int dailyTimes;

	@Id
	@Override
	public String getId() {
		return id;
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
	public Timestamp getEndTime() {
		return endTime;
	}

	@Column
	public int getDailyTimes() {
		return dailyTimes;
	}

	@Column
	public long getCharId() {
		return charId;
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

	public void setEndTime(Timestamp endTime) {
		this.endTime = endTime;
	}

	public void setDailyTimes(int dailyTimes) {
		this.dailyTimes = dailyTimes;
	}
}
