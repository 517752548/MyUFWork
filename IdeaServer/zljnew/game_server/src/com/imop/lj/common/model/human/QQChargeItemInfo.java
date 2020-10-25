package com.imop.lj.common.model.human;

import com.imop.lj.common.model.reward.RewardInfo;

public class QQChargeItemInfo {
	private int chargeTplId;
	private String icon;
	private int buyCost;
	private int yellowVipBuyCost;
	private int giveBondNum;
	private RewardInfo chargeRewardInfo;
	
	public int getChargeTplId() {
		return chargeTplId;
	}
	public void setChargeTplId(int chargeTplId) {
		this.chargeTplId = chargeTplId;
	}
	public String getIcon() {
		return icon;
	}
	public void setIcon(String icon) {
		this.icon = icon;
	}
	public int getBuyCost() {
		return buyCost;
	}
	public void setBuyCost(int buyCost) {
		this.buyCost = buyCost;
	}
	public int getYellowVipBuyCost() {
		return yellowVipBuyCost;
	}
	public void setYellowVipBuyCost(int yellowVipBuyCost) {
		this.yellowVipBuyCost = yellowVipBuyCost;
	}
	public int getGiveBondNum() {
		return giveBondNum;
	}
	public void setGiveBondNum(int giveBondNum) {
		this.giveBondNum = giveBondNum;
	}
	public RewardInfo getChargeRewardInfo() {
		return chargeRewardInfo;
	}
	public void setChargeRewardInfo(RewardInfo chargeRewardInfo) {
		this.chargeRewardInfo = chargeRewardInfo;
	}
	
}
