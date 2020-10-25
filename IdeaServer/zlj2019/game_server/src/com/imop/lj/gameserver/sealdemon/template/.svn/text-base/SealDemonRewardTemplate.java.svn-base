package com.imop.lj.gameserver.sealdemon.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

@ExcelRowBinding
public class SealDemonRewardTemplate extends SealDemonRewardTemplateVO{

	@Override
	public void check() throws TemplateConfigException {
		//下限不能超过上限
		if (this.levelMin > this.levelMax) {
			throw new TemplateConfigException(sheetName, id, "等级下限超过了上限！");
		}
	}

}
