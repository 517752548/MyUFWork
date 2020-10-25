package com.imop.lj.gameserver.pet.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.item.template.ItemTemplate;


@ExcelRowBinding
public class PetVariationTemplate extends PetVariationTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		// TODO 自动生成的方法存根
		//装备验证
		ItemTemplate itemTpl = templateService.get(this.getItemId(), ItemTemplate.class);
		if (itemTpl == null) {
			throw new TemplateConfigException(this.sheetName, this.id, "物品不存在！ equipmentID="+this.getItemId());
		}
		
		//货币是否存在
		if (this.currencyNum > 0) {
			if (null == Currency.valueOf(this.currencyType)) {
				throw new TemplateConfigException(this.sheetName, this.id, "货币类型不合法!" + this.currencyType);
			}
		}
	}

}
