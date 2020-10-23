package com.imop.lj.gameserver.humanskill.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import java.util.List;

/**
 * 人物技能等级
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class HumanSubSkillLevelTemplateVO extends TemplateObject {

	/** $field.comment */
	@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.humanskill.template.HumanSubSkillCost.class, collectionNumber = "1,2,3,4;5,6,7,8;9,10,11,12;13,14,15,16;17,18,19,20;21,22,23,24;25,26,27,28;29,30,31,32;33,34,35,36")
	protected List<com.imop.lj.gameserver.humanskill.template.HumanSubSkillCost> humanSubSkillCostList;


	public List<com.imop.lj.gameserver.humanskill.template.HumanSubSkillCost> getHumanSubSkillCostList() {
		return this.humanSubSkillCostList;
	}

	public void setHumanSubSkillCostList(List<com.imop.lj.gameserver.humanskill.template.HumanSubSkillCost> humanSubSkillCostList) {
		if (humanSubSkillCostList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[$field.comment]humanSubSkillCostList不可以为空");
		}	
		this.humanSubSkillCostList = humanSubSkillCostList;
	}
	

	@Override
	public String toString() {
		return "HumanSubSkillLevelTemplateVO[humanSubSkillCostList=" + humanSubSkillCostList + ",]";

	}
}