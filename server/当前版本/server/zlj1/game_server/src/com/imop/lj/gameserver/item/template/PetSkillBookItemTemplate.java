package com.imop.lj.gameserver.item.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.common.model.item.AttrDesc;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef.Position;
import com.imop.lj.gameserver.item.feature.ItemFeature;
import com.imop.lj.gameserver.item.feature.PetSkillBookFeature;
import com.imop.lj.gameserver.skill.template.SkillTemplate;

/**
 * 宠物技能书
 */
@ExcelRowBinding
public class PetSkillBookItemTemplate extends PetSkillBookItemTemplateVO {
	@Override
	public void check() throws TemplateConfigException {
		if (templateService.get(this.skillTplId, SkillTemplate.class) == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "技能Id不存在！ skillTplId=" + this.skillTplId);
		}
		
		if (this.bookLevel > Globals.getGameConstants().getPetSkillLevelMax()) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "技能书等级超过上限！bookLevel=" + this.bookLevel);
		}
	}

	@Override
	public Position getPosition() {
		return Position.NULL;
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
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public ItemFeature initItemFeature(Item item) {
		PetSkillBookFeature feature = new PetSkillBookFeature(item);
		return feature;
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
