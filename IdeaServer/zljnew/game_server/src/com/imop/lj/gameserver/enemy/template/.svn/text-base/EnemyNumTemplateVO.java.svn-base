package com.imop.lj.gameserver.enemy.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 遇怪
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class EnemyNumTemplateVO extends TemplateObject {

	/** 最小遇怪数量 */
	@ExcelCellBinding(offset = 1)
	protected int minNum;

	/** 最大遇怪数量 */
	@ExcelCellBinding(offset = 2)
	protected int maxNum;


	public int getMinNum() {
		return this.minNum;
	}

	public void setMinNum(int minNum) {
		if (minNum == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[最小遇怪数量]minNum不可以为0");
		}
		if (minNum < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[最小遇怪数量]minNum的值不得小于1");
		}
		this.minNum = minNum;
	}
	
	public int getMaxNum() {
		return this.maxNum;
	}

	public void setMaxNum(int maxNum) {
		if (maxNum == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[最大遇怪数量]maxNum不可以为0");
		}
		if (maxNum < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[最大遇怪数量]maxNum的值不得小于1");
		}
		this.maxNum = maxNum;
	}
	

	@Override
	public String toString() {
		return "EnemyNumTemplateVO[minNum=" + minNum + ",maxNum=" + maxNum + ",]";

	}
}