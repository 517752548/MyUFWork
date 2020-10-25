package com.imop.lj.gameserver.equip.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 装备锁定属性重铸
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class EquipRecastLockAttrTemplateVO extends TemplateObject {

	/** 重铸装备颜色ID */
	@ExcelCellBinding(offset = 1)
	protected int equipColorId;

	/** 锁定属性条数 */
	@ExcelCellBinding(offset = 2)
	protected int lockNum;

	/** 重铸消耗道具模板ID */
	@ExcelCellBinding(offset = 3)
	protected int itemId;

	/** 重铸消耗道具数量 */
	@ExcelCellBinding(offset = 4)
	protected int itemNum;

	/** 重铸消耗货币类型 */
	@ExcelCellBinding(offset = 5)
	protected int currencyType;

	/** 重铸消耗货币数量 */
	@ExcelCellBinding(offset = 6)
	protected int currencyNum;


	public int getEquipColorId() {
		return this.equipColorId;
	}

	public void setEquipColorId(int equipColorId) {
		if (equipColorId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[重铸装备颜色ID]equipColorId不可以为0");
		}
		this.equipColorId = equipColorId;
	}
	
	public int getLockNum() {
		return this.lockNum;
	}

	public void setLockNum(int lockNum) {
		if (lockNum > 6 || lockNum < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[锁定属性条数]lockNum的值不合法，应为0至6之间");
		}
		this.lockNum = lockNum;
	}
	
	public int getItemId() {
		return this.itemId;
	}

	public void setItemId(int itemId) {
		if (itemId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[重铸消耗道具模板ID]itemId不可以为0");
		}
		if (itemId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[重铸消耗道具模板ID]itemId的值不得小于1");
		}
		this.itemId = itemId;
	}
	
	public int getItemNum() {
		return this.itemNum;
	}

	public void setItemNum(int itemNum) {
		this.itemNum = itemNum;
	}
	
	public int getCurrencyType() {
		return this.currencyType;
	}

	public void setCurrencyType(int currencyType) {
		if (currencyType == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[重铸消耗货币类型]currencyType不可以为0");
		}
		if (currencyType < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[重铸消耗货币类型]currencyType的值不得小于1");
		}
		this.currencyType = currencyType;
	}
	
	public int getCurrencyNum() {
		return this.currencyNum;
	}

	public void setCurrencyNum(int currencyNum) {
		this.currencyNum = currencyNum;
	}
	

	@Override
	public String toString() {
		return "EquipRecastLockAttrTemplateVO[equipColorId=" + equipColorId + ",lockNum=" + lockNum + ",itemId=" + itemId + ",itemNum=" + itemNum + ",currencyType=" + currencyType + ",currencyNum=" + currencyNum + ",]";

	}
}