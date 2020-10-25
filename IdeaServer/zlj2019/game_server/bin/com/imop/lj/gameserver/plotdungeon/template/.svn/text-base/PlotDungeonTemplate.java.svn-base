package com.imop.lj.gameserver.plotdungeon.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.enemy.template.EnemyArmyTemplate;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;
import com.imop.lj.gameserver.task.TaskDef.QuestType;
import com.imop.lj.gameserver.task.template.QuestTemplate;

@ExcelRowBinding
public class PlotDungeonTemplate extends PlotDungeonTemplateVO{

	@Override
	public void check() throws TemplateConfigException {
		//任务id是否存在
		QuestTemplate questTemplate = templateService.get(this.triggerQuestId, QuestTemplate.class);
		if(questTemplate == null){
			throw new TemplateConfigException(this.sheetName, getId(), String.format("主线任务Id不存在[%d]", triggerQuestId));
		}
		if(questTemplate.getQuestType() != QuestType.COMMON.getIndex()){
			throw new TemplateConfigException(this.sheetName, getId(), String.format("任务类型[%d]不正确", questTemplate.getQuestType()));
		}
		//怪物组Id是否存在
		if (templateService.get(this.enemyArmyId, EnemyArmyTemplate.class) == null){
			throw new TemplateConfigException(this.sheetName, getId(), String.format("怪物组Id不存在[%d]", enemyArmyId));
		}
		// 奖励检查
		RewardConfigTemplate rewardTpl = templateService.get(this.dailyRewardId, RewardConfigTemplate.class);
		if (null == rewardTpl) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励Id不存在[%d]", dailyRewardId));
		}
		// 奖励类型检查
		if (rewardTpl.getRewardReasonType() != RewardReasonType.PLOT_DUNGEON_REWARD) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励身份识别类型[%d]", rewardTpl.getRewardReasonTypeId()));
		}
	}

}
