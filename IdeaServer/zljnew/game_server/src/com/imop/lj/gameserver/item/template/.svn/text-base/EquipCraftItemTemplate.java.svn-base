package com.imop.lj.gameserver.item.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.common.model.item.AttrDesc;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef.Position;
import com.imop.lj.gameserver.item.feature.ItemFeature;
import com.imop.lj.gameserver.item.feature.NormalFeature;

/**
 * 装备打造材料
 */
@ExcelRowBinding
public class EquipCraftItemTemplate extends EquipCraftItemTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		//合成后的道具id是否存在
		if (this.composeItemId > 0) {
			if (templateService.get(this.composeItemId, ItemTemplate.class) == null) {
				throw new TemplateConfigException(this.getSheetName(), this.getId(), "合成道具Id不存在！" + this.composeItemId);
			}
			if (this.composeNum <= 0) {
				throw new TemplateConfigException(this.getSheetName(), this.getId(), "合成消耗数量非法！" + this.composeNum);
			}
		}
	}
	
	@Override
	public Position getPosition() {
		return Position.NULL;
	}

	@Override
	public ItemFeature initItemFeature(Item item) {
		NormalFeature feature = new NormalFeature(item);
		return feature;
	}

	@Override
	public boolean isConsumable() {
		return false;
	}

	@Override
	public boolean isEquipment() {
		return false;
	}
	
	@Override
	public AttrDesc[] getAllAttrs() {
		return new AttrDesc[0];
	}

	@Override
	public boolean isGem() {
		return false;
	}
	
	@Override
	public boolean isSkillEffectItem() {
		return false;
	}
	
	@Override
	public boolean canCompose() {
		if (this.composeItemId > 0 && this.composeNum > 0) {
			return true;
		}
		return false;
	}
}
