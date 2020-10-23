package com.imop.lj.gameserver.pet.template;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.pet.PetDef.SkillType;
import com.imop.lj.gameserver.role.properties.PropertyType;
import com.imop.lj.gameserver.skill.template.SkillTemplate;


/**
 * 骑宠被动普通技能
 */
@ExcelRowBinding
public class PetHorsePassiveNormalSkillTemplate extends PetHorsePassiveNormalSkillTemplateVO {
	
	private List<PassiveTalentPropItem> validPropList = new ArrayList<PassiveTalentPropItem>();
	
	@Override
	public void check() throws TemplateConfigException {
		//技能模板是否存在
		SkillTemplate skillTpl = templateService.get(id, SkillTemplate.class);
		if (skillTpl == null) {
			throw new TemplateConfigException(this.sheetName, this.id, "技能Id在技能配置表不存在！");
		}
		//必须是普通技能，且为被动
		if (!skillTpl.isPassive() || skillTpl.getSkillType() != SkillType.PET_HORSE_NORMAL) {
			throw new TemplateConfigException(this.sheetName, this.id, "技能Id在技能配置表不是骑宠被动普通技能！");
		}
		
		//验证属性是否合法
		for (PassiveTalentPropItem item : propList) {
			if (item.getPropKey() > 0) {
				boolean flag = PetPropTemplate.isValidPropKey(item.getPropKey(), PropertyType.PET_PROP_A);
				if (!flag) {
					throw new TemplateConfigException(this.sheetName, this.id, "一级属性key不存在！");
				}
				if (item.getPropValue() <= 0 || item.getPropLevelAdd() <= 0) {
					throw new TemplateConfigException(this.sheetName, this.id, "属性值非法！");
				}
				
				validPropList.add(item);
			}
		}
	}

	/**
	 * 获取经过校验的属性加值列表
	 * @return
	 */
	public List<PassiveTalentPropItem> getValidPropList() {
		return validPropList;
	}

}
