package com.imop.lj.gameserver.humanskill.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;

/**
 * 人物技能
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class HumanSubSkillTemplateVO extends TemplateObject {

	/** 名称 */
	@ExcelCellBinding(offset = 1)
	protected String name;

	/** 开启所需人物等级 */
	@ExcelCellBinding(offset = 2)
	protected int needHumanLevel;

	/** 开启所需心法等级 */
	@ExcelCellBinding(offset = 3)
	protected int needMainSkillLevel;

	/** 技能位置 */
	@ExcelCellBinding(offset = 4)
	protected int subSkillPosition;


	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		if (StringUtils.isEmpty(name)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[名称]name不可以为空");
		}
		if (name != null) {
			this.name = name.trim();
		}else{
			this.name = name;
		}
	}
	
	public int getNeedHumanLevel() {
		return this.needHumanLevel;
	}

	public void setNeedHumanLevel(int needHumanLevel) {
		if (needHumanLevel < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[开启所需人物等级]needHumanLevel的值不得小于0");
		}
		this.needHumanLevel = needHumanLevel;
	}
	
	public int getNeedMainSkillLevel() {
		return this.needMainSkillLevel;
	}

	public void setNeedMainSkillLevel(int needMainSkillLevel) {
		if (needMainSkillLevel < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[开启所需心法等级]needMainSkillLevel的值不得小于0");
		}
		this.needMainSkillLevel = needMainSkillLevel;
	}
	
	public int getSubSkillPosition() {
		return this.subSkillPosition;
	}

	public void setSubSkillPosition(int subSkillPosition) {
		if (subSkillPosition < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[技能位置]subSkillPosition的值不得小于0");
		}
		this.subSkillPosition = subSkillPosition;
	}
	

	@Override
	public String toString() {
		return "HumanSubSkillTemplateVO[name=" + name + ",needHumanLevel=" + needHumanLevel + ",needMainSkillLevel=" + needMainSkillLevel + ",subSkillPosition=" + subSkillPosition + ",]";

	}
}