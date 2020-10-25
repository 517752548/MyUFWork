package com.imop.lj.db.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月4日 下午5:22:46
 * @version 1.0
 */
@Entity
@Table(name = "t_cdkey")
@Comment(content = "数据库实体类：CDKey表")
public class CDKeyEntity implements BaseEntity<String>, CharSubEntity {

	private static final long serialVersionUID = 1L;
	
	/** cdkey */
	@Comment(content = "主键 cdkey ")
	private String id;
	/** 活动名称 */
	@Comment(content = "cdkey套餐id")
	private Integer plansId;
	/** 礼包名称 */
	@Comment(content = "礼包Id")
	private Integer giftId;
	/** 分组id */
	@Comment(content = "分组id")
	private int groupId;
	/** gmId */
	@Comment(content = "gmId")
	private String gmId;
	/** 状态 0创建，1领取 */
	@Comment(content = "状态")
	private int state;
	/** 创建时间 */
	@Comment(content = "创建时间 ")
	private long createTime;
	/** openId */
	@Comment(content = "openId")
	private String openId;
	/** 角色id */
	@Comment(content = "角色id")
	private long charId = 0;
	/** 角色id */
	@Comment(content = "角色名称")
	private String charName = "";
	/** 领取角色所在服务器id */
	@Comment(content = "领取角色服务器id")
	private String chartServerId = "";
	/** 领取时间 */
	@Comment(content = "领取时间 ")
	private long takeTime;
	@Comment(content = "是否删除 ")
	private int isDel;

	
	@Id
	@Override
	@Column(length = 36)
	public String getId() {
		return this.id;
	}
	
	@Override
	public void setId(String id) {
		this.id = id;
		
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public Integer getPlansId() {
		return plansId;
	}

	public void setPlansId(Integer plansId) {
		this.plansId = plansId;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public Integer getGiftId() {
		return giftId;
	}

	public void setGiftId(Integer giftId) {
		this.giftId = giftId;
	}


	@Column(columnDefinition = "varchar(255) default '' ")
	public String getGmId() {
		return gmId;
	}

	public void setGmId(String gmId) {
		this.gmId = gmId;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getState() {
		return state;
	}

	public void setState(int state) {
		this.state = state;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getCreateTime() {
		return createTime;
	}

	public void setCreateTime(long createTime) {
		this.createTime = createTime;
	}

	@Column(columnDefinition = "varchar(255) default '' ")
	public String getOpenId() {
		return openId;
	}

	public void setOpenId(String openId) {
		this.openId = openId;
	}

	@Override
	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getCharId() {
		return charId;
	}

	public void setCharId(long charId) {
		this.charId = charId;
	}

	@Column(columnDefinition = "varchar(255) default '' ")
	public String getCharName() {
		return charName;
	}

	public void setCharName(String charName) {
		this.charName = charName;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getTakeTime() {
		return takeTime;
	}

	public void setTakeTime(long takeTime) {
		this.takeTime = takeTime;
	}
	
	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getGroupId() {
		return groupId;
	}

	public void setGroupId(int groupId) {
		this.groupId = groupId;
	}
	
	@Column(columnDefinition = " varchar(255) default '' ")
	public String getChartServerId() {
		return chartServerId;
	}
	
	public void setChartServerId(String chartServerId) {
		this.chartServerId = chartServerId;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getIsDel() {
		return isDel;
	}

	public void setIsDel(int isDel) {
		this.isDel = isDel;
	}

}
