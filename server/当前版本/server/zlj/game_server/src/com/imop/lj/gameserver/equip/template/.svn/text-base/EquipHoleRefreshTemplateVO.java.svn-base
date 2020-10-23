package com.imop.lj.gameserver.equip.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 洗孔消耗
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class EquipHoleRefreshTemplateVO extends TemplateObject {

	/** 装备等级下限 */
	@ExcelCellBinding(offset = 1)
	protected int levelMin;

	/** 装备等级上限 */
	@ExcelCellBinding(offset = 2)
	protected int levelMax;

	/** 消耗银票 */
	@ExcelCellBinding(offset = 3)
	protected int costGold;

	/** 消耗道具 */
	@ExcelCellBinding(offset = 4)
	protected int itemId;

	/** 消耗道具数量 */
	@ExcelCellBinding(offset = 5)
	protected int itemNum;


	public int getLevelMin() {
		return this.levelMin;
	}

	public void setLevelMin(int levelMin) {
		if (levelMin < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[装备等级下限]levelMin的值不得小于1");
		}
		this.levelMin = levelMin;
	}
	
	public int getLevelMax() {
		return this.levelMax;
	}

	public void setLevelMax(int levelMax) {
		if (levelMax < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[装备等级上限]levelMax的值不得小于1");
		}
		this.levelMax = levelMax;
	}
	
	public int getCostGold() {
		return this.costGold;
	}

	public void setCostGold(int costGold) {
		if (costGold < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[消耗银票]costGold的值不得小于1");
		}
		this.costGold = costGold;
	}
	
	public int getItemId() {
		return this.itemId;
	}

	public void setItemId(int itemId) {
		if (itemId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[消耗道具]itemId的值不得小于1");
		}
		this.itemId = itemId;
	}
	
	public int getItemNum() {
		return this.itemNum;
	}

	public void setItemNum(int itemNum) {
		if (itemNum < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[消耗道具数量]itemNum的值不得小于1");
		}
		this.itemNum = itemNum;
	}
	

	@Override
	public String toString() {
		return "EquipHoleRefreshTemplateVO[levelMin=" + levelMin + ",levelMax=" + levelMax + ",costGold=" + costGold + ",itemId=" + itemId + ",itemNum=" + itemNum + ",]";

	}
}