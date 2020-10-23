package com.imop.lj.db.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;

/**
 *帮派boss挑战次数排名表
 * 
 */
@Entity
@Table(name = "t_corpsboss_count_rank")
@Comment(content="数据库实体类：帮派boss挑战次数排名表")
public class CorpsBossCountRankEntity implements BaseEntity<Long> {
	private static final long serialVersionUID = 1L;
	
	@Comment(content="主键")
	private long id;
	@Comment(content="帮派Id")
	private long corpsId;
	@Comment(content="帮派排名")
	private int rank;
	@Comment(content="帮派等级")
	private int level;
	@Comment(content="帮派boss挑战次数")
	private int bossKillCount;
	@Comment(content="最后更新时间 ")
	private long lastUpdateTime;
	
	@Id
	@Override
	public Long getId() {
		return this.id;
	}

	@Override
	public void setId(Long id) {
		this.id = id;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getCorpsId() {
		return corpsId;
	}

	public void setCorpsId(long corpsId) {
		this.corpsId = corpsId;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getRank() {
		return rank;
	}

	public void setRank(int rank) {
		this.rank = rank;
	}
	
	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getLevel() {
		return level;
	}

	public void setLevel(int level) {
		this.level = level;
	}
	
	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getBossKillCount() {
		return bossKillCount;
	}

	public void setBossKillCount(int bossKillCount) {
		this.bossKillCount = bossKillCount;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getLastUpdateTime() {
		return lastUpdateTime;
	}

	public void setLastUpdateTime(long lastUpdateTime) {
		this.lastUpdateTime = lastUpdateTime;
	}

}
