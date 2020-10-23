package com.imop.lj.db.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;

/**
 *帮派boss进度排名表
 * 
 */
@Entity
@Table(name = "t_corpsboss_rank")
@Comment(content="数据库实体类：帮派boss进度排名表")
public class CorpsBossRankEntity implements BaseEntity<Long> {
	private static final long serialVersionUID = 1L;
	
	@Comment(content="主键")
	private long id;
	@Comment(content="帮派Id")
	private long corpsId;
	@Comment(content="帮派排名")
	private int rank;
	@Comment(content="帮派等级")
	private int level;
	@Comment(content="帮派boss最佳进度")
	private int bossBestLevel;
	@Comment(content="回合数")
	private int bossKillRound;
	@Comment(content="成员总战力")
	private int bossKillPowerSum;
	@Comment(content="成员数量")
	private int bossKillMemberNum;
	@Comment(content="成员总等级")
	private int bossKillLevelSum;
	@Comment(content="帮派boss最优战报")
	private String bossBestKiller;
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
	public int getBossBestLevel() {
		return bossBestLevel;
	}

	public void setBossBestLevel(int bossBestLevel) {
		this.bossBestLevel = bossBestLevel;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getBossKillRound() {
		return bossKillRound;
	}

	public void setBossKillRound(int bossKillRound) {
		this.bossKillRound = bossKillRound;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getBossKillPowerSum() {
		return bossKillPowerSum;
	}

	public void setBossKillPowerSum(int bossKillPowerSum) {
		this.bossKillPowerSum = bossKillPowerSum;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getBossKillMemberNum() {
		return bossKillMemberNum;
	}

	public void setBossKillMemberNum(int bossKillMemberNum) {
		this.bossKillMemberNum = bossKillMemberNum;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getBossKillLevelSum() {
		return bossKillLevelSum;
	}

	public void setBossKillLevelSum(int bossKillLevelSum) {
		this.bossKillLevelSum = bossKillLevelSum;
	}

	@Column(columnDefinition = " varchar(255) ", nullable = true)
	public String getBossBestKiller() {
		return bossBestKiller;
	}

	public void setBossBestKiller(String bossBestKiller) {
		this.bossBestKiller = bossBestKiller;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getLastUpdateTime() {
		return lastUpdateTime;
	}

	public void setLastUpdateTime(long lastUpdateTime) {
		this.lastUpdateTime = lastUpdateTime;
	}

}
