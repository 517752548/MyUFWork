package com.imop.lj.gameserver.equip.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.item.ItemDef.Grade;

/**
 * 打造-颜色阶数系数
 */
@ExcelRowBinding
public class CraftEquipGradeColorTemplate extends CraftEquipGradeColorTemplateVO {
	@Override
	public void check() throws TemplateConfigException {
		if (Grade.valueOf(this.id) == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "阶数不存在！" + this.id);
		}
	}
	
}
