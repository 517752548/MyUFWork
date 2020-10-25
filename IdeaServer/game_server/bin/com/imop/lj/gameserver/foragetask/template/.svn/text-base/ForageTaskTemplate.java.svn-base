package com.imop.lj.gameserver.foragetask.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;


/**
 * 护送粮草等级模板
 */
@ExcelRowBinding
public class ForageTaskTemplate extends ForageTaskTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		//下限不能超过上限
		if (this.levelMin > this.levelMax) {
			throw new TemplateConfigException(sheetName, id, "等级下限超过了上限！");
		}
	}

	
}
