package com.imop.lj.gm.service.xls;

public class MobileActivityInfo {
	//模版ID
	private int templateId;
	//subtype
	private int subType;
	//名称
	private String name;
	//是否可用
	private int useOrNot;
	// 描述
	private String desc;
	//结算天数	
	private int day;
	//结算小时
	private int hour;
	
	public int getTemplateId() {
		return templateId;
	}
	public void setTemplateId(int templateId) {
		this.templateId = templateId;
	}
	public int getSubType() {
		return subType;
	}
	public void setSubType(int subType) {
		this.subType = subType;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public int getUseOrNot() {
		return useOrNot;
	}
	public void setUseOrNot(int useOrNot) {
		this.useOrNot = useOrNot;
	}
	public String getDesc() {
		return desc;
	}
	public void setDesc(String desc) {
		this.desc = desc;
	}
	public int getDay() {
		return day;
	}
	public void setDay(int day) {
		this.day = day;
	}
	public int getHour() {
		return hour;
	}
	public void setHour(int hour) {
		this.hour = hour;
	}
	
}
