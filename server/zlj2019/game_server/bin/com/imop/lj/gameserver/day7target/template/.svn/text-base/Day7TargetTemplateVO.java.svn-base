package com.imop.lj.gameserver.day7target.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 七日目标
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class Day7TargetTemplateVO extends TemplateObject {

	/** 天数 */
	@ExcelCellBinding(offset = 1)
	protected int day;

	/** 目标任务Id */
	@ExcelCellBinding(offset = 2)
	protected int questId;


	public int getDay() {
		return this.day;
	}

	public void setDay(int day) {
		if (day == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[天数]day不可以为0");
		}
		if (day > 7 || day < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[天数]day的值不合法，应为1至7之间");
		}
		this.day = day;
	}
	
	public int getQuestId() {
		return this.questId;
	}

	public void setQuestId(int questId) {
		if (questId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[目标任务Id]questId的值不得小于1");
		}
		this.questId = questId;
	}
	

	@Override
	public String toString() {
		return "Day7TargetTemplateVO[day=" + day + ",questId=" + questId + ",]";

	}
}