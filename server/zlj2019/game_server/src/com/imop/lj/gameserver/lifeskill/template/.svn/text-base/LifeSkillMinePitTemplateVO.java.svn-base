package com.imop.lj.gameserver.lifeskill.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 生活技能-采矿-矿坑
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class LifeSkillMinePitTemplateVO extends TemplateObject {

	/** 开启所需的采矿等级 */
	@ExcelCellBinding(offset = 1)
	protected int openNeedMineLevel;


	public int getOpenNeedMineLevel() {
		return this.openNeedMineLevel;
	}

	public void setOpenNeedMineLevel(int openNeedMineLevel) {
		if (openNeedMineLevel == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[开启所需的采矿等级]openNeedMineLevel不可以为0");
		}
		if (openNeedMineLevel < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[开启所需的采矿等级]openNeedMineLevel的值不得小于0");
		}
		this.openNeedMineLevel = openNeedMineLevel;
	}
	

	@Override
	public String toString() {
		return "LifeSkillMinePitTemplateVO[openNeedMineLevel=" + openNeedMineLevel + ",]";

	}
}