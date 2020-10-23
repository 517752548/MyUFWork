package com.imop.lj.gm.model.log;

import java.util.List;

public class CommercemeetingLog extends BaseLog{
	private long commerceId;// 商会ID
	private String commerceName;// 商会名
	private int commerceLevel;// 商会等级
	private String result; //详细操作
	private int oprationgType;//操作类型
	private int membernums;//商会成员数目
	private long humanId;//被操作者id
	private String humanName;//被操作者姓名
	public long getCommerceId() {
		return commerceId;
	}
	public void setCommerceId(long commerceId) {
		this.commerceId = commerceId;
	}
	public String getCommerceName() {
		return commerceName;
	}
	public void setCommerceName(String commerceName) {
		this.commerceName = commerceName;
	}
	public int getCommerceLevel() {
		return commerceLevel;
	}
	public void setCommerceLevel(int commerceLevel) {
		this.commerceLevel = commerceLevel;
	}
	public String getResult() {
		return result;
	}
	public void setResult(String result) {
		this.result = result;
	}
	public int getOprationgType() {
		return oprationgType;
	}
	public void setOprationgType(int oprationgType) {
		this.oprationgType = oprationgType;
	}
	public int getMembernums() {
		return membernums;
	}
	public void setMembernums(int membernums) {
		this.membernums = membernums;
	}
	public long getHumanId() {
		return humanId;
	}
	public void setHumanId(long humanId) {
		this.humanId = humanId;
	}
	public String getHumanName() {
		return humanName;
	}
	public void setHumanName(String humanName) {
		this.humanName = humanName;
	}
	@SuppressWarnings("unchecked")
	@Override
	public List toList(){
		List list = super.toList();
		list.add(commerceId);
		list.add(commerceName);
		list.add(commerceLevel);
		list.add(result);
		list.add(oprationgType);
		list.add(membernums);
		list.add(humanId);
		list.add(humanName);
		return list;
	}
}
