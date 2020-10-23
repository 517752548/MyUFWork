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
 * 数据库实体类:服务器版本实体
 * 
 */
@Entity
@Table(name = "t_db_version")
@Comment(content="数据库实体类:服务器版本实体")
public class DbVersion implements BaseEntity<Integer>{
	private static final long serialVersionUID = 1L;
	/** 主键 */
	@Comment(content="主键 ")
	private Integer id;
	/** 服务器版本号 */
	@Comment(content="服务器版本号 ")
	private String version;
	/** 服务器版本号更新时间 */
	@Comment(content="服务器版本号更新时间 ")
	private Timestamp updateTime;
	/** 服务器开服时间 */
	@Comment(content="服务器开服时间")
	private Timestamp openTime;
	/** 服务器合服时间 */
	@Comment(content="服务器合服时间")
	private Timestamp mergeTime;
	
	@Comment(content="服务器Id列表，普通服一个如[1001]，合过服的是多个，如[1001,1002]")
	private String serverIds;
	
	@Comment(content="服务器名称列表，与serverIds对应，如[1区,2区]")
	private String serverNames;
	
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	public Integer getId() {
		return id;
	}

	public void setId(Integer id) {
		this.id = id;
	}

	@Column(nullable = false, insertable = true, updatable = false)
	public String getVersion() {
		return version;
	}

	public void setVersion(String version) {
		this.version = version;
	}

	@Column(nullable = false, insertable = true, updatable = false)
	public Timestamp getUpdateTime() {
		return updateTime;
	}

	public void setUpdateTime(Timestamp updateTime) {
		this.updateTime = updateTime;
	}

	@Column(nullable = false, insertable = true, updatable = false)
	public Timestamp getOpenTime() {
		return openTime;
	}

	public void setOpenTime(Timestamp openTime) {
		this.openTime = openTime;
	}

	@Column(nullable = true, insertable = true, updatable = false)
	public Timestamp getMergeTime() {
		return mergeTime;
	}

	public void setMergeTime(Timestamp mergeTime) {
		this.mergeTime = mergeTime;
	}

	@Column(nullable = true, insertable = true, updatable = true)
	public String getServerIds() {
		return serverIds;
	}

	public void setServerIds(String serverIds) {
		this.serverIds = serverIds;
	}

	@Column(nullable = true, insertable = true, updatable = true)
	public String getServerNames() {
		return serverNames;
	}

	public void setServerNames(String serverNames) {
		this.serverNames = serverNames;
	}

}
