package com.imop.lj.db.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;

/**
 * 场景实体
 * 
 */
@Entity
@Table(name = "t_scene_info")
@Comment(content="数据库实体类：场景实体")
public class SceneEntity implements BaseEntity<Long> {
	/** serialVersionUID */
	private static final long serialVersionUID = 3001700052406535172L;
	/** 主键 uuid */
	@Comment(content="主键 uuid")
	private long id;
	/** 模版 Id */
	@Comment(content="模版 Id")
	private int templateId;
	/** 大字段 */
	@Comment(content="大字段 ")
	private String properties;

	/**
	 * 类默认构造器
	 * 
	 */
	public SceneEntity() {
	}

	@Id
	@Column
	@Override
	public Long getId() {
		return id;
	}

	@Override
	public void setId(Long id) {
		this.id = id;
	}

	@Column
	public Integer getTemplateId() {
		return this.templateId;
	}

	public void setTemplateId(int value) {
		this.templateId = value;
	}

	@Column(columnDefinition = "text")
	public String getProperties() {
		return this.properties;
	}

	public void setProperties(String value) {
		this.properties = value;
	}
}
