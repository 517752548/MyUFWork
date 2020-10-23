package com.imop.lj.gameserver.equip.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 镶嵌宝石限制
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class EquipGemLimitTemplateVO extends TemplateObject {

	/** 装备部位Id */
	@ExcelCellBinding(offset = 1)
	protected int posId;

	/** 可镶嵌宝石Id */
	@ExcelCellBinding(offset = 2)
	protected int gemItemId;


	public int getPosId() {
		return this.posId;
	}

	public void setPosId(int posId) {
		if (posId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[装备部位Id]posId的值不得小于1");
		}
		this.posId = posId;
	}
	
	public int getGemItemId() {
		return this.gemItemId;
	}

	public void setGemItemId(int gemItemId) {
		if (gemItemId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[可镶嵌宝石Id]gemItemId的值不得小于1");
		}
		this.gemItemId = gemItemId;
	}
	

	@Override
	public String toString() {
		return "EquipGemLimitTemplateVO[posId=" + posId + ",gemItemId=" + gemItemId + ",]";

	}
}