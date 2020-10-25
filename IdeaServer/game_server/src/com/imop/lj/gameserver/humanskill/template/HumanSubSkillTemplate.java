package com.imop.lj.gameserver.humanskill.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.pet.PetDef.SkillType;
import com.imop.lj.gameserver.skill.template.SkillTemplate;

@ExcelRowBinding
public class HumanSubSkillTemplate extends HumanSubSkillTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		if(templateService.get(this.getId(), SkillTemplate.class) == null){
			throw new TemplateConfigException(this.sheetName, this.id, "无法找到对应的技能!");
		}
		SkillTemplate st = templateService.get(this.getId(), SkillTemplate.class);
		if(st.getSkillType() != SkillType.MIND_A && st.getSkillType() != SkillType.MIND_B){
			throw new TemplateConfigException(this.sheetName, this.id, "该技能不是人物技能!");
		}
	}

}
