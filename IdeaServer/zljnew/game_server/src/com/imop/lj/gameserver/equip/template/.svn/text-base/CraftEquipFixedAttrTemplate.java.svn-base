package com.imop.lj.gameserver.equip.template;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.item.ItemDef.Grade;
import com.imop.lj.gameserver.item.template.EquipItemAttribute;
import com.imop.lj.gameserver.pet.template.PetPropTemplate;
import com.imop.lj.gameserver.role.properties.PropertyType;

/**
 * 打造-固定属性
 */
@ExcelRowBinding
public class CraftEquipFixedAttrTemplate extends CraftEquipFixedAttrTemplateVO {
	
	private List<EquipItemAttribute> validFixedAttrList = new ArrayList<EquipItemAttribute>();
	
	@Override
	public void check() throws TemplateConfigException {
		if (Grade.valueOf(this.gradeId) == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "阶数Id不存在！" + this.gradeId);
		}
		
		for (EquipItemAttribute prop : fixeAttrList) {
			if (prop.getPropKey() > 0 && prop.getPropValue() > 0) {
				boolean isAPropBase = PetPropTemplate.isValidPropKey(prop.getPropKey(), PropertyType.PET_PROP_A);
				boolean isBPropBase = PetPropTemplate.isValidPropKey(prop.getPropKey(), PropertyType.PET_PROP_B);
				if (!isAPropBase && !isBPropBase) {
					throw new TemplateConfigException(this.sheetName, this.id, "固定属性key不存在！key=" + prop.getPropKey());
				}
				validFixedAttrList.add(prop);
			}
		}
		if (validFixedAttrList.isEmpty()) {
			throw new TemplateConfigException(this.sheetName, this.id, "固定属性不能全都是空的！");
		}
	}
	
	public Grade getGrade() {
		return Grade.valueOf(this.gradeId);
	}

	public List<EquipItemAttribute> getValidFixedAttrList() {
		return validFixedAttrList;
	}

}
