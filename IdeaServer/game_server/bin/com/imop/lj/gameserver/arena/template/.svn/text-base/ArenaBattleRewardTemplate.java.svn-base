package com.imop.lj.gameserver.arena.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;

/**
 * 竞技场战斗奖励
 * 
 */
@ExcelRowBinding
public class ArenaBattleRewardTemplate extends ArenaBattleRewardTemplateVO {
	@Override
	public void check() throws TemplateConfigException {
		// 奖励Id是否存在
		if (winRewardId > 0) {
			RewardConfigTemplate rewardTpl = templateService.get(winRewardId, RewardConfigTemplate.class);
			if(null == rewardTpl) {
				throw new TemplateConfigException(this.sheetName, getId(), String.format("胜利奖励Id不存在%d！", winRewardId));
			}
			// 奖励类型检查
			if (rewardTpl.getRewardReasonType() != RewardReasonType.ARENA_ATTACK) {
				throw new TemplateConfigException(this.sheetName, getId(), String.format("胜利奖励身份识别类型[%d]", rewardTpl.getRewardReasonTypeId()));
			}
		}
		// 奖励Id是否存在
		if (lossRewardId > 0) {
			RewardConfigTemplate rewardTpl = templateService.get(lossRewardId, RewardConfigTemplate.class);
			if(null == rewardTpl) {
				throw new TemplateConfigException(this.sheetName, getId(), String.format("失败奖励Id不存在%d！", lossRewardId));
			}
			// 奖励类型检查
			if (rewardTpl.getRewardReasonType() != RewardReasonType.ARENA_ATTACK) {
				throw new TemplateConfigException(this.sheetName, getId(), String.format("失败奖励身份识别类型[%d]", rewardTpl.getRewardReasonTypeId()));
			}
		}
		
	}
}