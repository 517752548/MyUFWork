package com.imop.lj.gameserver.equip.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 等阶概率
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class CraftEquipGradeTemplateVO extends TemplateObject {

	/** 装备ID */
	@ExcelCellBinding(offset = 1)
	protected int equipmentID;

	/** 装备等阶 */
	@ExcelCellBinding(offset = 2)
	protected int grade;

	/** 概率 */
	@ExcelCellBinding(offset = 3)
	protected int gradeProb;


	public int getEquipmentID() {
		return this.equipmentID;
	}

	public void setEquipmentID(int equipmentID) {
		if (equipmentID == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[装备ID]equipmentID不可以为0");
		}
		this.equipmentID = equipmentID;
	}
	
	public int getGrade() {
		return this.grade;
	}

	public void setGrade(int grade) {
		if (grade == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[装备等阶]grade不可以为0");
		}
		if (grade < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[装备等阶]grade的值不得小于1");
		}
		this.grade = grade;
	}
	
	public int getGradeProb() {
		return this.gradeProb;
	}

	public void setGradeProb(int gradeProb) {
		this.gradeProb = gradeProb;
	}
	

	@Override
	public String toString() {
		return "CraftEquipGradeTemplateVO[equipmentID=" + equipmentID + ",grade=" + grade + ",gradeProb=" + gradeProb + ",]";

	}
}