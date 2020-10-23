package com.imop.lj.gameserver.equip.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 打造-属性权重
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class CraftEquipPropTemplateVO extends TemplateObject {

	/** 单价值数值 */
	@ExcelCellBinding(offset = 2)
	protected int propValue;

	/** 权重 */
	@ExcelCellBinding(offset = 3)
	protected int weight;


	public int getPropValue() {
		return this.propValue;
	}

	public void setPropValue(int propValue) {
		if (propValue < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[单价值数值]propValue的值不得小于0");
		}
		this.propValue = propValue;
	}
	
	public int getWeight() {
		return this.weight;
	}

	public void setWeight(int weight) {
		if (weight < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[权重]weight的值不得小于0");
		}
		this.weight = weight;
	}
	

	@Override
	public String toString() {
		return "CraftEquipPropTemplateVO[propValue=" + propValue + ",weight=" + weight + ",]";

	}
}