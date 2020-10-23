package com.imop.lj.gameserver.equip.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 装备打造
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class CraftEquipTemplateVO extends TemplateObject {

	/** 打造等级 */
	@ExcelCellBinding(offset = 1)
	protected int craftLevel;

	/** 装备等级段 */
	@ExcelCellBinding(offset = 2)
	protected int levelSegment;

	/** 消耗银币 */
	@ExcelCellBinding(offset = 3)
	protected int coins;


	public int getCraftLevel() {
		return this.craftLevel;
	}

	public void setCraftLevel(int craftLevel) {
		if (craftLevel == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[打造等级]craftLevel不可以为0");
		}
		if (craftLevel < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[打造等级]craftLevel的值不得小于1");
		}
		this.craftLevel = craftLevel;
	}
	
	public int getLevelSegment() {
		return this.levelSegment;
	}

	public void setLevelSegment(int levelSegment) {
		if (levelSegment == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[装备等级段]levelSegment不可以为0");
		}
		if (levelSegment < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[装备等级段]levelSegment的值不得小于1");
		}
		this.levelSegment = levelSegment;
	}
	
	public int getCoins() {
		return this.coins;
	}

	public void setCoins(int coins) {
		if (coins == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[消耗银币]coins不可以为0");
		}
		if (coins < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[消耗银币]coins的值不得小于0");
		}
		this.coins = coins;
	}
	

	@Override
	public String toString() {
		return "CraftEquipTemplateVO[craftLevel=" + craftLevel + ",levelSegment=" + levelSegment + ",coins=" + coins + ",]";

	}
}