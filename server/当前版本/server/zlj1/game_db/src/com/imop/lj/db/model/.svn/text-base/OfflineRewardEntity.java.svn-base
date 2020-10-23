package com.imop.lj.db.model;

import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.core.orm.SoftDeleteEntity;

/**
 * 玩家离线奖励
 * 
 */
@Entity
@Table(name = "t_offline_reward")
@Comment(content="数据库实体类型：玩家离线奖励")
public class OfflineRewardEntity implements BaseEntity<Long>, CharSubEntity, SoftDeleteEntity<Long> {
	private static final long serialVersionUID = 1L;
	/** 主键 */
	@Comment(content="主键 ")
	private Long id;
	
	/** 玩家Id */
	@Comment(content="玩家Id")
	private long charId;
	/** 奖励类型 */
	@Comment(content="奖励类型")
	private int rewardType;
	/** 奖励json串 */
	@Comment(content="奖励json串")
	private String rewards;
	/** 属性 */
	@Comment(content="属性")
	private String props;
	/** 创建时间 */
	@Comment(content="创建时间")
	private long createTime;
	
	/** 是否已删除 */
	@Comment(content="是否已删除")
	private int deleted;
	/** 删除时间 */
	@Comment(content="删除时间 ")
	private Timestamp deleteDate;
	
	@Id
	@Override
	public Long getId() {
		return id;
	}

	@Override
	public void setId(Long id) {
		this.id = id;
	}

	@Override
	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getCharId() {
		return charId;
	}

	public void setCharId(long charId) {
		this.charId = charId;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getRewardType() {
		return rewardType;
	}

	public void setRewardType(int rewardType) {
		this.rewardType = rewardType;
	}

	@Column(columnDefinition = "TEXT")
	public String getRewards() {
		return rewards;
	}

	public void setRewards(String rewards) {
		this.rewards = rewards;
	}

	@Column(columnDefinition = "TEXT")
	public String getProps() {
		return props;
	}

	public void setProps(String props) {
		this.props = props;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getCreateTime() {
		return createTime;
	}

	public void setCreateTime(long createTime) {
		this.createTime = createTime;
	}

	@Override
	@Column
	public int getDeleted() {
		return deleted;
	}
	
	public void setDeleted(int deleted) {
		this.deleted = deleted;
	}

	@Override
	@Column
	public Timestamp getDeleteDate() {
		return deleteDate;
	}

	public void setDeleteDate(Timestamp deleteDate) {
		this.deleteDate = deleteDate;
	}
}
