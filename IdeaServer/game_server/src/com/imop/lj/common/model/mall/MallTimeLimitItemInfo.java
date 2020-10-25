package com.imop.lj.common.model.mall;

import com.imop.lj.common.model.CurrencyInfo;
import com.imop.lj.common.model.item.CommonItem;

/**
 * 商城限时商品
 * 
 * @author xiaowei.liu
 * 
 */
public class MallTimeLimitItemInfo {
	private int mallItemId;
	private CommonItem commonItem;
	private CurrencyInfo price;
	private long validPeriod;
	private int limitStock;
	private int stock;
	private int limitPurchase;
	private int limitPurchaseNum;
	private String marks;

	public int getMallItemId() {
		return mallItemId;
	}

	public void setMallItemId(int mallItemId) {
		this.mallItemId = mallItemId;
	}

	public CommonItem getCommonItem() {
		return commonItem;
	}

	public void setCommonItem(CommonItem commonItem) {
		this.commonItem = commonItem;
	}

	public CurrencyInfo getPrice() {
		return price;
	}

	public void setPrice(CurrencyInfo price) {
		this.price = price;
	}

	public long getValidPeriod() {
		return validPeriod;
	}

	public void setValidPeriod(long validPeriod) {
		this.validPeriod = validPeriod;
	}

	public int getLimitStock() {
		return limitStock;
	}

	public void setLimitStock(int limitStock) {
		this.limitStock = limitStock;
	}

	public int getStock() {
		return stock;
	}

	public void setStock(int stock) {
		this.stock = stock;
	}

	public int getLimitPurchase() {
		return limitPurchase;
	}

	public void setLimitPurchase(int limitPurchase) {
		this.limitPurchase = limitPurchase;
	}

	public int getLimitPurchaseNum() {
		return limitPurchaseNum;
	}

	public void setLimitPurchaseNum(int limitPurchaseNum) {
		this.limitPurchaseNum = limitPurchaseNum;
	}

	public String getMarks() {
		return marks;
	}

	public void setMarks(String marks) {
		this.marks = marks;
	}

}
