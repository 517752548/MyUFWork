package com.imop.lj.gameserver.pet.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 骑宠悟性等级
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class PetHorsePerceptLevelTemplateVO extends TemplateObject {

	/** 悟性经验值 */
	@ExcelCellBinding(offset = 1)
	protected long perceptExp;

	/** 属性附加属性比例 */
	@ExcelCellBinding(offset = 2)
	protected int addtionAttr;

	/** 属性附加等级 */
	@ExcelCellBinding(offset = 3)
	protected int addtionLevel;

	/** 骑宠评分 */
	@ExcelCellBinding(offset = 4)
	protected int petHorseScore;


	public long getPerceptExp() {
		return this.perceptExp;
	}

	public void setPerceptExp(long perceptExp) {
		if (perceptExp < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[悟性经验值]perceptExp的值不得小于0");
		}
		this.perceptExp = perceptExp;
	}
	
	public int getAddtionAttr() {
		return this.addtionAttr;
	}

	public void setAddtionAttr(int addtionAttr) {
		if (addtionAttr == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[属性附加属性比例]addtionAttr不可以为0");
		}
		if (addtionAttr < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[属性附加属性比例]addtionAttr的值不得小于0");
		}
		this.addtionAttr = addtionAttr;
	}
	
	public int getAddtionLevel() {
		return this.addtionLevel;
	}

	public void setAddtionLevel(int addtionLevel) {
		if (addtionLevel == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[属性附加等级]addtionLevel不可以为0");
		}
		if (addtionLevel < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[属性附加等级]addtionLevel的值不得小于0");
		}
		this.addtionLevel = addtionLevel;
	}
	
	public int getPetHorseScore() {
		return this.petHorseScore;
	}

	public void setPetHorseScore(int petHorseScore) {
		if (petHorseScore == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[骑宠评分]petHorseScore不可以为0");
		}
		if (petHorseScore < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[骑宠评分]petHorseScore的值不得小于0");
		}
		this.petHorseScore = petHorseScore;
	}
	

	@Override
	public String toString() {
		return "PetHorsePerceptLevelTemplateVO[perceptExp=" + perceptExp + ",addtionAttr=" + addtionAttr + ",addtionLevel=" + addtionLevel + ",petHorseScore=" + petHorseScore + ",]";

	}
}