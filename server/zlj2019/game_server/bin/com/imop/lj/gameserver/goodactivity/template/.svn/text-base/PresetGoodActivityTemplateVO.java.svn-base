package com.imop.lj.gameserver.goodactivity.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 预置活动
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class PresetGoodActivityTemplateVO extends TemplateObject {

	/** 活动模版ID */
	@ExcelCellBinding(offset = 1)
	protected int activityTplId;

	/** 延迟时间 */
	@ExcelCellBinding(offset = 2)
	protected int delayTime;

	/** 持续时间 */
	@ExcelCellBinding(offset = 3)
	protected int duration;

	/** 是否生效 */
	@ExcelCellBinding(offset = 4)
	protected int activityUsable;

	/** 活动名称 */
	@ExcelCellBinding(offset = 5)
	protected String activityName;

	/** 活动描述 */
	@ExcelCellBinding(offset = 6)
	protected String activityDesc;

	/** 名称Icon */
	@ExcelCellBinding(offset = 7)
	protected int nameIcon;

	/** 标题Icon */
	@ExcelCellBinding(offset = 8)
	protected int tatleIcon;


	public int getActivityTplId() {
		return this.activityTplId;
	}

	public void setActivityTplId(int activityTplId) {
		if (activityTplId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[活动模版ID]activityTplId不可以为0");
		}
		this.activityTplId = activityTplId;
	}
	
	public int getDelayTime() {
		return this.delayTime;
	}

	public void setDelayTime(int delayTime) {
		if (delayTime < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[延迟时间]delayTime的值不得小于0");
		}
		this.delayTime = delayTime;
	}
	
	public int getDuration() {
		return this.duration;
	}

	public void setDuration(int duration) {
		if (duration < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[持续时间]duration的值不得小于1");
		}
		this.duration = duration;
	}
	
	public int getActivityUsable() {
		return this.activityUsable;
	}

	public void setActivityUsable(int activityUsable) {
		if (activityUsable > 1 || activityUsable < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[是否生效]activityUsable的值不合法，应为0至1之间");
		}
		this.activityUsable = activityUsable;
	}
	
	public String getActivityName() {
		return this.activityName;
	}

	public void setActivityName(String activityName) {
		if (activityName != null) {
			this.activityName = activityName.trim();
		}else{
			this.activityName = activityName;
		}
	}
	
	public String getActivityDesc() {
		return this.activityDesc;
	}

	public void setActivityDesc(String activityDesc) {
		if (activityDesc != null) {
			this.activityDesc = activityDesc.trim();
		}else{
			this.activityDesc = activityDesc;
		}
	}
	
	public int getNameIcon() {
		return this.nameIcon;
	}

	public void setNameIcon(int nameIcon) {
		if (nameIcon < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[名称Icon]nameIcon的值不得小于0");
		}
		this.nameIcon = nameIcon;
	}
	
	public int getTatleIcon() {
		return this.tatleIcon;
	}

	public void setTatleIcon(int tatleIcon) {
		if (tatleIcon < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					9, "[标题Icon]tatleIcon的值不得小于0");
		}
		this.tatleIcon = tatleIcon;
	}
	

	@Override
	public String toString() {
		return "PresetGoodActivityTemplateVO[activityTplId=" + activityTplId + ",delayTime=" + delayTime + ",duration=" + duration + ",activityUsable=" + activityUsable + ",activityName=" + activityName + ",activityDesc=" + activityDesc + ",nameIcon=" + nameIcon + ",tatleIcon=" + tatleIcon + ",]";

	}
}