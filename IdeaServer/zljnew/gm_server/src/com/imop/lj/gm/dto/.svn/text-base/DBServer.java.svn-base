package com.imop.lj.gm.dto;

/**
 * 数据库服务器对象信息 与db.xml中的database信息对应
 *
 * @author linfan
 * @author kai.shi
 */
public class DBServer {
	/** 数据库服务器id */
	private String id;

	/** 取服务器端serverId的前三位 */
	private String serverId;

	/**后台服务器名，与服务器端服务器名无关*/
	private String dbServerName;

	/**快速通道服务器对应的服务器名*/
	private String serverName;

	/**快速通道对应的URL*/
	private String serverURL;

	/** 数据库服务器所属的大区ID */
	private String regionId;

	/** 数据库服务器所属的大区名字 */
	private String regionName;

	/** 数据库IP地址 */
	private String dbIp;

	/** 数据库端口 */
	private String dbport;

	/** 数据库名称 */
	private String dbName;

	/** 数据库用户名 */
	private String dbUsername;

	/** 数据库密码 */
	private String dbPassword;


	/** 数据库管理的worldServerIp */
	private String telnetIp;

	/** 数据库端口 */
	private String telnetPort;

	/**  数据库连接情况 */
	private boolean connectStatus;

	/**  数据库连接耗时 */
	private long connectTime;

	/**  数据库权限颜色 */
	private String prvColor;

	/** 数据库类型 0:GM数据库 1:GAME数据库 2:LOG数据库*/
	private int dbType ;

	/** 是否是GM数据库 */
	public boolean isGM(){
		return this.dbType ==0;
	}
	/** 是否是GAME数据库 */
	public boolean isGame(){
		return this.dbType ==1;
	}
	/** 是否是LOG数据库 */
	public boolean isLog(){
		return this.dbType ==2;
	}

	public String getPrvColor() {
		return prvColor;
	}

	public void setPrvColor(String prvColor) {
		this.prvColor = prvColor;
	}

	public String getDbServerName() {
		return dbServerName;
	}

	public void setDbServerName(String dbServerName) {
		this.dbServerName = dbServerName;
	}

	public String getTelnetPort() {
		return telnetPort;
	}

	public void setTelnetPort(String telnetPort) {
		this.telnetPort = telnetPort;
	}

	public String getServerURL() {
		return serverURL;
	}

	public void setServerURL(String serverURL) {
		this.serverURL = serverURL;
	}

	public boolean isConnectStatus() {
		return connectStatus;
	}

	public void setConnectStatus(boolean connectStatus) {
		this.connectStatus = connectStatus;
	}

	public long getConnectTime() {
		return connectTime;
	}

	public void setConnectTime(long connectTime) {
		this.connectTime = connectTime;
	}

	public String getTelnetIp() {
		return telnetIp;
	}

	public void setTelnetIp(String telnetIp) {
		this.telnetIp = telnetIp;
	}

	public String getServerName() {
		return serverName;
	}

	public void setServerName(String serverName) {
		this.serverName = serverName;
	}

	public String getId() {
		return id;
	}

	public void setId(String id) {
		this.id = id;
	}

	public String getServerId() {
		return serverId;
	}

	public void setServerId(String serverId) {
		this.serverId = serverId;
	}

	public String getRegionId() {
		return regionId;
	}

	public void setRegionId(String regionId) {
		this.regionId = regionId;
	}

	public String getDbIp() {
		return dbIp;
	}

	public void setDbIp(String dbIp) {
		this.dbIp = dbIp;
	}

	public String getDbName() {
		return dbName;
	}

	public void setDbName(String dbName) {
		this.dbName = dbName;
	}

	public String getDbUsername() {
		return dbUsername;
	}

	public void setDbUsername(String dbUsername) {
		this.dbUsername = dbUsername;
	}

	public String getDbPassword() {
		return dbPassword;
	}

	public void setDbPassword(String dbPassword) {
		this.dbPassword = dbPassword;
	}

	public String getDbport() {
		return dbport;
	}

	public void setDbport(String dbport) {
		this.dbport = dbport;
	}

	public String getRegionName() {
		return regionName;
	}

	public void setRegionName(String regionName) {
		this.regionName = regionName;
	}

	public void setDbType(int dbType) {
		this.dbType = dbType;
	}

	public int getDbType() {
		return dbType;
	}
}
