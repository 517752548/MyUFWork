package com.imop.lj.gameserver.item.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.common.model.item.AttrDesc;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef.GemType;
import com.imop.lj.gameserver.item.ItemDef.Position;
import com.imop.lj.gameserver.item.feature.ItemFeature;
import com.imop.lj.gameserver.item.feature.NormalFeature;
import com.imop.lj.gameserver.pet.template.PetPropTemplate;
import com.imop.lj.gameserver.role.properties.PropertyType;


@ExcelRowBinding
public class GemItemTemplate extends GemItemTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		//检查属性key是否存在
		boolean isAPropLimit = PetPropTemplate.isValidPropKey(this.propKey, PropertyType.PET_PROP_A);
		boolean isBPropLimit = PetPropTemplate.isValidPropKey(this.propKey, PropertyType.PET_PROP_B);
		if (!isAPropLimit && !isBPropLimit) {
			throw new TemplateConfigException(this.sheetName, this.id, "属性key不存在！key=" + this.propKey);
		}
		if (this.propValue <= 0) {
			throw new TemplateConfigException(this.sheetName, this.id, "属性值非法！" + this.propValue);
		}
		
		//检查宝石颜色是否存在
		if (GemType.valueOf(this.gemTypeId) == null) {
			throw new TemplateConfigException(this.sheetName, this.id, "宝石颜色非法！" + this.gemTypeId);
		}
		
		//宝石等级是否合法
		if (this.gemLevel <= 0 || this.gemLevel > Globals.getGameConstants().getGemMaxLevel()) {
			throw new TemplateConfigException(this.sheetName, this.id, "宝石等级非法！" + this.gemLevel);
		}
		
	}
	
	public int getPropKeyIndex(int propType) {
		return getPropKey() - PropertyType.genPropertyKey(0, propType);
	}
	
	/**
	 * 获取宝石颜色（类型）
	 * @return
	 */
	public GemType getGemType() {
		return GemType.valueOf(this.gemTypeId);
	}
	
	@Override
	public AttrDesc[] getAllAttrs() {
		return null;
	}

	@Override
	public Position getPosition() {
		return Position.NULL;
	}

	@Override
	public boolean isEquipment() {
		return false;
	}

	@Override
	public boolean isConsumable() {
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
	
	@Override
	public boolean canCompose() {
		return false;
	}
}
