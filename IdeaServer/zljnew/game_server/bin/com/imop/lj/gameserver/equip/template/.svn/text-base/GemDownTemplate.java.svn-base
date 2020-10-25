package com.imop.lj.gameserver.equip.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.item.template.ItemTemplate;

/**
 * 
 * 宝石摘除消耗
 *
 */
@ExcelRowBinding
public class GemDownTemplate extends GemDownTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		ItemTemplate itemTpl = templateService.get(this.itemId1, ItemTemplate.class);
		if (itemTpl == null ) {
			throw new TemplateConfigException(this.sheetName, this.id, "低级消耗道具Id不存在！  " + this.itemId1);
		}
		
		ItemTemplate itemTpl2 = templateService.get(this.itemId2, ItemTemplate.class);
		if (itemTpl2 == null ) {
			throw new TemplateConfigException(this.sheetName, this.id, "高级消耗道具Id不存在！  " + this.itemId2);
		}
		
	}

}
