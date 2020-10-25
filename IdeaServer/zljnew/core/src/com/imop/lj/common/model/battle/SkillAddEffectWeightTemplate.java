package com.imop.lj.common.model.battle;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.core.template.BeanFieldNumber;

/**
 * 
 * 技能效果权重模板
 */
@ExcelRowBinding
public class SkillAddEffectWeightTemplate {
	@BeanFieldNumber(number = 1)
	private int effectId;
	@BeanFieldNumber(number = 2)
	private int weight;
	public int getEffectId() {
		return effectId;
	}
	public void setEffectId(int effectId) {
		this.effectId = effectId;
	}
	public int getWeight() {
		return weight;
	}
	public void setWeight(int weight) {
		this.weight = weight;
	}
	@Override
	public String toString() {
		return "SkillAddEffectWeightTemplate [effectId=" + effectId + ", weight=" + weight + "]";
	}
	
	
}
