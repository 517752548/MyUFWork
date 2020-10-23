package com.imop.lj.gameserver.equip.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 装备洗炼
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class EquipRefineryTemplateVO extends TemplateObject {

	/** 装备ID */
	@ExcelCellBinding(offset = 1)
	protected int equipmentID;

	/** 装备等阶 */
	@ExcelCellBinding(offset = 2)
	protected int grade;

	/** 概率 */
	@ExcelCellBinding(offset = 3)
	protected int gradeProb;

	/** 洗练消耗道具ID */
	@ExcelCellBinding(offset = 4)
	protected int itemId;

	/** 洗炼消耗道具数量 */
	@ExcelCellBinding(offset = 5)
	protected int itemNum;

	/** 洗炼消耗银票 */
	@ExcelCellBinding(offset = 6)
	protected int currencyNum;


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
	
	public int getItemId() {
		return this.itemId;
	}

	public void setItemId(int itemId) {
		if (itemId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[洗练消耗道具ID]itemId不可以为0");
		}
		if (itemId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[洗练消耗道具ID]itemId的值不得小于1");
		}
		this.itemId = itemId;
	}
	
	public int getItemNum() {
		return this.itemNum;
	}

	public void setItemNum(int itemNum) {
		this.itemNum = itemNum;
	}
	
	public int getCurrencyNum() {
		return this.currencyNum;
	}

	public void setCurrencyNum(int currencyNum) {
		this.currencyNum = currencyNum;
	}
	

	@Override
	public String toString() {
		return "EquipRefineryTemplateVO[equipmentID=" + equipmentID + ",grade=" + grade + ",gradeProb=" + gradeProb + ",itemId=" + itemId + ",itemNum=" + itemNum + ",currencyNum=" + currencyNum + ",]";

	}
}