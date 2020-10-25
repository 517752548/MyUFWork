package com.imop.lj.gameserver.timeevent.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;

/**
 * 装备强化活动
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class EnhanceActivityTemplateVO extends TemplateObject {

	/** 开始时间 */
	@ExcelCellBinding(offset = 1)
	protected int startTimeId;

	/** 结束时间 */
	@ExcelCellBinding(offset = 2)
	protected int endTimeId;

	/** 活动时间描述多语言ID */
	@ExcelCellBinding(offset = 3)
	protected long timeLangId;

	/** 活动时间描述 */
	@ExcelCellBinding(offset = 4)
	protected String activityTimeDesc;

	/** 起效星期 */
	@ExcelCellBinding(offset = 5)
	protected String fixedWeekStr;

	/** 活动类型 */
	@ExcelCellBinding(offset = 6)
	protected int activityTypeId;

	/** 公告ID */
	@ExcelCellBinding(offset = 7)
	protected int broadcastId;


	public int getStartTimeId() {
		return this.startTimeId;
	}

	public void setStartTimeId(int startTimeId) {
		if (startTimeId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[开始时间]startTimeId不可以为0");
		}
		this.startTimeId = startTimeId;
	}
	
	public int getEndTimeId() {
		return this.endTimeId;
	}

	public void setEndTimeId(int endTimeId) {
		if (endTimeId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[结束时间]endTimeId不可以为0");
		}
		this.endTimeId = endTimeId;
	}
	
	public long getTimeLangId() {
		return this.timeLangId;
	}

	public void setTimeLangId(long timeLangId) {
		if (timeLangId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[活动时间描述多语言ID]timeLangId的值不得小于0");
		}
		this.timeLangId = timeLangId;
	}
	
	public String getActivityTimeDesc() {
		return this.activityTimeDesc;
	}

	public void setActivityTimeDesc(String activityTimeDesc) {
		if (StringUtils.isEmpty(activityTimeDesc)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[活动时间描述]activityTimeDesc不可以为空");
		}
		if (activityTimeDesc != null) {
			this.activityTimeDesc = activityTimeDesc.trim();
		}else{
			this.activityTimeDesc = activityTimeDesc;
		}
	}
	
	public String getFixedWeekStr() {
		return this.fixedWeekStr;
	}

	public void setFixedWeekStr(String fixedWeekStr) {
		if (StringUtils.isEmpty(fixedWeekStr)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[起效星期]fixedWeekStr不可以为空");
		}
		if (fixedWeekStr != null) {
			this.fixedWeekStr = fixedWeekStr.trim();
		}else{
			this.fixedWeekStr = fixedWeekStr;
		}
	}
	
	public int getActivityTypeId() {
		return this.activityTypeId;
	}

	public void setActivityTypeId(int activityTypeId) {
		if (activityTypeId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[活动类型]activityTypeId不可以为0");
		}
		this.activityTypeId = activityTypeId;
	}
	
	public int getBroadcastId() {
		return this.broadcastId;
	}

	public void setBroadcastId(int broadcastId) {
		if (broadcastId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[公告ID]broadcastId的值不得小于0");
		}
		this.broadcastId = broadcastId;
	}
	

	@Override
	public String toString() {
		return "EnhanceActivityTemplateVO[startTimeId=" + startTimeId + ",endTimeId=" + endTimeId + ",timeLangId=" + timeLangId + ",activityTimeDesc=" + activityTimeDesc + ",fixedWeekStr=" + fixedWeekStr + ",activityTypeId=" + activityTypeId + ",broadcastId=" + broadcastId + ",]";

	}
}