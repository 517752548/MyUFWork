package com.imop.lj.gameserver.timelimit.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.task.TaskDef.QuestType;
import com.imop.lj.gameserver.task.template.QuestTemplate;

@ExcelRowBinding
public class TimeLimitMonsterTemplate extends TimeLimitMonsterTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		//下限不能超过上限
		if (this.levelMin > this.levelMax) {
			throw new TemplateConfigException(sheetName, id, "等级下限超过了上限！");
		}
		
		//任务Id是否存在
		QuestTemplate questTpl = templateService.get(this.questId, QuestTemplate.class);
		if (questTpl == null || questTpl.getQuestTypeEnum() != QuestType.TIME_LIMIT_MONSTER) {
			throw new TemplateConfigException(sheetName, id, "任务Id不存在或类型不是限时杀怪任务!");
		}
		
	}

}
