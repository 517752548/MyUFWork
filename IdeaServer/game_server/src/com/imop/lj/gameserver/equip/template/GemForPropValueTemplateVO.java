package com.imop.lj.gameserver.equip.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 属性种类对应单价值
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class GemForPropValueTemplateVO extends TemplateObject {

	/** 属性名称 */
	@ExcelCellBinding(offset = 1)
	protected String name;

	/** 单颗价值系数 */
	@ExcelCellBinding(offset = 2)
	protected int value;


	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		if (name != null) {
			this.name = name.trim();
		}else{
			this.name = name;
		}
	}
	
	public int getValue() {
		return this.value;
	}

	public void setValue(int value) {
		if (value == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[单颗价值系数]value不可以为0");
		}
		if (value < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[单颗价值系数]value的值不得小于1");
		}
		this.value = value;
	}
	

	@Override
	public String toString() {
		return "GemForPropValueTemplateVO[name=" + name + ",value=" + value + ",]";

	}
}