package com.imop.lj.deploy.config;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

/**
 * 部署配置
 *
 *
 */
@XmlRootElement(name = "deploy_config")
@XmlAccessorType(XmlAccessType.PROPERTY)
public class DeployConfig {
	/** 名称 */
	private String name;
	/** 语言 */
	private String language = "zh_CN";
	/** 大区ID */
	private int regionId;
	/** 服务器组ID */
	private int serverGroupId;

	/** 是否为调试模式,默认为0：生产模式 */
	private int debug = 0;

	/** local的域名 */
	private String localDomain = "local.tr.mop.com";
	
	private String apiDomain = "127.0.0.1:8080";
	/** 认证方式,默认为1：local认证 */
	private int authType = 1;

	private String platformName="";

	/** 数据表资源  */
	private ResourceConfig resConfig;

	/** 战报保存目录 */
	private BattleReportDirConfig reportConfig;

	/** mmo的业务数据库 */
	private DBConfig mmoDb;
	/** 日志数据库 */
	private DBConfig logDb;
	/** 战报数据库 */
	private DBConfig battleReportDb;

	/** 日志服务器 */
	private LogServerConfig logServer;
	/** Game Server */
	private GameServerConfig gameServer;
	/** 客户端配置 */
	private ClientConfig clientConfig;

	/** 定时消息调度器初始化类型 0：使用ScheduledExecutorService 1：使用Timer 默认： 0 */
	private int scheduleInitType = 0;
	/** 平台名称  */
	private String channelName = "";
	
	private String scribeIp="127.0.0.1";
	
	/**
	 * 合服时用到的名字后缀，标识玩家是那个服的，如 1区
	 */
	protected String mergeName = "";

	@XmlAttribute()
	public int getScheduleInitType() {
		return scheduleInitType;
	}

	public void setScheduleInitType(int scheduleInitType) {
		this.scheduleInitType = scheduleInitType;
	}

	@XmlAttribute(required = true)
	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	@XmlAttribute(required = true)
	public String getLanguage() {
		return language;
	}

	public void setLanguage(String language) {
		this.language = language;
	}

	@XmlElement(name = "mmo_db", required = true, nillable = false)
	public DBConfig getMmoDb() {
		return mmoDb;
	}

	public void setMmoDb(DBConfig mmoDb) {
		this.mmoDb = mmoDb;
	}

	@XmlElement(name = "battle_report_db", required = true, nillable = false)
	public DBConfig getBattleReportDb() {
		return battleReportDb;
	}

	public void setBattleReportDb(DBConfig battleReportDb) {
		this.battleReportDb = battleReportDb;
	}

	@XmlElement(name = "log_db", required = true, nillable = false)
	public DBConfig getLogDb() {
		return logDb;
	}

	public void setLogDb(DBConfig logDb) {
		this.logDb = logDb;
	}

	@XmlElement(name = "game_server", required = true, nillable = false)
	public GameServerConfig getGameServer() {
		return gameServer;
	}

	public void setGameServer(GameServerConfig gameServer) {
		this.gameServer = gameServer;
	}

	@XmlElement(name = "log_server", required = true, nillable = false)
	public LogServerConfig getLogServer() {
		return logServer;
	}

	public void setLogServer(LogServerConfig logServer) {
		this.logServer = logServer;
	}


	@XmlElement(name = "client", required = true, nillable = false)
	public ClientConfig getClientConfig() {
		return this.clientConfig;
	}

	public void setClientConfig(ClientConfig clientConfig) {
		this.clientConfig = clientConfig;
	}

	/**
	 * @return the regionId
	 */
	@XmlAttribute(required = true)
	public int getRegionId() {
		return regionId;
	}

	/**
	 * @param regionId
	 *            the regionId to set
	 */
	public void setRegionId(int regionId) {
		this.regionId = regionId;
	}

	/**
	 * @return the serverGroupId
	 */
	@XmlAttribute(required = true)
	public int getServerGroupId() {
		return serverGroupId;
	}

	/**
	 * @param serverGroupId
	 *            the serverGroupId to set
	 */
	public void setServerGroupId(int serverGroupId) {
		this.serverGroupId = serverGroupId;
	}

	/**
	 * 取得游戏世界ID,提供给Local使用,regionId*100+服号,如101,表示1区,1服
	 *
	 * @return
	 */
	public int getLocalHostId() {
		return this.regionId * 1000 + this.serverGroupId;
	}

	@XmlAttribute()
	public String getApiDomain() {
		return apiDomain;
	}

	public void setApiDomain(String apiDomain) {
		this.apiDomain = apiDomain;
	}

	/**
	 * @return the localDomain
	 */
	@XmlAttribute()
	public String getLocalDomain() {
		return localDomain;
	}

	/**
	 * @param localDomain
	 *            the localDomain to set
	 */
	public void setLocalDomain(String localDomain) {
		this.localDomain = localDomain;
	}

	/**
	 * @return the debug
	 *
	 */
	@XmlAttribute()
	public int getDebug() {
		return debug;
	}

	public void setDebug(int debug) {
		this.debug = debug;
	}

	/**
	 * @return the authType
	 */
	@XmlAttribute()
	public int getAuthType() {
		return authType;
	}

	public int getGameServerCount() {
		return 1;
	}

	/**
	 * @param authType
	 *            the authType to set
	 */
	public void setAuthType(int authType) {
		this.authType = authType;
	}


	public void setResConfig(ResourceConfig resConfig) {
		this.resConfig = resConfig;
	}


	public void setReportConfig(BattleReportDirConfig reportConfig) {
		this.reportConfig = reportConfig;
	}


	@XmlElement(name = "resource", required = true, nillable = false)
	public ResourceConfig getResConfig() {
		return resConfig;
	}

	@XmlElement(name = "battleReport", required = true, nillable = false)
	public BattleReportDirConfig getReportConfig() {
		return reportConfig;
	}

	@XmlAttribute()
	public String getPlatformName() {
		return platformName;
	}

	public void setPlatformName(String platformName) {
		this.platformName = platformName;
	}
	
	@XmlAttribute()
	public String getChannelName() {
		return channelName;
	}

	public void setChannelName(String channelName) {
		this.channelName = channelName;
	}
	
	public String getPrefixServerName(){
		return this.getName().split("\\.")[0];
	}
	
	@XmlAttribute()
	public String getScribeIp() {
		return scribeIp;
	}

	public void setScribeIp(String scribeIp) {
		this.scribeIp = scribeIp;
	}

	@XmlAttribute()
	public String getMergeName() {
		return mergeName;
	}

	public void setMergeName(String mergeName) {
		this.mergeName = mergeName;
	}

	@Override
	public String toString() {
		return "DeployConfig [name=" + name + ", language=" + language
				+ ", regionId=" + regionId + ", serverGroupId=" + serverGroupId
				+ ", debug=" + debug + ", localDomain=" + localDomain
				+ ", apiDomain=" + apiDomain + ", authType=" + authType
				+ ", platformName=" + platformName + ", resConfig=" + resConfig
				+ ", reportConfig=" + reportConfig + ", mmoDb=" + mmoDb
				+ ", logDb=" + logDb + ", battleReportDb=" + battleReportDb
				+ ", logServer=" + logServer + ", gameServer=" + gameServer
				+ ", clientConfig=" + clientConfig + ", scheduleInitType="
				+ scheduleInitType + ", channelName=" + channelName
				+ ", scribeIp=" + scribeIp + ", mergeName=" + mergeName + "]";
	}
	
	
}
