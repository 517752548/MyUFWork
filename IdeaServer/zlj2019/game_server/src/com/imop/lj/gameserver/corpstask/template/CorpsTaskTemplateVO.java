package com.imop.lj.gameserver.corpstask.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 帮派任务模板
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class CorpsTaskTemplateVO extends TemplateObject {

	/** 帮派等级 */
	@ExcelCellBinding(offset = 1)
	protected int corpsLevel;

	/** 任务Id */
	@ExcelCellBinding(offset = 2)
	protected int questId;


	public int getCorpsLevel() {
		return this.corpsLevel;
	}

	public void setCorpsLevel(int corpsLevel) {
		if (corpsLevel < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[帮派等级]corpsLevel的值不得小于0");
		}
		this.corpsLevel = corpsLevel;
	}
	
	public int getQuestId() {
		return this.questId;
	}

	public void setQuestId(int questId) {
		if (questId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[任务Id]questId的值不得小于0");
		}
		this.questId = questId;
	}
	

	@Override
	public String toString() {
		return "CorpsTaskTemplateVO[corpsLevel=" + corpsLevel + ",questId=" + questId + ",]";

	}
}