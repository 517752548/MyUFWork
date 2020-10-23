package com.imop.lj.gameserver.activityui.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;
import com.imop.lj.gameserver.reward.template.ShowRewardTemplate;

@ExcelRowBinding
public class ActivityUIRewardTemplate extends ActivityUIRewardTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		if(this.id > Globals.getGameConstants().getMaxActivityNum()){
			throw new TemplateConfigException(this.sheetName, this.id, "活力值大于上限="+this.id+ ", max="+Globals.getGameConstants().getMaxActivityNum());
		}
		if(null == templateService.get(this.getShowRewardId(), ShowRewardTemplate.class)){
			throw new TemplateConfigException(this.sheetName, this.id, "显示奖励ID不存在="+this.getShowRewardId());
		}
		
		// 奖励检查
		RewardConfigTemplate rewardTpl = templateService.get(rewardId, RewardConfigTemplate.class);
		if (null == rewardTpl) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励Id不存在[%d]", rewardId));
		}
		// 奖励类型检查
		if (rewardTpl.getRewardReasonType() != RewardReasonType.ACTIVITYUI_REWARD) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励身份识别类型[%d]", rewardTpl.getRewardReasonTypeId()));
		}
		
	}

}
