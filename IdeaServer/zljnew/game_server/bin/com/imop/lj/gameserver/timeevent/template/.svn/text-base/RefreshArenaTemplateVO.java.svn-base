package com.imop.lj.gameserver.timeevent.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.annotation.NotTranslate;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;

/**
 * 刷新竞技场
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class RefreshArenaTemplateVO extends TemplateObject {

	/** 刷新竞技场时间点 */
	@NotTranslate
	@ExcelCellBinding(offset = 1)
	protected String refreshArenaTimeIds;


	public String getRefreshArenaTimeIds() {
		return this.refreshArenaTimeIds;
	}

	public void setRefreshArenaTimeIds(String refreshArenaTimeIds) {
		if (StringUtils.isEmpty(refreshArenaTimeIds)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[刷新竞技场时间点]refreshArenaTimeIds不可以为空");
		}
		if (refreshArenaTimeIds != null) {
			this.refreshArenaTimeIds = refreshArenaTimeIds.trim();
		}else{
			this.refreshArenaTimeIds = refreshArenaTimeIds;
		}
	}
	

	@Override
	public String toString() {
		return "RefreshArenaTemplateVO[refreshArenaTimeIds=" + refreshArenaTimeIds + ",]";

	}
}