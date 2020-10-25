package com.imop.lj.tools.log;

import java.util.List;

import com.imop.lj.tools.log.LogMsgGenerator.Field;

public class LogType
{
	/**log的字段名称*/
	private String name;
	
	/**log相关类名称*/
	private String className;
	
	/**log的id*/
	private int id;
	
	/**log的注释*/
	private String comment;
	
	private List<Field> fields;

	public List<Field> getFields() {
		return fields;
	}

	public void setFields(List<Field> fields) {
		this.fields = fields;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getClassName() {
		return className;
	}

	public void setClassName(String className) {
		this.className = className;
	}

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public String getComment() {
		return comment;
	}

	public void setComment(String comment) {
		this.comment = comment;
	}
}
