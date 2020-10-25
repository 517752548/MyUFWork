package com.imop.lj.gm.autolog.model;
import java.util.List;
import com.imop.lj.gm.model.log.BaseLog;
/**
 * This is an auto generated source,please don't modify it.
 */
 
public class MoneyLog extends BaseLog{

	//主货币类型
    private int mainCurrency;
	//主货币钱数变化值
    private long mainDelta;
	//主货币剩余金钱
    private long mainCurrLeft;
	//辅助货币类型
    private int altCurrency;
	//辅助货币变化值
    private long altDelta;
	//辅助货币剩余金钱
    private long altCurrLeft;
	//第三货币类型
    private int thirdCurrency;
	//第三货币变化值
    private long thirdDelta;
	//第三货币剩余金钱
    private long thirdCurrLeft;

	@SuppressWarnings("unchecked")
	@Override
	public List toList(){
		List list = super.toList();
		list.add(mainCurrency);
		list.add(mainDelta);
		list.add(mainCurrLeft);
		list.add(altCurrency);
		list.add(altDelta);
		list.add(altCurrLeft);
		list.add(thirdCurrency);
		list.add(thirdDelta);
		list.add(thirdCurrLeft);
		return list;
	}
	
	public int getMainCurrency() {
		return mainCurrency;
	}
	public long getMainDelta() {
		return mainDelta;
	}
	public long getMainCurrLeft() {
		return mainCurrLeft;
	}
	public int getAltCurrency() {
		return altCurrency;
	}
	public long getAltDelta() {
		return altDelta;
	}
	public long getAltCurrLeft() {
		return altCurrLeft;
	}
	public int getThirdCurrency() {
		return thirdCurrency;
	}
	public long getThirdDelta() {
		return thirdDelta;
	}
	public long getThirdCurrLeft() {
		return thirdCurrLeft;
	}
        
	public void setMainCurrency(int mainCurrency) {
		this.mainCurrency = mainCurrency;
	}
	public void setMainDelta(long mainDelta) {
		this.mainDelta = mainDelta;
	}
	public void setMainCurrLeft(long mainCurrLeft) {
		this.mainCurrLeft = mainCurrLeft;
	}
	public void setAltCurrency(int altCurrency) {
		this.altCurrency = altCurrency;
	}
	public void setAltDelta(long altDelta) {
		this.altDelta = altDelta;
	}
	public void setAltCurrLeft(long altCurrLeft) {
		this.altCurrLeft = altCurrLeft;
	}
	public void setThirdCurrency(int thirdCurrency) {
		this.thirdCurrency = thirdCurrency;
	}
	public void setThirdDelta(long thirdDelta) {
		this.thirdDelta = thirdDelta;
	}
	public void setThirdCurrLeft(long thirdCurrLeft) {
		this.thirdCurrLeft = thirdCurrLeft;
	}

}