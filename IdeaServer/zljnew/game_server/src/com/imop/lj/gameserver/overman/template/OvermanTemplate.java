package com.imop.lj.gameserver.overman.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;

/**
 * Created by zhangzhe on 15/12/28.
 */
@ExcelRowBinding
public class OvermanTemplate extends OvermanTemplateVO {
	
    @Override
    public void check() throws TemplateConfigException {
    	// 奖励检查
    	RewardConfigTemplate rewardTpl = templateService.get(overmanReward, RewardConfigTemplate.class);
    	if (null == rewardTpl) {
    		throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励Id不存在[%d]", overmanReward));
    	}
    	// 奖励类型检查
    	if (rewardTpl.getRewardReasonType() != RewardReasonType.OVERMAN_REWARD) {
    		throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励身份识别类型[%d]", rewardTpl.getRewardReasonTypeId()));
    	}
    	
    	// 奖励检查
    	RewardConfigTemplate rewardTpl1 = templateService.get(lowermanReward, RewardConfigTemplate.class);
    	if (null == rewardTpl1) {
    		throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励Id不存在[%d]", lowermanReward));
    	}
    	// 奖励类型检查
    	if (rewardTpl1.getRewardReasonType() != RewardReasonType.OVERMAN_REWARD) {
    		throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励身份识别类型[%d]", rewardTpl1.getRewardReasonTypeId()));
    	}
    }
}
