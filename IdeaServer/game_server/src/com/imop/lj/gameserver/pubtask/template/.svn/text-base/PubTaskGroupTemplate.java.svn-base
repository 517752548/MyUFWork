package com.imop.lj.gameserver.pubtask.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.task.TaskDef.QuestType;
import com.imop.lj.gameserver.task.template.QuestTemplate;


/**
 * 酒馆任务组模板
 */
@ExcelRowBinding
public class PubTaskGroupTemplate extends PubTaskGroupTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		//questId是否存在
		QuestTemplate questTpl = templateService.get(this.questId, QuestTemplate.class);
		if (questTpl == null || questTpl.getQuestTypeEnum() != QuestType.PUB) {
			throw new TemplateConfigException(sheetName, id, "任务Id不存在或类型不是酒馆任务!");
		}
	}

	
}
