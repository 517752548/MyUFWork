package com.imop.lj.gameserver.arena.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.currency.Currency;

/**
 * 竞技场购买消耗
 * 
 */
@ExcelRowBinding
public class ArenaBuyTimesTemplate extends ArenaBuyTimesTemplateVO {
	@Override
	public void check() throws TemplateConfigException {
		//货币类型是否存在
		if(null == Currency.valueOf(this.currencyId)) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("currencyId不存在%d！", currencyId));
		}
		
	}
}