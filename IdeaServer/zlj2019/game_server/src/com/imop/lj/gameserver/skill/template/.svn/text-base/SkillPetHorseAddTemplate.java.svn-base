package com.imop.lj.gameserver.skill.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.skill.SkillDef.ScenariosType;
import com.imop.lj.gameserver.skill.SkillPetHorseAddTemplateVO;

@ExcelRowBinding
public class SkillPetHorseAddTemplate extends SkillPetHorseAddTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		//技能id是否存在
		if (null == templateService.get(id, SkillTemplate.class)) {
			throw new TemplateConfigException(this.sheetName, this.id, "技能Id非法！" + id);
		}
		if (null == templateService.get(effectSkillId, SkillTemplate.class)) {
			throw new TemplateConfigException(this.sheetName, this.id, "影响技能Id非法！" + effectSkillId);
		}
		//技能应用场景是否非法
		if(ScenariosType.valueOf(this.scenarios) == null){
			throw new TemplateConfigException(this.sheetName, this.id, "应用场景非法！" + scenarios);
		}
	}

}
