package com.renren.games.api.core.config;

public class QQConfig implements IConfig {
	
	/** 没有兑换订单状态值*/
	public static int QQ_NOT_CHARGE = 0;
	
	/** 兑换完成订单状态值*/
	public static int QQ_CHARGED = 1;

	protected String appid = "1101336700";

	protected String appkey = "EPrNgH7bBKgEU40q";

	protected String serverName = "119.147.19.43";

	protected String telnetUserName = "qq";

	protected String telnetPassword = "EPrNgH7bBKgEU40q";

	protected String debug_buyGoods = "";

	protected String debug_getInfo = "";

	protected String debug_isAreaLogin = "";

	protected String debug_isLogin = "";

	protected String debug_isVip = "";
	
	protected String debug_verifyInvkey = "";

	/** qq订单失效时间 */
	protected int billTokenPeriod = 15 * 60;

	public QQConfig() {

	}

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

	public String getAppid() {
		return appid;
	}

	public void setAppid(String appid) {
		this.appid = appid;
	}

	public String getAppkey() {
		return appkey;
	}

	public void setAppkey(String appkey) {
		this.appkey = appkey;
	}

	public String getServerName() {
		return serverName;
	}

	public void setServerName(String serverName) {
		this.serverName = serverName;
	}

	public String getTelnetUserName() {
		return telnetUserName;
	}

	public void setTelnetUserName(String telnetUserName) {
		this.telnetUserName = telnetUserName;
	}

	public String getTelnetPassword() {
		return telnetPassword;
	}

	public void setTelnetPassword(String telnetPassword) {
		this.telnetPassword = telnetPassword;
	}

	public int getBillTokenPeriod() {
		return billTokenPeriod;
	}

	public void setBillTokenPeriod(int billTokenPeriod) {
		this.billTokenPeriod = billTokenPeriod;
	}

	public String getDebug_buyGoods() {
		return debug_buyGoods;
	}

	public void setDebug_buyGoods(String debug_buyGoods) {
		this.debug_buyGoods = debug_buyGoods;
	}

	public String getDebug_getInfo() {
		return debug_getInfo;
	}

	public void setDebug_getInfo(String debug_getInfo) {
		this.debug_getInfo = debug_getInfo;
	}

	public String getDebug_isAreaLogin() {
		return debug_isAreaLogin;
	}

	public void setDebug_isAreaLogin(String debug_isAreaLogin) {
		this.debug_isAreaLogin = debug_isAreaLogin;
	}

	public String getDebug_isLogin() {
		return debug_isLogin;
	}

	public void setDebug_isLogin(String debug_isLogin) {
		this.debug_isLogin = debug_isLogin;
	}

	public String getDebug_isVip() {
		return debug_isVip;
	}

	public void setDebug_isVip(String debug_isVip) {
		this.debug_isVip = debug_isVip;
	}

	public String getDebug_verifyInvkey() {
		return debug_verifyInvkey;
	}

	public void setDebug_verifyInvkey(String debug_verifyInvkey) {
		this.debug_verifyInvkey = debug_verifyInvkey;
	}
}
