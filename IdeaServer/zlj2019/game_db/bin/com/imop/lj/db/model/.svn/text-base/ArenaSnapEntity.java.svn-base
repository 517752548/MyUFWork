package com.imop.lj.db.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;


@Entity
@Table(name = "t_arena_snap")
@Comment(content="数据库实体数据：竞技场离线数据")
public class ArenaSnapEntity implements BaseEntity<Long> {
	private static final long serialVersionUID = 1L;
	
	/** 玩家角色ID 主键 */
	@Comment(content="主键")
	private long id;
	/** 当前排名 */
	@Comment(content="当前排名")
	private int rank;
	/** 等级快照 */
	@Comment(content="等级快照")
	private int snapLevel;
	/** 排名快照 */
	@Comment(content="排名快照")
	private int snapRank;
	/** 最高排名 */
	@Comment(content="最高排名")
	private int rankMax;
	/** 当前连续胜利次数 */
	@Comment(content="当前连续胜利次数")
	private int conWinTimes;
	/** 总共挑战胜利次数 */
	@Comment(content="总共挑战胜利次数")
	private int winTimes;
	/** 总共失败次数 */
	@Comment(content="总共失败次数")
	private int lossTimes;
	/** 总共挑战次数 */
	@Comment(content="总共挑战次数")
	private int attackTotalTimes;
	
	/** 攻击冷却时间 */
	@Comment(content="攻击冷却时间")
	private long attackCdTime;
	
	/** 对手列表 */
	@Comment(content="对手列表")
	private String opList;
	/** 战斗日志 */
	@Comment(content="战斗日志")
	private String fightLog;
	
	@Id
	@Override
	public Long getId() {
		return id;
	}
	
	@Override
	public void setId(Long id) {
		this.id = id;
	}
	
	public void setId(long id) {
		this.id = id;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getRank() {
		return rank;
	}

	public void setRank(int rank) {
		this.rank = rank;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getSnapLevel() {
		return snapLevel;
	}

	public void setSnapLevel(int snapLevel) {
		this.snapLevel = snapLevel;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getSnapRank() {
		return snapRank;
	}

	public void setSnapRank(int snapRank) {
		this.snapRank = snapRank;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getRankMax() {
		return rankMax;
	}

	public void setRankMax(int rankMax) {
		this.rankMax = rankMax;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getConWinTimes() {
		return conWinTimes;
	}

	public void setConWinTimes(int conWinTimes) {
		this.conWinTimes = conWinTimes;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getWinTimes() {
		return winTimes;
	}

	public void setWinTimes(int winTimes) {
		this.winTimes = winTimes;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getLossTimes() {
		return lossTimes;
	}

	public void setLossTimes(int lossTimes) {
		this.lossTimes = lossTimes;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getAttackTotalTimes() {
		return attackTotalTimes;
	}

	public void setAttackTotalTimes(int attackTotalTimes) {
		this.attackTotalTimes = attackTotalTimes;
	}
	
	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getAttackCdTime() {
		return attackCdTime;
	}

	public void setAttackCdTime(long attackCdTime) {
		this.attackCdTime = attackCdTime;
	}

	@Column(columnDefinition = "TEXT")
	public String getOpList() {
		return opList;
	}

	public void setOpList(String opList) {
		this.opList = opList;
	}

	@Column(columnDefinition = "TEXT")
	public String getFightLog() {
		return fightLog;
	}

	public void setFightLog(String fightLog) {
		this.fightLog = fightLog;
	}
	
}
