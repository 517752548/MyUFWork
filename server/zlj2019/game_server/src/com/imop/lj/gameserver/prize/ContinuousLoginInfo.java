package com.imop.lj.gameserver.prize;

public class ContinuousLoginInfo  {
	private int status; //是否可领取 /** 奖励状态 已奖励/未奖励 */
	private int day; //连续登陆天数
	
	public int getDay() {
		return day;
	}

	public void setDay(int day) {
		this.day = day;
	}

	public int getStatus() {
		return status;
	}

	public void setStatus(int status) {
		this.status = status;
	}
	
	
}
