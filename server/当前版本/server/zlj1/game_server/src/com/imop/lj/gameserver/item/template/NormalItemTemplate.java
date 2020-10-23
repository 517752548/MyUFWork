package com.imop.lj.gameserver.item.template;

import com.imop.lj.common.model.item.AttrDesc;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef.Position;
import com.imop.lj.gameserver.item.feature.ItemFeature;
import com.imop.lj.gameserver.item.feature.NormalFeature;

/**
 * 普通道具模板
 */
@ExcelRowBinding
public class NormalItemTemplate extends NormalItemTemplateVO {

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
}
