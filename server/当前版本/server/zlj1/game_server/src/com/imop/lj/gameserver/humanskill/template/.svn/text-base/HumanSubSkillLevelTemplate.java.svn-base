package com.imop.lj.gameserver.humanskill.template;

import java.util.Map;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.currency.Currency;

@ExcelRowBinding
public class HumanSubSkillLevelTemplate extends HumanSubSkillLevelTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		Map<Integer, HumanSubSkillLevelTemplate> levelMap = templateService.getAll(HumanSubSkillLevelTemplate.class);
		if(this.getId()+1>levelMap.size()){
			throw new TemplateConfigException(this.sheetName, this.id, "人物技能等级没有从0开始或者不连续!");
		}
		if(this.getHumanSubSkillCostList() == null){
			throw new TemplateConfigException(this.sheetName, this.id, "人物技能消耗配置为空");
		}
		for(HumanSubSkillCost h : this.getHumanSubSkillCostList()){
			if(h == null || (Currency.valueOf(h.getCurrencyType1()) == null || Currency.valueOf(h.getCurrencyType2()) == null )){
				throw new TemplateConfigException(this.sheetName, this.id, "货币类型不正确!");
			}
		}
	}
}
