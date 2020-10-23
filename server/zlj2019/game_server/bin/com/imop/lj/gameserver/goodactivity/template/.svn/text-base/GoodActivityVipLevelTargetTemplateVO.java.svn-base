package com.imop.lj.gameserver.goodactivity.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;

/**
 * VIP等级
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class GoodActivityVipLevelTargetTemplateVO extends GoodActivityTargetTemplate {

	/** VIP等级要求 */
	@ExcelCellBinding(offset = 12)
	protected int needVipLevel;


	public int getNeedVipLevel() {
		return this.needVipLevel;
	}

	public void setNeedVipLevel(int needVipLevel) {
		if (needVipLevel < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					13, "[VIP等级要求]needVipLevel的值不得小于1");
		}
		this.needVipLevel = needVipLevel;
	}
	

	@Override
	public String toString() {
		return "GoodActivityVipLevelTargetTemplateVO[needVipLevel=" + needVipLevel + ",]";

	}
}