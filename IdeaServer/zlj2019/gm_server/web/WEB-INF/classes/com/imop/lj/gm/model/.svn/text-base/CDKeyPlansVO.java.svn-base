package com.imop.lj.gm.model;

import java.util.Date;

import com.imop.lj.db.model.CDKeyPlansEntity;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月27日 下午7:14:08
 * @version 1.0
 */

public class CDKeyPlansVO extends BaseVO {
	
	private int id;
	private int cdkeyPlansId;
	private String cdkeyPlansName;
	private Date startTime;
	private Date endTime;
	private Date createTime;
	private int gmId;
	
	
	public CDKeyPlansVO() {
		
	}
	
	public CDKeyPlansVO(CDKeyPlansEntity entity) {
		init(entity);
	}
	
	public void init(CDKeyPlansEntity entity ) {
		if(null == entity ){
			return;
		}
		this.id = entity.getId();
		this.cdkeyPlansId = entity.getCdkeyPlansId();
		this.cdkeyPlansName = entity.getCdkeyPlansName();
		this.startTime = new Date(entity.getStartTime());
		this.endTime = new Date(entity.getEndTime());
		this.createTime = new Date(entity.getCreateTime());
		this.gmId = entity.getGmId();
	}

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public int getCdkeyPlansId() {
		return cdkeyPlansId;
	}

	public void setCdkeyPlansId(int cdkeyPlansId) {
		this.cdkeyPlansId = cdkeyPlansId;
	}

	public String getCdkeyPlansName() {
		return cdkeyPlansName;
	}

	public void setCdkeyPlansName(String cdkeyPlansName) {
		this.cdkeyPlansName = cdkeyPlansName;
	}

	public Date getStartTime() {
		return startTime;
	}

	public void setStartTime(Date startTime) {
		this.startTime = startTime;
	}

	public Date getEndTime() {
		return endTime;
	}

	public void setEndTime(Date endTime) {
		this.endTime = endTime;
	}

	public Date getCreateTime() {
		return createTime;
	}

	public void setCreateTime(Date createTime) {
		this.createTime = createTime;
	}

	public int getGmId() {
		return gmId;
	}

	public void setGmId(int gmId) {
		this.gmId = gmId;
	}

}
