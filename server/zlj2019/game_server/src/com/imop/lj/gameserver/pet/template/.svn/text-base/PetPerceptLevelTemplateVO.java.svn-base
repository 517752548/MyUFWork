package com.imop.lj.gameserver.pet.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 宠物悟性等级
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class PetPerceptLevelTemplateVO extends TemplateObject {

	/** 悟性经验值 */
	@ExcelCellBinding(offset = 1)
	protected long perceptExp;

	/** 属性附加属性比例 */
	@ExcelCellBinding(offset = 2)
	protected int addtionAttr;

	/** 属性附加等级 */
	@ExcelCellBinding(offset = 3)
	protected int addtionLevel;

	/** 宠物评分 */
	@ExcelCellBinding(offset = 4)
	protected int petScore;


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
	
	public int getPetScore() {
		return this.petScore;
	}

	public void setPetScore(int petScore) {
		if (petScore == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[宠物评分]petScore不可以为0");
		}
		if (petScore < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[宠物评分]petScore的值不得小于0");
		}
		this.petScore = petScore;
	}
	

	@Override
	public String toString() {
		return "PetPerceptLevelTemplateVO[perceptExp=" + perceptExp + ",addtionAttr=" + addtionAttr + ",addtionLevel=" + addtionLevel + ",petScore=" + petScore + ",]";

	}
}