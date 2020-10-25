package com.imop.lj.db.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;

/**
 * 仙葫玩家数据库实体对象
 * 
 */
@Entity
@Table(name = "t_xianhu")
@Comment(content="数据库实体类：仙葫玩家数据")
public class XianhuEntity implements BaseEntity<Long> {
	/** */
	private static final long serialVersionUID = 6931213926527000159L;

	/** 主键 UUID */
	@Comment(content="主键 UUID")
	private long id;
	@Comment(content="所属角色")
	private long charId;
	
	@Comment(content="祈福仙葫日次数")
	private int normalCount;
	@Comment(content="祈福仙葫日次数 最后一次更新时间")
	private long normalLastTime;
	
	@Comment(content="灵犀祈福日次数")
	private int lingxiDayCount;
	@Comment(content="祈福仙葫日次数 最后一次更新时间")
	private long lingxiDayLastTime;
	
	@Comment(content="灵犀祈福周次数")
	private int lingxiWeekCount;
	@Comment(content="祈福仙葫周次数 最后一次更新时间")
	private long lingxiWeekLastTime;
	
	
	@Id
	@Override
	@Column(length = 36)
	public Long getId() {
		return this.id;
	}

	public void setId(Long id) {
		this.id = id;
	}
	
	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getCharId() {
		return charId;
	}
	

	public void setCharId(long charId) {
		this.charId = charId;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getNormalCount() {
		return normalCount;
	}

	public void setNormalCount(int normalCount) {
		this.normalCount = normalCount;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getNormalLastTime() {
		return normalLastTime;
	}

	public void setNormalLastTime(long normalLastTime) {
		this.normalLastTime = normalLastTime;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getLingxiDayCount() {
		return lingxiDayCount;
	}

	public void setLingxiDayCount(int lingxiDayCount) {
		this.lingxiDayCount = lingxiDayCount;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getLingxiDayLastTime() {
		return lingxiDayLastTime;
	}

	public void setLingxiDayLastTime(long lingxiDayLastTime) {
		this.lingxiDayLastTime = lingxiDayLastTime;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getLingxiWeekCount() {
		return lingxiWeekCount;
	}

	public void setLingxiWeekCount(int lingxiWeekCount) {
		this.lingxiWeekCount = lingxiWeekCount;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getLingxiWeekLastTime() {
		return lingxiWeekLastTime;
	}

	public void setLingxiWeekLastTime(long lingxiWeekLastTime) {
		this.lingxiWeekLastTime = lingxiWeekLastTime;
	}
	
}
