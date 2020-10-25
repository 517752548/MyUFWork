package com.imop.lj.db.model;

import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.core.orm.SoftDeleteEntity;

@Entity
@Table(name = "t_red_envelope")
@Comment(content="数据库实体类：红包 ")
public class RedEnvelopeEntity implements BaseEntity<String>,SoftDeleteEntity<String>{
	private static final long serialVersionUID = 1L;

	/** 主键 */
	@Comment(content="主键 ")
	private String id;
	/** 所属帮派Id*/
	@Comment(content="所属帮派Id")
	private long corpsId;
	/** 发红包玩家id*/
	@Comment(content="发红包玩家id")
	private long sendId;
	/** 发红包玩家名称*/
	@Comment(content="发红包玩家名称")
	private String sendName;
	/** 红包内容*/
	@Comment(content="红包内容")
	private String content;
	/** 红包状类型*/
	@Comment(content=" 红包类型")
	private int redEnvelopeType;
	/** 红包状态 */
	@Comment(content=" 红包状态 ")
	private int redEnvelopeStatus;
	/** 发送时间*/
	@Comment(content="发送时间")
	private long createTime;
	/** 红包总金额*/
	@Comment(content="红包总金额")
	private int bonusAmount;
	/** 红包随机分配金额 */
	@Comment(content="红包随机分配金额 ")
	private String randomRedEnveloperUnit;
	/** 剩余红包数量*/
	@Comment(content="剩余红包数量")
	private int remainingNum;
	/** 剩余红包金额*/
	@Comment(content="剩余红包金额")
	private int remainingBonus;

	/** 是否已删除 */
	@Comment(content="是否已删除  ")
	private int deleted;

	/** 删除时间 */
	@Comment(content="删除时间  ")
	private Timestamp deleteDate;

	/** 抢红包的玩家信息 */
	@Comment(content="抢红包的玩家信息")
	private String openRedEnveloperInfo;

	@Id
	@Override
	@Column(length = 36)
	public String getId() {
		return id;
	}

	@Column(columnDefinition = "bigint(20) default 0")
	public long getSendId() {
		return sendId;
	}

	@Column(columnDefinition = "VARCHAR(255)")
	public String getSendName() {
		return sendName;
	}

	@Override
	public void setId(String id) {
		this.id = id;
	}

	public void setSendName(String sendName) {
		this.sendName = sendName;
	}

	public void setContent(String content) {
		this.content = content;
	}
	
	@Column(columnDefinition = "bigint(20) default 0")
	public long getCorpsId() {
		return corpsId;
	}

	public void setCorpsId(long corpsId) {
		this.corpsId = corpsId;
	}

	@Column(columnDefinition = " int(2) default 0", nullable = false)
	public int getRedEnvelopeType() {
		return redEnvelopeType;
	}

	public void setRedEnvelopeType(int redEnvelopeType) {
		this.redEnvelopeType = redEnvelopeType;
	}

	@Column(columnDefinition = " int(2) default 0", nullable = false)
	public int getRedEnvelopeStatus() {
		return redEnvelopeStatus;
	}

	public void setRedEnvelopeStatus(int redEnvelopeStatus) {
		this.redEnvelopeStatus = redEnvelopeStatus;
	}

	@Column(columnDefinition = "bigint(20) default 0")
	public long getCreateTime() {
		return createTime;
	}

	public void setCreateTime(long createTime) {
		this.createTime = createTime;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getBonusAmount() {
		return bonusAmount;
	}

	public void setBonusAmount(int bonusAmount) {
		this.bonusAmount = bonusAmount;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getRemainingNum() {
		return remainingNum;
	}

	public void setRemainingNum(int remainingNum) {
		this.remainingNum = remainingNum;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getRemainingBonus() {
		return remainingBonus;
	}

	public void setRemainingBonus(int remainingBonus) {
		this.remainingBonus = remainingBonus;
	}

	@Column(columnDefinition = "LONGTEXT")
	public String getContent() {
		return content;
	}

	@Column(columnDefinition = "LONGTEXT")
	public String getRandomRedEnveloperUnit() {
		return randomRedEnveloperUnit;
	}

	public void setRandomRedEnveloperUnit(String randomRedEnveloperUnit) {
		this.randomRedEnveloperUnit = randomRedEnveloperUnit;
	}
	
	@Column
	@Override
	public int getDeleted() {
		return deleted;
	}

	@Column
	@Override
	public Timestamp getDeleteDate() {
		return deleteDate;
	}
	public void setDeleted(int deleted) {
		this.deleted = deleted;
	}

	public void setDeleteDate(Timestamp deleteDate) {
		this.deleteDate = deleteDate;
	}

	@Column(columnDefinition = "LONGTEXT")
	public String getOpenRedEnveloperInfo() {
		return openRedEnveloperInfo;
	}

	public void setOpenRedEnveloperInfo(String openRedEnveloperInfo) {
		this.openRedEnveloperInfo = openRedEnveloperInfo;
	}

	public void setSendId(long sendId) {
		this.sendId = sendId;
	}

}
