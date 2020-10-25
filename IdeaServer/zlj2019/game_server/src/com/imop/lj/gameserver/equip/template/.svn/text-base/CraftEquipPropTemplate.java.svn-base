package com.imop.lj.gameserver.equip.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.pet.template.PetPropTemplate;
import com.imop.lj.gameserver.role.properties.PropertyType;

/**
 * 打造-属性权重
 */
@ExcelRowBinding
public class CraftEquipPropTemplate extends CraftEquipPropTemplateVO {
	@Override
	public void check() throws TemplateConfigException {
		boolean isAPropBase = PetPropTemplate.isValidPropKey(this.id, PropertyType.PET_PROP_A);
		boolean isBPropBase = PetPropTemplate.isValidPropKey(this.id, PropertyType.PET_PROP_B);
		if (!isAPropBase && !isBPropBase) {
			throw new TemplateConfigException(this.sheetName, this.id, "属性key不存在！key=" + this.id);
		}
	}
	
}
