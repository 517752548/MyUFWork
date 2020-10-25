package com.imop.lj.gameserver.pet.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 升级经验
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class PetHorseLevelTemplateVO extends TemplateObject {

	/** 骑宠经验值 */
	@ExcelCellBinding(offset = 1)
	protected long petHorseExp;


	public long getPetHorseExp() {
		return this.petHorseExp;
	}

	public void setPetHorseExp(long petHorseExp) {
		if (petHorseExp < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[骑宠经验值]petHorseExp的值不得小于0");
		}
		this.petHorseExp = petHorseExp;
	}
	

	@Override
	public String toString() {
		return "PetHorseLevelTemplateVO[petHorseExp=" + petHorseExp + ",]";

	}
}