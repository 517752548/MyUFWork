package com.imop.lj.gameserver.timeevent.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.annotation.NotTranslate;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;

/**
 * 刷新混世魔王
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class RefreshDevilIncarnateTemplateVO extends TemplateObject {

	/** 刷新混世魔王时间点 */
	@NotTranslate
	@ExcelCellBinding(offset = 1)
	protected String refreshTimeIds;


	public String getRefreshTimeIds() {
		return this.refreshTimeIds;
	}

	public void setRefreshTimeIds(String refreshTimeIds) {
		if (StringUtils.isEmpty(refreshTimeIds)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[刷新混世魔王时间点]refreshTimeIds不可以为空");
		}
		if (refreshTimeIds != null) {
			this.refreshTimeIds = refreshTimeIds.trim();
		}else{
			this.refreshTimeIds = refreshTimeIds;
		}
	}
	

	@Override
	public String toString() {
		return "RefreshDevilIncarnateTemplateVO[refreshTimeIds=" + refreshTimeIds + ",]";

	}
}