package com.imop.lj.core.template;

import java.util.Arrays;

/**
 *
 *
 */
public class TemplateConfig {
	/** 模板的文件路径 */
	private String fileName;
	/** 该模板自定义的解析器 */
	private String parserClassName;
	/** 模板类型 */
	private Class<?>[] classes;

	//c#
	private boolean notclient;
	private boolean[] notclientClasses;//与classes属性的length相同
	
	public TemplateConfig(String fileName, Class<?>[] classes) {
		this.fileName = fileName;
		this.classes = classes;
	}
	
	public TemplateConfig(String fileName, Class<?>[] classes, boolean notclient, boolean[] notclientClasses) {
		this.fileName = fileName;
		this.classes = classes;
		this.notclient = notclient;
		this.notclientClasses = notclientClasses;
	}

	public void setFileName(String fileName) {
		this.fileName = fileName;
	}

	public String getFileName() {
		return fileName;
	}

	public String getParserClassName() {
		return parserClassName;
	}

	public void setParserClassName(String parserClassName) {
		this.parserClassName = parserClassName;
	}

	public void setClasses(Class<?>[] classes) {
		this.classes = classes;
	}

	public Class<?>[] getClasses() {
		return classes;
	}

	public boolean isNotclient() {
		return notclient;
	}

	public void setNotclient(boolean notclient) {
		this.notclient = notclient;
	}

	public boolean[] getNotclientClasses() {
		return notclientClasses;
	}

	public void setNotclientClasses(boolean[] notclientClasses) {
		this.notclientClasses = notclientClasses;
	}

	@Override
	public String toString() {
		return "TemplateConfig [classes=" + Arrays.toString(classes) + ", fileName=" + fileName + "]";
	}

}
