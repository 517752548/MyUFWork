package com.imop.lj.gameserver.equip.template;

import com.imop.lj.common.constants.RoleConstants;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.currency.Currency;
@ExcelRowBinding
public class GemCostTemplate extends GemCostTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		// TODO 自动生成的方法存根
		Integer size = templateService.getAll(GemCostTemplate.class).size();
		if(this.getId() > size || size > RoleConstants.PET_GEM_BAG_SUB_CAPACITY){
			throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "总个数不正确");
		}
		if(Currency.valueOf(this.getCurrencyType1()) == null || Currency.valueOf(this.getCurrencyType2()) == null || Currency.valueOf(this.getSynthesisCostCurrencyType()) == null){
			throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "货币类型不正确");
		}
	}

}
