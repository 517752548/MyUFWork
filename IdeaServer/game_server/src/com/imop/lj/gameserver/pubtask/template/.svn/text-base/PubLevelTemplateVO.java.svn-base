package com.imop.lj.gameserver.pubtask.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 酒馆等级模板
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class PubLevelTemplateVO extends TemplateObject {

	/** 经验值 */
	@ExcelCellBinding(offset = 1)
	protected long exp;


	public long getExp() {
		return this.exp;
	}

	public void setExp(long exp) {
		if (exp < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[经验值]exp的值不得小于0");
		}
		this.exp = exp;
	}
	

	@Override
	public String toString() {
		return "PubLevelTemplateVO[exp=" + exp + ",]";

	}
}