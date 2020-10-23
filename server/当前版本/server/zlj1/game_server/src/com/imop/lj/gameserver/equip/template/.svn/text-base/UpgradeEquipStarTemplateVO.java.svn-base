package com.imop.lj.gameserver.equip.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 装备位升星
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class UpgradeEquipStarTemplateVO extends TemplateObject {

	/** 基础物品ID */
	@ExcelCellBinding(offset = 1)
	protected int baseItemId;

	/** 基础物品数量 */
	@ExcelCellBinding(offset = 2)
	protected int baseItemNum;

	/** 基本概率 */
	@ExcelCellBinding(offset = 3)
	protected int baseProb;

	/** 额外加成所需物品ID */
	@ExcelCellBinding(offset = 4)
	protected int extraItemId;

	/** 额外概率加成所需物品数量 */
	@ExcelCellBinding(offset = 5)
	protected int extraItemNum;

	/** 额外概率 */
	@ExcelCellBinding(offset = 6)
	protected int extraItemProb;

	/** 加成百分比 */
	@ExcelCellBinding(offset = 7)
	protected int scale;

	/** 开启等级 */
	@ExcelCellBinding(offset = 8)
	protected int level;

	/** 所需银币 */
	@ExcelCellBinding(offset = 9)
	protected int coins;


	public int getBaseItemId() {
		return this.baseItemId;
	}

	public void setBaseItemId(int baseItemId) {
		if (baseItemId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[基础物品ID]baseItemId不可以为0");
		}
		if (baseItemId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[基础物品ID]baseItemId的值不得小于1");
		}
		this.baseItemId = baseItemId;
	}
	
	public int getBaseItemNum() {
		return this.baseItemNum;
	}

	public void setBaseItemNum(int baseItemNum) {
		if (baseItemNum == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[基础物品数量]baseItemNum不可以为0");
		}
		if (baseItemNum < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[基础物品数量]baseItemNum的值不得小于1");
		}
		this.baseItemNum = baseItemNum;
	}
	
	public int getBaseProb() {
		return this.baseProb;
	}

	public void setBaseProb(int baseProb) {
		if (baseProb == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[基本概率]baseProb不可以为0");
		}
		if (baseProb < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[基本概率]baseProb的值不得小于0");
		}
		this.baseProb = baseProb;
	}
	
	public int getExtraItemId() {
		return this.extraItemId;
	}

	public void setExtraItemId(int extraItemId) {
		if (extraItemId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[额外加成所需物品ID]extraItemId不可以为0");
		}
		if (extraItemId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[额外加成所需物品ID]extraItemId的值不得小于1");
		}
		this.extraItemId = extraItemId;
	}
	
	public int getExtraItemNum() {
		return this.extraItemNum;
	}

	public void setExtraItemNum(int extraItemNum) {
		if (extraItemNum == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[额外概率加成所需物品数量]extraItemNum不可以为0");
		}
		if (extraItemNum < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[额外概率加成所需物品数量]extraItemNum的值不得小于1");
		}
		this.extraItemNum = extraItemNum;
	}
	
	public int getExtraItemProb() {
		return this.extraItemProb;
	}

	public void setExtraItemProb(int extraItemProb) {
		if (extraItemProb == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[额外概率]extraItemProb不可以为0");
		}
		if (extraItemProb < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[额外概率]extraItemProb的值不得小于0");
		}
		this.extraItemProb = extraItemProb;
	}
	
	public int getScale() {
		return this.scale;
	}

	public void setScale(int scale) {
		if (scale == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[加成百分比]scale不可以为0");
		}
		if (scale < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[加成百分比]scale的值不得小于0");
		}
		this.scale = scale;
	}
	
	public int getLevel() {
		return this.level;
	}

	public void setLevel(int level) {
		if (level == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					9, "[开启等级]level不可以为0");
		}
		if (level < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					9, "[开启等级]level的值不得小于1");
		}
		this.level = level;
	}
	
	public int getCoins() {
		return this.coins;
	}

	public void setCoins(int coins) {
		if (coins == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					10, "[所需银币]coins不可以为0");
		}
		if (coins < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					10, "[所需银币]coins的值不得小于0");
		}
		this.coins = coins;
	}
	

	@Override
	public String toString() {
		return "UpgradeEquipStarTemplateVO[baseItemId=" + baseItemId + ",baseItemNum=" + baseItemNum + ",baseProb=" + baseProb + ",extraItemId=" + extraItemId + ",extraItemNum=" + extraItemNum + ",extraItemProb=" + extraItemProb + ",scale=" + scale + ",level=" + level + ",coins=" + coins + ",]";

	}
}