package com.imop.lj.gameserver.pet.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.core.template.BeanFieldNumber;
import com.imop.lj.gameserver.role.properties.PropertyType;

/**
 *
 * 装备的一个属性
 *
 */
@ExcelRowBinding
public class PassiveTalentPropItem {
	/** 属性key */
	@BeanFieldNumber(number = 1)
	private int propKey;
	/** 属性初始值 */
	@BeanFieldNumber(number = 2)
	private int propValue;
	/** 属性每级增加属性 */
	@BeanFieldNumber(number = 3)
	private int propLevelAdd;

	public PassiveTalentPropItem() {
		
	}

	public int getPropKey() {
		return propKey;
	}

	public void setPropKey(int propKey) {
		this.propKey = propKey;
	}

	public int getPropValue() {
		return propValue;
	}

	public void setPropValue(int propValue) {
		this.propValue = propValue;
	}
	
	public int getPropLevelAdd() {
		return propLevelAdd;
	}

	public void setPropLevelAdd(int propLevelAdd) {
		this.propLevelAdd = propLevelAdd;
	}

	/**
	 * 获取属性的索引，外层需自己调用属性类型校验，这里只做减法，不验证
	 * @param propType
	 * @return
	 */
	public int getPropKeyIndex(int propType) {
		return getPropKey() - PropertyType.genPropertyKey(0, propType);
	}

	@Override
	public String toString() {
		return "PassiveTalentPropItem [propKey=" + propKey + ", propValue="
				+ propValue + ", propLevelAdd=" + propLevelAdd + "]";
	}
}
