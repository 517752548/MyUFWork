package com.imop.lj.gameserver.pet.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 骑宠培养数值
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class PetHorseTrainPropTemplateVO extends TemplateObject {

	/** 培养方式Id */
	@ExcelCellBinding(offset = 1)
	protected int trainTypeId;

	/** 是否负数，0否1是 */
	@ExcelCellBinding(offset = 2)
	protected int minusFlag;

	/** 数值下限 */
	@ExcelCellBinding(offset = 3)
	protected int propMin;

	/** 数值上限 */
	@ExcelCellBinding(offset = 4)
	protected int propMax;

	/** 权重 */
	@ExcelCellBinding(offset = 5)
	protected int weight;


	public int getTrainTypeId() {
		return this.trainTypeId;
	}

	public void setTrainTypeId(int trainTypeId) {
		if (trainTypeId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[培养方式Id]trainTypeId的值不得小于1");
		}
		this.trainTypeId = trainTypeId;
	}
	
	public int getMinusFlag() {
		return this.minusFlag;
	}

	public void setMinusFlag(int minusFlag) {
		if (minusFlag < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[是否负数，0否1是]minusFlag的值不得小于0");
		}
		this.minusFlag = minusFlag;
	}
	
	public int getPropMin() {
		return this.propMin;
	}

	public void setPropMin(int propMin) {
		if (propMin < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[数值下限]propMin的值不得小于0");
		}
		this.propMin = propMin;
	}
	
	public int getPropMax() {
		return this.propMax;
	}

	public void setPropMax(int propMax) {
		if (propMax < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[数值上限]propMax的值不得小于0");
		}
		this.propMax = propMax;
	}
	
	public int getWeight() {
		return this.weight;
	}

	public void setWeight(int weight) {
		if (weight < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[权重]weight的值不得小于0");
		}
		this.weight = weight;
	}
	

	@Override
	public String toString() {
		return "PetHorseTrainPropTemplateVO[trainTypeId=" + trainTypeId + ",minusFlag=" + minusFlag + ",propMin=" + propMin + ",propMax=" + propMax + ",weight=" + weight + ",]";

	}
}