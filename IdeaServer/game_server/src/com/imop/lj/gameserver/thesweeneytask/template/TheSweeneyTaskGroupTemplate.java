package com.imop.lj.gameserver.thesweeneytask.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.task.TaskDef.QuestType;
import com.imop.lj.gameserver.task.template.QuestTemplate;


/**
 * 除暴安良任务组模板
 */
@ExcelRowBinding
public class TheSweeneyTaskGroupTemplate extends TheSweeneyTaskGroupTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		//questId是否存在
		QuestTemplate questTpl = templateService.get(this.questId, QuestTemplate.class);
		if (questTpl == null || questTpl.getQuestTypeEnum() != QuestType.THESWEENEY) {
			throw new TemplateConfigException(sheetName, id, "任务Id不存在或类型不是除暴安良任务!");
		}
	}

	
}
