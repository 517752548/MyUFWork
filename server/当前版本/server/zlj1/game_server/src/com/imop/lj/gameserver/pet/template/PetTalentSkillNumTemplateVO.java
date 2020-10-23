package com.imop.lj.gameserver.pet.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 宠物天赋技能数量
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class PetTalentSkillNumTemplateVO extends TemplateObject {

	/** 数量出现概率,扩大1000倍 */
	@ExcelCellBinding(offset = 1)
	protected int prob;

	/** 变异数量概率,扩大1000倍 */
	@ExcelCellBinding(offset = 2)
	protected int transformProb;


	public int getProb() {
		return this.prob;
	}

	public void setProb(int prob) {
		if (prob < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[数量出现概率,扩大1000倍]prob的值不得小于0");
		}
		this.prob = prob;
	}
	
	public int getTransformProb() {
		return this.transformProb;
	}

	public void setTransformProb(int transformProb) {
		if (transformProb < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[变异数量概率,扩大1000倍]transformProb的值不得小于0");
		}
		this.transformProb = transformProb;
	}
	

	@Override
	public String toString() {
		return "PetTalentSkillNumTemplateVO[prob=" + prob + ",transformProb=" + transformProb + ",]";

	}
}