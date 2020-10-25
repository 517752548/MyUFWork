package com.imop.lj.gameserver.equip.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 装备孔数
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class EquipHoleTemplateVO extends TemplateObject {

	/** 装备颜色 */
	@ExcelCellBinding(offset = 1)
	protected int colorId;

	/** 装备等级下限 */
	@ExcelCellBinding(offset = 2)
	protected int levelMin;

	/** 装备等级上限 */
	@ExcelCellBinding(offset = 3)
	protected int levelMax;

	/** 最大孔数 */
	@ExcelCellBinding(offset = 4)
	protected int maxHoleNum;


	public int getColorId() {
		return this.colorId;
	}

	public void setColorId(int colorId) {
		if (colorId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[装备颜色]colorId的值不得小于0");
		}
		this.colorId = colorId;
	}
	
	public int getLevelMin() {
		return this.levelMin;
	}

	public void setLevelMin(int levelMin) {
		if (levelMin < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[装备等级下限]levelMin的值不得小于1");
		}
		this.levelMin = levelMin;
	}
	
	public int getLevelMax() {
		return this.levelMax;
	}

	public void setLevelMax(int levelMax) {
		if (levelMax < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[装备等级上限]levelMax的值不得小于1");
		}
		this.levelMax = levelMax;
	}
	
	public int getMaxHoleNum() {
		return this.maxHoleNum;
	}

	public void setMaxHoleNum(int maxHoleNum) {
		if (maxHoleNum < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[最大孔数]maxHoleNum的值不得小于0");
		}
		this.maxHoleNum = maxHoleNum;
	}
	

	@Override
	public String toString() {
		return "EquipHoleTemplateVO[colorId=" + colorId + ",levelMin=" + levelMin + ",levelMax=" + levelMax + ",maxHoleNum=" + maxHoleNum + ",]";

	}
}