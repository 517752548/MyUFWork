package com.imop.lj.gameserver.skill.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 技能开格子
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class SkillEffectOpenTemplateVO extends TemplateObject {

	/** 所需道具Id */
	@ExcelCellBinding(offset = 1)
	protected int itemTplId;

	/** 所需道具数量 */
	@ExcelCellBinding(offset = 2)
	protected int itemNum;


	public int getItemTplId() {
		return this.itemTplId;
	}

	public void setItemTplId(int itemTplId) {
		if (itemTplId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[所需道具Id]itemTplId的值不得小于1");
		}
		this.itemTplId = itemTplId;
	}
	
	public int getItemNum() {
		return this.itemNum;
	}

	public void setItemNum(int itemNum) {
		if (itemNum < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[所需道具数量]itemNum的值不得小于1");
		}
		this.itemNum = itemNum;
	}
	

	@Override
	public String toString() {
		return "SkillEffectOpenTemplateVO[itemTplId=" + itemTplId + ",itemNum=" + itemNum + ",]";

	}
}