package com.imop.lj.gameserver.treasuremap.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;


/**
 * 藏宝图任务模板
 */
@ExcelRowBinding
public class TreasureMapTemplate extends TreasureMapTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		//下限不能超过上限
		if (this.levelMin > this.levelMax) {
			throw new TemplateConfigException(sheetName, id, "等级下限超过了上限！");
		}
	}

	
}
