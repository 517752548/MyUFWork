package com.imop.lj.gameserver.equip.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import java.util.List;

/**
 * 装备-属性权重表
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class EquipPropRandTemplateVO extends TemplateObject {

	/** 单价值数值 */
	@ExcelCellBinding(offset = 2)
	protected int propValue;

	/** 每10级权重 */
	@ExcelCollectionMapping(clazz = Integer.class, collectionNumber = "3;4;5;6;7;8;9;10;11;12")
	protected List<Integer> gradeWeightList;


	public int getPropValue() {
		return this.propValue;
	}

	public void setPropValue(int propValue) {
		if (propValue < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[单价值数值]propValue的值不得小于1");
		}
		this.propValue = propValue;
	}
	
	public List<Integer> getGradeWeightList() {
		return this.gradeWeightList;
	}

	public void setGradeWeightList(List<Integer> gradeWeightList) {
		if (gradeWeightList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[每10级权重]gradeWeightList不可以为空");
		}	
		this.gradeWeightList = gradeWeightList;
	}
	

	@Override
	public String toString() {
		return "EquipPropRandTemplateVO[propValue=" + propValue + ",gradeWeightList=" + gradeWeightList + ",]";

	}
}