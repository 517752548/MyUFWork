package com.imop.lj.gameserver.behavior.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 行为模板
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class BehaviorTemplateVO extends TemplateObject {

	/**  建筑名称多语言 Id */
	@ExcelCellBinding(offset = 1)
	protected int opCountMax;

	/**  重置时间 为小时 如值为1，重置时间为每天1点钟,最大值为23 */
	@ExcelCellBinding(offset = 2)
	protected int resetTime;


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
					3, "[ 重置时间 为小时 如值为1，重置时间为每天1点钟,最大值为23]resetTime的值不合法，应为0至23之间");
		}
		this.resetTime = resetTime;
	}
	

	@Override
	public String toString() {
		return "BehaviorTemplateVO[opCountMax=" + opCountMax + ",resetTime=" + resetTime + ",]";

	}
}