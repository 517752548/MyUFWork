package com.imop.lj.gameserver.humanskill.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.pet.template.PetPropTemplate;
import com.imop.lj.gameserver.role.properties.PropertyType;
import com.imop.lj.gameserver.skill.template.SkillTemplate;


@ExcelRowBinding
public class HumanSubPassiveSkillTemplate extends
		HumanSubPassiveSkillTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		if(null == templateService.get(this.id, SkillTemplate.class)){
			throw new TemplateConfigException(this.sheetName, this.id, "无法找到对应的技能!");
		}
		
		if(!PetPropTemplate.isValidPropKey(this.getPropType(), PropertyType.PET_PROP_A) && 
				!PetPropTemplate.isValidPropKey(this.getPropType(), PropertyType.PET_PROP_B)){
			throw new TemplateConfigException(this.sheetName, this.id, "属性对应key值不是合法的1级或2级属性!");
		}
	}

}
