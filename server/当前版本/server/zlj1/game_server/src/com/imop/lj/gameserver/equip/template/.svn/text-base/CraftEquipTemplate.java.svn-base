package com.imop.lj.gameserver.equip.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.item.template.EquipItemTemplate;
import com.imop.lj.gameserver.item.template.ItemTemplate;

@ExcelRowBinding
public class CraftEquipTemplate extends CraftEquipTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		//装备验证
		ItemTemplate itemTpl = templateService.get(this.id, ItemTemplate.class);
		if (itemTpl == null || !itemTpl.isEquipment()) {
			throw new TemplateConfigException(this.sheetName, this.id, "装备不存在！ equipmentID="+this.id);
		}
		EquipItemTemplate equipTpl = (EquipItemTemplate)itemTpl;
		if (equipTpl.isFixedEquip()) {
			throw new TemplateConfigException(this.sheetName, this.id, "固定属性的装备不能打造！equipmentID="+this.id);
		}
		//if(this.coins<0||this.coins>Globals.getGameConstants().getGoldAmendUpper()
		//打造等级越界
		if(this.craftLevel<0 || this.craftLevel>Globals.getGameConstants().getLevelMax()){
			throw new TemplateConfigException(this.sheetName, this.id, "打造等级越界！craftLevel=" + craftLevel + ",equipID="+ this.id);
		}
		//this.levelSegment
	}

}
