package com.imop.lj.gameserver.humanskill.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.core.template.BeanFieldNumber;

@ExcelRowBinding
public class HumanSubSkillCost {
	
	/** 花费类型1 */
	@BeanFieldNumber(number = 1)
	private int currencyType1;
	/** 花费类型1对应数量 */
	@BeanFieldNumber(number = 2)
	private int currencyNum1;
	/** 花费类型1 */
	@BeanFieldNumber(number = 3)
	private int currencyType2;
	/** 花费类型1对应数量 */
	@BeanFieldNumber(number = 4)
	private int currencyNum2;
	
	public HumanSubSkillCost() {
		super();
	}
	
	public HumanSubSkillCost(int currencyType1, int currencyNum1,
			int currencyType2, int currencyNum2) {
		super();
		this.currencyType1 = currencyType1;
		this.currencyNum1 = currencyNum1;
		this.currencyType2 = currencyType2;
		this.currencyNum2 = currencyNum2;
	}

	public int getCurrencyType1() {
		return currencyType1;
	}
	public void setCurrencyType1(int currencyType1) {
		this.currencyType1 = currencyType1;
	}
	public int getCurrencyNum1() {
		return currencyNum1;
	}
	public void setCurrencyNum1(int currencyNum1) {
		this.currencyNum1 = currencyNum1;
	}
	public int getCurrencyType2() {
		return currencyType2;
	}
	public void setCurrencyType2(int currencyType2) {
		this.currencyType2 = currencyType2;
	}
	public int getCurrencyNum2() {
		return currencyNum2;
	}
	public void setCurrencyNum2(int currencyNum2) {
		this.currencyNum2 = currencyNum2;
	}
	
	public int getCost1(double costCoef) {
		return (int)Math.ceil(getCurrencyNum1() * costCoef);
	}
	
	public int getCost2(double costCoef) {
		return (int)Math.ceil(getCurrencyNum2() * costCoef);
	}
	
}
