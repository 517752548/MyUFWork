package com.imop.lj.gameserver.skill.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import java.util.List;

/**
 * 技能表现
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class SkillPerformTemplateVO extends TemplateObject {

	/** 技能组合Id */
	@ExcelCellBinding(offset = 1)
	protected String composeId;

	/** 技能Id */
	@ExcelCellBinding(offset = 2)
	protected String skillId;

	/** 技能表现说明 */
	@ExcelCellBinding(offset = 3)
	protected String desc;

	/** 技能动作id */
	@ExcelCellBinding(offset = 4)
	protected String actionId;

	/** 技能动作类型(1投掷子弹，2射击子弹，3平推子弹，4其它，5冲锋) */
	@ExcelCellBinding(offset = 5)
	protected int actionType;

	/** 是否近身攻击（1是，0否） */
	@ExcelCellBinding(offset = 6)
	protected int isNearAttack;

	/** 技能影响开始的时间（秒） */
	@ExcelCellBinding(offset = 7)
	protected float impactStartTime;

	/** 技能影响的次数 */
	@ExcelCellBinding(offset = 8)
	protected int impactTimes;

	/** 技能影响的时间间隔（秒） */
	@ExcelCellBinding(offset = 9)
	protected float impactInterval;

	/** 动作完成后除子弹外的特效延迟几秒完成 */
	@ExcelCellBinding(offset = 10)
	protected float effectStopDelayTime;

	/** 技能特效项列表 */
	@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.skill.template.SkillPerformEffectItemTemplate.class, collectionNumber = "11,12,13,14,15,16;17,18,19,20,21,22;23,24,25,26,27,28")
	protected List<com.imop.lj.gameserver.skill.template.SkillPerformEffectItemTemplate> effectItemList;

	/** 受击特效 */
	@ExcelCellBinding(offset = 29)
	protected String blowEffectId;

	/** 被击特效出现位置（1头顶，2胸口，3脚下） */
	@ExcelCellBinding(offset = 30)
	protected int blowEffectPosId;

	/** 技能音效项列表 */
	@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.skill.template.SkillPerformSoundItemTemplate.class, collectionNumber = "31,32,33;34,35,36;37,38,39")
	protected List<com.imop.lj.gameserver.skill.template.SkillPerformSoundItemTemplate> soundItemList;

	/** 总时长（秒） */
	@ExcelCellBinding(offset = 40)
	protected float totalTime;


	public String getComposeId() {
		return this.composeId;
	}

	public void setComposeId(String composeId) {
		if (composeId != null) {
			this.composeId = composeId.trim();
		}else{
			this.composeId = composeId;
		}
	}
	
	public String getSkillId() {
		return this.skillId;
	}

	public void setSkillId(String skillId) {
		if (skillId != null) {
			this.skillId = skillId.trim();
		}else{
			this.skillId = skillId;
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
	
	public String getActionId() {
		return this.actionId;
	}

	public void setActionId(String actionId) {
		if (actionId != null) {
			this.actionId = actionId.trim();
		}else{
			this.actionId = actionId;
		}
	}
	
	public int getActionType() {
		return this.actionType;
	}

	public void setActionType(int actionType) {
		this.actionType = actionType;
	}
	
	public int getIsNearAttack() {
		return this.isNearAttack;
	}

	public void setIsNearAttack(int isNearAttack) {
		this.isNearAttack = isNearAttack;
	}
	
	public float getImpactStartTime() {
		return this.impactStartTime;
	}

	public void setImpactStartTime(float impactStartTime) {
		this.impactStartTime = impactStartTime;
	}
	
	public int getImpactTimes() {
		return this.impactTimes;
	}

	public void setImpactTimes(int impactTimes) {
		this.impactTimes = impactTimes;
	}
	
	public float getImpactInterval() {
		return this.impactInterval;
	}

	public void setImpactInterval(float impactInterval) {
		this.impactInterval = impactInterval;
	}
	
	public float getEffectStopDelayTime() {
		return this.effectStopDelayTime;
	}

	public void setEffectStopDelayTime(float effectStopDelayTime) {
		this.effectStopDelayTime = effectStopDelayTime;
	}
	
	public List<com.imop.lj.gameserver.skill.template.SkillPerformEffectItemTemplate> getEffectItemList() {
		return this.effectItemList;
	}

	public void setEffectItemList(List<com.imop.lj.gameserver.skill.template.SkillPerformEffectItemTemplate> effectItemList) {
		if (effectItemList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					12, "[技能特效项列表]effectItemList不可以为空");
		}	
		this.effectItemList = effectItemList;
	}
	
	public String getBlowEffectId() {
		return this.blowEffectId;
	}

	public void setBlowEffectId(String blowEffectId) {
		if (blowEffectId != null) {
			this.blowEffectId = blowEffectId.trim();
		}else{
			this.blowEffectId = blowEffectId;
		}
	}
	
	public int getBlowEffectPosId() {
		return this.blowEffectPosId;
	}

	public void setBlowEffectPosId(int blowEffectPosId) {
		this.blowEffectPosId = blowEffectPosId;
	}
	
	public List<com.imop.lj.gameserver.skill.template.SkillPerformSoundItemTemplate> getSoundItemList() {
		return this.soundItemList;
	}

	public void setSoundItemList(List<com.imop.lj.gameserver.skill.template.SkillPerformSoundItemTemplate> soundItemList) {
		if (soundItemList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					32, "[技能音效项列表]soundItemList不可以为空");
		}	
		this.soundItemList = soundItemList;
	}
	
	public float getTotalTime() {
		return this.totalTime;
	}

	public void setTotalTime(float totalTime) {
		this.totalTime = totalTime;
	}
	

	@Override
	public String toString() {
		return "SkillPerformTemplateVO[composeId=" + composeId + ",skillId=" + skillId + ",desc=" + desc + ",actionId=" + actionId + ",actionType=" + actionType + ",isNearAttack=" + isNearAttack + ",impactStartTime=" + impactStartTime + ",impactTimes=" + impactTimes + ",impactInterval=" + impactInterval + ",effectStopDelayTime=" + effectStopDelayTime + ",effectItemList=" + effectItemList + ",blowEffectId=" + blowEffectId + ",blowEffectPosId=" + blowEffectPosId + ",soundItemList=" + soundItemList + ",totalTime=" + totalTime + ",]";

	}
}