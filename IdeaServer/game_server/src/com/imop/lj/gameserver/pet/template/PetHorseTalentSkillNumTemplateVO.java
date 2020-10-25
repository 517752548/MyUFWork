package com.imop.lj.gameserver.pet.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 骑宠天赋技能数量
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class PetHorseTalentSkillNumTemplateVO extends TemplateObject {

	/** 还童次数下限 */
	@ExcelCellBinding(offset = 1)
	protected int affiMinNum;

	/** 还童次数上限 */
	@ExcelCellBinding(offset = 2)
	protected int affiMaxNum;

	/** 天赋技能数量 */
	@ExcelCellBinding(offset = 3)
	protected int talentSkillNum;

	/** 技能权重 */
	@ExcelCellBinding(offset = 4)
	protected int weight;

	/** 天赋技能开关 */
	@ExcelCellBinding(offset = 5)
	protected int talentSkill1Flag;

	/** 变异开关 */
	@ExcelCellBinding(offset = 6)
	protected int variationFlag;

	/** 成长率卓越完美开关 */
	@ExcelCellBinding(offset = 7)
	protected int growthFlag;


	public int getAffiMinNum() {
		return this.affiMinNum;
	}

	public void setAffiMinNum(int affiMinNum) {
		if (affiMinNum < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[还童次数下限]affiMinNum的值不得小于0");
		}
		this.affiMinNum = affiMinNum;
	}
	
	public int getAffiMaxNum() {
		return this.affiMaxNum;
	}

	public void setAffiMaxNum(int affiMaxNum) {
		if (affiMaxNum < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[还童次数上限]affiMaxNum的值不得小于1");
		}
		this.affiMaxNum = affiMaxNum;
	}
	
	public int getTalentSkillNum() {
		return this.talentSkillNum;
	}

	public void setTalentSkillNum(int talentSkillNum) {
		if (talentSkillNum < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[天赋技能数量]talentSkillNum的值不得小于0");
		}
		this.talentSkillNum = talentSkillNum;
	}
	
	public int getWeight() {
		return this.weight;
	}

	public void setWeight(int weight) {
		if (weight < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[技能权重]weight的值不得小于0");
		}
		this.weight = weight;
	}
	
	public int getTalentSkill1Flag() {
		return this.talentSkill1Flag;
	}

	public void setTalentSkill1Flag(int talentSkill1Flag) {
		if (talentSkill1Flag < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[天赋技能开关]talentSkill1Flag的值不得小于0");
		}
		this.talentSkill1Flag = talentSkill1Flag;
	}
	
	public int getVariationFlag() {
		return this.variationFlag;
	}

	public void setVariationFlag(int variationFlag) {
		if (variationFlag < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[变异开关]variationFlag的值不得小于0");
		}
		this.variationFlag = variationFlag;
	}
	
	public int getGrowthFlag() {
		return this.growthFlag;
	}

	public void setGrowthFlag(int growthFlag) {
		if (growthFlag < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[成长率卓越完美开关]growthFlag的值不得小于0");
		}
		this.growthFlag = growthFlag;
	}
	

	@Override
	public String toString() {
		return "PetHorseTalentSkillNumTemplateVO[affiMinNum=" + affiMinNum + ",affiMaxNum=" + affiMaxNum + ",talentSkillNum=" + talentSkillNum + ",weight=" + weight + ",talentSkill1Flag=" + talentSkill1Flag + ",variationFlag=" + variationFlag + ",growthFlag=" + growthFlag + ",]";

	}
}