package com.imop.lj.gameserver.activity.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.annotation.NotClient;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;
import java.util.List;

/**
 * 活动模板
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class ActivityTemplateVO extends TemplateObject {

	/** 活动是否开启（1开启，0关闭） */
	@ExcelCellBinding(offset = 1)
	protected int isOpen;

	/**  活动名称多语言id */
	@ExcelCellBinding(offset = 2)
	@NotClient
	protected long nameLangId;

	/**  活动名称 */
	@ExcelCellBinding(offset = 3)
	protected String name;

	/**  活动时间描述多语言id */
	@ExcelCellBinding(offset = 4)
	protected long timeDescLangId;

	/**  活动时间描述 */
	@ExcelCellBinding(offset = 5)
	protected String timeDesc;

	/**  活动描述多语言id */
	@ExcelCellBinding(offset = 6)
	protected long descLangId;

	/**  活动描述 */
	@ExcelCellBinding(offset = 7)
	protected String desc;

	/** 对应功能类型Id */
	@ExcelCellBinding(offset = 8)
	protected int funcTypeId;

	/** 周几限制 */
	@ExcelCellBinding(offset = 9)
	protected String weekLimitStr;

	/** 活动提醒时间 */
	@ExcelCellBinding(offset = 10)
	protected int noticeActivityTimeEventId;

	/**  活动准备时间 */
	@ExcelCellBinding(offset = 11)
	protected int readyActivityTimeEventId;

	/**  活动开始时间 */
	@ExcelCellBinding(offset = 12)
	protected int startActivityTimeEventId;

	/**  活动结束时间 */
	@ExcelCellBinding(offset = 13)
	protected int endActivityTimeEventId;

	/**  活动图标 */
	@ExcelCellBinding(offset = 14)
	protected int icon;

	/** 活动执行函数 */
	@ExcelRowBinding
	protected com.imop.lj.gameserver.activity.template.ActivityFunctionTemplate activityFunctionTemplate;

	/** 活动个阶段函数 */
	@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.activity.template.ActivityMessageTemplate.class, collectionNumber = "21,22,23,24,25,26;27,28,29,30,31,32;33,34,35,36,37,38;39,40,41,42,43,44")
	protected List<com.imop.lj.gameserver.activity.template.ActivityMessageTemplate> activityMessageTemplateList;


	public int getIsOpen() {
		return this.isOpen;
	}

	public void setIsOpen(int isOpen) {
		if (isOpen == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[活动是否开启（1开启，0关闭）]isOpen不可以为0");
		}
		if (isOpen > 1 || isOpen < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[活动是否开启（1开启，0关闭）]isOpen的值不合法，应为0至1之间");
		}
		this.isOpen = isOpen;
	}
	
	public long getNameLangId() {
		return this.nameLangId;
	}

	public void setNameLangId(long nameLangId) {
		this.nameLangId = nameLangId;
	}
	
	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		if (StringUtils.isEmpty(name)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[ 活动名称]name不可以为空");
		}
		if (name != null) {
			this.name = name.trim();
		}else{
			this.name = name;
		}
	}
	
	public long getTimeDescLangId() {
		return this.timeDescLangId;
	}

	public void setTimeDescLangId(long timeDescLangId) {
		this.timeDescLangId = timeDescLangId;
	}
	
	public String getTimeDesc() {
		return this.timeDesc;
	}

	public void setTimeDesc(String timeDesc) {
		if (StringUtils.isEmpty(timeDesc)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[ 活动时间描述]timeDesc不可以为空");
		}
		if (timeDesc != null) {
			this.timeDesc = timeDesc.trim();
		}else{
			this.timeDesc = timeDesc;
		}
	}
	
	public long getDescLangId() {
		return this.descLangId;
	}

	public void setDescLangId(long descLangId) {
		this.descLangId = descLangId;
	}
	
	public String getDesc() {
		return this.desc;
	}

	public void setDesc(String desc) {
		if (StringUtils.isEmpty(desc)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[ 活动描述]desc不可以为空");
		}
		if (desc != null) {
			this.desc = desc.trim();
		}else{
			this.desc = desc;
		}
	}
	
	public int getFuncTypeId() {
		return this.funcTypeId;
	}

	public void setFuncTypeId(int funcTypeId) {
		this.funcTypeId = funcTypeId;
	}
	
	public String getWeekLimitStr() {
		return this.weekLimitStr;
	}

	public void setWeekLimitStr(String weekLimitStr) {
		if (weekLimitStr != null) {
			this.weekLimitStr = weekLimitStr.trim();
		}else{
			this.weekLimitStr = weekLimitStr;
		}
	}
	
	public int getNoticeActivityTimeEventId() {
		return this.noticeActivityTimeEventId;
	}

	public void setNoticeActivityTimeEventId(int noticeActivityTimeEventId) {
		if (noticeActivityTimeEventId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					11, "[活动提醒时间]noticeActivityTimeEventId的值不得小于0");
		}
		this.noticeActivityTimeEventId = noticeActivityTimeEventId;
	}
	
	public int getReadyActivityTimeEventId() {
		return this.readyActivityTimeEventId;
	}

	public void setReadyActivityTimeEventId(int readyActivityTimeEventId) {
		if (readyActivityTimeEventId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					12, "[ 活动准备时间]readyActivityTimeEventId的值不得小于0");
		}
		this.readyActivityTimeEventId = readyActivityTimeEventId;
	}
	
	public int getStartActivityTimeEventId() {
		return this.startActivityTimeEventId;
	}

	public void setStartActivityTimeEventId(int startActivityTimeEventId) {
		if (startActivityTimeEventId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					13, "[ 活动开始时间]startActivityTimeEventId不可以为0");
		}
		this.startActivityTimeEventId = startActivityTimeEventId;
	}
	
	public int getEndActivityTimeEventId() {
		return this.endActivityTimeEventId;
	}

	public void setEndActivityTimeEventId(int endActivityTimeEventId) {
		if (endActivityTimeEventId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					14, "[ 活动结束时间]endActivityTimeEventId不可以为0");
		}
		this.endActivityTimeEventId = endActivityTimeEventId;
	}
	
	public int getIcon() {
		return this.icon;
	}

	public void setIcon(int icon) {
		if (icon == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					15, "[ 活动图标]icon不可以为0");
		}
		this.icon = icon;
	}
	
	public com.imop.lj.gameserver.activity.template.ActivityFunctionTemplate getActivityFunctionTemplate() {
		return this.activityFunctionTemplate;
	}

	public void setActivityFunctionTemplate(com.imop.lj.gameserver.activity.template.ActivityFunctionTemplate activityFunctionTemplate) {
		if (activityFunctionTemplate == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					16, "[活动执行函数]activityFunctionTemplate不可以为空");
		}	
		this.activityFunctionTemplate = activityFunctionTemplate;
	}
	
	public List<com.imop.lj.gameserver.activity.template.ActivityMessageTemplate> getActivityMessageTemplateList() {
		return this.activityMessageTemplateList;
	}

	public void setActivityMessageTemplateList(List<com.imop.lj.gameserver.activity.template.ActivityMessageTemplate> activityMessageTemplateList) {
		if (activityMessageTemplateList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					22, "[活动个阶段函数]activityMessageTemplateList不可以为空");
		}	
		this.activityMessageTemplateList = activityMessageTemplateList;
	}
	

	@Override
	public String toString() {
		return "ActivityTemplateVO[isOpen=" + isOpen + ",nameLangId=" + nameLangId + ",name=" + name + ",timeDescLangId=" + timeDescLangId + ",timeDesc=" + timeDesc + ",descLangId=" + descLangId + ",desc=" + desc + ",funcTypeId=" + funcTypeId + ",weekLimitStr=" + weekLimitStr + ",noticeActivityTimeEventId=" + noticeActivityTimeEventId + ",readyActivityTimeEventId=" + readyActivityTimeEventId + ",startActivityTimeEventId=" + startActivityTimeEventId + ",endActivityTimeEventId=" + endActivityTimeEventId + ",icon=" + icon + ",activityFunctionTemplate=" + activityFunctionTemplate + ",activityMessageTemplateList=" + activityMessageTemplateList + ",]";

	}
}