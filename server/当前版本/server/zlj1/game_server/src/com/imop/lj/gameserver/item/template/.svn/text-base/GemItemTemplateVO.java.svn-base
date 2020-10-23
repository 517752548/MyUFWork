package com.imop.lj.gameserver.item.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;

/**
 * 宠物技能书
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class GemItemTemplateVO extends ItemTemplate {

	/** 宝石类别 */
	@ExcelCellBinding(offset = 34)
	protected int gemType;

	/** 宝石等级 */
	@ExcelCellBinding(offset = 35)
	protected int gemLevel;


	public int getGemType() {
		return this.gemType;
	}

	public void setGemType(int gemType) {
		if (gemType == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					35, "[宝石类别]gemType不可以为0");
		}
		if (gemType < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					35, "[宝石类别]gemType的值不得小于1");
		}
		this.gemType = gemType;
	}
	
	public int getGemLevel() {
		return this.gemLevel;
	}

	public void setGemLevel(int gemLevel) {
		if (gemLevel == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					36, "[宝石等级]gemLevel不可以为0");
		}
		if (gemLevel < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					36, "[宝石等级]gemLevel的值不得小于1");
		}
		this.gemLevel = gemLevel;
	}
	

	@Override
	public String toString() {
		return "GemItemTemplateVO[gemType=" + gemType + ",gemLevel=" + gemLevel + ",]";

	}
}