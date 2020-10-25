package com.imop.lj.gameserver.ringtask.template;

import java.util.List;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.task.TaskDef.QuestType;
import com.imop.lj.gameserver.task.template.QuestTemplate;


/**
 * 跑环任务模板
 */
@ExcelRowBinding
public class RingTaskTemplate extends RingTaskTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		//下限不能超过上限
		if (this.levelMin > this.levelMax) {
			throw new TemplateConfigException(sheetName, id, "等级下限超过了上限！");
		}
		
		//任务Id是否存在
		
		List<Integer> taskLst = this.ringTaskList;
		if(taskLst.isEmpty()){
			throw new TemplateConfigException(sheetName, id, "任务不可为空！");
		}
		for (Integer questId : taskLst) {
			QuestTemplate questTemplate = templateService.get(questId, QuestTemplate.class);
			if(questTemplate == null || questTemplate.getQuestTypeEnum() != QuestType.RING){
				throw new TemplateConfigException(sheetName, id, "任务Id不存在或类型不是跑环任务!questId = " + questId);
			}
		}
	}

	
}
