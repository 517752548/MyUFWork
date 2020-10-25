package com.imop.lj.gameserver.pet.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.pet.PetDef.PetTrainType;

/**
 * 宠物培养消耗
 * 
 */
@ExcelRowBinding
public class PetTrainCostTemplate extends PetTrainCostTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		if (PetTrainType.valueOf(this.id) == null) {
			throw new TemplateConfigException(this.sheetName, this.id, "培养方式不存在！" + this.id);
		}
		if (Currency.valueOf(this.currencyTypeId) == null) {
			throw new TemplateConfigException(this.sheetName, this.id, "货币类型不存在！" + this.currencyTypeId);
		}
		
	}
	
	public Currency getCostCurrency() {
		return Currency.valueOf(this.currencyTypeId);
	}
	
}
