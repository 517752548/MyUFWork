package com.imop.lj.gameserver.arena.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;
import com.imop.lj.gameserver.reward.template.ShowRewardTemplate;

/**
 * 竞技场排名奖励区间配置模板
 * 
 */
@ExcelRowBinding
public class ArenaRankRewardTemplate extends ArenaRankRewardTemplateVO {
	@Override
	public void check() throws TemplateConfigException {
		//显示奖励id是否存在
		if (null == templateService.get(showRewardId, ShowRewardTemplate.class)) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("显示奖励Id不存在%d！", showRewardId));
		}
		// 奖励Id是否存在
		if(null == templateService.get(rewardId, RewardConfigTemplate.class)) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励Id不存在%d！", rewardId));
		}
		RewardConfigTemplate rewardTpl = templateService.get(rewardId, RewardConfigTemplate.class);
		// 奖励类型检查
		if (rewardTpl.getRewardReasonType() != RewardReasonType.ARENA_RANK) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励身份识别类型[%d]", rewardTpl.getRewardReasonTypeId()));
		}
	}
}