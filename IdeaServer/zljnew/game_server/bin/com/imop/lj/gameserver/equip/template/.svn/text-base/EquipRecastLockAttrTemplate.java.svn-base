package com.imop.lj.gameserver.equip.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.item.template.ItemTemplate;

@ExcelRowBinding
public class EquipRecastLockAttrTemplate extends EquipRecastLockAttrTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		ItemTemplate itemTpl = templateService.get(this.itemId, ItemTemplate.class);
		if (itemTpl == null ) {
			throw new TemplateConfigException(this.sheetName, this.id, "道具不存在！ equipmentID="+this.id);
		}
		
		if(Currency.valueOf(this.getCurrencyType()) == null ){
			throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "货币类型不正确");
		}
	}
}
