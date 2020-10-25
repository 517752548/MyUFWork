package com.imop.lj.gameserver.human.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 限时礼包清空设置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class TimeGiftConfigTemplateVO extends TemplateObject {

	/** $field.comment */
	@ExcelCellBinding(offset = 1)
	protected int resetTime;

	/** $field.comment */
	@ExcelCellBinding(offset = 2)
	protected long clearTime;


	public int getResetTime() {
		return this.resetTime;
	}

	public void setResetTime(int resetTime) {
		if (resetTime == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[$field.comment]resetTime不可以为0");
		}
		if (resetTime < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[$field.comment]resetTime的值不得小于0");
		}
		this.resetTime = resetTime;
	}
	
	public long getClearTime() {
		return this.clearTime;
	}

	public void setClearTime(long clearTime) {
		if (clearTime < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[$field.comment]clearTime的值不得小于0");
		}
		this.clearTime = clearTime;
	}
	

	@Override
	public String toString() {
		return "TimeGiftConfigTemplateVO[resetTime=" + resetTime + ",clearTime=" + clearTime + ",]";

	}
}