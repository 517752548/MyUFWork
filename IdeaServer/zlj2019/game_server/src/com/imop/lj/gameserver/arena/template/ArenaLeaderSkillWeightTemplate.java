package com.imop.lj.gameserver.arena.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.pet.PetDef.JobType;
import com.imop.lj.gameserver.skill.template.SkillTemplate;

/**
 * 竞技场人物技能权重
 * 
 */
@ExcelRowBinding
public class ArenaLeaderSkillWeightTemplate extends ArenaLeaderSkillWeightTemplateVO implements IArenaSkillWeightTpl {
	
	@Override
	public void check() throws TemplateConfigException {
		//职业是否存在
		if(null == JobType.valueOf(this.jobTypeId)) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("职业不存在%d！", jobTypeId));
		}
		//技能是否存在
		if (null == templateService.get(skillId, SkillTemplate.class)) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("技能不存在%d！", skillId));
		}
	}
	
	@Override
	public boolean isFirst() {
		return isFirst == 1;
	}
}