package com.imop.lj.gameserver.equip.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import java.util.List;

/**
 * 打造-打造花费
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class CraftEquipCostTemplateVO extends TemplateObject {

	/** 装备ID */
	@ExcelCellBinding(offset = 1)
	protected int equipId;

	/** 装备类别Id */
	@ExcelCellBinding(offset = 2)
	protected int equipTypeId;

	/** 是否可打造（0不可，1可以） */
	@ExcelCellBinding(offset = 3)
	protected int canCraftFlag;

	/** 装备等级下限 */
	@ExcelCellBinding(offset = 4)
	protected int levelMin;

	/** 装备等级上限 */
	@ExcelCellBinding(offset = 5)
	protected int levelMax;

	/** 颜色概率-组Id */
	@ExcelCellBinding(offset = 6)
	protected int colorGroupId;

	/** 花费银票 */
	@ExcelCellBinding(offset = 7)
	protected int costGold;

	/** 消耗道具列表 */
	@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.equip.template.CraftEquipCostItem.class, collectionNumber = "8,9;10,11;12,13")
	protected List<com.imop.lj.gameserver.equip.template.CraftEquipCostItem> costItemList;

	/** 配方Id */
	@ExcelCellBinding(offset = 14)
	protected int recipeId;

	/** 固定属性组Id */
	@ExcelCellBinding(offset = 15)
	protected int fixedAttrGroupId;

	/** 材料提升概率组id */
	@ExcelCellBinding(offset = 16)
	protected int itemProbGroupId;


	public int getEquipId() {
		return this.equipId;
	}

	public void setEquipId(int equipId) {
		if (equipId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[装备ID]equipId的值不得小于1");
		}
		this.equipId = equipId;
	}
	
	public int getEquipTypeId() {
		return this.equipTypeId;
	}

	public void setEquipTypeId(int equipTypeId) {
		if (equipTypeId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[装备类别Id]equipTypeId的值不得小于1");
		}
		this.equipTypeId = equipTypeId;
	}
	
	public int getCanCraftFlag() {
		return this.canCraftFlag;
	}

	public void setCanCraftFlag(int canCraftFlag) {
		if (canCraftFlag > 1 || canCraftFlag < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[是否可打造（0不可，1可以）]canCraftFlag的值不合法，应为0至1之间");
		}
		this.canCraftFlag = canCraftFlag;
	}
	
	public int getLevelMin() {
		return this.levelMin;
	}

	public void setLevelMin(int levelMin) {
		if (levelMin < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[装备等级下限]levelMin的值不得小于1");
		}
		this.levelMin = levelMin;
	}
	
	public int getLevelMax() {
		return this.levelMax;
	}

	public void setLevelMax(int levelMax) {
		if (levelMax < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[装备等级上限]levelMax的值不得小于1");
		}
		this.levelMax = levelMax;
	}
	
	public int getColorGroupId() {
		return this.colorGroupId;
	}

	public void setColorGroupId(int colorGroupId) {
		if (colorGroupId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[颜色概率-组Id]colorGroupId的值不得小于1");
		}
		this.colorGroupId = colorGroupId;
	}
	
	public int getCostGold() {
		return this.costGold;
	}

	public void setCostGold(int costGold) {
		if (costGold < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[花费银票]costGold的值不得小于1");
		}
		this.costGold = costGold;
	}
	
	public List<com.imop.lj.gameserver.equip.template.CraftEquipCostItem> getCostItemList() {
		return this.costItemList;
	}

	public void setCostItemList(List<com.imop.lj.gameserver.equip.template.CraftEquipCostItem> costItemList) {
		if (costItemList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					9, "[消耗道具列表]costItemList不可以为空");
		}	
		this.costItemList = costItemList;
	}
	
	public int getRecipeId() {
		return this.recipeId;
	}

	public void setRecipeId(int recipeId) {
		if (recipeId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					15, "[配方Id]recipeId的值不得小于1");
		}
		this.recipeId = recipeId;
	}
	
	public int getFixedAttrGroupId() {
		return this.fixedAttrGroupId;
	}

	public void setFixedAttrGroupId(int fixedAttrGroupId) {
		if (fixedAttrGroupId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					16, "[固定属性组Id]fixedAttrGroupId的值不得小于1");
		}
		this.fixedAttrGroupId = fixedAttrGroupId;
	}
	
	public int getItemProbGroupId() {
		return this.itemProbGroupId;
	}

	public void setItemProbGroupId(int itemProbGroupId) {
		if (itemProbGroupId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					17, "[材料提升概率组id]itemProbGroupId的值不得小于1");
		}
		this.itemProbGroupId = itemProbGroupId;
	}
	

	@Override
	public String toString() {
		return "CraftEquipCostTemplateVO[equipId=" + equipId + ",equipTypeId=" + equipTypeId + ",canCraftFlag=" + canCraftFlag + ",levelMin=" + levelMin + ",levelMax=" + levelMax + ",colorGroupId=" + colorGroupId + ",costGold=" + costGold + ",costItemList=" + costItemList + ",recipeId=" + recipeId + ",fixedAttrGroupId=" + fixedAttrGroupId + ",itemProbGroupId=" + itemProbGroupId + ",]";

	}
}