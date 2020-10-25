package com.imop.lj.gameserver.wizardraid.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 绿野仙踪-波数配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class WizardRaidWaveTemplateVO extends TemplateObject {

	/** 开始时间，毫秒 */
	@ExcelCellBinding(offset = 1)
	protected int startTime;


	public int getStartTime() {
		return this.startTime;
	}

	public void setStartTime(int startTime) {
		if (startTime < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[开始时间，毫秒]startTime的值不得小于0");
		}
		this.startTime = startTime;
	}
	

	@Override
	public String toString() {
		return "WizardRaidWaveTemplateVO[startTime=" + startTime + ",]";

	}
}