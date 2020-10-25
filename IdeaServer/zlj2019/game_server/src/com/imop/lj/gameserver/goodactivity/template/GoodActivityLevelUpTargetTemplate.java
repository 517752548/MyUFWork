package com.imop.lj.gameserver.goodactivity.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.goodactivity.activity.GoodActivityDef.GoodActivityType;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;

/**
 * 等级排名
 */
@ExcelRowBinding
public class GoodActivityLevelUpTargetTemplate extends GoodActivityLevelUpTargetTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		super.check();
		
		//奖励类型检查
		RewardConfigTemplate rewardTpl = templateService.get(rewardId, RewardConfigTemplate.class);
		if (rewardTpl.getRewardReasonType() != RewardReasonType.GA_LEVEL_UP_REWARD) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励身份识别类型[%d]", rewardTpl.getRewardReasonTypeId()));
		}
	}

	@Override
	public GoodActivityType getGoodActivityType() {
		return GoodActivityType.LEVEL_UP;
	}
	
}