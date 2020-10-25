package com.imop.lj.db.model;

import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.orm.BaseEntity;
/**
 * DirtyWordsType实体
 * 
 */
@Entity
@Table(name = "t_dirtywords")
public class DirtyWordsTypeEntity implements BaseEntity<Integer>{
	private static final long serialVersionUID = 1L;
	
	/** 主键 */
	private Integer id;
	/**  */
	private int dirtyWordsType;
	/** 更新时间 */
	private Timestamp updateTime;

	@Id
	@Column
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	public Integer getId() {
		return id;
	}

	public void setId(Integer id) {
		this.id = id;
	}

	@Column(columnDefinition = " int default 0",nullable = false)
	public int getDirtyWordsType() {
		return dirtyWordsType;
	}

	public void setDirtyWordsType(int dirtyWordsType) {
		this.dirtyWordsType = dirtyWordsType;
	}

	@Column
	public Timestamp getUpdateTime() {
		return updateTime;
	}

	public void setUpdateTime(Timestamp updateTime) {
		this.updateTime = updateTime;
	}
}