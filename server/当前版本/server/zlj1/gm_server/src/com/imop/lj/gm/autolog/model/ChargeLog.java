package com.imop.lj.gm.autolog.model;
import java.util.List;
import com.imop.lj.gm.model.log.BaseLog;
/**
 * This is an auto generated source,please don't modify it.
 */
 
public class ChargeLog extends BaseLog{

	//货币类型
    private int moneyType;
	//充值前数量
    private int currencyBefore;
	//充值后数量
    private int currencyAfter;
	//要兑换多少MM
    private int mmCost;
	//接口返回的充值结果
    private String result;
	//订单号即平台orderId
    private String transfer;

	@SuppressWarnings("unchecked")
	@Override
	public List toList(){
		List list = super.toList();
		list.add(moneyType);
		list.add(currencyBefore);
		list.add(currencyAfter);
		list.add(mmCost);
		list.add(result);
		list.add(transfer);
		return list;
	}
	
	public int getMoneyType() {
		return moneyType;
	}
	public int getCurrencyBefore() {
		return currencyBefore;
	}
	public int getCurrencyAfter() {
		return currencyAfter;
	}
	public int getMmCost() {
		return mmCost;
	}
	public String getResult() {
		return result;
	}
	public String getTransfer() {
		return transfer;
	}
        
	public void setMoneyType(int moneyType) {
		this.moneyType = moneyType;
	}
	public void setCurrencyBefore(int currencyBefore) {
		this.currencyBefore = currencyBefore;
	}
	public void setCurrencyAfter(int currencyAfter) {
		this.currencyAfter = currencyAfter;
	}
	public void setMmCost(int mmCost) {
		this.mmCost = mmCost;
	}
	public void setResult(String result) {
		this.result = result;
	}
	public void setTransfer(String transfer) {
		this.transfer = transfer;
	}

}