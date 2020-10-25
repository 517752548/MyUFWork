package com.imop.lj.db.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月27日 下午7:16:14
 * @version 1.0
 */
@Entity
@Table(name = "t_cdkey_plans")
@Comment(content = "数据库实体类：CDKeyPlans套餐表")
public class CDKeyPlansEntity implements BaseEntity<Integer> {

	private static final long serialVersionUID = 1L;
	
	@Comment(content="主键 ")
	private int id;
	@Comment(content="CDKEY套餐Id")
	private int cdkeyPlansId;
	@Comment(content="CDKEY套餐名字")
	private String cdkeyPlansName;
	@Comment(content="CDKEY有效期开始时间")
	private long startTime;
	@Comment(content="CDKEY有效期结束时间")
	private long endTime;
	@Comment(content="CDKEY套餐创建时间")
	private long createTime;
	@Comment(content="CDKEY套餐创建gmid")
	private int gmId;
	@Comment(content="是否删除")
	private int isDel;

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

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getCdkeyPlansId() {
		return cdkeyPlansId;
	}

	public void setCdkeyPlansId(int cdkeyPlansId) {
		this.cdkeyPlansId = cdkeyPlansId;
	}

	@Column(columnDefinition = "varchar(255) default '' ", nullable = false)
	public String getCdkeyPlansName() {
		return cdkeyPlansName;
	}

	public void setCdkeyPlansName(String cdkeyPlansName) {
		this.cdkeyPlansName = cdkeyPlansName;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getStartTime() {
		return startTime;
	}

	public void setStartTime(long startTime) {
		this.startTime = startTime;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getEndTime() {
		return endTime;
	}

	public void setEndTime(long endTime) {
		this.endTime = endTime;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getCreateTime() {
		return createTime;
	}

	public void setCreateTime(long createTime) {
		this.createTime = createTime;
	}

	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getGmId() {
		return gmId;
	}

	public void setGmId(int gmId) {
		this.gmId = gmId;
	}
	
	@Column(columnDefinition = " int(11) default 0", nullable = false)
	public int getIsDel() {
		return isDel;
	}

	public void setIsDel(int isDel) {
		this.isDel = isDel;
	}
}
