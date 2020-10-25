package com.imop.lj.gameserver.humanskill.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.util.StringUtils;
import java.util.List;

/**
 * 人物技能等级
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class HumanSubSkillLevelTemplateVO extends TemplateObject {

	/** 技能ID */
	@ExcelCellBinding(offset = 1)
	protected int subSkillId;

	/** 技能名称 */
	@ExcelCellBinding(offset = 2)
	protected String name;

	/** 技能等级 */
	@ExcelCellBinding(offset = 3)
	protected int subSkillLevel;

	/** 所需心法等级 */
	@ExcelCellBinding(offset = 4)
	protected int needMainSkillLevel;

	/** 所需玩家等级 */
	@ExcelCellBinding(offset = 5)
	protected int needHumanLevel;

	/** 升级技能层数熟练度列表 */
	@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.humanskill.template.HumanSubSkillCost.class, collectionNumber = "6;7;8;9;10;11;12;13;14;15")
	protected List<com.imop.lj.gameserver.humanskill.template.HumanSubSkillCost> humanSubSkillCostList;

	/** 消耗技能书Id */
	@ExcelCellBinding(offset = 16)
	protected int subSkillBookId;


	public int getSubSkillId() {
		return this.subSkillId;
	}

	public void setSubSkillId(int subSkillId) {
		if (subSkillId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[技能ID]subSkillId不可以为0");
		}
		if (subSkillId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[技能ID]subSkillId的值不得小于1");
		}
		this.subSkillId = subSkillId;
	}
	
	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		if (StringUtils.isEmpty(name)) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[技能名称]name不可以为空");
		}
		if (name != null) {
			this.name = name.trim();
		}else{
			this.name = name;
		}
	}
	
	public int getSubSkillLevel() {
		return this.subSkillLevel;
	}

	public void setSubSkillLevel(int subSkillLevel) {
		if (subSkillLevel == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[技能等级]subSkillLevel不可以为0");
		}
		if (subSkillLevel < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[技能等级]subSkillLevel的值不得小于1");
		}
		this.subSkillLevel = subSkillLevel;
	}
	
	public int getNeedMainSkillLevel() {
		return this.needMainSkillLevel;
	}

	public void setNeedMainSkillLevel(int needMainSkillLevel) {
		if (needMainSkillLevel == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[所需心法等级]needMainSkillLevel不可以为0");
		}
		if (needMainSkillLevel < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[所需心法等级]needMainSkillLevel的值不得小于1");
		}
		this.needMainSkillLevel = needMainSkillLevel;
	}
	
	public int getNeedHumanLevel() {
		return this.needHumanLevel;
	}

	public void setNeedHumanLevel(int needHumanLevel) {
		if (needHumanLevel == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[所需玩家等级]needHumanLevel不可以为0");
		}
		if (needHumanLevel < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[所需玩家等级]needHumanLevel的值不得小于1");
		}
		this.needHumanLevel = needHumanLevel;
	}
	
	public List<com.imop.lj.gameserver.humanskill.template.HumanSubSkillCost> getHumanSubSkillCostList() {
		return this.humanSubSkillCostList;
	}

	public void setHumanSubSkillCostList(List<com.imop.lj.gameserver.humanskill.template.HumanSubSkillCost> humanSubSkillCostList) {
		if (humanSubSkillCostList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[升级技能层数熟练度列表]humanSubSkillCostList不可以为空");
		}	
		this.humanSubSkillCostList = humanSubSkillCostList;
	}
	
	public int getSubSkillBookId() {
		return this.subSkillBookId;
	}

	public void setSubSkillBookId(int subSkillBookId) {
		if (subSkillBookId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					17, "[消耗技能书Id]subSkillBookId不可以为0");
		}
		if (subSkillBookId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					17, "[消耗技能书Id]subSkillBookId的值不得小于1");
		}
		this.subSkillBookId = subSkillBookId;
	}
	

	@Override
	public String toString() {
		return "HumanSubSkillLevelTemplateVO[subSkillId=" + subSkillId + ",name=" + name + ",subSkillLevel=" + subSkillLevel + ",needMainSkillLevel=" + needMainSkillLevel + ",needHumanLevel=" + needHumanLevel + ",humanSubSkillCostList=" + humanSubSkillCostList + ",subSkillBookId=" + subSkillBookId + ",]";

	}
}