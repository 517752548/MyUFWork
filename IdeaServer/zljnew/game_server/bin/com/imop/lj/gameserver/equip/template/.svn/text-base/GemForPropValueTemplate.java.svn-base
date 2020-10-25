package com.imop.lj.gameserver.equip.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.pet.template.PetPropTemplate;
import com.imop.lj.gameserver.role.properties.PropertyType;

@ExcelRowBinding
public class GemForPropValueTemplate extends GemForPropValueTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		// TODO 自动生成的方法存根
		if(!PetPropTemplate.isValidPropKey(this.getId(), PropertyType.PET_PROP_A) && !PetPropTemplate.isValidPropKey(this.getId(), PropertyType.PET_PROP_B)){
			throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "属性key值不是合法的1级或2级属性");
		}
	}

}
