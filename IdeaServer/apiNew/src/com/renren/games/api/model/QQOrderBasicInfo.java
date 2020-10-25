package com.renren.games.api.model;

public class QQOrderBasicInfo {
	
	private String openid;

	private String openkey;

	private String pf;

	private String pfkey;

	private String billToken;

	public String getOpenid() {
		return openid;
	}

	public void setOpenid(String openid) {
		this.openid = openid;
	}

	public String getOpenkey() {
		return openkey;
	}

	public void setOpenkey(String openkey) {
		this.openkey = openkey;
	}

	public String getPf() {
		return pf;
	}

	public void setPf(String pf) {
		this.pf = pf;
	}

	public String getPfkey() {
		return pfkey;
	}

	public void setPfkey(String pfkey) {
		this.pfkey = pfkey;
	}

	public String getBillToken() {
		return billToken;
	}

	public void setBillToken(String billToken) {
		this.billToken = billToken;
	}
}
