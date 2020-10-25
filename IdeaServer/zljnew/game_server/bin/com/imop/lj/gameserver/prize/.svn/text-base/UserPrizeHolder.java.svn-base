package com.imop.lj.gameserver.prize;


/**
 * 奖励数据结构
 * 
 */
public class UserPrizeHolder extends BasePrizeHolder {
	
	/** 奖励编号 */
	private int userPrizeId;
	/** 玩家通行证 */
	private String passportId;
	/** 奖励类型 */
	private int type;
	/** 奖励状态 已奖励/未奖励 */
	private int status;
	/** 奖励信息 */
	private String prizeInfo;
	
	
	@Override
	public int getUniqueId()
	{
		return userPrizeId;
	}

	public int getUserPrizeId() {
		return userPrizeId;
	}

	public void setId(int userPrizeId) {
		this.userPrizeId = userPrizeId;
	}

	public String getPassportId() {
		return passportId;
	}

	public void setPassportId(String passportId) {
		this.passportId = passportId;
	}

	public int getType() {
		return type;
	}

	public void setType(int type) {
		this.type = type;
	}

	public int getStatus() {
		return status;
	}

	public void setStatus(int status) {
		this.status = status;
	}

	public String getPrizeInfo() {
		return prizeInfo;
	}

	public void setPrizeInfo(String prizeInfo) {
		this.prizeInfo = prizeInfo;
	}

	@Override
	public String toString() {
		return "UserPrizeHolder [passportId=" + passportId 
				+ ", prizeInfo=" + prizeInfo 
				+ ", status=" + status 
				+ ", type=" + type 
				+ ", userPrizeId=" + userPrizeId
				+ "]";
	}

}
