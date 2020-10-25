package com.imop.lj.gameserver.pet.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.pet.PetDef.SkillType;
import com.imop.lj.gameserver.skill.template.SkillTemplate;

/**
 * 宠物天赋技能升级
 * 
 */
@ExcelRowBinding
public class PetTalentSkillLevelTemplate extends PetTalentSkillLevelTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		//talentSkillId是否存在
		SkillTemplate skillTpl = templateService.get(talentSkillId, SkillTemplate.class);
		if (null == skillTpl) {
			throw new TemplateConfigException(this.sheetName, this.id, "宠物天赋技能Id不存在！" + this.talentSkillId);
		}
		if (skillTpl.getSkillType() != SkillType.PET_TALENT) {
			throw new TemplateConfigException(this.sheetName, this.id, "该技能不是宠物天赋技能！" + this.talentSkillId);
		}
		//技能等级是否在指定范围内
		if (this.skillLevel > Globals.getGameConstants().getPetSkillLevelMax()) {
			throw new TemplateConfigException(this.sheetName, this.id, "技能等级数值超过上限！" + this.skillLevel);
		}
		
	}
	
}
