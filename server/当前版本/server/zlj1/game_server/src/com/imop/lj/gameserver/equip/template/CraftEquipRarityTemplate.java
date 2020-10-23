package com.imop.lj.gameserver.equip.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.item.ItemDef.Rarity;

@ExcelRowBinding
public class CraftEquipRarityTemplate extends CraftEquipRarityTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		// TODO 自动生成的方法存根
		if(templateService.get(equipmentID, CraftEquipTemplate.class)==null){
			throw new TemplateConfigException(this.sheetName, this.id, "装备不存在！ equipmentID="+equipmentID);
		}
		//颜色
		if (Rarity.valueOf(rarity) == null) {
			throw new TemplateConfigException(this.sheetName, this.id, "颜色不存在！rarityId=" + rarity + ",equipID="+ equipmentID);
		}	
		//颜色概率
		if(rarityProb<0 || this.rarityProb>Globals.getGameConstants().getRandomBase()){
			throw new TemplateConfigException(this.sheetName, this.id, "颜色概率越界！rarityId=" + rarity + ",equipID="+ equipmentID);
		}
	}

}
