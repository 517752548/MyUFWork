package com.imop.lj.gameserver.arena.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 竞技场人物技能权重
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class ArenaLeaderSkillWeightTemplateVO extends TemplateObject {

	/** 职业 */
	@ExcelCellBinding(offset = 1)
	protected int jobTypeId;

	/** 技能ID */
	@ExcelCellBinding(offset = 2)
	protected int skillId;

	/** 是否优先施放该技能 */
	@ExcelCellBinding(offset = 3)
	protected int isFirst;

	/** 技能权重 */
	@ExcelCellBinding(offset = 4)
	protected int weight;

	/** 技能冷却回合 */
	@ExcelCellBinding(offset = 5)
	protected int cdRound;


	public int getJobTypeId() {
		return this.jobTypeId;
	}

	public void setJobTypeId(int jobTypeId) {
		if (jobTypeId > 8 || jobTypeId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[职业]jobTypeId的值不合法，应为1至8之间");
		}
		this.jobTypeId = jobTypeId;
	}
	
	public int getSkillId() {
		return this.skillId;
	}

	public void setSkillId(int skillId) {
		if (skillId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[技能ID]skillId的值不得小于1");
		}
		this.skillId = skillId;
	}
	
	public int getIsFirst() {
		return this.isFirst;
	}

	public void setIsFirst(int isFirst) {
		if (isFirst > 1 || isFirst < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[是否优先施放该技能]isFirst的值不合法，应为0至1之间");
		}
		this.isFirst = isFirst;
	}
	
	public int getWeight() {
		return this.weight;
	}

	public void setWeight(int weight) {
		if (weight < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[技能权重]weight的值不得小于1");
		}
		this.weight = weight;
	}
	
	public int getCdRound() {
		return this.cdRound;
	}

	public void setCdRound(int cdRound) {
		if (cdRound < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[技能冷却回合]cdRound的值不得小于0");
		}
		this.cdRound = cdRound;
	}
	

	@Override
	public String toString() {
		return "ArenaLeaderSkillWeightTemplateVO[jobTypeId=" + jobTypeId + ",skillId=" + skillId + ",isFirst=" + isFirst + ",weight=" + weight + ",cdRound=" + cdRound + ",]";

	}
}