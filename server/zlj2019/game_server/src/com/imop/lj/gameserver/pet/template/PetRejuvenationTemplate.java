package com.imop.lj.gameserver.pet.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.pet.PetDef.PetPetType;


@ExcelRowBinding
public class PetRejuvenationTemplate extends PetRejuvenationTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		
		if (PetPetType.valueOf(petpetTypeId) == null) {
			throw new TemplateConfigException(sheetName, id, "宠物类型不存在! " + petpetTypeId);
		}
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
