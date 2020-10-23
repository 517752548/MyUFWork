package com.imop.lj.gameserver.equip.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import java.util.List;

/**
 * 装备-固定属性表
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class EquipFixedPropTemplateVO extends TemplateObject {

	/** 装备部位Id */
	@ExcelCellBinding(offset = 1)
	protected int positionId;

	/** 颜色Id */
	@ExcelCellBinding(offset = 2)
	protected int colorId;

	/** 按职业固定属性列表 */
	@ExcelCollectionMapping(clazz = Integer.class, collectionNumber = "3;4;5;6")
	protected List<Integer> jobPropList;


	public int getPositionId() {
		return this.positionId;
	}

	public void setPositionId(int positionId) {
		if (positionId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[装备部位Id]positionId的值不得小于1");
		}
		this.positionId = positionId;
	}
	
	public int getColorId() {
		return this.colorId;
	}

	public void setColorId(int colorId) {
		if (colorId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[颜色Id]colorId的值不得小于1");
		}
		this.colorId = colorId;
	}
	
	public List<Integer> getJobPropList() {
		return this.jobPropList;
	}

	public void setJobPropList(List<Integer> jobPropList) {
		if (jobPropList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[按职业固定属性列表]jobPropList不可以为空");
		}	
		this.jobPropList = jobPropList;
	}
	

	@Override
	public String toString() {
		return "EquipFixedPropTemplateVO[positionId=" + positionId + ",colorId=" + colorId + ",jobPropList=" + jobPropList + ",]";

	}
}