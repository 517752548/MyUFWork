package com.imop.lj.gameserver.vip.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;
import com.imop.lj.gameserver.vip.VipDef;
import com.imop.lj.gameserver.vip.VipDef.VipLevel;

/**
 * VIP升级配置
 * 
 * @author xiaowei.liu
 * 
 */
@ExcelRowBinding
public class VipUpgradeTemplate extends VipUpgradeTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		if (this.id > VipDef.VipMaxLevel || this.id < VipLevel.VIP0.getIndex()) {
			throw new TemplateConfigException(sheetName, this.id, "VIP级别非法！");
		}
		
		if (this.id == 0) {
			return;
		}
		
		int preId = this.id - 1;
		if (this.templateService.get(preId, VipUpgradeTemplate.class) == null) {
			throw new TemplateConfigException(sheetName, this.id, "升级配置不连续");
		}
		
		// 奖励检查
		RewardConfigTemplate rewardTpl = templateService.get(dayRewardId, RewardConfigTemplate.class);
		if (null == rewardTpl) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励Id不存在[%d]", dayRewardId));
		}
		// 奖励类型检查
		if (rewardTpl.getRewardReasonType() != RewardReasonType.VIP_DAY_REWARD) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励身份识别类型[%d]", rewardTpl.getRewardReasonTypeId()));
		}
	}
}
