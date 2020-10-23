package com.imop.lj.db.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;

/**
 * 仙葫排行数据库实体对象
 * 
 */
@Entity
@Table(name = "t_xianhu_rank")
@Comment(content="数据库实体类：仙葫排行数据")
public class XianhuRankEntity implements BaseEntity<Long> {
	/** */
	private static final long serialVersionUID = 6931213926527000159L;

	/** 主键 UUID */
	@Comment(content="主键 UUID")
	private long id;
	
	@Comment(content="排行类型")
	private int rankType;
	@Comment(content="排名")
	private int rank;
	
	@Comment(content="所属角色")
	private long charId;
	@Comment(content="次数")
	private int targetCount;
	@Comment(content="最后一次更新时间")
	private long lastTime;
	@Comment(content="是否已领取奖励，0未领取，1已领取")
	private int rewardFlag;
	@Comment(content="领取奖励时间")
	private long rewardTime;
	
	
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
	public int getRankType() {
		return rankType;
	}

	public void setRankType(int rankType) {
		this.rankType = rankType;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getTargetCount() {
		return targetCount;
	}

	public void setTargetCount(int targetCount) {
		this.targetCount = targetCount;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getLastTime() {
		return lastTime;
	}

	public void setLastTime(long lastTime) {
		this.lastTime = lastTime;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getRewardFlag() {
		return rewardFlag;
	}

	public void setRewardFlag(int rewardFlag) {
		this.rewardFlag = rewardFlag;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getRewardTime() {
		return rewardTime;
	}

	public void setRewardTime(long rewardTime) {
		this.rewardTime = rewardTime;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getRank() {
		return rank;
	}

	public void setRank(int rank) {
		this.rank = rank;
	}

}
