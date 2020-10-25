package com.imop.lj.gameserver.otherplatform;

import com.imop.lj.core.config.Config;

public class OtherplatformConstants implements Config {
	
	private String qqTelnetUserName = "qq";

	private String qqTelnetPassword = "EPrNgH7bBKgEU40q";
	
	private long qqAppId = 1101346127L;
	
	/** api请求时的key */
	private String apiLocalkey ="f9a7531a561645fdff1a01e152a46522";
	
	private String qqAreaLoginUrl = "api/qq/qqAreaLogin";
	
	private String qqBuyGoodsUrl = "api/qq/qqBuyGoods";
	
	private String qqIsVip = "api/qq/qqIsVip";
	
	private String qqIsLogin = "api/qq/qqIsLogin";
	
	private String qqRecharge = "api/qq/qqRecharge";
	
	private String qqFinishMarketTask = "api/qq/qqFinishMarketTask";
	
	private String qqGetMarketAward = "api/qq/qqGetMarketAward";
	
	private String qqGetPubacctBalance = "api/qq/qqGetPubacctBalance";
	
	// 发微博接口
	private String qqAddTUrl = "api/qq/qqAddT";
	
	/** 请求buy_goods时的参数，营销用的分区Id */
	private String qqZoneid = "0";
	
	/** kaiying日志server的配置 */
	private String kaiyingLogServerIp = "10.142.55.38";
	private int kaiyingLogServerPort = 8800;
	

	@Override
	public String getVersion() {
		return null;
	}

	@Override
	public void validate() {

	}

	@Override
	public boolean getIsDebug() {
		return false;
	}

	public String getQqTelnetUserName() {
		return qqTelnetUserName;
	}

	public void setQqTelnetUserName(String qqTelnetUserName) {
		this.qqTelnetUserName = qqTelnetUserName;
	}

	public String getQqTelnetPassword() {
		return qqTelnetPassword;
	}

	public void setQqTelnetPassword(String qqTelnetPassword) {
		this.qqTelnetPassword = qqTelnetPassword;
	}

	public String getQqAreaLoginUrl() {
		return qqAreaLoginUrl;
	}

	public void setQqAreaLoginUrl(String qqAreaLoginUrl) {
		this.qqAreaLoginUrl = qqAreaLoginUrl;
	}

	public String getQqBuyGoodsUrl() {
		return qqBuyGoodsUrl;
	}

	public void setQqBuyGoodsUrl(String qqBuyGoodsUrl) {
		this.qqBuyGoodsUrl = qqBuyGoodsUrl;
	}

	public String getQqIsVip() {
		return qqIsVip;
	}

	public void setQqIsVip(String qqIsVip) {
		this.qqIsVip = qqIsVip;
	}

	public String getApiLocalkey() {
		return apiLocalkey;
	}

	public void setApiLocalkey(String apiLocalkey) {
		this.apiLocalkey = apiLocalkey;
	}

	public String getQqZoneid() {
		return qqZoneid;
	}

	public void setQqZoneid(String qqZoneid) {
		this.qqZoneid = qqZoneid;
	}

	public String getQqRecharge() {
		return qqRecharge;
	}

	public void setQqRecharge(String qqRecharge) {
		this.qqRecharge = qqRecharge;
	}

	public String getKaiyingLogServerIp() {
		return kaiyingLogServerIp;
	}

	public void setKaiyingLogServerIp(String kaiyingLogServerIp) {
		this.kaiyingLogServerIp = kaiyingLogServerIp;
	}

	public int getKaiyingLogServerPort() {
		return kaiyingLogServerPort;
	}

	public void setKaiyingLogServerPort(int kaiyingLogServerPort) {
		this.kaiyingLogServerPort = kaiyingLogServerPort;
	}

	public long getQqAppId() {
		return qqAppId;
	}

	public void setQqAppId(long qqAppId) {
		this.qqAppId = qqAppId;
	}

	public String getQqAddTUrl() {
		return qqAddTUrl;
	}

	public void setQqAddTUrl(String qqAddTUrl) {
		this.qqAddTUrl = qqAddTUrl;
	}

	public String getQqIsLogin() {
		return qqIsLogin;
	}

	public void setQqIsLogin(String qqIsLogin) {
		this.qqIsLogin = qqIsLogin;
	}

	public String getQqFinishMarketTask() {
		return qqFinishMarketTask;
	}

	public void setQqFinishMarketTask(String qqFinishMarketTask) {
		this.qqFinishMarketTask = qqFinishMarketTask;
	}

	public String getQqGetMarketAward() {
		return qqGetMarketAward;
	}

	public void setQqGetMarketAward(String qqGetMarketAward) {
		this.qqGetMarketAward = qqGetMarketAward;
	}

	public String getQqGetPubacctBalance() {
		return qqGetPubacctBalance;
	}

	public void setQqGetPubacctBalance(String qqGetPubacctBalance) {
		this.qqGetPubacctBalance = qqGetPubacctBalance;
	}
	
}
