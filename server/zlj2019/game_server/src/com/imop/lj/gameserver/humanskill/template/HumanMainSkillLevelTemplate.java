package com.imop.lj.gameserver.humanskill.template;

import java.util.Map;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.currency.Currency;

@ExcelRowBinding
public class HumanMainSkillLevelTemplate extends HumanMainSkillLevelTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		// TODO 自动生成的方法存根
		Map<Integer, HumanMainSkillLevelTemplate> levelMap = templateService.getAll(HumanMainSkillLevelTemplate.class);
		if(this.getId()>levelMap.size()){
			throw new TemplateConfigException(this.sheetName, this.id, "心法	等级没有从1开始或者不连续!");
		}
		if(Currency.valueOf(this.getCurrencyType1()) == null || Currency.valueOf(this.getCurrencyType2()) == null ){
			throw new TemplateConfigException(this.sheetName, this.id, "货币类型不正确!");
		}
	}

}
