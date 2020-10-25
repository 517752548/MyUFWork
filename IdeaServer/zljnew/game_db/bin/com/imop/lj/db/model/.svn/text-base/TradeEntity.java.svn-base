package com.imop.lj.db.model;

import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.SoftDeleteEntity;

/**
 *酒馆任务表
 * 
 */
@Entity
@Table(name = "t_trade_info")
@Comment(content="数据库实体类：交易实体")
public class TradeEntity implements SoftDeleteEntity<Long> {
	/** */
	private static final long serialVersionUID = -6091604494623983576L;
	
	/** 主键 */
	@Comment(content="主键")
	private Long id;
	/** 卖家角色Id */
	@Comment(content="卖家角色Id")
	private long sellerCharId;
	/** 买家角色Id */
	@Comment(content="买家角色Id")
	private long buyerCharId;
	/** 商品类型 */
	@Comment(content="商品类型")
	private int type;
	/** 交易状态 */
	@Comment(content="交易状态")
	private int tradeStatus;
	/** 商品在卖家摊位的位置 */
	@Comment(content="摊位位置")
	private int boothIndex;
	/** 出售货币类型 */
	@Comment(content="出售货币类型")
	private int currencyType;
	/** 售价 */
	@Comment(content="售价")
	private int currencyNum;
	/** 商品详细信息 */
	@Comment(content="商品详细信息")
	private String commodityInfo;
	/** 交易创建时间 */
	@Comment(content="交易创建时间")
	private Timestamp startTime;
	/** 交易最后更新时间*/
	@Comment(content="交易最后更新时间 ")
	private Timestamp lastUpdateTime;
	/** 商品下架时间*/
	@Comment(content="商品下架时间 ")
	private Timestamp overDueTime;
	/** 商品出售数量*/
	@Comment(content="商品出货量 ")
	private Integer commodityNum;
	@Comment(content="删除时间")
	private Timestamp deleteDate;
	@Comment(content="是否已删除")
	private int deleted;
	
	
	public TradeEntity() {
		super();
	}

	@Id
	@Override
	@Column
	public Long getId() {
		return this.id;
	}

	@Override
	public void setId(Long id) {
		this.id = id ;
	}
	
	
	@Override
	@Column
	public int getDeleted() {
		return this.deleted;
	}
	
	@Column
	public long getSellerCharId() {
		return sellerCharId;
	}

	@Column
	public long getBuyerCharId() {
		return buyerCharId;
	}

	@Column
	public int getType() {
		return type;
	}

	@Column
	public int getTradeStatus() {
		return tradeStatus;
	}

	@Column(columnDefinition = " varchar(4096) default ''", nullable = true)
	public String getCommodityInfo() {
		return commodityInfo;
	}
	
	public void setSellerCharId(long sellerCharId) {
		this.sellerCharId = sellerCharId;
	}

	public void setBuyerCharId(long buyerCharId) {
		this.buyerCharId = buyerCharId;
	}

	public void setType(int type) {
		this.type = type;
	}

	public void setTradeStatus(int tradeStatus) {
		this.tradeStatus = tradeStatus;
	}

	public void setCommodityInfo(String commodityInfo) {
		this.commodityInfo = commodityInfo;
	}

	public void setDeleted(int deleted) {
		this.deleted = deleted;
	}
	
	@Column
	public int getBoothIndex() {
		return boothIndex;
	}

	public void setBoothIndex(int boothIndex) {
		this.boothIndex = boothIndex;
	}

	@Column
	public int getCurrencyType() {
		return currencyType;
	}

	public void setCurrencyType(int currencyType) {
		this.currencyType = currencyType;
	}

	@Column
	public int getCurrencyNum() {
		return currencyNum;
	}

	public void setCurrencyNum(int currencyNum) {
		this.currencyNum = currencyNum;
	}

	@Column
	public Timestamp getStartTime() {
		return startTime;
	}

	public void setStartTime(Timestamp startTime) {
		this.startTime = startTime;
	}

	@Column
	public Timestamp getLastUpdateTime() {
		return lastUpdateTime;
	}

	public void setLastUpdateTime(Timestamp lastUpdateTime) {
		this.lastUpdateTime = lastUpdateTime;
	}

	@Column
	public Timestamp getOverDueTime() {
		return overDueTime;
	}

	public void setOverDueTime(Timestamp overDueTime) {
		this.overDueTime = overDueTime;
	}

	@Column
	public Timestamp getDeleteDate() {
		return deleteDate;
	}

	public void setDeleteDate(Timestamp deleteDate) {
		this.deleteDate = deleteDate;
	}

	@Column
	public Integer getCommodityNum() {
		return commodityNum;
	}

	public void setCommodityNum(Integer commodityNum) {
		this.commodityNum = commodityNum;
	}


	

}
