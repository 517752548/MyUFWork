package com.imop.lj.gameserver.mall.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 商城结束公告时间
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class MallEndBoradcastTimeTemplateVO extends TemplateObject {

	/** 相对于结束的时间 */
	@ExcelCellBinding(offset = 1)
	protected long endTime;


	public long getEndTime() {
		return this.endTime;
	}

	public void setEndTime(long endTime) {
		if (endTime < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[相对于结束的时间]endTime的值不得小于0");
		}
		this.endTime = endTime;
	}
	

	@Override
	public String toString() {
		return "MallEndBoradcastTimeTemplateVO[endTime=" + endTime + ",]";

	}
}