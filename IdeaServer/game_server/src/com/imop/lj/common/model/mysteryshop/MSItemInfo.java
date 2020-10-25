package com.imop.lj.common.model.mysteryshop;

/**
 * 神秘商店物品信息
 * 
 * @author xiaowei.liu
 * 
 */
public class MSItemInfo {
	/**
	 * 商品ID
	 */
	private int id;
	/**
	 * 1-等待购买,2-已购买
	 */
	private int buyState;

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public int getBuyState() {
		return buyState;
	}

	public void setBuyState(int buyState) {
		this.buyState = buyState;
	}

	@Override
	public String toString() {
		return "MSItemInfo [id=" + id + ", buyState=" + buyState + "]";
	}
}
