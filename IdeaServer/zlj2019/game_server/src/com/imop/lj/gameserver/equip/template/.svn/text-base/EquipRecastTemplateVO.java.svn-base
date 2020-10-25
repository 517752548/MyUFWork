package com.imop.lj.gameserver.equip.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 装备重铸
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class EquipRecastTemplateVO extends TemplateObject {

	/** 是否能够被重铸（1开启，0关闭） */
	@ExcelCellBinding(offset = 1)
	protected int isAbleToRecast;

	/** 重铸消耗货币类型 */
	@ExcelCellBinding(offset = 2)
	protected int currencyType;

	/** 重铸消耗货币数量 */
	@ExcelCellBinding(offset = 3)
	protected int currencyNum;

	/** 重铸消耗道具模板ID */
	@ExcelCellBinding(offset = 4)
	protected int itemId;

	/** 重铸消耗道具数量 */
	@ExcelCellBinding(offset = 5)
	protected int itemNum;


	public int getIsAbleToRecast() {
		return this.isAbleToRecast;
	}

	public void setIsAbleToRecast(int isAbleToRecast) {
		if (isAbleToRecast > 1 || isAbleToRecast < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[是否能够被重铸（1开启，0关闭）]isAbleToRecast的值不合法，应为0至1之间");
		}
		this.isAbleToRecast = isAbleToRecast;
	}
	
	public int getCurrencyType() {
		return this.currencyType;
	}

	public void setCurrencyType(int currencyType) {
		if (currencyType == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[重铸消耗货币类型]currencyType不可以为0");
		}
		if (currencyType < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[重铸消耗货币类型]currencyType的值不得小于1");
		}
		this.currencyType = currencyType;
	}
	
	public int getCurrencyNum() {
		return this.currencyNum;
	}

	public void setCurrencyNum(int currencyNum) {
		this.currencyNum = currencyNum;
	}
	
	public int getItemId() {
		return this.itemId;
	}

	public void setItemId(int itemId) {
		if (itemId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[重铸消耗道具模板ID]itemId不可以为0");
		}
		if (itemId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[重铸消耗道具模板ID]itemId的值不得小于1");
		}
		this.itemId = itemId;
	}
	
	public int getItemNum() {
		return this.itemNum;
	}

	public void setItemNum(int itemNum) {
		this.itemNum = itemNum;
	}
	

	@Override
	public String toString() {
		return "EquipRecastTemplateVO[isAbleToRecast=" + isAbleToRecast + ",currencyType=" + currencyType + ",currencyNum=" + currencyNum + ",itemId=" + itemId + ",itemNum=" + itemNum + ",]";

	}
}