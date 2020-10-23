package com.imop.lj.gameserver.equip.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 颜色概率
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class CraftEquipRarityTemplateVO extends TemplateObject {

	/** 装备ID */
	@ExcelCellBinding(offset = 1)
	protected int equipmentID;

	/** 装备颜色 */
	@ExcelCellBinding(offset = 2)
	protected int rarity;

	/** 概率 */
	@ExcelCellBinding(offset = 3)
	protected int rarityProb;


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
	
	public int getRarity() {
		return this.rarity;
	}

	public void setRarity(int rarity) {
		if (rarity == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[装备颜色]rarity不可以为0");
		}
		if (rarity < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[装备颜色]rarity的值不得小于1");
		}
		this.rarity = rarity;
	}
	
	public int getRarityProb() {
		return this.rarityProb;
	}

	public void setRarityProb(int rarityProb) {
		this.rarityProb = rarityProb;
	}
	

	@Override
	public String toString() {
		return "CraftEquipRarityTemplateVO[equipmentID=" + equipmentID + ",rarity=" + rarity + ",rarityProb=" + rarityProb + ",]";

	}
}