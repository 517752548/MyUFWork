package com.imop.lj.gameserver.item.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;

/**
 * 装备打造材料
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class EquipCraftItemTemplateVO extends ItemTemplate {

	/** 材料组Id */
	@ExcelCellBinding(offset = 38)
	protected int groupId;


	public int getGroupId() {
		return this.groupId;
	}

	public void setGroupId(int groupId) {
		if (groupId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					39, "[材料组Id]groupId的值不得小于1");
		}
		this.groupId = groupId;
	}
	

	@Override
	public String toString() {
		return "EquipCraftItemTemplateVO[groupId=" + groupId + ",]";

	}
}