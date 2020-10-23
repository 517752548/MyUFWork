package com.imop.lj.gameserver.equip.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 所需材料
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class CraftEquipMaterialTemplateVO extends TemplateObject {

	/** 装备ID */
	@ExcelCellBinding(offset = 1)
	protected int equipmentID;

	/** 材料ID */
	@ExcelCellBinding(offset = 2)
	protected int materialID;

	/** 消耗材料数量 */
	@ExcelCellBinding(offset = 3)
	protected int materialNum;

	/** 单个材料消耗银币 */
	@ExcelCellBinding(offset = 4)
	protected int coins;


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
	
	public int getMaterialID() {
		return this.materialID;
	}

	public void setMaterialID(int materialID) {
		if (materialID == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[材料ID]materialID不可以为0");
		}
		this.materialID = materialID;
	}
	
	public int getMaterialNum() {
		return this.materialNum;
	}

	public void setMaterialNum(int materialNum) {
		if (materialNum == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[消耗材料数量]materialNum不可以为0");
		}
		if (materialNum < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[消耗材料数量]materialNum的值不得小于1");
		}
		this.materialNum = materialNum;
	}
	
	public int getCoins() {
		return this.coins;
	}

	public void setCoins(int coins) {
		if (coins == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[单个材料消耗银币]coins不可以为0");
		}
		if (coins < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[单个材料消耗银币]coins的值不得小于0");
		}
		this.coins = coins;
	}
	

	@Override
	public String toString() {
		return "CraftEquipMaterialTemplateVO[equipmentID=" + equipmentID + ",materialID=" + materialID + ",materialNum=" + materialNum + ",coins=" + coins + ",]";

	}
}