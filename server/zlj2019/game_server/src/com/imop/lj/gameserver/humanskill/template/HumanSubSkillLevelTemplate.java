package com.imop.lj.gameserver.humanskill.template;

import java.util.Map;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

@ExcelRowBinding
public class HumanSubSkillLevelTemplate extends HumanSubSkillLevelTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		Map<Integer, HumanSubSkillLevelTemplate> levelMap = templateService.getAll(HumanSubSkillLevelTemplate.class);
		if(this.getHumanSubSkillCostList() == null){
			throw new TemplateConfigException(this.sheetName, this.id, "人物技能消耗配置为空");
		}
		for(HumanSubSkillCost h : this.getHumanSubSkillCostList()){
			if(h == null || h.getNeedProficiency() <=0 ){
				throw new TemplateConfigException(this.sheetName, this.id, "所需熟练度不正确!");
			}
		}
	}
}
