package com.imop.lj.db.model;

import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;

/**
 * GM补偿实体类:GM补偿实体
 * 
 */
@Entity
@Table(name = "t_user_prize")
@Comment(content="数据库实体类：GM补偿")
public class UserPrize implements BaseEntity<Integer> {
	
	private static final long serialVersionUID = 1L;
	
	/** 主键 */
	@Comment(content="主键")
	private Integer id;

	/** 玩家账号ID */
	@Comment(content="玩家账号ID")
	private String passportId;
	
	/** 角色ID */
	@Comment(content="角色ID")
	private long charId;

	/** GM补偿名称 */
	@Comment(content="GM补偿名称")
	private String userPrizeName;

	/** 奖励金钱 */
	@Comment(content="奖励金钱")
	private String coin;

	/** 奖励物品 */
	@Comment(content="奖励物品")
	private String item;

	/** 补偿类型 */
	@Comment(content="补偿类型")
	private int type;

	/** 领取状态(1表示已经领取,0代表未领取) */
	@Comment(content="领取状态(1表示已经领取,0代表未领取)")
	private int status;

	/** 记录创建时间 */
	@Comment(content="记录创建时间")
	private Timestamp createTime;

	/**过期时间*/
	@Comment(content="过期时间")
	private Timestamp expireTime;
	
	/** 记录更新时间 */
	@Comment(content="记录更新时间")
	private Timestamp updateTime;
	
	/** 带有属性的装备 */
	@Comment(content="装备属性")
	private String itemParams;
	
	@Comment(content="gm补偿信息")
	private String params;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Override
	public Integer getId() {
		return id;
	}

	@Override
	public void setId(Integer id) {
		this.id = id;
	}

	@Column(columnDefinition = "text", nullable = false)
	public String getPassportId() {
		return passportId;
	}

	public void setPassportId(String passportId) {
		this.passportId = passportId;
	}
	
	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getCharId() {
		return charId;
	}

	public void setCharId(long charId) {
		this.charId = charId;
	}

	@Column(columnDefinition = " varchar(32)", nullable = false)
	public String getUserPrizeName() {
		return userPrizeName;
	}

	public void setUserPrizeName(String userPrizeName) {
		this.userPrizeName = userPrizeName;
	}

	@Column(columnDefinition = "text")
	public String getCoin() {
		return coin;
	}

	public void setCoin(String coin) {
		this.coin = coin;
	}

	@Column(columnDefinition = "text")
	public String getItem() {
		return item;
	}

	public void setItem(String item) {
		this.item = item;
	}

	@Column(columnDefinition = "int default 0", nullable = false)
	public int getType() {
		return type;
	}

	public void setType(int type) {
		this.type = type;
	}

	@Column(columnDefinition = "int default 0", nullable = false)
	public int getStatus() {
		return status;
	}

	public void setStatus(int status) {
		this.status = status;
	}

	@Column
	public Timestamp getCreateTime() {
		return createTime;
	}

	public void setCreateTime(Timestamp createTime) {
		this.createTime = createTime;
	}

	@Column
	public Timestamp getUpdateTime() {
		return updateTime;
	}

	public void setUpdateTime(Timestamp updateTime) {
		this.updateTime = updateTime;
	}

	@Column
	public Timestamp getExpireTime() {
		return expireTime;
	}

	public void setExpireTime(Timestamp expireTime) {
		this.expireTime = expireTime;
	}

	@Column(columnDefinition = "text")
	public String getItemParams() {
		return itemParams;
	}

	public void setItemParams(String itemParams) {
		this.itemParams = itemParams;
	}

	@Column(columnDefinition = "text")
	public String getParams() {
		return params;
	}

	public void setParams(String params) {
		this.params = params;
	}
}
