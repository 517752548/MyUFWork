package com.imop.lj.common.model.corps;

public class OpenRedEnveloperInfo {
	/** 抢到红包玩家id*/
	private long recId;
	/** 抢到红包玩家姓名*/
	private String recName;
	/** 抢到红包的时间*/
	private long openTime;
	/** 抢到的红包金额*/
	private int gotBonus;
	public long getRecId() {
		return recId;
	}
	public void setRecId(long recId) {
		this.recId = recId;
	}
	public String getRecName() {
		return recName;
	}
	public void setRecName(String recName) {
		this.recName = recName;
	}
	public long getOpenTime() {
		return openTime;
	}
	public void setOpenTime(long openTime) {
		this.openTime = openTime;
	}
	public int getGotBonus() {
		return gotBonus;
	}
	public void setGotBonus(int gotBonus) {
		this.gotBonus = gotBonus;
	}
	@Override
	public String toString() {
		return "CorpsRedEnvelopeInfo [recId=" + recId + ", recName=" + recName + ", openTime=" + openTime
				+ ", gotBonus=" + gotBonus + "]";
	}	
	
	
}
