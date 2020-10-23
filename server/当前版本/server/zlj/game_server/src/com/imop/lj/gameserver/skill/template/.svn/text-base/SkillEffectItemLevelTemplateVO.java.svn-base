package com.imop.lj.gameserver.skill.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 仙符升级配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class SkillEffectItemLevelTemplateVO extends TemplateObject {

	/** 经验值 */
	@ExcelCellBinding(offset = 1)
	protected int exp;


	public int getExp() {
		return this.exp;
	}

	public void setExp(int exp) {
		if (exp < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[经验值]exp的值不得小于0");
		}
		this.exp = exp;
	}
	

	@Override
	public String toString() {
		return "SkillEffectItemLevelTemplateVO[exp=" + exp + ",]";

	}
}