package com.imop.lj.gameserver.treasuremap.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.task.TaskDef.QuestType;
import com.imop.lj.gameserver.task.template.QuestTemplate;


/**
 * 藏宝图任务组模板
 */
@ExcelRowBinding
public class TreasureMapGroupTemplate extends TreasureMapGroupTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		//questId是否存在
		QuestTemplate questTpl = templateService.get(this.questId, QuestTemplate.class);
		if (questTpl == null || questTpl.getQuestTypeEnum() != QuestType.TREASUREMAP) {
			throw new TemplateConfigException(sheetName, id, "任务Id不存在或类型不是藏宝图任务!");
		}
	}

	
}
