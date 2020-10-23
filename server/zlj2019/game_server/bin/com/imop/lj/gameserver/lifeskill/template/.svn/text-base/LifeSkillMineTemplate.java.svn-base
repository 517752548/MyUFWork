package com.imop.lj.gameserver.lifeskill.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;

@ExcelRowBinding
public class LifeSkillMineTemplate extends LifeSkillMineTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		// 奖励检查
		RewardConfigTemplate rewardTpl = templateService.get(selfReward1, RewardConfigTemplate.class);
		if (null == rewardTpl) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励Id不存在[%d]", selfReward1));
		}
		// 奖励类型检查
		if (rewardTpl.getRewardReasonType() != RewardReasonType.MINE_REWARD) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励身份识别类型[%d]", rewardTpl.getRewardReasonTypeId()));
		}
		// 奖励检查
		RewardConfigTemplate rewardTpl2 = templateService.get(selfReward2, RewardConfigTemplate.class);
		if (null == rewardTpl2) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励Id2不存在[%d]", selfReward2));
		}
		// 奖励类型检查
		if (rewardTpl2.getRewardReasonType() != RewardReasonType.MINE_REWARD) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励身份2识别类型[%d]", rewardTpl2.getRewardReasonTypeId()));
		}
		// 奖励检查
		RewardConfigTemplate rewardTpl3 = templateService.get(selfReward3, RewardConfigTemplate.class);
		if (null == rewardTpl3) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励Id3不存在[%d]", selfReward3));
		}
		// 奖励类型检查
		if (rewardTpl3.getRewardReasonType() != RewardReasonType.MINE_REWARD) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励身份3识别类型[%d]", rewardTpl3.getRewardReasonTypeId()));
		}
		
		//ItemId
		ItemTemplate itemTpl = templateService.get(this.getMineItemId(), ItemTemplate.class);
		if (itemTpl == null ) {
			throw new TemplateConfigException(this.sheetName, this.id, "矿石不存在！ equipmentID="+this.getMineItemId());
		}
	}

}
