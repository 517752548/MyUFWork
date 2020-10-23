package com.imop.lj.gameserver.corpstask.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.corps.template.CorpsUpgradeTemplate;
import com.imop.lj.gameserver.corpstask.CorpsTaskTemplateVO;
import com.imop.lj.gameserver.task.TaskDef.QuestType;
import com.imop.lj.gameserver.task.template.QuestTemplate;

/**
 * 帮派任务模板
 */
@ExcelRowBinding
public class CorpsTaskTemplate extends CorpsTaskTemplateVO{

	@Override
	public void check() throws TemplateConfigException {
		CorpsUpgradeTemplate tpl = templateService.get(corpsLevel, CorpsUpgradeTemplate.class);
		if (null == tpl) {
			throw new TemplateConfigException(this.sheetName, this.id, "帮派等级不存在！" + this.corpsLevel);
		}
		
		//questId是否存在
		QuestTemplate questTpl = templateService.get(this.questId, QuestTemplate.class);
		if (questTpl == null || questTpl.getQuestTypeEnum() != QuestType.CORPSTASK) {
			throw new TemplateConfigException(sheetName, id, "任务Id不存在或类型不是帮派任务!");
		}
	}

	
}
