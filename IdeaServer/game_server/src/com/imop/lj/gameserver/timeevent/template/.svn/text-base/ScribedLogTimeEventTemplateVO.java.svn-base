package com.imop.lj.gameserver.timeevent.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.annotation.NotTranslate;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;

/**
 * scribedLog日志更新时间
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class ScribedLogTimeEventTemplateVO extends TemplateObject {

	/** 刷新活动时间点 */
	@NotTranslate
	@ExcelCellBinding(offset = 1)
	protected String refreshActivityTimeIds;


	public String getRefreshActivityTimeIds() {
		return this.refreshActivityTimeIds;
	}

	public void setRefreshActivityTimeIds(String refreshActivityTimeIds) {
		if (StringUtils.isEmpty(refreshActivityTimeIds)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[刷新活动时间点]refreshActivityTimeIds不可以为空");
		}
		if (refreshActivityTimeIds != null) {
			this.refreshActivityTimeIds = refreshActivityTimeIds.trim();
		}else{
			this.refreshActivityTimeIds = refreshActivityTimeIds;
		}
	}
	

	@Override
	public String toString() {
		return "ScribedLogTimeEventTemplateVO[refreshActivityTimeIds=" + refreshActivityTimeIds + ",]";

	}
}