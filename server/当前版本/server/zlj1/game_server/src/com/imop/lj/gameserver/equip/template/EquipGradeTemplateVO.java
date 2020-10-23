package com.imop.lj.gameserver.equip.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 装备-阶数加成
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class EquipGradeTemplateVO extends TemplateObject {

	/** 扩大1000倍 */
	@ExcelCellBinding(offset = 2)
	protected int addValue;


	public int getAddValue() {
		return this.addValue;
	}

	public void setAddValue(int addValue) {
		if (addValue < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[扩大1000倍]addValue的值不得小于0");
		}
		this.addValue = addValue;
	}
	

	@Override
	public String toString() {
		return "EquipGradeTemplateVO[addValue=" + addValue + ",]";

	}
}