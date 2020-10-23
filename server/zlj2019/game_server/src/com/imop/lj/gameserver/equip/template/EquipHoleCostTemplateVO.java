package com.imop.lj.gameserver.equip.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 打孔消耗
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class EquipHoleCostTemplateVO extends TemplateObject {

	/** 孔数 */
	@ExcelCellBinding(offset = 1)
	protected int hole;

	/** 装备等级下限 */
	@ExcelCellBinding(offset = 2)
	protected int levelMin;

	/** 装备等级上限 */
	@ExcelCellBinding(offset = 3)
	protected int levelMax;

	/** 消耗银票 */
	@ExcelCellBinding(offset = 4)
	protected int costGold;

	/** 消耗道具 */
	@ExcelCellBinding(offset = 5)
	protected int itemId1;

	/** 消耗道具数量 */
	@ExcelCellBinding(offset = 6)
	protected int itemNum1;

	/** 或消耗道具 */
	@ExcelCellBinding(offset = 7)
	protected int itemId2;

	/** 或消耗道具数量 */
	@ExcelCellBinding(offset = 8)
	protected int itemNum2;


	public int getHole() {
		return this.hole;
	}

	public void setHole(int hole) {
		if (hole < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[孔数]hole的值不得小于1");
		}
		this.hole = hole;
	}
	
	public int getLevelMin() {
		return this.levelMin;
	}

	public void setLevelMin(int levelMin) {
		if (levelMin < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[装备等级下限]levelMin的值不得小于1");
		}
		this.levelMin = levelMin;
	}
	
	public int getLevelMax() {
		return this.levelMax;
	}

	public void setLevelMax(int levelMax) {
		if (levelMax < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[装备等级上限]levelMax的值不得小于1");
		}
		this.levelMax = levelMax;
	}
	
	public int getCostGold() {
		return this.costGold;
	}

	public void setCostGold(int costGold) {
		if (costGold < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[消耗银票]costGold的值不得小于1");
		}
		this.costGold = costGold;
	}
	
	public int getItemId1() {
		return this.itemId1;
	}

	public void setItemId1(int itemId1) {
		if (itemId1 < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[消耗道具]itemId1的值不得小于1");
		}
		this.itemId1 = itemId1;
	}
	
	public int getItemNum1() {
		return this.itemNum1;
	}

	public void setItemNum1(int itemNum1) {
		if (itemNum1 < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[消耗道具数量]itemNum1的值不得小于1");
		}
		this.itemNum1 = itemNum1;
	}
	
	public int getItemId2() {
		return this.itemId2;
	}

	public void setItemId2(int itemId2) {
		if (itemId2 < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[或消耗道具]itemId2的值不得小于0");
		}
		this.itemId2 = itemId2;
	}
	
	public int getItemNum2() {
		return this.itemNum2;
	}

	public void setItemNum2(int itemNum2) {
		if (itemNum2 < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					9, "[或消耗道具数量]itemNum2的值不得小于0");
		}
		this.itemNum2 = itemNum2;
	}
	

	@Override
	public String toString() {
		return "EquipHoleCostTemplateVO[hole=" + hole + ",levelMin=" + levelMin + ",levelMax=" + levelMax + ",costGold=" + costGold + ",itemId1=" + itemId1 + ",itemNum1=" + itemNum1 + ",itemId2=" + itemId2 + ",itemNum2=" + itemNum2 + ",]";

	}
}