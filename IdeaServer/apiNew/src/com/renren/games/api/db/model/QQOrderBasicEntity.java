package com.renren.games.api.db.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.renren.games.api.annotation.Comment;

/**
 * 数据库实体类：角色信息，暂时先放在这儿
 *
 */
@Entity
@Table(name = "t_qqorder_basic_info")
@Comment(content="qq订单基本信息")
public class QQOrderBasicEntity implements BaseEntity<String> {
	/** */
	private static final long serialVersionUID = 1L;
	
	@Comment(content="'bill'+openid+token")
	private String id;
	
	@Comment(content="玩家角色id")
	private long charId;
	
	@Comment(content="openid")
	private String openid;

	@Comment(content="openkey")
	private String openkey;

	@Comment(content="pf")
	private String pf;

	@Comment(content="pfkey")
	private String pfkey;
	
	@Comment(content="appid")
	private String appid;

	@Comment(content="billToken")
	private String billToken;

	@Comment(content="创建时间 ")
	private long createDate;
	
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
	public String getOpenid() {
		return openid;
	}

	public void setOpenid(String openid) {
		this.openid = openid;
	}

	@Column(columnDefinition = "VARCHAR(255)")
	public String getOpenkey() {
		return openkey;
	}

	public void setOpenkey(String openkey) {
		this.openkey = openkey;
	}

	@Column(columnDefinition = "VARCHAR(255)")
	public String getPf() {
		return pf;
	}

	public void setPf(String pf) {
		this.pf = pf;
	}

	@Column(columnDefinition = "VARCHAR(255)")
	public String getPfkey() {
		return pfkey;
	}

	public void setPfkey(String pfkey) {
		this.pfkey = pfkey;
	}

	@Column(columnDefinition = "VARCHAR(255)")
	public String getBillToken() {
		return billToken;
	}

	public void setBillToken(String billToken) {
		this.billToken = billToken;
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
}
