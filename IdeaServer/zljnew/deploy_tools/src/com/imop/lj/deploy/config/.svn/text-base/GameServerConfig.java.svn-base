package com.imop.lj.deploy.config;

import javax.xml.bind.annotation.XmlAttribute;

/**
 * Gamse Server的配置
 *
 *
 */
public class GameServerConfig extends ServerConfig {
	/** 防沉迷开关 */
	private boolean wallowControlled = true;

	/** 性能采集开关 */
	private boolean probeTurnOn = false;

	/** 平台接口默认打开 */
	private boolean localTurnOn = true;

	/** 服务器启动是否直接启动登陆墙 */
	private boolean loginWallEnabled = true;

	/** 是否开启充值 */
	private boolean chargeEnabled = false;

	/** 战报服务的服务类型 0-文件 1-数据库 */
	private int battleReportServiceType = 0;

	/** 运营公司，默认为renren */
	private String operationCom="renren";

	/** telnet端口 */
	private int telnetPort;
	/** 采用异或方式加载模版资源 */
	private boolean templateXorLoad = true;
	/** 时区 */
	private String timeZone = "";
	/** 充值兑换比例 */
	private float chargeMM2DiamondRate = 10.0f;
	/** localKey */
	private String localKey = "";
	/** Apple 商店类型 */
	private String appleStoreType = "buy";
	/** 打开新手引导 */
	private boolean openNewerGuide = true;
	
	/** 打开新手引导 */
	private boolean kaiyingLog = true;
	
	/**
	 * 跨服服务器ip地址
	 */
	protected String worldServerConfigIp;
	/**
	 * 跨服服务器端口号
	 */
	protected int worldServerConfigPort;
	/**
	 * 跨服服务器功能开关true表示需要连接跨服服务器false不需要连接跨服服务器
	 */
	protected boolean worldServerConfigTurnOn = false;
	/**
	 * 此服是不是跨服服务器0代表游戏服务器1代表跨服服务器
	 */
	protected int serverType = 0;

	@Override
	public String getServerName() {
		return "game_server";
	}

	@Override
	public String[] getConfigs() {
		return new String[]{"hibernate.properties","log4j.properties","game_server.cfg.js","battle_report_ibatis_config.xml"};
	}

	@Override
	public String getTemplatePackage() {
		return "gameserver/";
	}

	@Override
	public String getMainClass() {
		return "com.imop.lj.gameserver.GameServer";
	}

	@XmlAttribute(name="wallowControlled")
	public boolean isWallowControlled(){
		return this.wallowControlled;
	}

	public void setWallowControlled(boolean wallowControlled){
		this.wallowControlled = wallowControlled;
	}

	@XmlAttribute(required = true)
	public int getTelnetPort() {
		return telnetPort;
	}

	public void setTelnetPort(int telnetPort) {
		this.telnetPort = telnetPort;
	}

	@XmlAttribute(name="probeTurnOn")
	public boolean isProbeTurnOn() {
		return probeTurnOn;
	}

	public void setProbeTurnOn(boolean probeTurnOn) {
		this.probeTurnOn = probeTurnOn;
	}

	@XmlAttribute(name="chargeEnabled")
	public boolean isChargeEnabled() {
		return chargeEnabled;
	}

	public void setChargeEnabled(boolean chargeEnabled) {
		this.chargeEnabled = chargeEnabled;
	}

	@XmlAttribute(name="battleReportServiceType")
	public int getBattleReportServiceType() {
		return battleReportServiceType;
	}

	public void setBattleReportServiceType(int battleReportServiceType) {
		this.battleReportServiceType = battleReportServiceType;
	}

	@XmlAttribute(name="localTurnOn")
	public boolean isLocalTurnOn() {
		return localTurnOn;
	}

	public void setLocalTurnOn(boolean localTurnOn) {
		this.localTurnOn = localTurnOn;
	}

	@XmlAttribute(name="loginWallEnabled")
	public boolean isLoginWallEnabled() {
		return loginWallEnabled;
	}

	public void setLoginWallEnabled(boolean loginWallEnabled)
	{
		this.loginWallEnabled = loginWallEnabled;
	}

	/**
	 * @return the operationCom
	 */
	@XmlAttribute(name = "operation_com")
	public String getOperationCom() {
		return operationCom;
	}

	/**
	 * @param operationCom the operationCom to set
	 */
	public void setOperationCom(String operationCom) {
		this.operationCom = operationCom;
	}



	@Override
	@XmlAttribute()
	public String getGcOpt() {
		return (this.gcOpt == null || this.gcOpt.trim().equals("")) ? "-XX:NewRatio=2 -XX:PermSize=64m -XX:MaxPermSize=64m -XX:+UseConcMarkSweepGC" : this.gcOpt;
	}

	/**
	 * 是否以异或方式加载模版资源
	 *
	 * @param value
	 */
	@XmlAttribute
	public boolean isTemplateXorLoad() {
		return this.templateXorLoad;
	}

	/**
	 * 是否以异或方式加载模版资源
	 *
	 * @param value
	 */
	public void setTemplateXorLoad(boolean value) {
		this.templateXorLoad = value;
	}

	/**
	 * 获取时区
	 *
	 * @return
	 */
	@XmlAttribute
	public String getTimeZone() {
		return this.timeZone;
	}

	/**
	 * 设置时区
	 *
	 * @param value
	 */
	public void setTimeZone(String value) {
		this.timeZone = value;
	}

	/**
	 * 获取兑换比例
	 *
	 * @return
	 */
	@XmlAttribute
	public float getChargeMM2DiamondRate() {
		return this.chargeMM2DiamondRate;
	}

	/**
	 * 设置兑换比例
	 *
	 * @param value
	 */
	public void setChargeMM2DiamondRate(float value) {
		this.chargeMM2DiamondRate = value;
	}

	/**
	 * 获取平台密钥
	 *
	 * @return
	 *
	 */
	@XmlAttribute
	public String getLocalKey() {
		return this.localKey;
	}

	/**
	 * 设置平台密钥
	 *
	 * @param value
	 *
	 */
	public void setLocalKey(String value) {
		this.localKey = value;
	}

	@XmlAttribute
	public String getAppleStoreType() {
		return appleStoreType;
	}

	public void setAppleStoreType(String appleStoreType) {
		this.appleStoreType = appleStoreType;
	}

	/**
	 * 新手引导是否已打开?
	 *
	 * @return
	 */
	@XmlAttribute
	public boolean isOpenNewerGuide() {
		return this.openNewerGuide;
	}

	/**
	 * 打开新手引导
	 *
	 * @param value
	 */
	public void setOpenNewerGuide(boolean value) {
		this.openNewerGuide = value;
	}

	@XmlAttribute(name = "kaiyingLog")
	public boolean isKaiyingLog() {
		return kaiyingLog;
	}

	public void setKaiyingLog(boolean kaiyingLog) {
		this.kaiyingLog = kaiyingLog;
	}
	
	//跨服相关配置
	@XmlAttribute
	public String getWorldServerConfigIp() {
		return worldServerConfigIp;
	}

	public void setWorldServerConfigIp(String worldServerConfigIp) {
		this.worldServerConfigIp = worldServerConfigIp;
	}

	@XmlAttribute
	public int getWorldServerConfigPort() {
		return worldServerConfigPort;
	}

	public void setWorldServerConfigPort(int worldServerConfigPort) {
		this.worldServerConfigPort = worldServerConfigPort;
	}

	@XmlAttribute
	public boolean isWorldServerConfigTurnOn() {
		return worldServerConfigTurnOn;
	}

	public void setWorldServerConfigTurnOn(boolean worldServerConfigTurnOn) {
		this.worldServerConfigTurnOn = worldServerConfigTurnOn;
	}

	@XmlAttribute
	public int getServerType() {
		return serverType;
	}

	public void setServerType(int serverType) {
		this.serverType = serverType;
	}
}
