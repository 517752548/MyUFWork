package com.imop.lj.gameserver.thesweeneytask.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;


/**
 * 除暴任务模板
 */
@ExcelRowBinding
public class TheSweeneyTaskTemplate extends TheSweeneyTaskTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		//下限不能超过上限
		if (this.levelMin > this.levelMax) {
			throw new TemplateConfigException(sheetName, id, "等级下限超过了上限！");
		}
		
		// 奖励检查
		RewardConfigTemplate rewardTpl = templateService.get(specialAwards, RewardConfigTemplate.class);
		if (null == rewardTpl) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励Id不存在[%d]", specialAwards));
		}
		// 奖励类型检查
		if (rewardTpl.getRewardReasonType() != RewardReasonType.SWEENEY_TASK_SPECIAL) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励身份识别类型[%d]", rewardTpl.getRewardReasonTypeId()));
		}
	}

	
}
