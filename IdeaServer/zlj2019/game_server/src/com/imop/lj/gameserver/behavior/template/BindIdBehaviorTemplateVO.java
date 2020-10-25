package com.imop.lj.gameserver.behavior.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 绑定Id行为模板
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class BindIdBehaviorTemplateVO extends TemplateObject {

	/**  建筑名称多语言 Id */
	@ExcelCellBinding(offset = 1)
	protected int opCountMax;

	/**  重置小时 如值为1，重置时间为每天1点钟,最大值为23 */
	@ExcelCellBinding(offset = 2)
	protected int resetTime;

	/**  重置天，如果类型为每周，则表示周几；如果类型为每n天，则表示n */
	@ExcelCellBinding(offset = 3)
	protected int periodDay;


	public int getOpCountMax() {
		return this.opCountMax;
	}

	public void setOpCountMax(int opCountMax) {
		if (opCountMax < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[ 建筑名称多语言 Id]opCountMax的值不得小于0");
		}
		this.opCountMax = opCountMax;
	}
	
	public int getResetTime() {
		return this.resetTime;
	}

	public void setResetTime(int resetTime) {
		if (resetTime > 23 || resetTime < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[ 重置小时 如值为1，重置时间为每天1点钟,最大值为23]resetTime的值不合法，应为0至23之间");
		}
		this.resetTime = resetTime;
	}
	
	public int getPeriodDay() {
		return this.periodDay;
	}

	public void setPeriodDay(int periodDay) {
		if (periodDay < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[ 重置天，如果类型为每周，则表示周几；如果类型为每n天，则表示n]periodDay的值不得小于0");
		}
		this.periodDay = periodDay;
	}
	

	@Override
	public String toString() {
		return "BindIdBehaviorTemplateVO[opCountMax=" + opCountMax + ",resetTime=" + resetTime + ",periodDay=" + periodDay + ",]";

	}
}