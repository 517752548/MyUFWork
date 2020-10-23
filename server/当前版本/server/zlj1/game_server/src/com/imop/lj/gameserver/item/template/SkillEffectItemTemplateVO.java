package com.imop.lj.gameserver.item.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;

/**
 * 仙符道具
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class SkillEffectItemTemplateVO extends ItemTemplate {

	/** 技能效果ID */
	@ExcelCellBinding(offset = 34)
	protected int skillEffectId;

	/** 初始经验 */
	@ExcelCellBinding(offset = 35)
	protected int initExp;

	/** 等级上限 */
	@ExcelCellBinding(offset = 36)
	protected int levelMax;

	/** 镶嵌类型（同一类型的不能同时在一个技能上） */
	@ExcelCellBinding(offset = 37)
	protected int embedType;

	/** 是否稀有（稀有的一个技能只能有一个） */
	@ExcelCellBinding(offset = 38)
	protected int uniqueFlag;


	public int getSkillEffectId() {
		return this.skillEffectId;
	}

	public void setSkillEffectId(int skillEffectId) {
		if (skillEffectId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					35, "[技能效果ID]skillEffectId的值不得小于0");
		}
		this.skillEffectId = skillEffectId;
	}
	
	public int getInitExp() {
		return this.initExp;
	}

	public void setInitExp(int initExp) {
		if (initExp < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					36, "[初始经验]initExp的值不得小于1");
		}
		this.initExp = initExp;
	}
	
	public int getLevelMax() {
		return this.levelMax;
	}

	public void setLevelMax(int levelMax) {
		if (levelMax < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					37, "[等级上限]levelMax的值不得小于0");
		}
		this.levelMax = levelMax;
	}
	
	public int getEmbedType() {
		return this.embedType;
	}

	public void setEmbedType(int embedType) {
		if (embedType < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					38, "[镶嵌类型（同一类型的不能同时在一个技能上）]embedType的值不得小于0");
		}
		this.embedType = embedType;
	}
	
	public int getUniqueFlag() {
		return this.uniqueFlag;
	}

	public void setUniqueFlag(int uniqueFlag) {
		if (uniqueFlag < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					39, "[是否稀有（稀有的一个技能只能有一个）]uniqueFlag的值不得小于0");
		}
		this.uniqueFlag = uniqueFlag;
	}
	

	@Override
	public String toString() {
		return "SkillEffectItemTemplateVO[skillEffectId=" + skillEffectId + ",initExp=" + initExp + ",levelMax=" + levelMax + ",embedType=" + embedType + ",uniqueFlag=" + uniqueFlag + ",]";

	}
}