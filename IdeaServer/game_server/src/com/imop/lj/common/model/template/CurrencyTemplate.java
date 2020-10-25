package com.imop.lj.common.model.template;

import com.imop.lj.common.model.CurrencyInfo;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.core.template.BeanFieldNumber;

@ExcelRowBinding
public class CurrencyTemplate {
	/** 货币类型 */
	@BeanFieldNumber(number = 1)
	private int currencyType;
	/** 货币数量 */
	@BeanFieldNumber(number = 2)
	private int num;

	public int getCurrencyType() {
		return currencyType;
	}

	public void setCurrencyType(int currencyType) {
		this.currencyType = currencyType;
	}

	public int getNum() {
		return num;
	}

	public void setNum(int num) {
		this.num = num;
	}
	
	/**
	 * 根据货币模版获取货币信息
	 * 
	 * @return
	 */
	public CurrencyInfo getCurrencyInfo() {
		CurrencyInfo currencyInfo = new CurrencyInfo();
		currencyInfo.setCurrencyType(this.currencyType);
		currencyInfo.setNum(this.num);
		return currencyInfo;
	}
	
	@Override
	public String toString(){
		return "currencyType = " + currencyType + ", num = " + num;
	}
}
