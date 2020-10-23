package com.imop.lj.common.model.equip;

public class CraftInfo {
	//基础属性key
	private int baseAttrKey;
	//基础属性数值
	private int baseAttrValue;
	//大概率属性列表
	private CraftAttrInfo[] craftAttrInfos;
	//属性条数列表
	private CraftAttrNumInfo[] craftAttrNumInfos;
	//最大孔数
	private int holeMaxNum;
	
	public int getBaseAttrKey() {
		return baseAttrKey;
	}
	public void setBaseAttrKey(int baseAttrKey) {
		this.baseAttrKey = baseAttrKey;
	}
	public int getBaseAttrValue() {
		return baseAttrValue;
	}
	public void setBaseAttrValue(int baseAttrValue) {
		this.baseAttrValue = baseAttrValue;
	}
	public CraftAttrInfo[] getCraftAttrInfos() {
		return craftAttrInfos;
	}
	public void setCraftAttrInfos(CraftAttrInfo[] craftAttrInfos) {
		this.craftAttrInfos = craftAttrInfos;
	}
	public CraftAttrNumInfo[] getCraftAttrNumInfos() {
		return craftAttrNumInfos;
	}
	public void setCraftAttrNumInfos(CraftAttrNumInfo[] craftAttrNumInfos) {
		this.craftAttrNumInfos = craftAttrNumInfos;
	}
	public int getHoleMaxNum() {
		return holeMaxNum;
	}
	public void setHoleMaxNum(int holeMaxNum) {
		this.holeMaxNum = holeMaxNum;
	}
	
}
