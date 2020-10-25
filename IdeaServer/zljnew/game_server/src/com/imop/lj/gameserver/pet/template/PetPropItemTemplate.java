package com.imop.lj.gameserver.pet.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.item.template.ItemTemplate;

@ExcelRowBinding
public class PetPropItemTemplate extends PetPropItemTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		//道具是否存在,跳过无的道具
		if(this.itemId > 0){
			ItemTemplate tpl = templateService.get(this.itemId, ItemTemplate.class);
			if(tpl == null){
				throw new TemplateConfigException(this.sheetName, this.id, "道具Id不存在！");
			}
		}
	}

}
