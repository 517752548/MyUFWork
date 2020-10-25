package com.imop.lj.gameserver.equip.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.item.ItemDef.Rarity;

/**
 * 装备孔数
 * @author yu.zhao
 *
 */
@ExcelRowBinding
public class EquipHoleTemplate extends EquipHoleTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		if (this.maxHoleNum < 0 || this.maxHoleNum > Globals.getGameConstants().getGemHoleMaxNum()) {
			throw new TemplateConfigException(this.sheetName, this.id, "最大孔数非法！ " + this.maxHoleNum);
		}
		
		if(Rarity.valueOf(this.colorId) == null ){
			throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "装备颜色Id不存在！ " + this.colorId);
		}
	}
	
	public Rarity getColor() {
		return Rarity.valueOf(this.colorId);
	}
}
