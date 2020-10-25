package com.imop.lj.db.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;

/***
 * 财务汇报道具数据表
 *
 */
@Entity
@Table(name = "t_item_cost")
@Comment(content="数据库实体类：财务汇报道具数据表")
public class ItemCostRecordEntity implements BaseEntity<Long> {

	private static final long serialVersionUID = 1L;
	
	/** 主键 */
	@Comment(content="主键")
	private Long id;
	
	/**	玩家ID*/
	@Comment(content="玩家ID")
	private long charId;
	
	/**	模版ID*/
	@Comment(content="模版ID")
	private int templateId;
	
	/**道具个数*/
	@Comment(content="道具个数")
	private int itemNum;
	
	/**物品总价值*/
	@Comment(content="物品总价值")
	private long totalCost;
	
	/**实际花费金钱*/
	@Comment(content="实际花费金钱")
	private long actualCost;
	
	/**免费的个数*/
	@Comment(content="免费的个数")
	private int freeNum;
	
	@Id
	@Override
	public Long getId() {
		return id;
	}

	@Override
	public void setId(Long id) {
		this.id = id;
	}

	public static long getSerialversionuid() {
		return serialVersionUID;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getCharId() {
		return charId;
	}

	public void setCharId(long charId) {
		this.charId = charId;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getTemplateId() {
		return templateId;
	}

	public void setTemplateId(int templateId) {
		this.templateId = templateId;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getItemNum() {
		return itemNum;
	}

	public void setItemNum(int itemNum) {
		this.itemNum = itemNum;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getTotalCost() {
		return totalCost;
	}

	public void setTotalCost(long totalCost) {
		this.totalCost = totalCost;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getActualCost() {
		return actualCost;
	}

	public void setActualCost(long actualCost) {
		this.actualCost = actualCost;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getFreeNum() {
		return freeNum;
	}

	public void setFreeNum(int freeNum) {
		this.freeNum = freeNum;
	}
}
