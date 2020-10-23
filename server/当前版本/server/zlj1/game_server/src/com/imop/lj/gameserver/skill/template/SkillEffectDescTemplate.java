package com.imop.lj.gameserver.skill.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

/**
 * 效果描述
 * 
 */
@ExcelRowBinding
public class SkillEffectDescTemplate extends SkillEffectDescTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		//技能效果是否存在
		if (templateService.get(this.id, SkillEffectTemplate.class) == null) {
			throw new TemplateConfigException(sheetName, id, "效果不存在！" + this.id);
		}
	}
	
}
