package com.imop.lj.gameserver.skill.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.core.template.BeanFieldNumber;

@ExcelRowBinding
public class SkillPerformEffectItemTemplate {
	/**技能特效id*/
	@BeanFieldNumber(number = 1)
	private String effectId;
	
	/**技能特效类型*/
	@BeanFieldNumber(number = 2)
	private int effectType;
	
	/**特效出现目标*/
	@BeanFieldNumber(number = 3)
	private int effectShowTargetType;
	
	/**特效出现位置*/
	@BeanFieldNumber(number = 4)
	private int effectShowPosType;
	
	/**特效对应目标（1每个目标各一个，2所有目标公用一个）*/
	@BeanFieldNumber(number = 5)
	private int effectTargetType;
	
	/**特效出现时间(秒)*/
	@BeanFieldNumber(number = 6)
	private float effectShowTime;

	/**
	 * @return the effectId
	 */
	public String getEffectId() {
		return effectId;
	}

	/**
	 * @param effectId the effectId to set
	 */
	public void setEffectId(String effectId) {
		this.effectId = effectId;
	}

	/**
	 * @return the effectType
	 */
	public int getEffectType() {
		return effectType;
	}

	/**
	 * @param effectType the effectType to set
	 */
	public void setEffectType(int effectType) {
		this.effectType = effectType;
	}

	/**
	 * @return the effectShowTargetType
	 */
	public int getEffectShowTargetType() {
		return effectShowTargetType;
	}

	/**
	 * @param effectShowTargetType the effectShowTargetType to set
	 */
	public void setEffectShowTargetType(int effectShowTargetType) {
		this.effectShowTargetType = effectShowTargetType;
	}

	/**
	 * @return the effectShowPosType
	 */
	public int getEffectShowPosType() {
		return effectShowPosType;
	}

	/**
	 * @param effectShowPosType the effectShowPosType to set
	 */
	public void setEffectShowPosType(int effectShowPosType) {
		this.effectShowPosType = effectShowPosType;
	}

	/**
	 * @return the effectShowTime
	 */
	public float getEffectShowTime() {
		return effectShowTime;
	}

	/**
	 * @param effectShowTime the effectShowTime to set
	 */
	public void setEffectShowTime(float effectShowTime) {
		this.effectShowTime = effectShowTime;
	}

	public int getEffectTargetType() {
		return effectTargetType;
	}

	public void setEffectTargetType(int effectTargetType) {
		this.effectTargetType = effectTargetType;
	}
	
}
