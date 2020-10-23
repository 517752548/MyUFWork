package com.imop.lj.gameserver.equip.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.item.ItemDef.Grade;

/**
 * 打造-颜色概率
 */
@ExcelRowBinding
public class CraftEquipColorTemplate extends CraftEquipColorTemplateVO {
	//概率总基数
	private int totalBase;
	
	@Override
	public void check() throws TemplateConfigException {
		if (Grade.valueOf(this.gradeId) == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "阶数不存在！" + this.gradeId);
		}
		
		for (Integer prop : propList) {
			totalBase += prop;
		}
	}
	
	public Grade getGrade() {
		return Grade.valueOf(this.gradeId);
	}

	public int getTotalBase() {
		return totalBase;
	}

}
