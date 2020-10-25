package com.imop.lj.gameserver.lifeskill.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 生活技能-采矿-消耗
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class LifeSkillMineCostTemplateVO extends TemplateObject {

	/** 消耗货币类型 */
	@ExcelCellBinding(offset = 1)
	protected int currencyType;

	/** 消耗货币数量 */
	@ExcelCellBinding(offset = 2)
	protected int currencyNum;

	/** 消耗时间/小时 */
	@ExcelCellBinding(offset = 3)
	protected int costTime;


	public int getCurrencyType() {
		return this.currencyType;
	}

	public void setCurrencyType(int currencyType) {
		if (currencyType == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[消耗货币类型]currencyType不可以为0");
		}
		if (currencyType < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[消耗货币类型]currencyType的值不得小于1");
		}
		this.currencyType = currencyType;
	}
	
	public int getCurrencyNum() {
		return this.currencyNum;
	}

	public void setCurrencyNum(int currencyNum) {
		if (currencyNum < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[消耗货币数量]currencyNum的值不得小于0");
		}
		this.currencyNum = currencyNum;
	}
	
	public int getCostTime() {
		return this.costTime;
	}

	public void setCostTime(int costTime) {
		if (costTime < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[消耗时间/小时]costTime的值不得小于0");
		}
		this.costTime = costTime;
	}
	

	@Override
	public String toString() {
		return "LifeSkillMineCostTemplateVO[currencyType=" + currencyType + ",currencyNum=" + currencyNum + ",costTime=" + costTime + ",]";

	}
}