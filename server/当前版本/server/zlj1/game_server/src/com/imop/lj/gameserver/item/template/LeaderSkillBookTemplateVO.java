package com.imop.lj.gameserver.item.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;

/**
 * 人物技能书
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class LeaderSkillBookTemplateVO extends ItemTemplate {

	/** 职业要求 */
	@ExcelCellBinding(offset = 34)
	protected int jobLimit;

	/** 技能ID */
	@ExcelCellBinding(offset = 35)
	protected int skillId;


	public int getJobLimit() {
		return this.jobLimit;
	}

	public void setJobLimit(int jobLimit) {
		if (jobLimit < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					35, "[职业要求]jobLimit的值不得小于1");
		}
		this.jobLimit = jobLimit;
	}
	
	public int getSkillId() {
		return this.skillId;
	}

	public void setSkillId(int skillId) {
		this.skillId = skillId;
	}
	

	@Override
	public String toString() {
		return "LeaderSkillBookTemplateVO[jobLimit=" + jobLimit + ",skillId=" + skillId + ",]";

	}
}