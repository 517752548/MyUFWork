package com.imop.lj.gameserver.foragetask.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.task.TaskDef.QuestType;
import com.imop.lj.gameserver.task.template.QuestTemplate;


/**
 * 护送粮草任务组模板
 */
@ExcelRowBinding
public class ForageTaskGroupTemplate extends ForageTaskGroupTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		//questId是否存在
		QuestTemplate questTpl = templateService.get(this.questId, QuestTemplate.class);
		if (questTpl == null || questTpl.getQuestTypeEnum() != QuestType.FORAGE) {
			throw new TemplateConfigException(sheetName, id, "任务Id不存在或类型不是护送粮草任务!");
		}
	}

	
}
