package com.imop.lj.gameserver.lifeskill.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.currency.Currency;

@ExcelRowBinding
public class LifeSkillMineLevelTemplate extends LifeSkillMineLevelTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		if(Currency.valueOf(this.getCurrencyType()) == null ){
			throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "货币类型不正确");
		}
	}

}
