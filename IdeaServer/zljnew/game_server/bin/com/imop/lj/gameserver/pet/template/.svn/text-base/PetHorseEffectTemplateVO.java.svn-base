package com.imop.lj.gameserver.pet.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import java.util.List;

/**
 * 骑宠悟性类别
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class PetHorseEffectTemplateVO extends TemplateObject {

	/** 基础属性列表，目前只有一组 */
	@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.item.template.EquipItemAttribute.class, collectionNumber = "1,2;3,4;5,6;7,8;9,10;11,12")
	protected List<com.imop.lj.gameserver.item.template.EquipItemAttribute> basePropList;


	public List<com.imop.lj.gameserver.item.template.EquipItemAttribute> getBasePropList() {
		return this.basePropList;
	}

	public void setBasePropList(List<com.imop.lj.gameserver.item.template.EquipItemAttribute> basePropList) {
		if (basePropList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[基础属性列表，目前只有一组]basePropList不可以为空");
		}	
		this.basePropList = basePropList;
	}
	

	@Override
	public String toString() {
		return "PetHorseEffectTemplateVO[basePropList=" + basePropList + ",]";

	}
}