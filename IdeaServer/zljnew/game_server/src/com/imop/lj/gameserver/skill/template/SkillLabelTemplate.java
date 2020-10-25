package com.imop.lj.gameserver.skill.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.battle.core.BattleDef.LabelCatalog;

/**
 * 技能标识配置
 * 
 */
@ExcelRowBinding
public class SkillLabelTemplate extends SkillLabelTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		LabelCatalog c = LabelCatalog.valueOf(this.id);
		if (c == null) {
			throw new TemplateConfigException(sheetName, id, "类型Id不存在！");
		}
	}
	
	public LabelCatalog getLabelCatalog() {
		return LabelCatalog.valueOf(this.id);
	}
	
}
