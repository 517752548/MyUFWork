package com.imop.lj.core.config;

import java.io.File;

import com.imop.lj.common.constants.CommonErrorLogInfo;
import com.imop.lj.core.util.ErrorsUtil;
import com.imop.lj.core.util.StringUtils;
import com.imop.lj.probe.config.ProbeConfig;

/**
 * {@link Config}的简单实现
 *
 */
public abstract class ServerConfig implements Config {
	/**
	 * 服务器类型：1-GameServer 2-WorldServer 3-LoginServer 4-DBSServer 5-AgentServer 6-LogServer
	 */
	protected int serverType;
	/** 生产模式:0 调式模式:1 */
	protected int debug = 0;
	
	/** 配置文件是否加密*/
	protected boolean encryptResource = false;
	
	/** 系统的字符编码 */
	protected String charset;
	/** 系统配置的版本号 */
	protected String version;
	/** 系统配置的资源版本号 */
	protected String resourceVersion;
	/** 大区的ID */
	protected String regionId;
	/** 服的ID */
	protected String serverGroupId;
	/** 游戏世界ID,提供给Local使用,规则是 regionId*serverGroupId,如101,表示1区,1服 */
	protected String localHostId;
	/** 服务器ID 规则是:是 localHostId+serverIndexId,如1011,表示1区,1服的第一个服务器 */
	protected String serverId;
	/** 服务绑定的IP */
	protected String bindIp;
	/** 服务器在服务器组中的索引值 */
	protected int serverIndex;
	/** 服务器监听的端口,多个商品以逗号","分隔 */
	protected String ports;
	/** 服务器的名称 */
	protected String serverName;
	/** 服务器的主机ip */
	protected String serverHost;
	/** 服务器组的域名 s1.l.mop.com */
	protected String serverDomain;
	/** 每个端口IO处理的线程个数 */
	protected int ioProcessor;
	/** 系统所使用的语言 */
	protected String language;
	/** 多语言资源所在的目录 */
	protected String i18nDir;
	/** 资源文件根目录 */
	protected String baseResourceDir;
	/** 脚本所在的目录 */
	protected String scriptDir;
	/** 脚本的头文件 */
	protected String scriptHeaderName;
	
	/** 地图文件的目录 */
	protected String mapDir;

	/** 物品编辑器自动生成的配置目录 */
	protected String exportDataDir;
	/** Flash 客户端发送poliyc请求时的响应 */
	protected String flashSocketPolicy;
	/** Local的URL地址 */
	protected String localDomain;
	/** 是否定时检查玩家的连接 */
	protected boolean checkPing;
	/** 如果checkPing为true,表示ping的周期,单位秒 */
	protected int pingPeriod;
	/** ping的超时时间，操作该时间未收到ping消息，则断开客户端连接 */
	protected int pingTimeOut;
	/** 数据库初始化类型： 0 Hibernate 1 Ibatis */
	protected int dbInitType = 0;
	/** 数据库配置文件路径 */
	protected String dbConfigName;
//	/** h2配置文件路径 */
//	protected String h2ConfigName;

	/** GameServer个数 */
	protected int gameServerCount;

	/** 是否使用H2Cache */
	protected boolean turnOnH2Cache = false;

	/** 是否在启动时加载所有角色 */
	protected boolean loadAllHumansToCache = true;

	/** 是否开启local接口 */
	protected boolean turnOnLocalInterface = false;
	/** 请求接口所在域名 */
	protected String requestDomain;
	/** 汇报接口所在域名 */
	protected String reportDomain;

	/** Log Server配置 */
	protected LogConfig logConfig = new LogConfig();
	/** 性能探针配置 */
	protected ProbeConfig probeConfig = new ProbeConfig();

	/** 写死的，没在配置里 */
	protected String gameId = "ts";

	/** MIS (后台)系统 IP 地址 */
	protected String misIps = null;

	/**充值 人人豆兑换元宝的比率是1：10 ***/
	protected int chargeMM2DiamondRate =10;

	protected String platformName="renren.com";
	
	/** dirtyWorlds简版地址 */
	protected String dirtyWordsPartUrl = "http://down.51rs.cn/games-common/dirtywords/part.csv";
	/** dirtyWorlds完全版地址 */
	protected String dirtyWordsFullUrl = "http://down.51rs.cn/games-common/dirtywords/full.csv";
	
	/** 防洪水的控制 */
	protected boolean floodControl = false;

	public int getChargeMM2DiamondRate() {
		return chargeMM2DiamondRate;
	}

	public void setChargeMM2DiamondRate(int chargeMM2DiamondRate) {
		this.chargeMM2DiamondRate = chargeMM2DiamondRate;
	}

	@Override
	public boolean getIsDebug() {
		return getDebug() == 1;
	}

	@Override
	public String getVersion() {
		return this.version;
	}

	public void setVersion(String version) {
		this.version = version;
	}

	/**
	 * 取得资源文件的绝对路径
	 *
	 * @param path
	 * @return
	 */
	public String getResourceFullPath(String path) {
		return this.baseResourceDir + File.separator + path;
	}

	/**
	 * 取得资源文件的绝对路径
	 *
	 * @param pathes
	 *            路径的参数,每个参数将使用路径分隔符连接起来
	 * @return
	 */
	public String getResourceFullPath(String... pathes) {
		StringBuilder _sb = new StringBuilder();
		_sb.append(this.baseResourceDir);
		for (String _path : pathes) {
			_sb.append(File.separator);
			_sb.append(_path);
		}
		return _sb.toString();
	}

	public String getBaseResourceDir() {
		return baseResourceDir;
	}

	public void setBaseResourceDir(String baseResourceDir) {
		this.baseResourceDir = baseResourceDir;
	}

	public String getLanguage() {
		return language;
	}

	public void setLanguage(String language) {
		this.language = language;
	}

	public String getI18nDir() {
		return i18nDir;
	}

	public void setI18nDir(String dir) {
		i18nDir = dir;
	}

	public String getCharset() {
		return charset;
	}

	public void setCharset(String charset) {
		this.charset = charset;
	}

	/**
	 * @return the localHostId
	 */
	public String getLocalHostId() {
		return localHostId;
	}

	/**
	 * @param localHostId
	 *            the localHostId to set
	 */
	public void setLocalHostId(String localHostId) {
		this.localHostId = localHostId;
	}

	public void setRegionId(String regionId) {
		this.regionId = regionId;
	}

	public String getRegionId() {
		return regionId;
	}

	/**
	 * @return the serverId
	 */
	public String getServerId() {
		return serverId;
	}
	
	public int getServerIdInt() {
		return Integer.parseInt(serverId);
	}

	/**
	 * @param serverId
	 *            the serverId to set
	 */
	public void setServerId(String serverId) {
		this.serverId = serverId;
	}

	/**
	 * @return the serverGroupId
	 */
	public String getServerGroupId() {
		return serverGroupId;
	}

	/**
	 * @param serverGroupId
	 *            the serverGroupId to set
	 */
	public void setServerGroupId(String serverGroupId) {
		this.serverGroupId = serverGroupId;
	}

	/**
	 * @return the serverIndexId
	 */
	public int getServerIndex() {
		return serverIndex;
	}

	/**
	 * @param serverIndexId
	 *            the serverIndexId to set
	 */
	public void setServerIndex(int serverIndex) {
		this.serverIndex = serverIndex;
	}

	public String getBindIp() {
		return bindIp;
	}

	public void setBindIp(String bindIp) {
		this.bindIp = bindIp;
	}

	public String getPorts() {
		return ports;
	}

	public void setPorts(String ports) {
		this.ports = ports;
	}

	public String getServerName() {
		return serverName;
	}

	public void setServerName(String serverName) {
		this.serverName = serverName;
	}

	public String getServerHost() {
		return serverHost;
	}

	public void setServerHost(String serverHost) {
		this.serverHost = serverHost;
	}

	/**
	 * @return the ioProcessor
	 */
	public int getIoProcessor() {
		return ioProcessor;
	}

	/**
	 * @param ioProcessor
	 *            the ioProcessor to set
	 */
	public void setIoProcessor(int ioProcessor) {
		this.ioProcessor = ioProcessor;
	}


	public boolean isTurnOnH2Cache() {
		return turnOnH2Cache;
	}

	public boolean isLoadAllHumansToCache() {
		return loadAllHumansToCache;
	}

	public void setTurnOnH2Cache(boolean turnOnH2Cache) {
		this.turnOnH2Cache = turnOnH2Cache;
	}

	public LogConfig getLogConfig() {
		return logConfig;
	}

	public void setDebug(int debug) {
		this.debug = debug;
	}

	public int getDebug() {
		return debug;
	}

	public String getScriptDir() {
		return scriptDir;
	}

	public void setScriptDir(String scriptDir) {
		this.scriptDir = scriptDir;
	}

	public String getFlashSocketPolicy() {
		return flashSocketPolicy;
	}

	public void setFlashSocketPolicy(String flashSocketPolicy) {
		this.flashSocketPolicy = flashSocketPolicy;
	}

	public boolean isCheckPing() {
		return checkPing;
	}

	public void setCheckPing(boolean checkPing) {
		this.checkPing = checkPing;
	}

	public int getPingPeriod() {
		return pingPeriod;
	}

	public void setPingPeriod(int pingPeriod) {
		this.pingPeriod = pingPeriod;
	}

	public int getDbInitType() {
		return dbInitType;
	}

	public void setDbInitType(int dbInitType) {
		this.dbInitType = dbInitType;
	}

	public String getDbConfigName() {
		return dbConfigName;
	}


	public void setDbConfigName(String dbConfigName) {
		this.dbConfigName = dbConfigName;
	}

//	public String getH2ConfigName() {
//		return h2ConfigName;
//	}
//
//	public void setH2ConfigName(String h2ConfigName) {
//		this.h2ConfigName = h2ConfigName;
//	}

	public void setExportDataDir(String exportDataDir) {
		this.exportDataDir = exportDataDir;
	}

	public String getExportDataDir() {
		return exportDataDir;
	}

	public void setScriptHeaderName(String scriptHeaderName) {
		this.scriptHeaderName = scriptHeaderName;
	}

	public String getScriptHeaderName() {
		return scriptHeaderName;
	}

	/**
	 * @return the localDomain
	 */
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

	public int getPingTimeOut() {
		return pingTimeOut;
	}

	public void setPingTimeOut(int pingTimeOut) {
		this.pingTimeOut = pingTimeOut;
	}

	public void setServerType(int serverType) {
		this.serverType = serverType;
	}

	public int getServerType() {
		return serverType;
	}



	/**
	 * Log Server 配置
	 *
	 *
	 */
	public static class LogConfig {
		/** Log Server地址 */
		private String logServerIp;
		/** Log Server端口 */
		private int logServerPort;

		public void setLogServerIp(String logServerIp) {
			this.logServerIp = logServerIp;
		}

		public String getLogServerIp() {
			return logServerIp;
		}

		public void setLogServerPort(int logServerPort) {
			this.logServerPort = logServerPort;
		}

		public int getLogServerPort() {
			return logServerPort;
		}

	}

	@Override
	public void validate() {
		if (serverType < 1) {
			throw new IllegalArgumentException(
					"The serverType must not be empty");
		}

		if (StringUtils.isEmpty(this.regionId)
				|| StringUtils.isEmpty(this.serverGroupId)) {
			throw new IllegalArgumentException(
					"The regionId,serverGroupId and the serverIndexId must not be empty");
		}
		if (StringUtils.isEmpty(this.localHostId)
				|| StringUtils.isEmpty(this.serverId)) {
			throw new IllegalArgumentException(
					"The localHostId and the serverId must not be empty");
		}
		if (this.ports == null || (ports = ports.trim()).length() == 0) {
			throw new IllegalArgumentException(ErrorsUtil.error(
					CommonErrorLogInfo.ARG_NOT_NULL_EXCEPT, "", "ports"));
		}
		// 版本号配置检查
		if (this.getVersion() == null) {
			throw new IllegalArgumentException("The version  must not be null");
		}
		if (checkPing) {
			// 如果启用ping,那么ping的周期应该大于0
			if (this.pingPeriod <= 0) {
				throw new IllegalArgumentException(ErrorsUtil.error(
						CommonErrorLogInfo.ARG_POSITIVE_NUMBER_EXCEPT, "",
						"pingPeriod"));
			}
		}
		if (serverType == 1) {
			/* 日志服务器检查 */
			if (this.logConfig.logServerIp == null
					|| (this.logConfig.logServerIp = logConfig.logServerIp
							.trim()).length() == 0) {
				throw new IllegalArgumentException(
						"The logsConfig.logServerIp must not be null.");
			}

			if (this.logConfig.logServerPort <= 0) {
				throw new IllegalArgumentException(
						"The logsConfig.logServerPort must be greater than 0.");
			}
		}

		/* 性能汇报检查 */
		if (this.probeConfig.getReporterIp() == null) {
			throw new IllegalArgumentException(
					"The probeConfig.reporterIp must not be null.");
		}
		this.probeConfig.setReporterIp(probeConfig.getReporterIp().trim());
		if (probeConfig.getReporterIp().length() == 0) {
			throw new IllegalArgumentException(
					"The probeConfig.reporterIp must not be null.");
		}
		if (this.probeConfig.getReporterPort() <= 0) {
			throw new IllegalArgumentException(
					"The probeConfig.reporterPort must be greater than 0.");
		}

	}


	public void setServerDomain(String serverDomain) {
		this.serverDomain = serverDomain;
	}

	public String getServerDomain() {
		return serverDomain;
	}

	/**
	 * 获得脚本文件全目录
	 *
	 * @return
	 */
	public String getScriptDirFullPath() {
		return this.getResourceFullPath(this.getScriptDir());
	}
	
	/**
	 * 获取地图文件的全目录
	 * @return
	 */
	public String getMapDirFullPath() {
		return this.getResourceFullPath(this.getMapDir());
	}

	public void setResourceVersion(String resourceVersion) {
		this.resourceVersion = resourceVersion;
	}

	public String getResourceVersion() {
		return resourceVersion;
	}

	public void setGameServerCount(int gameServerCount) {
		this.gameServerCount = gameServerCount;
	}

	public int getGameServerCount() {
		return gameServerCount;
	}

	public boolean isTurnOnLocalInterface() {
		return turnOnLocalInterface;
	}

	public void setTurnOnLocalInterface(boolean turnOnLocalInterface) {
		this.turnOnLocalInterface = turnOnLocalInterface;
	}

	public String getRequestDomain() {
		return requestDomain;
	}

	public void setRequestDomain(String requestDomain) {
		this.requestDomain = requestDomain;
	}

	public String getReportDomain() {
		return reportDomain;
	}

	public void setReportDomain(String reportDomain) {
		this.reportDomain = reportDomain;
	}



	/**
	 * 获取 MIS (后台)系统 IP 地址
	 *
	 * @return
	 */
	public String getMisIps() {
		return this.misIps;
	}

	/**
	 * 设置 MIS (后台)系统 IP 地址
	 *
	 * @param allowedIps
	 */
	public void setMisIps(String allowedIps) {
		this.misIps = allowedIps;
	}

	public ProbeConfig getProbeConfig() {
		return probeConfig;
	}

	public String getGameId() {
		return gameId;
	}

	public void setGameId(String gameId) {
		this.gameId = gameId;
	}

	public String getPlatformName() {
		return platformName;
	}

	public void setPlatformName(String platformName) {
		this.platformName = platformName;
	}

	public String getDirtyWordsPartUrl() {
		return dirtyWordsPartUrl;
	}

	public void setDirtyWordsPartUrl(String dirtyWordsPartUrl) {
		this.dirtyWordsPartUrl = dirtyWordsPartUrl;
	}

	public String getDirtyWordsFullUrl() {
		return dirtyWordsFullUrl;
	}

	public void setDirtyWordsFullUrl(String dirtyWordsFullUrl) {
		this.dirtyWordsFullUrl = dirtyWordsFullUrl;
	}

	public boolean isEncryptResource() {
		return encryptResource;
	}

	public void setEncryptResource(boolean encryptResource) {
		this.encryptResource = encryptResource;
	}

	public String getMapDir() {
		return mapDir;
	}

	public void setMapDir(String mapDir) {
		this.mapDir = mapDir;
	}

	public boolean isFloodControl() {
		return floodControl;
	}

	public void setFloodControl(boolean floodControl) {
		this.floodControl = floodControl;
	}
	
}
