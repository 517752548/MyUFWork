package com.imop.lj.gameserver.wing.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.currency.Currency;

@ExcelRowBinding
public class WingUpgradeTemplate extends WingUpgradeTemplateVO{

	@Override
	public void check() throws TemplateConfigException {
		
		WingTemplate wingTpl = templateService.get(wingTplId, WingTemplate.class);
		if (null == wingTpl) {
			throw new TemplateConfigException(this.sheetName, this.id, "翅膀Id不存在！" + this.wingTplId);
		}
		
		
		if(Currency.valueOf(this.getCurrencyType()) == null){
			throw new TemplateConfigException(this.sheetName, this.id, "货币类型错误！id=" + this.id);
		}
		
		
	}

}
