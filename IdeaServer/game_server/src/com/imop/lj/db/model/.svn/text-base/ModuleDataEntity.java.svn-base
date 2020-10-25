package com.imop.lj.db.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;

@Entity
@Table(name = "t_module_data")
@Comment(content = "数据库实体类：功能数据")
public class ModuleDataEntity implements BaseEntity<Integer> {
	private static final long serialVersionUID = 1L;
	@Comment(content = "功能类型")
	private int moduleTypeId;
	@Comment(content = "功能数据")
	private String json;

	@Id
	@Override
	public Integer getId() {
		return this.moduleTypeId;
	}

	@Override
	public void setId(Integer id) {
		this.moduleTypeId = id;
	}

	@Column(columnDefinition = "text")
	public String getJson() {
		return json;
	}

	public void setJson(String json) {
		this.json = json;
	}

}
