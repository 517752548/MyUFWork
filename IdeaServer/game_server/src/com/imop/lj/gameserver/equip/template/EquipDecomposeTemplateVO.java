package com.imop.lj.gameserver.equip.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 装备分解
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class EquipDecomposeTemplateVO extends TemplateObject {

	/** 装备颜色 */
	@ExcelCellBinding(offset = 1)
	protected int color;

	/** 等级下限 */
	@ExcelCellBinding(offset = 2)
	protected int lowLevel;

	/** 等级上限 */
	@ExcelCellBinding(offset = 3)
	protected int hightLevel;

	/** 消耗货币类型 */
	@ExcelCellBinding(offset = 4)
	protected int currencyType;

	/** 消耗货币数量 */
	@ExcelCellBinding(offset = 5)
	protected int currencyNum;

	/** 奖励ID */
	@ExcelCellBinding(offset = 6)
	protected int rewardId;

	/** 是否有效 */
	@ExcelCellBinding(offset = 7)
	protected int isAvailable;


	public int getColor() {
		return this.color;
	}

	public void setColor(int color) {
		if (color < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[装备颜色]color的值不得小于0");
		}
		this.color = color;
	}
	
	public int getLowLevel() {
		return this.lowLevel;
	}

	public void setLowLevel(int lowLevel) {
		if (lowLevel < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[等级下限]lowLevel的值不得小于0");
		}
		this.lowLevel = lowLevel;
	}
	
	public int getHightLevel() {
		return this.hightLevel;
	}

	public void setHightLevel(int hightLevel) {
		if (hightLevel < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[等级上限]hightLevel的值不得小于0");
		}
		this.hightLevel = hightLevel;
	}
	
	public int getCurrencyType() {
		return this.currencyType;
	}

	public void setCurrencyType(int currencyType) {
		if (currencyType == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[消耗货币类型]currencyType不可以为0");
		}
		if (currencyType < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[消耗货币类型]currencyType的值不得小于1");
		}
		this.currencyType = currencyType;
	}
	
	public int getCurrencyNum() {
		return this.currencyNum;
	}

	public void setCurrencyNum(int currencyNum) {
		if (currencyNum < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[消耗货币数量]currencyNum的值不得小于0");
		}
		this.currencyNum = currencyNum;
	}
	
	public int getRewardId() {
		return this.rewardId;
	}

	public void setRewardId(int rewardId) {
		if (rewardId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[奖励ID]rewardId不可以为0");
		}
		if (rewardId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[奖励ID]rewardId的值不得小于0");
		}
		this.rewardId = rewardId;
	}
	
	public int getIsAvailable() {
		return this.isAvailable;
	}

	public void setIsAvailable(int isAvailable) {
		if (isAvailable > 1 || isAvailable < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[是否有效]isAvailable的值不合法，应为0至1之间");
		}
		this.isAvailable = isAvailable;
	}
	

	@Override
	public String toString() {
		return "EquipDecomposeTemplateVO[color=" + color + ",lowLevel=" + lowLevel + ",hightLevel=" + hightLevel + ",currencyType=" + currencyType + ",currencyNum=" + currencyNum + ",rewardId=" + rewardId + ",isAvailable=" + isAvailable + ",]";

	}
}