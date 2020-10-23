package com.imop.lj.common.model.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.annotation.NotTranslate;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;

/**
 * 定时事件
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class TimeEventTemplateVO extends TemplateObject {

	/** 触发时间 HH:mm:ss */
	@NotTranslate
	@ExcelCellBinding(offset = 1)
	protected String triggerTime;


	public String getTriggerTime() {
		return this.triggerTime;
	}

	public void setTriggerTime(String triggerTime) {
		if (StringUtils.isEmpty(triggerTime)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[触发时间 HH:mm:ss]triggerTime不可以为空");
		}
		if (triggerTime != null) {
			this.triggerTime = triggerTime.trim();
		}else{
			this.triggerTime = triggerTime;
		}
	}
	

	@Override
	public String toString() {
		return "TimeEventTemplateVO[triggerTime=" + triggerTime + ",]";

	}
}