package com.imop.lj.gameserver.wizardraid.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 绿野仙踪-怪物位置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class WizardRaidPositionTemplateVO extends TemplateObject {

	/** 坐标x */
	@ExcelCellBinding(offset = 1)
	protected int x;

	/** 坐标y */
	@ExcelCellBinding(offset = 2)
	protected int y;


	public int getX() {
		return this.x;
	}

	public void setX(int x) {
		if (x < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[坐标x]x的值不得小于0");
		}
		this.x = x;
	}
	
	public int getY() {
		return this.y;
	}

	public void setY(int y) {
		if (y < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[坐标y]y的值不得小于0");
		}
		this.y = y;
	}
	

	@Override
	public String toString() {
		return "WizardRaidPositionTemplateVO[x=" + x + ",y=" + y + ",]";

	}
}