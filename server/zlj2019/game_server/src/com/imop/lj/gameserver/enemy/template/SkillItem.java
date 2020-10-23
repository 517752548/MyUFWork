package com.imop.lj.gameserver.enemy.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.core.template.BeanFieldNumber;

@ExcelRowBinding
public class SkillItem {
	/**技能id*/
	@BeanFieldNumber(number = 1)
	private int skillId;
	
	/**技能权重*/
	@BeanFieldNumber(number = 2)
	private int weight;
	
	/**技能冷却回合数*/
	@BeanFieldNumber(number = 3)
	private int cdRound;

	public int getSkillId() {
		return skillId;
	}

	public void setSkillId(int skillId) {
		this.skillId = skillId;
	}

	public int getWeight() {
		return weight;
	}

	public void setWeight(int weight) {
		this.weight = weight;
	}

	public int getCdRound() {
		return cdRound;
	}

	public void setCdRound(int cdRound) {
		this.cdRound = cdRound;
	}
	
}
