package com.imop.lj.common.model.equip;

public class CraftAttrInfo {
	//属性key
	private int attrKey;
	//属性最小值
	private int min;
	//属性最大值
	private int max;
	//属性概率*100
	private int prob;
	
	public int getAttrKey() {
		return attrKey;
	}
	public void setAttrKey(int attrKey) {
		this.attrKey = attrKey;
	}
	public int getMin() {
		return min;
	}
	public void setMin(int min) {
		this.min = min;
	}
	public int getMax() {
		return max;
	}
	public void setMax(int max) {
		this.max = max;
	}
	public int getProb() {
		return prob;
	}
	public void setProb(int prob) {
		this.prob = prob;
	}
}
