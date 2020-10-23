package com.imop.lj.common.model.item;

/**
 *
 * 物品属性信息
 *
 *
 */
public class AttrDesc {
	/** 属性key */
	int key;
	/** 属性描述 */
	String mainValue;

	public int getKey() {
		return key;
	}

	public void setKey(int key) {
		this.key = key;
	}

	public String getMainValue() {
		return mainValue;
	}

	public void setMainValue(String mainValue) {
		this.mainValue = mainValue;
	}

	@Override
	public String toString() {
		return "AttrDesc [key=" + key + ", mainValue=" + mainValue + "]";
	}
}
