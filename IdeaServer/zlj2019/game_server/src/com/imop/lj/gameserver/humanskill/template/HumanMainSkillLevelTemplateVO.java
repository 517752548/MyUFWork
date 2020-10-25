package com.imop.lj.gameserver.humanskill.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 人物心法等级
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class HumanMainSkillLevelTemplateVO extends TemplateObject {

	/** 货币类型1 */
	@ExcelCellBinding(offset = 1)
	protected int currencyType1;

	/** 货币数量1 */
	@ExcelCellBinding(offset = 2)
	protected int currencyNum1;

	/** 货币类型2 */
	@ExcelCellBinding(offset = 3)
	protected int currencyType2;

	/** 货币数量2 */
	@ExcelCellBinding(offset = 4)
	protected int currencyNum2;


	public int getCurrencyType1() {
		return this.currencyType1;
	}

	public void setCurrencyType1(int currencyType1) {
		if (currencyType1 < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[货币类型1]currencyType1的值不得小于0");
		}
		this.currencyType1 = currencyType1;
	}
	
	public int getCurrencyNum1() {
		return this.currencyNum1;
	}

	public void setCurrencyNum1(int currencyNum1) {
		if (currencyNum1 < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[货币数量1]currencyNum1的值不得小于0");
		}
		this.currencyNum1 = currencyNum1;
	}
	
	public int getCurrencyType2() {
		return this.currencyType2;
	}

	public void setCurrencyType2(int currencyType2) {
		if (currencyType2 < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[货币类型2]currencyType2的值不得小于0");
		}
		this.currencyType2 = currencyType2;
	}
	
	public int getCurrencyNum2() {
		return this.currencyNum2;
	}

	public void setCurrencyNum2(int currencyNum2) {
		if (currencyNum2 < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[货币数量2]currencyNum2的值不得小于0");
		}
		this.currencyNum2 = currencyNum2;
	}
	

	@Override
	public String toString() {
		return "HumanMainSkillLevelTemplateVO[currencyType1=" + currencyType1 + ",currencyNum1=" + currencyNum1 + ",currencyType2=" + currencyType2 + ",currencyNum2=" + currencyNum2 + ",]";

	}
}