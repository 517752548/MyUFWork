package com.imop.lj.gameserver.arena.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.broadcast.template.BroadcastTemplate;


/**
 * 竞技场连胜公告配置模板
 * 
 */
@ExcelRowBinding
public class ArenaConWinNoticeTemplate extends ArenaConWinNoticeTemplateVO {
	@Override
	public void check() throws TemplateConfigException {
		if (null == templateService.get(noticeId, BroadcastTemplate.class)) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("公告Id[%d]不存在！", noticeId));
		}
	}
}