package com.imop.lj.gameserver.charge.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.currency.Currency;

/**
 * 月卡模板
 */
@ExcelRowBinding
public class MonthCardTemplate extends MonthCardTemplateVO {

	@Override
	public void check() throws TemplateConfigException {

		//货币类型是否正确
		if(Currency.valueOf(this.monthCurrId) == null){
			throw new TemplateConfigException(this.sheetName, getId(), "月卡货币类型非法! monthCurrId = " + this.monthCurrId);
		}
		if(Currency.valueOf(this.rebateCurrId) == null){
			throw new TemplateConfigException(this.sheetName, getId(), "立返货币类型非法! monthCurrId = " + this.rebateCurrId);
		}
		if(Currency.valueOf(this.dayRebateCurrId) == null){
			throw new TemplateConfigException(this.sheetName, getId(), "每日返利货币类型非法! monthCurrId = " + this.dayRebateCurrId);
		}
	}

}
