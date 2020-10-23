package com.imop.lj.gameserver.pet.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 宠物悟性提升经验
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class PetPerceptPromoteTemplateVO extends TemplateObject {

	/** 提升方式 */
	@ExcelCellBinding(offset = 1)
	protected int promoteType;

	/** 悟性等级 */
	@ExcelCellBinding(offset = 2)
	protected int perceptLevel;

	/** 单次提供经验 */
	@ExcelCellBinding(offset = 3)
	protected int singleExp;

	/** 单次小暴击概率 */
	@ExcelCellBinding(offset = 4)
	protected int singleSmallCritProp;

	/** 单次大暴击概率 */
	@ExcelCellBinding(offset = 5)
	protected int singleBigCritProp;

	/** 批量小暴击概率 */
	@ExcelCellBinding(offset = 6)
	protected int batchSmallCritProp;

	/** 批量大暴击概率 */
	@ExcelCellBinding(offset = 7)
	protected int batchBigCritProp;


	public int getPromoteType() {
		return this.promoteType;
	}

	public void setPromoteType(int promoteType) {
		if (promoteType == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[提升方式]promoteType不可以为0");
		}
		if (promoteType < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[提升方式]promoteType的值不得小于0");
		}
		this.promoteType = promoteType;
	}
	
	public int getPerceptLevel() {
		return this.perceptLevel;
	}

	public void setPerceptLevel(int perceptLevel) {
		if (perceptLevel == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[悟性等级]perceptLevel不可以为0");
		}
		if (perceptLevel < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[悟性等级]perceptLevel的值不得小于0");
		}
		this.perceptLevel = perceptLevel;
	}
	
	public int getSingleExp() {
		return this.singleExp;
	}

	public void setSingleExp(int singleExp) {
		if (singleExp < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[单次提供经验]singleExp的值不得小于0");
		}
		this.singleExp = singleExp;
	}
	
	public int getSingleSmallCritProp() {
		return this.singleSmallCritProp;
	}

	public void setSingleSmallCritProp(int singleSmallCritProp) {
		if (singleSmallCritProp < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[单次小暴击概率]singleSmallCritProp的值不得小于0");
		}
		this.singleSmallCritProp = singleSmallCritProp;
	}
	
	public int getSingleBigCritProp() {
		return this.singleBigCritProp;
	}

	public void setSingleBigCritProp(int singleBigCritProp) {
		if (singleBigCritProp < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[单次大暴击概率]singleBigCritProp的值不得小于0");
		}
		this.singleBigCritProp = singleBigCritProp;
	}
	
	public int getBatchSmallCritProp() {
		return this.batchSmallCritProp;
	}

	public void setBatchSmallCritProp(int batchSmallCritProp) {
		if (batchSmallCritProp < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[批量小暴击概率]batchSmallCritProp的值不得小于0");
		}
		this.batchSmallCritProp = batchSmallCritProp;
	}
	
	public int getBatchBigCritProp() {
		return this.batchBigCritProp;
	}

	public void setBatchBigCritProp(int batchBigCritProp) {
		if (batchBigCritProp < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[批量大暴击概率]batchBigCritProp的值不得小于0");
		}
		this.batchBigCritProp = batchBigCritProp;
	}
	

	@Override
	public String toString() {
		return "PetPerceptPromoteTemplateVO[promoteType=" + promoteType + ",perceptLevel=" + perceptLevel + ",singleExp=" + singleExp + ",singleSmallCritProp=" + singleSmallCritProp + ",singleBigCritProp=" + singleBigCritProp + ",batchSmallCritProp=" + batchSmallCritProp + ",batchBigCritProp=" + batchBigCritProp + ",]";

	}
}