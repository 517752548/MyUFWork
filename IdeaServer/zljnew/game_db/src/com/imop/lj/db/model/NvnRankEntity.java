package com.imop.lj.db.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;

/**
 *nvn排名表
 * 
 */
@Entity
@Table(name = "t_nvn_rank")
@Comment(content="数据库实体类：nvn排名表")
public class NvnRankEntity implements BaseEntity<Long> {
	private static final long serialVersionUID = 1L;
	
	@Comment(content="主键")
	private long id;
	@Comment(content="角色Id")
	private long charId;
	@Comment(content="积分")
	private int score;
	@Comment(content="连胜")
	private int conWin;
	@Comment(content="胜利")
	private int win;
	@Comment(content="失败")
	private int loss;
	@Comment(content="排名")
	private int rank;
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
	public long getCharId() {
		return charId;
	}

	public void setCharId(long charId) {
		this.charId = charId;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getRank() {
		return rank;
	}

	public void setRank(int rank) {
		this.rank = rank;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getScore() {
		return score;
	}

	public void setScore(int score) {
		this.score = score;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getLastUpdateTime() {
		return lastUpdateTime;
	}

	public void setLastUpdateTime(long lastUpdateTime) {
		this.lastUpdateTime = lastUpdateTime;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getConWin() {
		return conWin;
	}

	public void setConWin(int conWin) {
		this.conWin = conWin;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getWin() {
		return win;
	}

	public void setWin(int win) {
		this.win = win;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getLoss() {
		return loss;
	}

	public void setLoss(int loss) {
		this.loss = loss;
	}

}
