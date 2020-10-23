package com.imop.lj.gameserver.goodactivity.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.goodactivity.activity.GoodActivityDef.CostSourceEnum;
import com.imop.lj.gameserver.goodactivity.activity.GoodActivityDef.GoodActivityType;

/**
 * 累计消耗
 */
@ExcelRowBinding
public class GoodActivityTotalCostTargetTemplate extends GoodActivityTotalCostTargetTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		super.check();
		
		// 检查货币类型
		Currency currency = Currency.valueOf(currencyId);
		if (null == currency) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("货币类型[%d]不存在！", currencyId));
		}
		// 检查消耗来源
		CostSourceEnum cs = CostSourceEnum.valueOf(sourceId);
		if (null == cs) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("消耗来源[%d]不存在！", sourceId));
		}
	}

	@Override
	public GoodActivityType getGoodActivityType() {
		return GoodActivityType.TOTAL_COST;
	}
	
	public Currency getCurrency() {
		return Currency.valueOf(currencyId);
	}
	
	public CostSourceEnum getCostSource() {
		return CostSourceEnum.valueOf(sourceId);
	}
}
