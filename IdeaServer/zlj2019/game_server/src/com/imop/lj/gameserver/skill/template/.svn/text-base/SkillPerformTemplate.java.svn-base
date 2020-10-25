package com.imop.lj.gameserver.skill.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

/**
 * 技能表现
 * 
 */
@ExcelRowBinding
public class SkillPerformTemplate extends SkillPerformTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		if(this.effectId > 0){
			SkillEffectTemplate tpl = templateService.get(this.effectId, SkillEffectTemplate.class);
			// 效果Id是否存在
			if (tpl == null) {
				throw new TemplateConfigException(this.sheetName, this.id, "效果Id不存在！" + effectId);
			}
		}
	}
	
}
