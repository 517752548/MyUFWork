package com.imop.lj.gameserver.prize;

/**
 * 新增加，方便客户端显示物品具体信息
 * @author gang.li1
 *
 */
public class UserPrizeTipInfo {
	/** 奖品ID*/
	private String prizeId;
	/** 金钱*/
	private UserPrizeItemTipInfo[] moneys;
	/** 物品*/
	private UserPrizeItemTipInfo[] items;
	
	public UserPrizeTipInfo() {
		super();
	}
	public UserPrizeTipInfo(String prizeId, UserPrizeItemTipInfo[] moneys,
			UserPrizeItemTipInfo[] items) {
		super();
		this.prizeId = prizeId;
		this.moneys = moneys;
		this.items = items;
	}
	public String getPrizeId() {
		return prizeId;
	}
	public void setPrizeId(String prizeId) {
		this.prizeId = prizeId;
	}
	public UserPrizeItemTipInfo[] getMoneys() {
		return moneys;
	}
	public void setMoneys(UserPrizeItemTipInfo[] moneys) {
		this.moneys = moneys;
	}
	public UserPrizeItemTipInfo[] getItems() {
		return items;
	}
	public void setItems(UserPrizeItemTipInfo[] items) {
		this.items = items;
	}
	
	
}
