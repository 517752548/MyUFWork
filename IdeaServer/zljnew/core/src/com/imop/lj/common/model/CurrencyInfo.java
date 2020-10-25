package com.imop.lj.common.model;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.core.template.BeanFieldNumber;

@ExcelRowBinding
public class CurrencyInfo{
	/** 货币类型 */
	@BeanFieldNumber(number=1)
	private int currencyType;
	/** 货币数量 */
	@BeanFieldNumber(number=2)
	private long num;

	public CurrencyInfo(){
		
	}
	
	public CurrencyInfo(int currencyType, long num){
		this.currencyType = currencyType;
		this.num = num;
	}
	public int getCurrencyType() {
		return currencyType;
	}

	public void setCurrencyType(int currencyType) {
		this.currencyType = currencyType;
	}

	public long getNum() {
		return num;
	}

	public void setNum(long num) {
		this.num = num;
	}

	public CurrencyInfo copySelf(){
		CurrencyInfo info = new CurrencyInfo();
		info.setCurrencyType(currencyType);
		info.setNum(num);
		return info;
	}
	
	@Override
	public String toString(){
		return "[currencyType = " + this.currencyType + ", num = " + num + "]";
	}
}
