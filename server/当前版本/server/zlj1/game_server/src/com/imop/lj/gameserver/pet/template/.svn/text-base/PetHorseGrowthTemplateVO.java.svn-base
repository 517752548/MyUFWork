package com.imop.lj.gameserver.pet.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 宠物成长率
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class PetHorseGrowthTemplateVO extends TemplateObject {

	/** 普通骑宠权重 */
	@ExcelCellBinding(offset = 1)
	protected int normalWeight;

	/** 成长率加成 */
	@ExcelCellBinding(offset = 2)
	protected int add;

	/** 成长率名称多语言Id */
	@ExcelCellBinding(offset = 3)
	protected long nameLangId;

	/** 成长率名称 */
	@ExcelCellBinding(offset = 4)
	protected String name;

	/** 骑宠评分 */
	@ExcelCellBinding(offset = 5)
	protected int petHorseScore;


	public int getNormalWeight() {
		return this.normalWeight;
	}

	public void setNormalWeight(int normalWeight) {
		if (normalWeight < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[普通骑宠权重]normalWeight的值不得小于0");
		}
		this.normalWeight = normalWeight;
	}
	
	public int getAdd() {
		return this.add;
	}

	public void setAdd(int add) {
		if (add < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[成长率加成]add的值不得小于0");
		}
		this.add = add;
	}
	
	public long getNameLangId() {
		return this.nameLangId;
	}

	public void setNameLangId(long nameLangId) {
		this.nameLangId = nameLangId;
	}
	
	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		if (name != null) {
			this.name = name.trim();
		}else{
			this.name = name;
		}
	}
	
	public int getPetHorseScore() {
		return this.petHorseScore;
	}

	public void setPetHorseScore(int petHorseScore) {
		if (petHorseScore < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[骑宠评分]petHorseScore的值不得小于0");
		}
		this.petHorseScore = petHorseScore;
	}
	

	@Override
	public String toString() {
		return "PetHorseGrowthTemplateVO[normalWeight=" + normalWeight + ",add=" + add + ",nameLangId=" + nameLangId + ",name=" + name + ",petHorseScore=" + petHorseScore + ",]";

	}
}