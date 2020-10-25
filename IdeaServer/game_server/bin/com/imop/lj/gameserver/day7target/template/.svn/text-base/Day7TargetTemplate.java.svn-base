package com.imop.lj.gameserver.day7target.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.task.TaskDef.QuestType;
import com.imop.lj.gameserver.task.template.QuestTemplate;

/**
 * 七日目标
 */
@ExcelRowBinding
public class Day7TargetTemplate extends Day7TargetTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		//目标任务是否存在
		QuestTemplate questTpl = templateService.get(questId, QuestTemplate.class);
		if (null == questTpl) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("任务Id不存在！[%d]", questId));
		}
		if (questTpl.getQuestTypeEnum() != QuestType.DAY7_TARGET) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("任务不是七日目标任务！[%d]", questId));
		}
		
	}

}
