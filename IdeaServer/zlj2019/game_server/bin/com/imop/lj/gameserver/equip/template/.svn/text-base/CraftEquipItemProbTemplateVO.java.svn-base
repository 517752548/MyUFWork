package com.imop.lj.gameserver.equip.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import java.util.List;

/**
 * 打造-材料提升概率
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class CraftEquipItemProbTemplateVO extends TemplateObject {

	/** 材料提升概率组id */
	@ExcelCellBinding(offset = 1)
	protected int groupId;

	/** 阶数Id */
	@ExcelCellBinding(offset = 2)
	protected int gradeId;

	/** 影响概率值 */
	@ExcelCollectionMapping(clazz = Integer.class, collectionNumber = "3;4;5;6;7")
	protected List<Integer> propList;

	/** 材料最大数量 */
	@ExcelCellBinding(offset = 8)
	protected int maxNum;


	public int getGroupId() {
		return this.groupId;
	}

	public void setGroupId(int groupId) {
		if (groupId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[材料提升概率组id]groupId的值不得小于1");
		}
		this.groupId = groupId;
	}
	
	public int getGradeId() {
		return this.gradeId;
	}

	public void setGradeId(int gradeId) {
		if (gradeId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[阶数Id]gradeId的值不得小于1");
		}
		this.gradeId = gradeId;
	}
	
	public List<Integer> getPropList() {
		return this.propList;
	}

	public void setPropList(List<Integer> propList) {
		if (propList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[影响概率值]propList不可以为空");
		}	
		this.propList = propList;
	}
	
	public int getMaxNum() {
		return this.maxNum;
	}

	public void setMaxNum(int maxNum) {
		if (maxNum < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					9, "[材料最大数量]maxNum的值不得小于1");
		}
		this.maxNum = maxNum;
	}
	

	@Override
	public String toString() {
		return "CraftEquipItemProbTemplateVO[groupId=" + groupId + ",gradeId=" + gradeId + ",propList=" + propList + ",maxNum=" + maxNum + ",]";

	}
}