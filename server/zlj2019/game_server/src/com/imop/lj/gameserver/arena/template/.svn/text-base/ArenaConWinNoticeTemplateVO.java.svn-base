package com.imop.lj.gameserver.arena.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 竞技场连胜公告
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class ArenaConWinNoticeTemplateVO extends TemplateObject {

	/** 连胜数 */
	@ExcelCellBinding(offset = 1)
	protected int conWinTimes;

	/** 公告Id */
	@ExcelCellBinding(offset = 2)
	protected int noticeId;


	public int getConWinTimes() {
		return this.conWinTimes;
	}

	public void setConWinTimes(int conWinTimes) {
		if (conWinTimes < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[连胜数]conWinTimes的值不得小于1");
		}
		this.conWinTimes = conWinTimes;
	}
	
	public int getNoticeId() {
		return this.noticeId;
	}

	public void setNoticeId(int noticeId) {
		if (noticeId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[公告Id]noticeId的值不得小于1");
		}
		this.noticeId = noticeId;
	}
	

	@Override
	public String toString() {
		return "ArenaConWinNoticeTemplateVO[conWinTimes=" + conWinTimes + ",noticeId=" + noticeId + ",]";

	}
}