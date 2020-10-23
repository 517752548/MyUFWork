package com.imop.lj.gameserver.item.template;

import com.imop.lj.common.model.item.AttrDesc;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef.Position;
import com.imop.lj.gameserver.item.feature.ItemFeature;
import com.imop.lj.gameserver.item.feature.NormalFeature;


@ExcelRowBinding
public class GemItemTemplate extends GemItemTemplateVO {

	@Override
	public AttrDesc[] getAllAttrs() {
		// TODO 自动生成的方法存根
		return null;
	}

	@Override
	public Position getPosition() {
		// TODO 自动生成的方法存根
		return Position.NULL;
	}

	@Override
	public boolean isEquipment() {
		// TODO 自动生成的方法存根
		return false;
	}

	@Override
	public boolean isConsumable() {
		// TODO 自动生成的方法存根
		return false;
	}

	@Override
	public ItemFeature initItemFeature(Item item) {
		NormalFeature feature = new NormalFeature(item);
		return feature;
	}

	@Override
	public boolean isGem() {
		return true;
	}

	@Override
	public boolean isSkillEffectItem() {
		return false;
	}
}
