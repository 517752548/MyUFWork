package com.imop.lj.gameserver.enemy.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 挂机满怪遇怪数量
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class EnemyGuaJiNumTemplateVO extends TemplateObject {

	/** 最大遇怪数量 */
	@ExcelCellBinding(offset = 1)
	protected int maxNum;


	public int getMaxNum() {
		return this.maxNum;
	}

	public void setMaxNum(int maxNum) {
		if (maxNum == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[最大遇怪数量]maxNum不可以为0");
		}
		if (maxNum < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[最大遇怪数量]maxNum的值不得小于1");
		}
		this.maxNum = maxNum;
	}
	

	@Override
	public String toString() {
		return "EnemyGuaJiNumTemplateVO[maxNum=" + maxNum + ",]";

	}
}