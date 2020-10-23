package com.imop.lj.db.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;


/**
 * 通天塔数据库实体对象
 * 
 */
@Entity
@Table(name = "t_tower_info")
@Comment(content="数据库实体类：通天塔")
public class TowerEntity implements BaseEntity<String>{
	/** */
	private static final long serialVersionUID = 1L;

	/** 主键 id */
	@Comment(content="主键 id")
	private String id;
	
    @Comment(content="通天塔层数")
	private int towerLevel;
    
    @Comment(content="最先击败者所属角色")
    private long fCharId;
    
    @Comment(content="最先击败者回合数")
    private int fRound;

    @Comment(content="最先击败者角色等级")
    private int fLevel;

	@Comment(content="最先击败者战斗结束时间")
	private long battleEndTime;
    
    @Comment(content="最先击败者战报")
    private String firstKiller;
    
    @Comment(content="最优击败者所属角色")
    private long bCharId;
    
    @Comment(content="最优击败者回合数")
    private int bRound;

    @Comment(content="最优击败者角色等级")
    private int bLevel;

	@Comment(content="最优击败者战斗持续时间")
	private long battleDuration;
	
    @Comment(content="最优击败者战报")
    private String bestKiller;

    @Id
	@Column(length = 36)
    @Override
    public String getId() {
        return id;
    }

    @Override
    public void setId(String aLong) {
        this.id = aLong;
    }

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getTowerLevel() {
		return towerLevel;
	}

	public void setTowerLevel(int towerLevel) {
		this.towerLevel = towerLevel;
	}
	
	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
    public long getfCharId() {
		return fCharId;
	}

	public void setfCharId(long fCharId) {
		this.fCharId = fCharId;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getfRound() {
		return fRound;
	}

	public void setfRound(int fRound) {
		this.fRound = fRound;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getfLevel() {
		return fLevel;
	}

	public void setfLevel(int fLevel) {
		this.fLevel = fLevel;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getBattleEndTime() {
		return battleEndTime;
	}

	public void setBattleEndTime(long battleEndTime) {
		this.battleEndTime = battleEndTime;
	}

	@Column(columnDefinition = " varchar(255) ", nullable = true)
	public String getFirstKiller() {
		return firstKiller;
	}

	public void setFirstKiller(String firstKiller) {
		this.firstKiller = firstKiller;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getbCharId() {
		return bCharId;
	}

	public void setbCharId(long bCharId) {
		this.bCharId = bCharId;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getbRound() {
		return bRound;
	}

	public void setbRound(int bRound) {
		this.bRound = bRound;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getbLevel() {
		return bLevel;
	}

	public void setbLevel(int bLevel) {
		this.bLevel = bLevel;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getBattleDuration() {
		return battleDuration;
	}
	
	public void setBattleDuration(long battleDuration) {
		this.battleDuration = battleDuration;
	}
	
	@Column(columnDefinition = " varchar(255) ", nullable = true)
	public String getBestKiller() {
		return bestKiller;
	}

	public void setBestKiller(String bestKiller) {
		this.bestKiller = bestKiller;
	}
	
}
