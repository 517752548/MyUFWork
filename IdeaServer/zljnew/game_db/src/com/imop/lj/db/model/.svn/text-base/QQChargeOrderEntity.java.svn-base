package com.imop.lj.db.model;

import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.SoftDeleteEntity;

/**
 * qq充值订单实体
 * @author yu.zhao
 *
 */
@Entity
@Table(name = "t_qq_charge_order")
@Comment(content="qq充值订单")
public class QQChargeOrderEntity implements SoftDeleteEntity<String> {
	/** */
	private static final long serialVersionUID = 1L;
	
	@Comment(content="唯一id，'QQ_'+openid+'_'+billno")
	private String id;
	
	@Comment(content="订单id，对应billno")
	private String billno;
	
	@Comment(content="openid")
	private String openId;
	
	@Comment(content="玩家角色id")
	private long charId;
	
	@Comment(content="充值套餐模板id")
	private int chargeTplId;
	
	@Comment(content="充值套餐数量")
	private int chargeTplNum;
	
	@Comment(content="params")
	private String params;
	
	@Comment(content="创建时间 ")
	private long createTime;
	
	@Comment(content="是否已删除")
	private int deleted;
	
	@Comment(content="删除时间 ")
	private Timestamp deleteDate;
	
	@Id
	@Override
	@Column(columnDefinition = "VARCHAR(255)")
	public String getId() {
		return id;
	}

	@Override
	public void setId(String id) {
		this.id = id;
	}

	@Column(columnDefinition = "VARCHAR(255)")
	public String getBillno() {
		return billno;
	}

	public void setBillno(String billno) {
		this.billno = billno;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getCharId() {
		return charId;
	}

	public void setCharId(long charId) {
		this.charId = charId;
	}

	@Column(columnDefinition = "TEXT")
	public String getParams() {
		return params;
	}

	public void setParams(String params) {
		this.params = params;
	}

	@Override
	@Column(columnDefinition = " int default 0", nullable = false)
	public int getDeleted() {
		return deleted;
	}

	public void setDeleted(int deleted) {
		this.deleted = deleted;
	}

	@Override
	public Timestamp getDeleteDate() {
		return deleteDate;
	}

	public void setDeleteDate(Timestamp deleteDate) {
		this.deleteDate = deleteDate;
	}
	
	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getCreateTime() {
		return createTime;
	}

	public void setCreateTime(long createTime) {
		this.createTime = createTime;
	}

	@Column(columnDefinition = "VARCHAR(255)")
	public String getOpenId() {
		return openId;
	}

	public void setOpenId(String openId) {
		this.openId = openId;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getChargeTplId() {
		return chargeTplId;
	}

	public void setChargeTplId(int chargeTplId) {
		this.chargeTplId = chargeTplId;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getChargeTplNum() {
		return chargeTplNum;
	}

	public void setChargeTplNum(int chargeTplNum) {
		this.chargeTplNum = chargeTplNum;
	}
	
}
