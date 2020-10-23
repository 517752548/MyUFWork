package com.imop.lj.gameserver.common.config;

import java.io.File;

import com.imop.lj.common.constants.FunctionSwitches;
import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.config.ServerConfig;
import com.imop.lj.core.config.WorldServerConfig;
import com.imop.lj.gameserver.player.auth.config.ZLJ37wanwanConfig;
import com.imop.lj.probe.PIProbeConstants.ProbeReporter;

/**
 * 服务器配置信息
 * 
 * 一些key/value对 获取资源的路径
 * 
 * @author jackflit
 * 
 */
public class GameServerConfig extends ServerConfig {

	/** 系统配置的数据库版本号 */
	private String dbVersion;

	/** 最大允许在线人数 */
	private int maxOnlineUsers;

	/** 南蛮入侵最大人数 */
	private int maxMonsterWarUsersNum = 9999;

	/** Boss战最大人数 */
	private int maxBossWarUsersNum = 9999;

	/** 记录统计值开关 */
	private boolean logStatistics = true;

	/* Telnet服务参数定义 */
	/** Telnet服务器名称 */
	private String telnetServerName;
	/** Telnet绑定的ip */
	private String telnetBindIp;
	/** Telnet绑定的端口 */
	private String telnetPort;

	/** 定时向Local汇报在线人数的间隔 单位：秒 */
	private int localReportOnlinePeriod = 300;
	/** 定时向Local汇报游戏服务器状态的间隔 单位：秒 */
	private int localReportStatusPeriod = 60;

	/** 认证方式, 默认平台认证 */
	private int authType = SharedConstants.AUTH_TYPE_DB;
	/** 登陆墙是否打开，默认关闭 */
	private volatile boolean loginWallEnabled = false;

	/** 反沉迷累计时长同步间隔 5分钟 :5 * 60,单位：秒 */
	private long wallowPeriod = 5 * 60;
	/** 防沉迷配置 */
	private boolean wallowControlled = false;

	/** 战报服务的类型,0 file 1 db */
	private int battleReportServiceType = 0;

	/** 战报数据库配置文件 */
	private String battleReportDbConfigName;
	/** 战报文件存储目录 */
	private String battleReportRootPath;

	/** 运营公司 */
	private String operationCom;

	/** 功能开关 */
	private FunctionSwitches funcSwitches = new FunctionSwitches();
	/** 开启新手引导 */
	private int openNewerGuide = 1;
	/** 车轮战功能开关 */
	private int _openBossWar = 1;
	/** 最大玩家等级 */
	private int maxHumanLevel = 120;
	/** 是否以异或方式加载模版资源 */
	private boolean templateXorLoad = true;

	private String appleStoreType = "buy";// sandbox

	// private boolean openProbeLog=false;

	private String localKey = "c762000b3eb6955de0862f435b28a8eb";

	/** 护送功能开关 */
	private int _openEscort = 1;
	/** 好友关系功能开关 */
	private int _openRelation = 1;

	private String scribeServerIp = "127.0.0.1";

	private boolean scribeOnTurn = true;

	// /** debug 角色自动创建*/
	// private boolean accountRoleDebug=true;

	/**
	 * 开启存储策略
	 */
	private boolean upgradeDbStrategy = false;

	/** 存储时间间隔,单位为毫秒 */
	private int dbUpdateInterval = 200 * 1000;

	/**
	 * 是否启动采样收集
	 */
	private boolean collectStrategy = false;

	/**
	 * log采样率，配置为分母，如配置是10，则采样率为1/10,如果是7，则采样率为1/7
	 */
	private int collectSimpling = 10;

	/**
	 * 帐号激活是否开启
	 */
	private boolean accountActivityOpen = false;
	/**
	 * 其他平台相关
	 */
	private ZLJ37wanwanConfig zlj37wanwanConfig = new ZLJ37wanwanConfig();

	/**
	 * 是否Debug血量
	 */
	private boolean battleDebug = false;

	/** session过期失效 ，单位为秒 */
	private int sessionExpireTime = 30 * 60 * 1000;

	/** 检查非法session的时间 单位：秒 */
	private int checkSessionExpireTime = 60;

	/**
	 * 直冲开关
	 */
	private boolean zhichongFlag = false;

	/** 是否使用自带的logServer */
	private volatile boolean selfLogServer = false;
	
	/** api请求的域名 */
	private String apiRequestDomain = "http://127.0.0.1:8080/qqapi/";
	
	/** kaiying的log是否开启 */
	private boolean kaiyingLog = false;

	protected WorldServerConfig worldServerConfig = new WorldServerConfig();
	
	/** 游戏检测跨服服务器，如果需要重新连接服务器，时间 单位：秒 */
	private int pingWorldServerPeriod = 60;
	
	//dataEye 应用Id
	private String dataEyeAppid = "315BCB49BB8A5130BD9171FEA6D230CF";
	//dataEye 在服务器上日志和 服务器上日志和 服务器上日志和 服务器上日志和 临时 文件的 文件的 存放 目录 。
	private String dataEyeBaseFileDir = "dataeye_logs";
	//dataEye maxHistoryLogFile值小于等于0时，则取默认，保存15天的日志
	private int dataEyeMaxHistoryLogFile = 15;
	//dataEye maxHistoryDataFile 值小于等于0时，则取默认，保存最近1000条日志
	private int dataEyeMaxHistoryDataFile = 1000;
	
	//reyun 应用Id
	private String reyunAppid = "b23b88f7c83cf5c821caee1e7fc09ab7";//"dd1419dd56d4002b064e3c361d758aa1";
	private String reyunAppidIOS = "7fbba6e85ffeb51b037f762c71d65cbc";
	private String reyunServer = "http://log.reyun.com";
	
	public GameServerConfig() {
		// Gameserver默认采用的汇报方式
		getProbeConfig().setProbeReporterMask(
				ProbeReporter.PREFORMANCE.mark | ProbeReporter.USER.mark);
	}

	/**
	 * 取得资源文件的绝对路径
	 * 
	 * @param pathes
	 *            路径的参数,每个参数将使用路径分隔符连接起来
	 * @return
	 */
	@Override
	public String getResourceFullPath(String... pathes) {
		StringBuilder _sb = new StringBuilder();
		_sb.append(this.getBaseResourceDir());
		for (String _path : pathes) {
			_sb.append(File.separator);
			_sb.append(_path);
		}
		return _sb.toString();
	}

	@Override
	public void validate() {
		super.validate();
	}

	/**
	 * 登陆墙是否打开
	 * 
	 * @return
	 */
	public boolean isLoginWallEnabled() {
		return loginWallEnabled;
	}

	/**
	 * 设置登陆墙是否打开
	 * 
	 * @param loginWallEnabled
	 */
	public void setLoginWallEnabled(boolean loginWallEnabled) {
		this.loginWallEnabled = loginWallEnabled;
	}

	/**
	 * 获得脚本文件路径
	 * 
	 * @param fileName
	 *            文件名
	 * @return
	 */
	public String getResourceFilePath(String fileName) {
		return this.getResourceFullPath(this.getScriptDir(), fileName);
	}

	/**
	 * @return the maxOnlineUsers
	 */
	public int getMaxOnlineUsers() {
		return maxOnlineUsers;
	}

	/**
	 * @param maxOnlineUsers
	 *            the maxOnlineUsers to set
	 */
	public void setMaxOnlineUsers(int maxOnlineUsers) {
		this.maxOnlineUsers = maxOnlineUsers;
	}

	public boolean isLogStatistics() {
		return logStatistics;
	}

	public void setLogStatistics(boolean logStatistics) {
		this.logStatistics = logStatistics;
	}

	public String getTelnetServerName() {
		return telnetServerName;
	}

	public void setTelnetServerName(String telnetServerName) {
		this.telnetServerName = telnetServerName;
	}

	public String getTelnetBindIp() {
		return telnetBindIp;
	}

	public void setTelnetBindIp(String telnetBindIp) {
		this.telnetBindIp = telnetBindIp;
	}

	public String getTelnetPort() {
		return telnetPort;
	}

	public void setTelnetPort(String telnetPort) {
		this.telnetPort = telnetPort;
	}

	public int getLocalReportOnlinePeriod() {
		return localReportOnlinePeriod;
	}

	public void setLocalReportOnlinePeriod(int localReportOnlinePeriod) {
		this.localReportOnlinePeriod = localReportOnlinePeriod;
	}

	public int getLocalReportStatusPeriod() {
		return localReportStatusPeriod;
	}

	public void setLocalReportStatusPeriod(int localReportStatusPeriod) {
		this.localReportStatusPeriod = localReportStatusPeriod;
	}

	public long getWallowPeriod() {
		return wallowPeriod;
	}

	public void setWallowPeriod(long wallowPeriod) {
		this.wallowPeriod = wallowPeriod;
	}

	public boolean isWallowControlled() {
		return wallowControlled;
	}

	public void setWallowControlled(boolean wallowControlled) {
		this.wallowControlled = wallowControlled;
	}

	public FunctionSwitches getFuncSwitches() {
		return funcSwitches;
	}

	public int getAuthType() {
		return authType;
	}

	public void setAuthType(int authType) {
		this.authType = authType;
	}

	public int getBattleReportServiceType() {
		return battleReportServiceType;
	}

	public void setBattleReportServiceType(int battleReportServiceType) {
		this.battleReportServiceType = battleReportServiceType;
	}

	public String getBattleReportDbConfigName() {
		return battleReportDbConfigName;
	}

	public void setBattleReportDbConfigName(String battleReportDbConfigName) {
		this.battleReportDbConfigName = battleReportDbConfigName;
	}

	public String getBattleReportRootPath() {
		return battleReportRootPath;
	}

	public void setBattleReportRootPath(String battleReportRootPath) {
		this.battleReportRootPath = battleReportRootPath;
	}

	public boolean isBattleReportFileOutputOn() {
		return funcSwitches.isBattleReportFileOutput();
	}

	public void setBattleReportFileOutputOn(boolean value) {
		funcSwitches.setBattleReportFileOutput(value);
	}

	public boolean isChargeEnabled() {
		return funcSwitches.isChargeEnabled();
	}

	public void setChargeEnabled(boolean value) {
		funcSwitches.setChargeEnabled(value);
	}

	public void setDbVersion(String dbVersion) {
		this.dbVersion = dbVersion;
	}

	public String getDbVersion() {
		return dbVersion;
	}

	public int getOpenNewerGuide() {
		return this.openNewerGuide;
	}

	public void setOpenNewerGuide(int value) {
		this.openNewerGuide = value;
	}

	public int getMaxHumanLevel() {
		return this.maxHumanLevel;
	}

	public void setMaxHumanLevel(int value) {
		this.maxHumanLevel = value;
	}

	public String getOperationCom() {
		return operationCom;
	}

	public void setOperationCom(String operationCom) {
		this.operationCom = operationCom;
	}

	/**
	 * 使用异或方式加载模版资源 ?
	 * 
	 * @return
	 */
	public boolean isTemplateXorLoad() {
		return this.templateXorLoad;
	}

	/**
	 * 使用异或方式加载模版资源 ?
	 * 
	 * @param value
	 */
	public void setTemplateXorLoad(boolean value) {
		this.templateXorLoad = value;
	}

	public String getAppleStoreType() {
		return appleStoreType;
	}

	public void setAppleStoreType(String appleStoreType) {
		this.appleStoreType = appleStoreType;
	}

	// public boolean isOpenProbeLog() {
	// return openProbeLog;
	// }
	//
	// public void setOpenProbeLog(boolean openProbeLog) {
	// this.openProbeLog = openProbeLog;
	// }
	public void setLocalKey(String key) {
		this.localKey = key;
	}

	public String getLocalKey() {
		return this.localKey;
	}

	/**
	 * 获取车轮战功能是否开放?
	 * 
	 * @return <ul>
	 *         <li>0 = 关闭</li>
	 *         <li>1 = 开放</li>
	 *         </ul>
	 * 
	 */
	public int getOpenBossWar() {
		return this._openBossWar;
	}

	/**
	 * 设置车轮战功能是否开放
	 * 
	 * @param value
	 */
	public void setOpenBossWar(int value) {
		this._openBossWar = value;
	}

	/**
	 * 获取护送功能是否开放?
	 * 
	 * @return <ul>
	 *         <li>0 = 关闭</li>
	 *         <li>1 = 开放</li>
	 *         </ul>
	 * 
	 */
	public int getOpenEscort() {
		return this._openEscort;
	}

	/**
	 * 获取好友(关系)功能是否开放?
	 * 
	 * @return <ul>
	 *         <li>0 = 关闭</li>
	 *         <li>1 = 开放</li>
	 *         </ul>
	 * 
	 */
	public int getOpenRelation() {
		return this._openRelation;
	}

	public String getScribeServerIp() {
		return scribeServerIp;
	}

	public void setScribeServerIp(String scribeServerIp) {
		this.scribeServerIp = scribeServerIp;
	}

	public boolean isScribeOnTurn() {
		return scribeOnTurn;
	}

	public void setScribeOnTurn(boolean scribeOnTurn) {
		this.scribeOnTurn = scribeOnTurn;
	}

	// public boolean isAccountRoleDebug() {
	// return accountRoleDebug;
	// }
	//
	// public void setAccountRoleDebug(boolean accountRoleDebug) {
	// this.accountRoleDebug = accountRoleDebug;
	// }

	public boolean isUpgradeDbStrategy() {
		return upgradeDbStrategy;
	}

	public void setUpgradeDbStrategy(boolean upgradeDbStrategy) {
		this.upgradeDbStrategy = upgradeDbStrategy;
	}

	public int getDbUpdateInterval() {
		return dbUpdateInterval;
	}

	public void setDbUpdateInterval(int dbUpdateInterval) {
		this.dbUpdateInterval = dbUpdateInterval;
	}

	public boolean isCollectStrategy() {
		return collectStrategy;
	}

	public void setCollectStrategy(boolean collectStrategy) {
		this.collectStrategy = collectStrategy;
	}

	public int getCollectSimpling() {
		return collectSimpling;
	}

	public void setCollectSimpling(int collectSimpling) {
		this.collectSimpling = collectSimpling;
	}

	public ZLJ37wanwanConfig getZlj37wanwanConfig() {
		return zlj37wanwanConfig;
	}

	public void setZlj37wanwanConfig(ZLJ37wanwanConfig zlj37wanwanConfig) {
		this.zlj37wanwanConfig = zlj37wanwanConfig;
	}

	public boolean isAccountActivityOpen() {
		return accountActivityOpen;
	}

	public void setAccountActivityOpen(boolean accountActivityOpen) {
		this.accountActivityOpen = accountActivityOpen;
	}

	public boolean isBattleDebug() {
		return battleDebug;
	}

	public void setBattleDebug(boolean battleDebug) {
		this.battleDebug = battleDebug;
	}

	public boolean isZhichongFlag() {
		return zhichongFlag;
	}

	public void setZhichongFlag(boolean zhichongFlag) {
		this.zhichongFlag = zhichongFlag;
	}

	public int getSessionExpireTime() {
		return sessionExpireTime;
	}

	public void setSessionExpireTime(int sessionExpireTime) {
		this.sessionExpireTime = sessionExpireTime;
	}

	public int getCheckSessionExpireTime() {
		return checkSessionExpireTime;
	}

	public void setCheckSessionExpireTime(int checkSessionExpireTime) {
		this.checkSessionExpireTime = checkSessionExpireTime;
	}

	public boolean getSelfLogServer() {
		return selfLogServer;
	}

	public void setSelfLogServer(boolean isSelfLogServer) {
		this.selfLogServer = isSelfLogServer;
	}

	public int getMaxMonsterWarUsersNum() {
		return maxMonsterWarUsersNum;
	}

	public void setMaxMonsterWarUsersNum(int maxMonsterWarUsersNum) {
		this.maxMonsterWarUsersNum = maxMonsterWarUsersNum;
	}

	public int getMaxBossWarUsersNum() {
		return maxBossWarUsersNum;
	}

	public void setMaxBossWarUsersNum(int maxBossWarUsersNum) {
		this.maxBossWarUsersNum = maxBossWarUsersNum;
	}

	public String getApiRequestDomain() {
		return apiRequestDomain;
	}

	public void setApiRequestDomain(String apiRequestDomain) {
		this.apiRequestDomain = apiRequestDomain;
	}

	public boolean isKaiyingLog() {
		return kaiyingLog;
	}

	public void setKaiyingLog(boolean kaiyingLog) {
		this.kaiyingLog = kaiyingLog;
	}

	public WorldServerConfig getWorldServerConfig() {
		return worldServerConfig;
	}

	public void setWorldServerConfig(WorldServerConfig worldServerConfig) {
		this.worldServerConfig = worldServerConfig;
	}

	public int getPingWorldServerPeriod() {
		return pingWorldServerPeriod;
	}

	public void setPingWorldServerPeriod(int pingWorldServerPeriod) {
		this.pingWorldServerPeriod = pingWorldServerPeriod;
	}

	public String getDataEyeAppid() {
		return dataEyeAppid;
	}

	public void setDataEyeAppid(String dataEyeAppid) {
		this.dataEyeAppid = dataEyeAppid;
	}

	public String getDataEyeBaseFileDir() {
		return dataEyeBaseFileDir;
	}

	public void setDataEyeBaseFileDir(String dataEyeBaseFileDir) {
		this.dataEyeBaseFileDir = dataEyeBaseFileDir;
	}

	public int getDataEyeMaxHistoryLogFile() {
		return dataEyeMaxHistoryLogFile;
	}

	public void setDataEyeMaxHistoryLogFile(int dataEyeMaxHistoryLogFile) {
		this.dataEyeMaxHistoryLogFile = dataEyeMaxHistoryLogFile;
	}

	public int getDataEyeMaxHistoryDataFile() {
		return dataEyeMaxHistoryDataFile;
	}

	public void setDataEyeMaxHistoryDataFile(int dataEyeMaxHistoryDataFile) {
		this.dataEyeMaxHistoryDataFile = dataEyeMaxHistoryDataFile;
	}

	public String getReyunAppid() {
		return reyunAppid;
	}

	public void setReyunAppid(String reyunAppid) {
		this.reyunAppid = reyunAppid;
	}

	public String getReyunServer() {
		return reyunServer;
	}

	public void setReyunServer(String reyunServer) {
		this.reyunServer = reyunServer;
	}

	public String getReyunAppidIOS() {
		return reyunAppidIOS;
	}

	public void setReyunAppidIOS(String reyunAppidIOS) {
		this.reyunAppidIOS = reyunAppidIOS;
	}

}
