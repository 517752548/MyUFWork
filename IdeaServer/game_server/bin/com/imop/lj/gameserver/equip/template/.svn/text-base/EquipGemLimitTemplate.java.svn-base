package com.imop.lj.gameserver.equip.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.item.ItemDef.Position;
import com.imop.lj.gameserver.item.template.ItemTemplate;

/**
 * 镶嵌宝石限制
 * @author yu.zhao
 *
 */
@ExcelRowBinding
public class EquipGemLimitTemplate extends EquipGemLimitTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		ItemTemplate itemTpl = templateService.get(this.gemItemId, ItemTemplate.class);
		if (itemTpl == null || !itemTpl.isGem()) {
			throw new TemplateConfigException(this.sheetName, this.id, "宝石Id不存在或不是宝石！ " + this.gemItemId);
		}
		
		if(Position.valueOf(this.posId) == null ){
			throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "装备部位Id不存在！ " + this.posId);
		}
	}
	
	public Position getPosition() {
		return Position.valueOf(this.posId);
	}
}
