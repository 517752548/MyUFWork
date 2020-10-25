package com.imop.lj.gameserver.ringtask.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;


/**
 * 跑环任务奖励模板
 */
@ExcelRowBinding
public class RingTaskRewardTemplate extends RingTaskRewardTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		//下限不能超过上限
		if (this.levelMin > this.levelMax) {
			throw new TemplateConfigException(sheetName, id, "等级下限超过了上限！");
		}
		
		//reward验证
		RewardConfigTemplate normalReward = templateService.get(this.normalRewardId, RewardConfigTemplate.class);
		if (normalReward == null) {
			throw new TemplateConfigException(this.sheetName, this.id, "普通奖励不存在！ rewardID="+this.normalRewardId);
		}
		RewardConfigTemplate vipReward = templateService.get(this.vipRewardId, RewardConfigTemplate.class);
		if (vipReward == null) {
			throw new TemplateConfigException(this.sheetName, this.id, "vip奖励不存在！ rewardID="+this.vipRewardId);
		}
		
		// 奖励类型检查
		if (normalReward.getRewardReasonType() != RewardReasonType.RING_TASK_REWARD) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励身份识别类型[%d]", normalReward.getRewardReasonTypeId()));
		}
		// 奖励类型检查
		if (vipReward.getRewardReasonType() != RewardReasonType.RING_TASK_REWARD) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励身份识别类型[%d]", vipReward.getRewardReasonTypeId()));
		}
	}

	
}
