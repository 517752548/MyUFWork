package com.imop.lj.gameserver.pet.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.pet.prop.PetAProperty;
import com.imop.lj.gameserver.pet.prop.PetBProperty;
import com.imop.lj.gameserver.role.properties.PropertyType;

/**
 * 一二级属性关系
 * 
 */
@ExcelRowBinding
public class PetPropTemplate extends PetPropTemplateVO {
	
	private int propIndex = -1;
	
	@Override
	public void check() throws TemplateConfigException {
		//检查二级属性key是否存在
		if (!isValidPropKey(id, PropertyType.PET_PROP_B)) {
			throw new TemplateConfigException(this.sheetName, this.id, "二级属性key不存在！");
		}
		
		propIndex = id - PropertyType.genPropertyKey(0, PropertyType.PET_PROP_B);
	}
	
	public static boolean isValidPropKey(int key, int propType) {
		boolean flag = false;
		int base = PropertyType.genPropertyKey(0, propType);
		int index = key - base;
		if (propType == PropertyType.PET_PROP_A) {
			flag = PetAProperty.isValidIndex(index);
		} 
		if (propType == PropertyType.PET_PROP_B) {
			flag = PetBProperty.isValidIndex(index);
		}
		return flag;
	}
	
	public int getPropIndex() {
		return propIndex;
	}
	
}
