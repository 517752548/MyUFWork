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
public abstract class PetLevelTemplateVO extends TemplateObject {

	/** 武将经验值 */
	@ExcelCellBinding(offset = 1)
	protected long mainExp;

	/** 宠物经验值 */
	@ExcelCellBinding(offset = 2)
	protected long petExp;


	public long getMainExp() {
		return this.mainExp;
	}

	public void setMainExp(long mainExp) {
		if (mainExp < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[武将经验值]mainExp的值不得小于0");
		}
		this.mainExp = mainExp;
	}
	
	public long getPetExp() {
		return this.petExp;
	}

	public void setPetExp(long petExp) {
		if (petExp < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[宠物经验值]petExp的值不得小于0");
		}
		this.petExp = petExp;
	}
	

	@Override
	public String toString() {
		return "PetLevelTemplateVO[mainExp=" + mainExp + ",petExp=" + petExp + ",]";

	}
}