package com.imop.lj.gameserver.pet.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 宠物悟性类别
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class PetPerceptTypeTemplateVO extends TemplateObject {

	/** 物品ID */
	@ExcelCellBinding(offset = 1)
	protected int itemId;

	/** 物品数量 */
	@ExcelCellBinding(offset = 2)
	protected int itemNum;

	/** 货币种类 */
	@ExcelCellBinding(offset = 3)
	protected int currencyType;

	/** 货币数量 */
	@ExcelCellBinding(offset = 4)
	protected int currencyNum;

	/** 对应vip功能Id */
	@ExcelCellBinding(offset = 5)
	protected int vipFuncId;


	public int getItemId() {
		return this.itemId;
	}

	public void setItemId(int itemId) {
		if (itemId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[物品ID]itemId不可以为0");
		}
		if (itemId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[物品ID]itemId的值不得小于0");
		}
		this.itemId = itemId;
	}
	
	public int getItemNum() {
		return this.itemNum;
	}

	public void setItemNum(int itemNum) {
		if (itemNum == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[物品数量]itemNum不可以为0");
		}
		if (itemNum < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[物品数量]itemNum的值不得小于0");
		}
		this.itemNum = itemNum;
	}
	
	public int getCurrencyType() {
		return this.currencyType;
	}

	public void setCurrencyType(int currencyType) {
		if (currencyType == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[货币种类]currencyType不可以为0");
		}
		if (currencyType < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[货币种类]currencyType的值不得小于0");
		}
		this.currencyType = currencyType;
	}
	
	public int getCurrencyNum() {
		return this.currencyNum;
	}

	public void setCurrencyNum(int currencyNum) {
		if (currencyNum == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[货币数量]currencyNum不可以为0");
		}
		if (currencyNum < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[货币数量]currencyNum的值不得小于0");
		}
		this.currencyNum = currencyNum;
	}
	
	public int getVipFuncId() {
		return this.vipFuncId;
	}

	public void setVipFuncId(int vipFuncId) {
		if (vipFuncId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[对应vip功能Id]vipFuncId的值不得小于0");
		}
		this.vipFuncId = vipFuncId;
	}
	

	@Override
	public String toString() {
		return "PetPerceptTypeTemplateVO[itemId=" + itemId + ",itemNum=" + itemNum + ",currencyType=" + currencyType + ",currencyNum=" + currencyNum + ",vipFuncId=" + vipFuncId + ",]";

	}
}