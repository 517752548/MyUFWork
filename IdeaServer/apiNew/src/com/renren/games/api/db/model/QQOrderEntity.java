package com.renren.games.api.db.model;

import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.renren.games.api.annotation.Comment;
import com.renren.games.api.db.SoftDeleteEntity;

/**
 * 数据库实体类：角色信息，暂时先放在这儿
 *
 */
@Entity
@Table(name = "t_qqorder_info")
@Comment(content="qq订单内容")
public class QQOrderEntity implements SoftDeleteEntity<String> {
	/** */
	private static final long serialVersionUID = 1L;
	/** 玩家角色ID 主键 */
	@Comment(content="订单id")
	private String id;
	
	@Comment(content="玩家角色id")
	private long charId;
	
	@Comment(content="平台id")
	private String platform;
	
	@Comment(content="serverName")
	private String serverName;
	
	@Comment(content="params")
	private String params;
	
	@Comment(content="创建时间 ")
	private long createDate;
	
	@Comment(content="是否已删除")
	private int deleted;
	
	@Comment(content="删除时间 ")
	private Timestamp deleteDate;
	
	@Comment(content="appid")
	private String appid;
	
	@Comment(content="openid")
	private String openid;
	
	@Comment(content="是否领取，默认是领取状态,1是已经领取，0是未领取")
	private int charged;
	
	@Comment(content="领取时间")
	private Timestamp chargeDate;
	
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

	@Column(columnDefinition = " bigint(20) ", nullable = false)
	public long getCharId() {
		return charId;
	}

	public void setCharId(long charId) {
		this.charId = charId;
	}

	@Column(columnDefinition = "VARCHAR(255)")
	public String getPlatform() {
		return platform;
	}

	public void setPlatform(String platform) {
		this.platform = platform;
	}

	@Column(columnDefinition = "VARCHAR(255)")
	public String getServerName() {
		return serverName;
	}

	public void setServerName(String serverName) {
		this.serverName = serverName;
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
	
	public long getCreateDate() {
		return createDate;
	}

	public void setCreateDate(long createDate) {
		this.createDate = createDate;
	}
	
	@Column(columnDefinition = "VARCHAR(255)")
	public String getAppid() {
		return appid;
	}

	public void setAppid(String appid) {
		this.appid = appid;
	}

	@Column(columnDefinition = "VARCHAR(255)")
	public String getOpenid() {
		return openid;
	}

	public void setOpenid(String openid) {
		this.openid = openid;
	}

	@Column(columnDefinition = " int default 0", nullable = false)
	public int getCharged() {
		return charged;
	}

	public void setCharged(int charged) {
		this.charged = charged;
	}

	public Timestamp getChargeDate() {
		return chargeDate;
	}

	public void setChargeDate(Timestamp chargeDate) {
		this.chargeDate = chargeDate;
	}
}
