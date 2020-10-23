package com.imop.lj.gameserver.equip.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.item.template.ItemTemplate;

/**
 * 打孔消耗
 * @author yu.zhao
 *
 */
@ExcelRowBinding
public class EquipHoleCostTemplate extends EquipHoleCostTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		if (this.hole <= 0 || this.hole > Globals.getGameConstants().getGemHoleMaxNum()) {
			throw new TemplateConfigException(this.sheetName, this.id, "孔数非法！ " + this.hole);
		}
		
		ItemTemplate itemTpl = templateService.get(this.itemId1, ItemTemplate.class);
		if (itemTpl == null) {
			throw new TemplateConfigException(this.sheetName, this.id, "消耗道具 不存在！ " + this.itemId1);
		}
		
		if (this.itemId2 > 0) {
			ItemTemplate itemTpl2 = templateService.get(this.itemId2, ItemTemplate.class);
			if (itemTpl2 == null) {
				throw new TemplateConfigException(this.sheetName, this.id, "或消耗道具 不存在！ " + this.itemId2);
			}
			if (itemNum2 <= 0) {
				throw new TemplateConfigException(this.sheetName, this.id, "或消耗道具数量非法！ " + this.itemNum2);
			}
		}
		
	}
	
}
