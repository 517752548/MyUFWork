package com.imop.lj.gm.dto;

/**
 * 报警监控显示的服务器对象
 *
 */
public class ServerStateVO {

	/** 服务器名称 */
	private String serverName;

	/** 上次访问时间 */
	private long lastGetTime;

	/** 服务器状态(true:正常连接,false:连接失败) */
	private boolean state;

	/** 错误连接次数 */
	private int errorCount;

	/** 在线人数 */
	private int onlineNum;

	/** 服务器版本 */
	private String svrVersion;


	/** 防火墙 */
	private String loginWallEnabled;

	/** 服务器类型 */
	private String type;

	public String getType() {
		return type;
	}

	public void setType(String type) {
		this.type = type;
	}

	public String getSvrVersion() {
		return svrVersion;
	}

	public void setSvrVersion(String svrVersion) {
		this.svrVersion = svrVersion;
	}

	public String getLoginWallEnabled() {
		return loginWallEnabled;
	}

	public void setLoginWallEnabled(String loginWallEnabled) {
		this.loginWallEnabled = loginWallEnabled;
	}

	public int getOnlineNum() {
		return onlineNum;
	}

	public void setOnlineNum(int onlineNum) {
		this.onlineNum = onlineNum;
	}

	public String getServerName() {
		return serverName;
	}

	public void setServerName(String serverName) {
		this.serverName = serverName;
	}

	public long getLastGetTime() {
		return lastGetTime;
	}

	public void setLastGetTime(long lastGetTime) {
		this.lastGetTime = lastGetTime;
	}

	public boolean isState() {
		return state;
	}

	public void setState(boolean state) {
		this.state = state;
	}

	public int getErrorCount() {
		return errorCount;
	}

	public void setErrorCount(int errorCount) {
		this.errorCount = errorCount;
	}

}
