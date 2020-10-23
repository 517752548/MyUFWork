package com.imop.lj.common.model.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.core.template.BeanFieldNumber;

@ExcelRowBinding
public class ItemCostPriceTemplate {
	@BeanFieldNumber(number = 1)
	private int itemTempId;
	@BeanFieldNumber(number = 2)
	private int num;
	@BeanFieldNumber(number = 3)
	private int price;

	public int getItemTempId() {
		return itemTempId;
	}

	public void setItemTempId(int itemTempId) {
		this.itemTempId = itemTempId;
	}

	public int getNum() {
		return num;
	}

	public void setNum(int num) {
		this.num = num;
	}

	public int getPrice() {
		return price;
	}

	public void setPrice(int price) {
		this.price = price;
	}

}
