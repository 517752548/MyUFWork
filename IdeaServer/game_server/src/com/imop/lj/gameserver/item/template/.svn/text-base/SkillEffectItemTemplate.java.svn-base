package com.imop.lj.gameserver.item.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.common.model.item.AttrDesc;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef.ItemType;
import com.imop.lj.gameserver.item.ItemDef.Position;
import com.imop.lj.gameserver.item.feature.ItemFeature;
import com.imop.lj.gameserver.item.feature.NormalFeature;
import com.imop.lj.gameserver.item.feature.SkillEffectItemFeature;
import com.imop.lj.gameserver.skill.template.SkillEffectItemLevelTemplate;
import com.imop.lj.gameserver.skill.template.SkillEffectTemplate;

/**
 * 仙符道具
 */
@ExcelRowBinding
public class SkillEffectItemTemplate extends SkillEffectItemTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		if (ItemType.SKILL_EFFECT_ITEM == getItemType()) {
			if (templateService.get(this.skillEffectId, SkillEffectTemplate.class) == null) {
				throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "技能效果Id不存在！" + this.skillEffectId);
			}
			
			if (templateService.get(this.levelMax, SkillEffectItemLevelTemplate.class) == null) {
				throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "等级上限不存在！ " + this.levelMax);
			}
		} else if (ItemType.SKILL_EFFECT_ITEM_EXP == getItemType()) {
			if (this.skillEffectId != 0) {
				throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "仙符经验道具的技能效果Id必须是0！" + this.skillEffectId);
			}
		}
	}
	
	/**
	 * 是否稀有
	 * @return
	 */
	public boolean isUnique() {
		return this.uniqueFlag == 1;
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
		return null;
	}

	@Override
	public ItemFeature initItemFeature(Item item) {
		if (item.getItemType() == ItemType.SKILL_EFFECT_ITEM) {
			return new SkillEffectItemFeature(item);
		}
		return new NormalFeature(item);
	}

	@Override
	public boolean isGem() {
		return false;
	}
	
	@Override
	public boolean isSkillEffectItem() {
		if (getItemType() == ItemType.SKILL_EFFECT_ITEM) {
			return true;
		}
		return false;
	}
	
	@Override
	public int getMaxOverlap() {
		//仙符的最大叠加数就是1
		if (getItemType() == ItemType.SKILL_EFFECT_ITEM) {
			return 1;
		}
		return super.getMaxOverlap();
	}

	@Override
	public boolean canCompose() {
		return false;
	}
	
}
