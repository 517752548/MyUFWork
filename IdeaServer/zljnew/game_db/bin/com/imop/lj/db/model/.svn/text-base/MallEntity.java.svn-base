package com.imop.lj.db.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;

/**
 * 
 * @author xiaowei.liu
 * 
 */
@Entity
@Table(name = "t_mall_info")
@Comment(content="数据库实体类：商城数据")
public class MallEntity implements BaseEntity<Long> {
	private static final long serialVersionUID = 1L;
	
	@Comment(content="数据库ID")
	private long id;
	
	// GM修改时，策划配置数据
	@Comment(content="初始配置开始时间")
	private long startConfigTime;
	
	// GM修改时，策划配置队列
	@Comment(content="初始配置队列组")
	private String queueConfig;

	// 当前队列配置
	@Comment(content="当前队列组")
	private String currQueueConfig;
	
	// 当前队列的UUID
	@Comment(content="当前队列的唯一ID")
	private String currQueueUUID;
	
	// 当前队列模版ID
	@Comment(content="当前队列模版ID")
	private int currQueueId;
	
	// 当前队列开始时间
	@Comment(content="当前队列开始时间")
	private long currStartTime;
	
	// 当前库存
	@Comment(content="库存")
	private String stockPack;
	
	// 修改时间
	@Comment(content="修改时间")
	private long updateTime;

	@Override
	@Id
	public Long getId() {
		return id;
	}

	@Override
	public void setId(Long id) {
		this.id = id;
	}

	@Column
	public long getStartConfigTime() {
		return startConfigTime;
	}

	public void setStartConfigTime(long startConfigTime) {
		this.startConfigTime = startConfigTime;
	}

	@Column(columnDefinition = "TEXT")
	public String getQueueConfig() {
		return queueConfig;
	}

	public void setQueueConfig(String queueConfig) {
		this.queueConfig = queueConfig;
	}

	@Column(columnDefinition = "TEXT")
	public String getCurrQueueConfig() {
		return currQueueConfig;
	}

	public void setCurrQueueConfig(String currQueueConfig) {
		this.currQueueConfig = currQueueConfig;
	}

	@Column(length = 36)
	public String getCurrQueueUUID() {
		return currQueueUUID;
	}

	public void setCurrQueueUUID(String currQueueUUID) {
		this.currQueueUUID = currQueueUUID;
	}

	@Column
	public int getCurrQueueId() {
		return currQueueId;
	}

	public void setCurrQueueId(int currQueueId) {
		this.currQueueId = currQueueId;
	}

	@Column
	public long getCurrStartTime() {
		return currStartTime;
	}

	public void setCurrStartTime(long currStartTime) {
		this.currStartTime = currStartTime;
	}

	@Column(columnDefinition = "TEXT")
	public String getStockPack() {
		return stockPack;
	}

	public void setStockPack(String stockPack) {
		this.stockPack = stockPack;
	}
	
	@Column
	public long getUpdateTime() {
		return updateTime;
	}

	public void setUpdateTime(long updateTime) {
		this.updateTime = updateTime;
	}
}
