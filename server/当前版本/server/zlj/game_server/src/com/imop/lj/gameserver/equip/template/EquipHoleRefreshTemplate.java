package com.imop.lj.gameserver.equip.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.item.template.ItemTemplate;

/**
 * 洗孔消耗
 * @author yu.zhao
 *
 */
@ExcelRowBinding
public class EquipHoleRefreshTemplate extends EquipHoleRefreshTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		ItemTemplate itemTpl = templateService.get(this.itemId, ItemTemplate.class);
		if (itemTpl == null) {
			throw new TemplateConfigException(this.sheetName, this.id, "消耗道具 不存在！ " + this.itemId);
		}
	}
	
	
}
