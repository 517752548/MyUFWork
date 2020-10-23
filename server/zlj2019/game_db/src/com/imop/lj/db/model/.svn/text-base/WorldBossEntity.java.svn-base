package com.imop.lj.db.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;


@Entity
@Table(name = "t_world_boss")
@Comment(content="数据库实体类：世界BOSS")
public class WorldBossEntity implements BaseEntity<Long> {
	private static final long serialVersionUID = 1L;
	
	/** 唯一ID 主键 */
	@Comment(content=" 唯一ID 主键")
	private long id;
	/** 国家 */
	@Comment(content="国家")
	private int country;
	/** boss模板Id */
	@Comment(content="boss模板Id")
	private int bossId;
	/** 最近一次领奖时间 */
	@Comment(content="最近一次领奖时间")
	private long lastUpdateTime;
	
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
	public int getCountry() {
		return country;
	}

	public void setCountry(int country) {
		this.country = country;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getBossId() {
		return bossId;
	}

	public void setBossId(int bossId) {
		this.bossId = bossId;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getLastUpdateTime() {
		return lastUpdateTime;
	}

	public void setLastUpdateTime(long lastUpdateTime) {
		this.lastUpdateTime = lastUpdateTime;
	}

}
