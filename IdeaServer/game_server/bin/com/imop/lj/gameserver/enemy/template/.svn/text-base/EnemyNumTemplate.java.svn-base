package com.imop.lj.gameserver.enemy.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;


@ExcelRowBinding
public class EnemyNumTemplate extends EnemyNumTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		// TODO 自动生成的方法存根
		if(this.getMinNum() > this.getMaxNum()){
			throw new TemplateConfigException(this.sheetName, getId(), "最小遇怪数量不可以大于最大遇怪数量！");
		}
	}

}
