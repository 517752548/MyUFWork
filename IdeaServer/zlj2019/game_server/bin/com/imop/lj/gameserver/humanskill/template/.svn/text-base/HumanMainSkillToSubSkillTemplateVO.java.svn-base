package com.imop.lj.gameserver.humanskill.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;

/**
 * 人物心法对应人物技能
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class HumanMainSkillToSubSkillTemplateVO extends TemplateObject {

	/** 技能名称 */
	@ExcelCellBinding(offset = 1)
	protected String name;

	/** 心法ID */
	@ExcelCellBinding(offset = 2)
	protected int mainSkillId;

	/** 技能ID */
	@ExcelCellBinding(offset = 3)
	protected int subSkillId;

	/** 描述 */
	@ExcelCellBinding(offset = 4)
	protected String descInfo;

	/** 心法系数 */
	@ExcelCellBinding(offset = 5)
	protected float mindCoefDesc;

	/** 技能系数 */
	@ExcelCellBinding(offset = 6)
	protected float skillCoefDesc;

	/** 系数1 */
	@ExcelCellBinding(offset = 7)
	protected float coef1Desc;

	/** 系数2 */
	@ExcelCellBinding(offset = 8)
	protected float coef2Desc;


	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		if (StringUtils.isEmpty(name)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[技能名称]name不可以为空");
		}
		if (name != null) {
			this.name = name.trim();
		}else{
			this.name = name;
		}
	}
	
	public int getMainSkillId() {
		return this.mainSkillId;
	}

	public void setMainSkillId(int mainSkillId) {
		if (mainSkillId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[心法ID]mainSkillId不可以为0");
		}
		if (mainSkillId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[心法ID]mainSkillId的值不得小于1");
		}
		this.mainSkillId = mainSkillId;
	}
	
	public int getSubSkillId() {
		return this.subSkillId;
	}

	public void setSubSkillId(int subSkillId) {
		if (subSkillId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[技能ID]subSkillId不可以为0");
		}
		if (subSkillId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[技能ID]subSkillId的值不得小于1");
		}
		this.subSkillId = subSkillId;
	}
	
	public String getDescInfo() {
		return this.descInfo;
	}

	public void setDescInfo(String descInfo) {
		if (descInfo != null) {
			this.descInfo = descInfo.trim();
		}else{
			this.descInfo = descInfo;
		}
	}
	
	public float getMindCoefDesc() {
		return this.mindCoefDesc;
	}

	public void setMindCoefDesc(float mindCoefDesc) {
		this.mindCoefDesc = mindCoefDesc;
	}
	
	public float getSkillCoefDesc() {
		return this.skillCoefDesc;
	}

	public void setSkillCoefDesc(float skillCoefDesc) {
		this.skillCoefDesc = skillCoefDesc;
	}
	
	public float getCoef1Desc() {
		return this.coef1Desc;
	}

	public void setCoef1Desc(float coef1Desc) {
		this.coef1Desc = coef1Desc;
	}
	
	public float getCoef2Desc() {
		return this.coef2Desc;
	}

	public void setCoef2Desc(float coef2Desc) {
		this.coef2Desc = coef2Desc;
	}
	

	@Override
	public String toString() {
		return "HumanMainSkillToSubSkillTemplateVO[name=" + name + ",mainSkillId=" + mainSkillId + ",subSkillId=" + subSkillId + ",descInfo=" + descInfo + ",mindCoefDesc=" + mindCoefDesc + ",skillCoefDesc=" + skillCoefDesc + ",coef1Desc=" + coef1Desc + ",coef2Desc=" + coef2Desc + ",]";

	}
}