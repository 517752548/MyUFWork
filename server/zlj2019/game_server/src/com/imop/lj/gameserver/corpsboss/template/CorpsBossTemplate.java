package com.imop.lj.gameserver.corpsboss.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.enemy.template.EnemyArmyTemplate;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;

@ExcelRowBinding
public class CorpsBossTemplate extends CorpsBossTemplateVO{

	@Override
	public void check() throws TemplateConfigException {
		//怪物组Id是否存在
		if (templateService.get(this.enemyArmyId, EnemyArmyTemplate.class) == null){
			throw new TemplateConfigException(this.sheetName, getId(), String.format("怪物组Id不存在[%d]", enemyArmyId));
		}
		// 奖励检查
		RewardConfigTemplate rewardTpl = templateService.get(rewardId, RewardConfigTemplate.class);
		if (null == rewardTpl) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励Id不存在[%d]", rewardId));
		}
		// 奖励类型检查
		if (rewardTpl.getRewardReasonType() != RewardReasonType.CORPS_BOSS_REWARD) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励身份识别类型[%d]", rewardTpl.getRewardReasonTypeId()));
		}
	}
	
}
