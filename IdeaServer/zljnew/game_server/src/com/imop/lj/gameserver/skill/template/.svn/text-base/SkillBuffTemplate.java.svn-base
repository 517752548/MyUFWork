package com.imop.lj.gameserver.skill.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.battle.core.BattleDef.BuffCatalog;

/**
 * buff配置
 * 
 */
@ExcelRowBinding
public class SkillBuffTemplate extends SkillBuffTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		BuffCatalog c = BuffCatalog.valueOf(this.buffCatalogId);
		if (c == null) {
			throw new TemplateConfigException(sheetName, id, "公式类型Id不存在！");
		}
	}
	
	public BuffCatalog getBuffCatalog() {
		return BuffCatalog.valueOf(this.buffCatalogId);
	}
	
}
