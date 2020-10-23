package com.imop.lj.gameserver.equip.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 宝石摘除消耗
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class GemDownTemplateVO extends TemplateObject {

	/** 消耗银票 */
	@ExcelCellBinding(offset = 1)
	protected int costGold;

	/** 低级消耗道具Id */
	@ExcelCellBinding(offset = 2)
	protected int itemId1;

	/** 低级消耗道具数量 */
	@ExcelCellBinding(offset = 3)
	protected int itemNum1;

	/** 高级消耗道具Id */
	@ExcelCellBinding(offset = 4)
	protected int itemId2;

	/** 高级消耗道具数量 */
	@ExcelCellBinding(offset = 5)
	protected int itemNum2;


	public int getCostGold() {
		return this.costGold;
	}

	public void setCostGold(int costGold) {
		if (costGold < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[消耗银票]costGold的值不得小于1");
		}
		this.costGold = costGold;
	}
	
	public int getItemId1() {
		return this.itemId1;
	}

	public void setItemId1(int itemId1) {
		if (itemId1 == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[低级消耗道具Id]itemId1不可以为0");
		}
		if (itemId1 < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[低级消耗道具Id]itemId1的值不得小于1");
		}
		this.itemId1 = itemId1;
	}
	
	public int getItemNum1() {
		return this.itemNum1;
	}

	public void setItemNum1(int itemNum1) {
		if (itemNum1 == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[低级消耗道具数量]itemNum1不可以为0");
		}
		if (itemNum1 < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[低级消耗道具数量]itemNum1的值不得小于1");
		}
		this.itemNum1 = itemNum1;
	}
	
	public int getItemId2() {
		return this.itemId2;
	}

	public void setItemId2(int itemId2) {
		if (itemId2 == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[高级消耗道具Id]itemId2不可以为0");
		}
		if (itemId2 < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[高级消耗道具Id]itemId2的值不得小于1");
		}
		this.itemId2 = itemId2;
	}
	
	public int getItemNum2() {
		return this.itemNum2;
	}

	public void setItemNum2(int itemNum2) {
		if (itemNum2 == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[高级消耗道具数量]itemNum2不可以为0");
		}
		if (itemNum2 < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[高级消耗道具数量]itemNum2的值不得小于1");
		}
		this.itemNum2 = itemNum2;
	}
	

	@Override
	public String toString() {
		return "GemDownTemplateVO[costGold=" + costGold + ",itemId1=" + itemId1 + ",itemNum1=" + itemNum1 + ",itemId2=" + itemId2 + ",itemNum2=" + itemNum2 + ",]";

	}
}