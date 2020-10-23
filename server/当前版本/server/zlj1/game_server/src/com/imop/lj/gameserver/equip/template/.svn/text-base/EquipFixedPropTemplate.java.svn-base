package com.imop.lj.gameserver.equip.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.item.ItemDef.Position;
import com.imop.lj.gameserver.item.ItemDef.Rarity;
import com.imop.lj.gameserver.pet.template.PetPropTemplate;
import com.imop.lj.gameserver.role.properties.PropertyType;

/**
 * 装备-固定属性表
 */
@ExcelRowBinding
public class EquipFixedPropTemplate extends EquipFixedPropTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		//装备位置
		if (Position.valueOf(this.positionId) == null) {
			throw new TemplateConfigException(this.sheetName, this.id, "位置Id不存在！positionId=" + positionId);
		}
		
		//阶数
		if (Rarity.valueOf(this.colorId) == null) {
			throw new TemplateConfigException(this.sheetName, this.id, "颜色Id不存在！colorId=" + colorId);
		}
		
		//检查属性key是否存在，不能有空值
		for (int i = 0; i < jobPropList.size(); i++) {
			int k = jobPropList.get(i);
			boolean isAPropBase = PetPropTemplate.isValidPropKey(k, PropertyType.PET_PROP_A);
			boolean isBPropBase = PetPropTemplate.isValidPropKey(k, PropertyType.PET_PROP_B);
			if (!isAPropBase && !isBPropBase) {
				throw new TemplateConfigException(this.sheetName, this.id, "属性key不存在！key=" + k);
			}
		}
	}
	
	public Position getPosition() {
		return Position.valueOf(this.positionId);
	}
	
	public Rarity getColor() {
		return Rarity.valueOf(this.colorId);
	}

}
