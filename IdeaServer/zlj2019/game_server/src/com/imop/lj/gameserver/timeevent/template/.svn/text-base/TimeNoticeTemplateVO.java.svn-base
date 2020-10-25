package com.imop.lj.gameserver.timeevent.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 定时公告
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class TimeNoticeTemplateVO extends TemplateObject {

	/** 公告时间Id */
	@ExcelCellBinding(offset = 1)
	protected int noticeTimeId;

	/** 广播Id */
	@ExcelCellBinding(offset = 2)
	protected int broadcastId;


	public int getNoticeTimeId() {
		return this.noticeTimeId;
	}

	public void setNoticeTimeId(int noticeTimeId) {
		if (noticeTimeId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[公告时间Id]noticeTimeId不可以为0");
		}
		if (noticeTimeId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[公告时间Id]noticeTimeId的值不得小于0");
		}
		this.noticeTimeId = noticeTimeId;
	}
	
	public int getBroadcastId() {
		return this.broadcastId;
	}

	public void setBroadcastId(int broadcastId) {
		if (broadcastId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[广播Id]broadcastId不可以为0");
		}
		if (broadcastId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[广播Id]broadcastId的值不得小于0");
		}
		this.broadcastId = broadcastId;
	}
	

	@Override
	public String toString() {
		return "TimeNoticeTemplateVO[noticeTimeId=" + noticeTimeId + ",broadcastId=" + broadcastId + ",]";

	}
}