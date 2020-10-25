package com.imop.lj.db.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;

/**
 * 全服的数据实体，记录全局数据
 * 
 */
@Entity
@Table(name = "t_arena_log")
@Comment(content="数据库实体数据：竞技场数据")
public class ArenaLogEntity implements BaseEntity<Long>{
	private static final long serialVersionUID = 1L;
	/** 主键 */
	@Comment(content="主键")
	private Long id;
	
	/** 竞技场日志 */
	@Comment(content = "竞技场日志")
	private String arenaLogs;

	@Id
	@Override
	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	@Column(columnDefinition = "TEXT")
	public String getArenaLogs() {
		return arenaLogs;
	}

	public void setArenaLogs(String arenaLogs) {
		this.arenaLogs = arenaLogs;
	}

}
