package com.imop.lj.gameserver.timelimit.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;
import com.imop.lj.gameserver.task.TaskDef.QuestType;
import com.imop.lj.gameserver.task.template.QuestTemplate;

@ExcelRowBinding
public class TimeLimitNpcTemplate extends TimeLimitNpcTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		//下限不能超过上限
		if (this.levelMin > this.levelMax) {
			throw new TemplateConfigException(sheetName, id, "等级下限超过了上限！");
		}
		
		//任务Id是否存在
		QuestTemplate questTpl = templateService.get(this.questId, QuestTemplate.class);
		if (questTpl == null || questTpl.getQuestTypeEnum() != QuestType.TIME_LIMIT_NPC) {
			throw new TemplateConfigException(sheetName, id, "任务Id不存在或类型不是限时挑战Npc任务!");
		}
		
		//助战奖励ID是否存在,类型检查
		RewardConfigTemplate assistReward = templateService.get(this.getAssistRewardId(), RewardConfigTemplate.class);
		if (assistReward == null) {
			throw new TemplateConfigException(this.sheetName, this.id, "助战奖励不存在！ rewardID="+this.getAssistRewardId());
		}
		if (assistReward.getRewardReasonType() != RewardReasonType.TIME_LIMIT_NPC_REWARD) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励身份识别类型[%d]", assistReward.getRewardReasonTypeId()));
		}
	}

}
