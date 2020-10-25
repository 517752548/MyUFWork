package com.imop.lj.gameserver.activityui.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 活动UI模板
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class ActivityUITemplateVO extends TemplateObject {

	/** 活动计数ID */
	@ExcelCellBinding(offset = 1)
	protected int behaviorId;

	/** 活动名称 */
	@ExcelCellBinding(offset = 2)
	protected String name;

	/**  奖励的活力值(单次) */
	@ExcelCellBinding(offset = 3)
	protected int energyNumPerTime;

	/**  奖励的活跃度(单次) */
	@ExcelCellBinding(offset = 4)
	protected int activityNumPerTime;

	/**  可以获得活力值的次数 */
	@ExcelCellBinding(offset = 5)
	protected int activityTotalTime;

	/**  活动对应功能Id */
	@ExcelCellBinding(offset = 6)
	protected int funcId;

	/**  定时任务Id */
	@ExcelCellBinding(offset = 7)
	protected int activityTimeEventId;

	/**  参与推荐随机 */
	@ExcelCellBinding(offset = 8)
	protected int participateRecommendRandom;

	/**  参加活动的超链接 */
	@ExcelCellBinding(offset = 9)
	protected String hyperlink;

	/**  活动时间说明 */
	@ExcelCellBinding(offset = 10)
	protected String activityTimeDesc;

	/**  开始时间 */
	@ExcelCellBinding(offset = 11)
	protected String startTimeDesc;

	/**  任务形式 */
	@ExcelCellBinding(offset = 12)
	protected String taskMemberDesc;

	/**  活动描述 */
	@ExcelCellBinding(offset = 13)
	protected String desc;

	/**  任务奖励展示 */
	@ExcelCellBinding(offset = 14)
	protected int showRewardId;

	/**  活动图标 */
	@ExcelCellBinding(offset = 15)
	protected String icon;

	/**  限时活动Id */
	@ExcelCellBinding(offset = 16)
	protected int timeLimitActivityId;

	/**  活动角标 */
	@ExcelCellBinding(offset = 17)
	protected String superScript;

	/**  活动开启条件描述 */
	@ExcelCellBinding(offset = 18)
	protected String openConditionDesc;


	public int getBehaviorId() {
		return this.behaviorId;
	}

	public void setBehaviorId(int behaviorId) {
		if (behaviorId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[活动计数ID]behaviorId的值不得小于0");
		}
		this.behaviorId = behaviorId;
	}
	
	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		if (name != null) {
			this.name = name.trim();
		}else{
			this.name = name;
		}
	}
	
	public int getEnergyNumPerTime() {
		return this.energyNumPerTime;
	}

	public void setEnergyNumPerTime(int energyNumPerTime) {
		this.energyNumPerTime = energyNumPerTime;
	}
	
	public int getActivityNumPerTime() {
		return this.activityNumPerTime;
	}

	public void setActivityNumPerTime(int activityNumPerTime) {
		this.activityNumPerTime = activityNumPerTime;
	}
	
	public int getActivityTotalTime() {
		return this.activityTotalTime;
	}

	public void setActivityTotalTime(int activityTotalTime) {
		this.activityTotalTime = activityTotalTime;
	}
	
	public int getFuncId() {
		return this.funcId;
	}

	public void setFuncId(int funcId) {
		if (funcId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[ 活动对应功能Id]funcId不可以为0");
		}
		this.funcId = funcId;
	}
	
	public int getActivityTimeEventId() {
		return this.activityTimeEventId;
	}

	public void setActivityTimeEventId(int activityTimeEventId) {
		this.activityTimeEventId = activityTimeEventId;
	}
	
	public int getParticipateRecommendRandom() {
		return this.participateRecommendRandom;
	}

	public void setParticipateRecommendRandom(int participateRecommendRandom) {
		this.participateRecommendRandom = participateRecommendRandom;
	}
	
	public String getHyperlink() {
		return this.hyperlink;
	}

	public void setHyperlink(String hyperlink) {
		if (hyperlink != null) {
			this.hyperlink = hyperlink.trim();
		}else{
			this.hyperlink = hyperlink;
		}
	}
	
	public String getActivityTimeDesc() {
		return this.activityTimeDesc;
	}

	public void setActivityTimeDesc(String activityTimeDesc) {
		if (activityTimeDesc != null) {
			this.activityTimeDesc = activityTimeDesc.trim();
		}else{
			this.activityTimeDesc = activityTimeDesc;
		}
	}
	
	public String getStartTimeDesc() {
		return this.startTimeDesc;
	}

	public void setStartTimeDesc(String startTimeDesc) {
		if (startTimeDesc != null) {
			this.startTimeDesc = startTimeDesc.trim();
		}else{
			this.startTimeDesc = startTimeDesc;
		}
	}
	
	public String getTaskMemberDesc() {
		return this.taskMemberDesc;
	}

	public void setTaskMemberDesc(String taskMemberDesc) {
		if (taskMemberDesc != null) {
			this.taskMemberDesc = taskMemberDesc.trim();
		}else{
			this.taskMemberDesc = taskMemberDesc;
		}
	}
	
	public String getDesc() {
		return this.desc;
	}

	public void setDesc(String desc) {
		if (desc != null) {
			this.desc = desc.trim();
		}else{
			this.desc = desc;
		}
	}
	
	public int getShowRewardId() {
		return this.showRewardId;
	}

	public void setShowRewardId(int showRewardId) {
		this.showRewardId = showRewardId;
	}
	
	public String getIcon() {
		return this.icon;
	}

	public void setIcon(String icon) {
		if (icon != null) {
			this.icon = icon.trim();
		}else{
			this.icon = icon;
		}
	}
	
	public int getTimeLimitActivityId() {
		return this.timeLimitActivityId;
	}

	public void setTimeLimitActivityId(int timeLimitActivityId) {
		this.timeLimitActivityId = timeLimitActivityId;
	}
	
	public String getSuperScript() {
		return this.superScript;
	}

	public void setSuperScript(String superScript) {
		if (superScript != null) {
			this.superScript = superScript.trim();
		}else{
			this.superScript = superScript;
		}
	}
	
	public String getOpenConditionDesc() {
		return this.openConditionDesc;
	}

	public void setOpenConditionDesc(String openConditionDesc) {
		if (openConditionDesc != null) {
			this.openConditionDesc = openConditionDesc.trim();
		}else{
			this.openConditionDesc = openConditionDesc;
		}
	}
	

	@Override
	public String toString() {
		return "ActivityUITemplateVO[behaviorId=" + behaviorId + ",name=" + name + ",energyNumPerTime=" + energyNumPerTime + ",activityNumPerTime=" + activityNumPerTime + ",activityTotalTime=" + activityTotalTime + ",funcId=" + funcId + ",activityTimeEventId=" + activityTimeEventId + ",participateRecommendRandom=" + participateRecommendRandom + ",hyperlink=" + hyperlink + ",activityTimeDesc=" + activityTimeDesc + ",startTimeDesc=" + startTimeDesc + ",taskMemberDesc=" + taskMemberDesc + ",desc=" + desc + ",showRewardId=" + showRewardId + ",icon=" + icon + ",timeLimitActivityId=" + timeLimitActivityId + ",superScript=" + superScript + ",openConditionDesc=" + openConditionDesc + ",]";

	}
}