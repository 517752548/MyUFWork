package com.imop.lj.gameserver.arena.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.skill.template.SkillTemplate;

/**
 * 竞技场宠物技能权重
 * 
 */
@ExcelRowBinding
public class ArenaPetSkillWeightTemplate extends ArenaPetSkillWeightTemplateVO implements IArenaSkillWeightTpl {
	
	@Override
	public void check() throws TemplateConfigException {
		//技能是否存在
		if (null == templateService.get(id, SkillTemplate.class)) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("技能不存在%d！", id));
		}
	}
	
	@Override
	public int getSkillId() {
		return this.id;
	}
	
	@Override
	public boolean isFirst() {
		return isFirst == 1;
	}
}