package com.imop.lj.gameserver.corpsassist.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;

@ExcelRowBinding
public class CorpsAssistGenTemplate extends CorpsAssistGenTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		// 奖励检查
		RewardConfigTemplate rewardTpl = templateService.get(rewardId, RewardConfigTemplate.class);
		if (null == rewardTpl) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励Id不存在[%d]", rewardId));
		}
		// 奖励类型检查
		if (rewardTpl.getRewardReasonType() != RewardReasonType.CORPS_ASSIST_REWARD) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励身份识别类型[%d]", rewardTpl.getRewardReasonTypeId()));
		}
		
		
		//道具是否存在
		ItemTemplate itemTpl = templateService.get(itemId, ItemTemplate.class);
		if(itemTpl == null){
			throw new TemplateConfigException(this.sheetName, getId(), String.format("道具Id不存在[%d]", itemId));
		}
	}

}
