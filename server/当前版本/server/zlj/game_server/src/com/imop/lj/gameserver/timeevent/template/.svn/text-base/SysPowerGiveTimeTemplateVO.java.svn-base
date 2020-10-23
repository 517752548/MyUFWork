package com.imop.lj.gameserver.timeevent.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;

/**
 * 赠送体力模板
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class SysPowerGiveTimeTemplateVO extends TemplateObject {

	/** 赠送体力时间点 */
	@ExcelCellBinding(offset = 1)
	protected String givePowerTimeIds;


	public String getGivePowerTimeIds() {
		return this.givePowerTimeIds;
	}

	public void setGivePowerTimeIds(String givePowerTimeIds) {
		if (StringUtils.isEmpty(givePowerTimeIds)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[赠送体力时间点]givePowerTimeIds不可以为空");
		}
		if (givePowerTimeIds != null) {
			this.givePowerTimeIds = givePowerTimeIds.trim();
		}else{
			this.givePowerTimeIds = givePowerTimeIds;
		}
	}
	

	@Override
	public String toString() {
		return "SysPowerGiveTimeTemplateVO[givePowerTimeIds=" + givePowerTimeIds + ",]";

	}
}