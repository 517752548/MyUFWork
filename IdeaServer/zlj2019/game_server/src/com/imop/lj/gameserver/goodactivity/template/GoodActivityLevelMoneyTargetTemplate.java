package com.imop.lj.gameserver.goodactivity.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.goodactivity.activity.GoodActivityDef.GoodActivityType;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;
import com.imop.lj.gameserver.vip.VipDef.VipFuncTypeEnum;

/**
 * 开服基金
 */
@ExcelRowBinding
public class GoodActivityLevelMoneyTargetTemplate extends GoodActivityLevelMoneyTargetTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		super.check();
		//奖励类型检查
		RewardConfigTemplate rewardTpl = templateService.get(rewardId, RewardConfigTemplate.class);
		if (rewardTpl.getRewardReasonType() != RewardReasonType.GA_LEVEL_MONEY_REWARD) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励身份识别类型[%d]", rewardTpl.getRewardReasonTypeId()));
		}
		
		if (vipLimitId > 0) {
			if (VipFuncTypeEnum.valueOf(vipLimitId) == null) {
				throw new TemplateConfigException(this.sheetName, getId(), String.format("vip限制类型错误[%d]", vipLimitId));
			}
		}
	}

	@Override
	public GoodActivityType getGoodActivityType() {
		return GoodActivityType.LEVEL_MONEY;
	}
	
	public VipFuncTypeEnum getVipLimit() {
		return vipLimitId > 0 ? VipFuncTypeEnum.valueOf(vipLimitId) : null;
	}
}
