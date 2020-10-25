package com.imop.lj.gameserver.timeevent.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.common.model.template.TimeEventTemplate;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.broadcast.template.BroadcastTemplate;


@ExcelRowBinding
public class TimeNoticeTemplate extends TimeNoticeTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		// 时间Id是否存在
		if (!templateService.isTemplateExist(noticeTimeId, TimeEventTemplate.class)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					"timeEventId=" + noticeTimeId + "不存在于timeEvent模板中");
		}
		// 广播id是否存在
		if (templateService.get(broadcastId, BroadcastTemplate.class) == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					"broadcastId=" + broadcastId + "不存在于broadcast模板中");
		}
	}

}
