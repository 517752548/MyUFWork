package com.imop.lj.gameserver.equip.template;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.item.ItemDef.Recipe;
import com.imop.lj.gameserver.item.template.EquipItemTemplate;
import com.imop.lj.gameserver.item.template.ItemTemplate;

/**
 * 打造-打造花费
 */
@ExcelRowBinding
public class CraftEquipCostTemplate extends CraftEquipCostTemplateVO {
	//过滤非法数据消耗道具列表
	private List<CraftEquipCostItem> validCostList = new ArrayList<CraftEquipCostItem>();
	
	@Override
	public void check() throws TemplateConfigException {
		ItemTemplate itemTpl = templateService.get(this.equipId, ItemTemplate.class);
		if (itemTpl == null || !itemTpl.isEquipment()) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "装备ID不存在！" + this.equipId);
		}
		EquipItemTemplate equipTpl = (EquipItemTemplate) itemTpl;
		if (equipTpl.isFixedEquip()) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "固定属性的装备不能打造！" + this.equipId);
		}
		
		if (templateService.get(this.equipTypeId, CraftEquipTypeTemplate.class) == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "装备类别Id不存在！" + this.equipId);
		}
		
		if (Recipe.valueOf(this.recipeId) == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "配方Id不存在！" + this.recipeId);
		}
		
		//过滤掉为0的数据
		for (CraftEquipCostItem cc : costItemList) {
			if (cc.getGroupId() != 0 && cc.getNum() > 0) {
				validCostList.add(cc);
			}
		}
		
	}
	
//	public Recipe getRecipe() {
//		return Recipe.valueOf(this.recipeId);
//	}

	public List<CraftEquipCostItem> getValidCostList() {
		return validCostList;
	}

	/**
	 * 是否玩家可以直接打造的装备
	 * @return
	 */
	public boolean canCraft() {
		return this.canCraftFlag == 1;
	}
}
