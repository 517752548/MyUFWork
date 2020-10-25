package com.imop.lj.gameserver.timeevent.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.common.model.template.TimeEventTemplate;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.core.util.StringUtils;


@ExcelRowBinding
public class RefreshDevilIncarnateTemplate extends RefreshDevilIncarnateTemplateVO {
	
	private int[] timeEventIds;	

	@Override
	public void setRefreshTimeIds(String refreshActivityTimeIds) {
		super.setRefreshTimeIds(refreshActivityTimeIds);
		timeEventIds = StringUtils.getIntArray(refreshActivityTimeIds, ";");
	}

	@Override
	public void check() throws TemplateConfigException {
		for(int timeEventId :timeEventIds )
		{
			if (!templateService.isTemplateExist(timeEventId,
					TimeEventTemplate.class)) {
				throw new TemplateConfigException(this.getSheetName(), this.getId(),
						"timeEventId=" + timeEventId + "不存在于timeEvent模板中");
			}	
		}
	}

	public int[] getTimeEventIds() {
		return timeEventIds;
	}
	

}
