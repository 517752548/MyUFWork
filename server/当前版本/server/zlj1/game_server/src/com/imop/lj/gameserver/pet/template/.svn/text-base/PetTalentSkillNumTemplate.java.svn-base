package com.imop.lj.gameserver.pet.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.common.Globals;


/**
 * 宠物天赋技能包
 * 
 */
@ExcelRowBinding
public class PetTalentSkillNumTemplate extends PetTalentSkillNumTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		//数量必须在指定范围内
		if (getId() > Globals.getGameConstants().getPetTalentSkillNumMax()) {
			throw new TemplateConfigException(this.sheetName, this.id, "数量超过上限！");
		}
		
	}
	
}
