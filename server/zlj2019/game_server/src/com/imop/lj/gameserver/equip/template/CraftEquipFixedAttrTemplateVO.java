package com.imop.lj.gameserver.equip.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import java.util.List;

/**
 * 打造-固定属性
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class CraftEquipFixedAttrTemplateVO extends TemplateObject {

	/** 组Id */
	@ExcelCellBinding(offset = 1)
	protected int groupId;

	/** 阶数Id */
	@ExcelCellBinding(offset = 2)
	protected int gradeId;

	/** 属性概率列表 */
	@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.item.template.EquipItemAttribute.class, collectionNumber = "3,4;5,6;7,8")
	protected List<com.imop.lj.gameserver.item.template.EquipItemAttribute> fixeAttrList;


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
					3, "[阶数Id]gradeId的值不得小于1");
		}
		this.gradeId = gradeId;
	}
	
	public List<com.imop.lj.gameserver.item.template.EquipItemAttribute> getFixeAttrList() {
		return this.fixeAttrList;
	}

	public void setFixeAttrList(List<com.imop.lj.gameserver.item.template.EquipItemAttribute> fixeAttrList) {
		if (fixeAttrList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[属性概率列表]fixeAttrList不可以为空");
		}	
		this.fixeAttrList = fixeAttrList;
	}
	

	@Override
	public String toString() {
		return "CraftEquipFixedAttrTemplateVO[groupId=" + groupId + ",gradeId=" + gradeId + ",fixeAttrList=" + fixeAttrList + ",]";

	}
}