package com.imop.lj.gameserver.reward.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
@ExcelRowBinding
public class LevelGiftPackTemplate extends LevelGiftPackTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		if(this.upperLevel < this.lowerLevel){
			throw new TemplateConfigException(sheetName, this.id, "等级上限小于下限");
		}
		
		RewardConfigTemplate reward = this.templateService.get(this.rewardId, RewardConfigTemplate.class);
		if(reward == null){
			throw new TemplateConfigException(sheetName, this.id, "奖励配置不存在");
		}
	}

}
