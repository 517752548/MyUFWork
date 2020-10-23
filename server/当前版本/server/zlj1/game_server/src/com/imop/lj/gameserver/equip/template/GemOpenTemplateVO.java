package com.imop.lj.gameserver.equip.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 宝石开孔
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class GemOpenTemplateVO extends TemplateObject {

	/** 宝石孔开启等级 */
	@ExcelCellBinding(offset = 1)
	protected int openLevel;


	public int getOpenLevel() {
		return this.openLevel;
	}

	public void setOpenLevel(int openLevel) {
		if (openLevel == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[宝石孔开启等级]openLevel不可以为0");
		}
		if (openLevel < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[宝石孔开启等级]openLevel的值不得小于1");
		}
		this.openLevel = openLevel;
	}
	

	@Override
	public String toString() {
		return "GemOpenTemplateVO[openLevel=" + openLevel + ",]";

	}
}