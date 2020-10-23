package com.imop.lj.gameserver.arena.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 竞技场购买消耗
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class ArenaBuyTimesTemplateVO extends TemplateObject {

	/** 花费货币类型 */
	@ExcelCellBinding(offset = 1)
	protected int currencyId;

	/** 货币数量 */
	@ExcelCellBinding(offset = 2)
	protected int cost;


	public int getCurrencyId() {
		return this.currencyId;
	}

	public void setCurrencyId(int currencyId) {
		if (currencyId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[花费货币类型]currencyId的值不得小于1");
		}
		this.currencyId = currencyId;
	}
	
	public int getCost() {
		return this.cost;
	}

	public void setCost(int cost) {
		if (cost < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[货币数量]cost的值不得小于1");
		}
		this.cost = cost;
	}
	

	@Override
	public String toString() {
		return "ArenaBuyTimesTemplateVO[currencyId=" + currencyId + ",cost=" + cost + ",]";

	}
}