package com.imop.lj.gameserver.goodactivity.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;

/**
 * 每日登陆
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class GoodActivitySevenDayLoginTemplateVO extends GoodActivityTargetTemplate {

	/** 登陆的天数 */
	@ExcelCellBinding(offset = 12)
	protected int needDay;


	public int getNeedDay() {
		return this.needDay;
	}

	public void setNeedDay(int needDay) {
		if (needDay < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					13, "[登陆的天数]needDay的值不得小于1");
		}
		this.needDay = needDay;
	}
	

	@Override
	public String toString() {
		return "GoodActivitySevenDayLoginTemplateVO[needDay=" + needDay + ",]";

	}
}