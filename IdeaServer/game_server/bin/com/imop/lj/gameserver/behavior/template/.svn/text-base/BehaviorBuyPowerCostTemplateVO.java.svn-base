package com.imop.lj.gameserver.behavior.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 购买体力价格配置表
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class BehaviorBuyPowerCostTemplateVO extends TemplateObject {

	/** 变更词多语言id */
	@ExcelCellBinding(offset = 1)
	protected int buyPowerCost;


	public int getBuyPowerCost() {
		return this.buyPowerCost;
	}

	public void setBuyPowerCost(int buyPowerCost) {
		if (buyPowerCost == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[变更词多语言id]buyPowerCost不可以为0");
		}
		if (buyPowerCost < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[变更词多语言id]buyPowerCost的值不得小于0");
		}
		this.buyPowerCost = buyPowerCost;
	}
	

	@Override
	public String toString() {
		return "BehaviorBuyPowerCostTemplateVO[buyPowerCost=" + buyPowerCost + ",]";

	}
}