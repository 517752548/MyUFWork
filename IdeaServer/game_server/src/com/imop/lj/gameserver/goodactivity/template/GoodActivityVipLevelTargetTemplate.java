package com.imop.lj.gameserver.goodactivity.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.goodactivity.activity.GoodActivityDef.GoodActivityType;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;
import com.imop.lj.gameserver.vip.VipDef;
import com.imop.lj.gameserver.vip.VipDef.VipLevel;

/**
 * VIP等级
 */
@ExcelRowBinding
public class GoodActivityVipLevelTargetTemplate extends GoodActivityVipLevelTargetTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		super.check();
		// vip等级是否合法
		if (VipDef.VipLevel.valueOf(needVipLevel) == null || 
				VipDef.VipLevel.valueOf(needVipLevel) == VipLevel.VIP0) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("vip等级[%d]不合法！", needVipLevel));
		}
		
		//奖励类型检查
		RewardConfigTemplate rewardTpl = templateService.get(rewardId, RewardConfigTemplate.class);
		if (rewardTpl.getRewardReasonType() != RewardReasonType.VIP_LEVEL_REWARD) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励身份识别类型[%d]", rewardTpl.getRewardReasonTypeId()));
		}
	}

	@Override
	public GoodActivityType getGoodActivityType() {
		return GoodActivityType.VIP_LEVEL;
	}
	
}
