package com.imop.lj.gm.model.log;

import java.util.List;

public class WashDiamondLog extends BaseLog {

    private String weaponTemplateId;
    private String diamondName;
    private String firstKey;
    private String firstValue;
    private String firstLock;
    private String secondKey;
    private String secondValue;
    private String secondLock;
    private String thirdKey;
    private String thirdValue;
    private String thirdLock;
    private String costMsg;



	public String getWeaponTemplateId() {
		return weaponTemplateId;
	}



	public void setWeaponTemplateId(String weaponTemplateId) {
		this.weaponTemplateId = weaponTemplateId;
	}



	public String getDiamondName() {
		return diamondName;
	}



	public void setDiamondName(String diamondName) {
		this.diamondName = diamondName;
	}



	public String getFirstKey() {
		return firstKey;
	}



	public void setFirstKey(String firstKey) {
		this.firstKey = firstKey;
	}



	public String getFirstValue() {
		return firstValue;
	}



	public void setFirstValue(String firstValue) {
		this.firstValue = firstValue;
	}



	public String getFirstLock() {
		return firstLock;
	}



	public void setFirstLock(String firstLock) {
		this.firstLock = firstLock;
	}



	public String getSecondKey() {
		return secondKey;
	}



	public void setSecondKey(String secondKey) {
		this.secondKey = secondKey;
	}



	public String getSecondValue() {
		return secondValue;
	}



	public void setSecondValue(String secondValue) {
		this.secondValue = secondValue;
	}



	public String getSecondLock() {
		return secondLock;
	}



	public void setSecondLock(String secondLock) {
		this.secondLock = secondLock;
	}



	public String getThirdKey() {
		return thirdKey;
	}



	public void setThirdKey(String thirdKey) {
		this.thirdKey = thirdKey;
	}



	public String getThirdValue() {
		return thirdValue;
	}



	public void setThirdValue(String thirdValue) {
		this.thirdValue = thirdValue;
	}



	public String getThirdLock() {
		return thirdLock;
	}



	public void setThirdLock(String thirdLock) {
		this.thirdLock = thirdLock;
	}



	public String getCostMsg() {
		return costMsg;
	}



	public void setCostMsg(String costMsg) {
		this.costMsg = costMsg;
	}



	@SuppressWarnings("unchecked")
	@Override
	public List toList(){
		List list = super.toList();
		list.add(this.weaponTemplateId);
		list.add(this.diamondName);
		list.add(this.firstKey);
		list.add(this.firstValue);
		list.add(this.firstLock);
		list.add(this.secondKey);
		list.add(this.secondValue);
		list.add(this.secondLock);
		list.add(this.thirdKey);
		list.add(this.thirdValue);
		list.add(this.thirdLock);
		list.add(this.costMsg);
		return list;
	}
}
