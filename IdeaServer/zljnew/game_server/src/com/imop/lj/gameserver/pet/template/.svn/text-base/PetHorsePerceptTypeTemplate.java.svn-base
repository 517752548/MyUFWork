package com.imop.lj.gameserver.pet.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.item.template.ItemTemplate;
@ExcelRowBinding

public class PetHorsePerceptTypeTemplate extends PetHorsePerceptTypeTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		//装备验证
		ItemTemplate itemTpl = templateService.get(this.getItemId(), ItemTemplate.class);
		if (itemTpl == null) {
			throw new TemplateConfigException(this.sheetName, this.id, "物品不存在！ equipmentID="+this.getItemId());
		}
	}

}
