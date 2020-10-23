package com.imop.lj.gameserver.onlinegift.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;

@ExcelRowBinding
public class OnlineGiftTemplate extends OnlineGiftTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		RewardConfigTemplate reward = this.templateService.get(this.rewardId,
				RewardConfigTemplate.class);
		if (reward == null
				|| reward.getRewardReasonType() != RewardReasonType.ONLINE_GIFT_REWARD) {
			throw new TemplateConfigException(sheetName, this.id, "奖励配置错误");
		}

		if (this.id == 1) {
			return;
		}

		int preId = this.id - 1;
		if (this.templateService.get(preId, OnlineGiftTemplate.class) == null) {
			throw new TemplateConfigException(sheetName, this.id, "前置ID不存在");
		}
	}

}
