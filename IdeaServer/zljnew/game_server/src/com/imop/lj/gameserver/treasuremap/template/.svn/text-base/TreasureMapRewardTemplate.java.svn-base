package com.imop.lj.gameserver.treasuremap.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.enemy.template.EnemyArmyTemplate;
import com.imop.lj.gameserver.item.ItemDef.ItemType;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;


/**
 * 藏宝图奖励模板
 */
@ExcelRowBinding
public class TreasureMapRewardTemplate extends TreasureMapRewardTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		
		//下限不能超过上限
		if (this.levelMin > this.levelMax) {
			throw new TemplateConfigException(sheetName, id, "等级下限超过了上限！");
		}
		
		//questId是否存在
		ItemTemplate questTpl = templateService.get(this.itemId, ItemTemplate.class);
		if (questTpl == null || questTpl.getItemType()  != ItemType.TREASURE_MAP_ITEM) {
			throw new TemplateConfigException(sheetName, id, "道具Id不存在或类型不是藏宝图!");
		}
		
		//检查参数是否正确
		if(getTriggerType() == 1) {
			if (null == templateService.get(getParam(), EnemyArmyTemplate.class)) {
				throw new TemplateConfigException(sheetName, id, "EnemyArmyTemplate不存在!");
			}
			if (null == templateService.get(getLoseReward(), RewardConfigTemplate.class)) {
				throw new TemplateConfigException(sheetName, id, "战斗基础奖励reward不存在!");
			}
		} else {
			// 奖励检查
			RewardConfigTemplate rewardTpl = templateService.get(getParam(), RewardConfigTemplate.class);
			if (null == rewardTpl) {
				throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励Id不存在[%d]", getParam()));
			}
			// 奖励类型检查
			if (rewardTpl.getRewardReasonType() != RewardReasonType.TREASURE_MAP_REWARD) {
				throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励身份识别类型[%d]", rewardTpl.getRewardReasonTypeId()));
			}
		}
	}

	
}
