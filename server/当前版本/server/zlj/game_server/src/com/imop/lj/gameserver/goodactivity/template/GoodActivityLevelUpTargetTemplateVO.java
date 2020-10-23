package com.imop.lj.gameserver.goodactivity.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;

/**
 * 等级排名
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class GoodActivityLevelUpTargetTemplateVO extends GoodActivityTargetTemplate {

	/** 等级要求 */
	@ExcelCellBinding(offset = 12)
	protected int needLevel;


	public int getNeedLevel() {
		return this.needLevel;
	}

	public void setNeedLevel(int needLevel) {
		if (needLevel < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					13, "[等级要求]needLevel的值不得小于1");
		}
		this.needLevel = needLevel;
	}
	

	@Override
	public String toString() {
		return "GoodActivityLevelUpTargetTemplateVO[needLevel=" + needLevel + ",]";

	}
}