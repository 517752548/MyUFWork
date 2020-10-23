package com.imop.lj.gameserver.goodactivity.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.goodactivity.activity.GoodActivityDef.GoodActivityType;

/**
 * 招财进宝
 */
@ExcelRowBinding
public class GoodActivityBuyMoneyTargetTemplate extends GoodActivityBuyMoneyTargetTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		super.check();
//		//奖励类型检查
//		RewardConfigTemplate rewardTpl = templateService.get(rewardId, RewardConfigTemplate.class);
//		if (rewardTpl.getRewardReasonType() != RewardReasonType.GA_BUY_MONEY_REWARD) {
//			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励身份识别类型[%d]", rewardTpl.getRewardReasonTypeId()));
//		}
		
		if (Currency.valueOf(this.costMoneyType) == null) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("花费货币类型不存在[%d]", this.costMoneyType));
		}
		if (Currency.valueOf(this.giveMoneyType) == null) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("产出货币类型不存在[%d]", this.giveMoneyType));
		}
		
		if (this.giveMoneyMax < this.giveMoneyMin) {
			throw new TemplateConfigException(this.sheetName, getId(), "产出货币上限不能小于下限！");
		}
	}

	@Override
	public GoodActivityType getGoodActivityType() {
		return GoodActivityType.BUY_MONEY;
	}
	
	public Currency getCostCurrency() {
		return Currency.valueOf(this.costMoneyType);
	}
	
	public Currency getGiveCurrency() {
		return Currency.valueOf(this.giveMoneyType);
	}
}
