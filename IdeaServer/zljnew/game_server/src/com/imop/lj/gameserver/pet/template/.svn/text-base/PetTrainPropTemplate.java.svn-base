package com.imop.lj.gameserver.pet.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.pet.PetDef.PetTrainType;

/**
 * 宠物培养数值
 * 
 */
@ExcelRowBinding
public class PetTrainPropTemplate extends PetTrainPropTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		if (PetTrainType.valueOf(this.trainTypeId) == null) {
			throw new TemplateConfigException(this.sheetName, this.id, "培养方式不存在！" + this.id);
		}
		if (this.propMin > this.propMax) {
			throw new TemplateConfigException(this.sheetName, this.id, "下限值不能超过上限值！");
		}
	}
	
	public PetTrainType getTrainType() {
		return PetTrainType.valueOf(this.trainTypeId);
	}
	
	public boolean isMinus() {
		return this.minusFlag >= 1;
	}
		
}
