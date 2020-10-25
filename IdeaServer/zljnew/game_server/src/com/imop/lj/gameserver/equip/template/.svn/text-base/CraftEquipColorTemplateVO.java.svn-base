package com.imop.lj.gameserver.equip.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import java.util.List;

/**
 * 打造-颜色概率
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class CraftEquipColorTemplateVO extends TemplateObject {

	/** 组Id */
	@ExcelCellBinding(offset = 1)
	protected int groupId;

	/** 阶数 */
	@ExcelCellBinding(offset = 2)
	protected int gradeId;

	/** 颜色概率列表 */
	@ExcelCollectionMapping(clazz = Integer.class, collectionNumber = "3;4;5;6;7")
	protected List<Integer> propList;


	public int getGroupId() {
		return this.groupId;
	}

	public void setGroupId(int groupId) {
		if (groupId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[组Id]groupId的值不得小于1");
		}
		this.groupId = groupId;
	}
	
	public int getGradeId() {
		return this.gradeId;
	}

	public void setGradeId(int gradeId) {
		if (gradeId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[阶数]gradeId的值不得小于1");
		}
		this.gradeId = gradeId;
	}
	
	public List<Integer> getPropList() {
		return this.propList;
	}

	public void setPropList(List<Integer> propList) {
		if (propList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[颜色概率列表]propList不可以为空");
		}	
		this.propList = propList;
	}
	

	@Override
	public String toString() {
		return "CraftEquipColorTemplateVO[groupId=" + groupId + ",gradeId=" + gradeId + ",propList=" + propList + ",]";

	}
}