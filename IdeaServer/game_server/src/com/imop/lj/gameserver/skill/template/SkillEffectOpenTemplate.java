package com.imop.lj.gameserver.skill.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.item.template.ItemTemplate;

/**
 * 技能开格子
 * 
 */
@ExcelRowBinding
public class SkillEffectOpenTemplate extends SkillEffectOpenTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		if (templateService.get(this.itemTplId, ItemTemplate.class) == null) {
			throw new TemplateConfigException(sheetName, id, "所需道具Id不存在！" + this.itemTplId);
		}
	}
	
}
