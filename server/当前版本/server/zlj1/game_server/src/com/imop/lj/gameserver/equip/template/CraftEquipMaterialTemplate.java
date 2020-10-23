package com.imop.lj.gameserver.equip.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.item.template.ItemTemplate;

@ExcelRowBinding
public class CraftEquipMaterialTemplate extends CraftEquipMaterialTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		// TODO 自动生成的方法存根
		if(templateService.get(equipmentID, CraftEquipTemplate.class)==null){
			throw new TemplateConfigException(this.sheetName, this.id, "装备不存在！ equipmentID="+equipmentID);
		}
		//材料
		if (templateService.get(materialID, ItemTemplate.class)==null) {
			throw new TemplateConfigException(this.sheetName, this.id, "材料不存在！materialID=" + materialID + ",equipID="+ equipmentID);
		}	
	}

}
