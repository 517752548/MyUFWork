package com.imop.lj.gameserver.equip.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.item.ItemDef.Grade;

/**
 * 打造-材料提升概率
 */
@ExcelRowBinding
public class CraftEquipItemProbTemplate extends CraftEquipItemProbTemplateVO {
	@Override
	public void check() throws TemplateConfigException {
		if (Grade.valueOf(this.gradeId) == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "阶数不存在！" + this.gradeId);
		}
		
		int total = 0;
		for (Integer p : propList) {
			total += p;
		}
		if (total != 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "颜色概率和不为0！");
		}
	}
	
	public Grade getGrade() {
		return Grade.valueOf(this.gradeId);
	}

}
