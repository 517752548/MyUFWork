package com.imop.lj.deploy.config;

import java.util.ArrayList;
import java.util.List;

import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlElement;

/**
 *
 *
 *
 */
public class GameManagerConfig {
	/**
	 * DB配置表，可通过xml读取
	 */
	private GameManagerDbConfigList gmDbConfigList;

	/**
	 * MMO DB配置，不可通过xml读取
	 */
	private GameMangerDBConfig gmMmoDBConfig;

	/**
	 * LOG DB配置，不可通过xml读取
	 */
	private GameMangerDBConfig gmLogDBConfig;

	public static GameManagerConfig buildFromDeployConfig(DeployConfig deployConfig) {
		GameManagerConfig _gmCongfig = new GameManagerConfig();
		GameManagerDbConfigList _gmDBCfgList = new GameManagerDbConfigList();

		List<GameMangerDBConfig> _gmDBList = new ArrayList<GameMangerDBConfig>();
		GameMangerDBConfig gmMmoDBConfig = new GameMangerDBConfig();
		GameMangerDBConfig gmLogDBConfig = new GameMangerDBConfig();

		DBConfig _mmoDb = deployConfig.getMmoDb();
		DBConfig _logDb = deployConfig.getLogDb();
		GameServerConfig _gameServer = deployConfig.getGameServer();
		LogServerConfig _logServer = deployConfig.getLogServer();
		ClientConfig _client = deployConfig.getClientConfig();

		// MMO DB的配置
		gmMmoDBConfig.setId(String.valueOf(deployConfig.getServerGroupId()));
		gmMmoDBConfig.setTypeId(deployConfig.getRegionId());
		gmMmoDBConfig.setDbSrvname(deployConfig.getName().substring(0, deployConfig.getName().indexOf('.')));

		gmMmoDBConfig.setSvrName(_client.getTitle());
		gmMmoDBConfig.setSvrId(deployConfig.getRegionId() * 1000 + deployConfig.getServerGroupId());
		gmMmoDBConfig.setSvrUrl("http://" + deployConfig.getName());

		gmMmoDBConfig.setDbIp(_mmoDb.getIp());
		gmMmoDBConfig.setDbPort(_mmoDb.getPort());
		gmMmoDBConfig.setDbName(_mmoDb.getDatabase());
		gmMmoDBConfig.setUser(_mmoDb.getUsername());
		gmMmoDBConfig.setPassword(_mmoDb.getPassword());
		gmMmoDBConfig.setTelIp(_gameServer.getLanIp());
		gmMmoDBConfig.setTelPort(_gameServer.getTelnetPort());

		_gmDBList.add(gmMmoDBConfig);

		// LOG DB的配置
		gmLogDBConfig.setId("log_" + deployConfig.getServerGroupId());
		gmLogDBConfig.setTypeId(deployConfig.getRegionId());
		gmLogDBConfig.setDbSrvname("log_" + deployConfig.getName().substring(0, deployConfig.getName().indexOf('.')));

		gmLogDBConfig.setSvrName(_client.getTitle());
		gmLogDBConfig.setSvrId(deployConfig.getRegionId() * 100 + deployConfig.getServerGroupId());
		gmLogDBConfig.setSvrUrl("http://" + deployConfig.getName());

		gmLogDBConfig.setDbIp(_logDb.getIp());
		gmLogDBConfig.setDbPort(_logDb.getPort());
		gmLogDBConfig.setDbName(_logDb.getDatabase());
		gmLogDBConfig.setUser(_logDb.getUsername());
		gmLogDBConfig.setPassword(_logDb.getPassword());
		gmLogDBConfig.setTelIp(_logServer.getLanIp());
		gmLogDBConfig.setTelPort(_logServer.getTelnetPort());

		_gmDBList.add(gmLogDBConfig);

		_gmDBCfgList.setGameServers(_gmDBList);
		_gmCongfig.setGameManagerDbConfigList(_gmDBCfgList);
		_gmCongfig.setGmMmoDBConfig(gmMmoDBConfig);
		_gmCongfig.setGmLogDBConfig(gmLogDBConfig);

		return _gmCongfig;
	}

	public GameMangerDBConfig getGmMmoDBConfig() {
		return gmMmoDBConfig;
	}

	private void setGmMmoDBConfig(GameMangerDBConfig gmMmoDBConfig) {
		this.gmMmoDBConfig = gmMmoDBConfig;
	}

	public GameMangerDBConfig getGmLogDBConfig() {
		return gmLogDBConfig;
	}

	private void setGmLogDBConfig(GameMangerDBConfig gmLogDBConfig) {
		this.gmLogDBConfig = gmLogDBConfig;
	}

	@XmlElement(name = "databases", required = true, nillable = false)
	public GameManagerDbConfigList getGameManagerDbConfigList() {
		return gmDbConfigList;
	}

	public void setGameManagerDbConfigList(GameManagerDbConfigList gameManagerDbConfigList) {
		this.gmDbConfigList = gameManagerDbConfigList;
	}

	public static class GameMangerDBConfig {
		/**
		 * 唯一id，与服务器端的serverId无关
		 */
		private String id;

		/**
		 * 表示是大区下某一组服,例如:typeId='1',它对应的大区是id="1"的龙之刃大区.
		 */
		private int typeId;

		/**
		 * 后台服务器名，与服务器端服务器名无关。如id="1"的名称为“test1”
		 */
		private String dbSrvname;

		/**
		 * 服务器端游戏服务器对应的名字,在快速通道中显示名称
		 */
		private String svrName;
		/**
		 * 取服务器端大区*100 + 服务器id
		 */
		private int svrId;

		/**
		 * 服务器端游戏服务器对应的ip地址或者域名,通过快速通道,在gm平台可以直接登录到游戏服务器中.
		 */
		private String svrUrl;
		/**
		 * 数据库ip
		 */
		private String dbIp;
		/**
		 * 数据库端口
		 */
		private int dbPort;
		/**
		 * 数据库名称
		 */
		private String dbName;
		/**
		 * 该数据库的用户名
		 */
		private String user;
		/**
		 * 该数据库的密码
		 */
		private String password;
		/**
		 * gm管理的游戏服务器的ip地址
		 */
		private String telIp;
		/**
		 * gm管理的游戏服务器的端口地址
		 */
		private int telPort;

		@XmlAttribute(required = true)
		public String getDbIp() {
			return dbIp;
		}

		@XmlAttribute(required = true)
		public String getDbName() {
			return dbName;
		}

		@XmlAttribute(required = true)
		public int getDbPort() {
			return dbPort;
		}

		@XmlAttribute(required = true)
		public String getDbSrvname() {
			return dbSrvname;
		}

		@XmlAttribute(required = true)
		public String getId() {
			return id;
		}

		@XmlAttribute(name = "ps", required = true)
		public String getPassword() {
			return password;
		}

		@XmlAttribute(required = true)
		public int getSvrId() {
			return svrId;
		}

		@XmlAttribute(required = true)
		public String getSvrName() {
			return svrName;
		}

		@XmlAttribute(required = true)
		public String getSvrUrl() {
			return svrUrl;
		}

		@XmlAttribute(required = true)
		public String getTelIp() {
			return telIp;
		}

		@XmlAttribute(required = true)
		public int getTelPort() {
			return telPort;
		}

		@XmlAttribute(required = true)
		public int getTypeId() {
			return typeId;
		}

		@XmlAttribute(name = "u", required = true)
		public String getUser() {
			return user;
		}

		public void setDbIp(String dbIp) {
			this.dbIp = dbIp;
		}

		public void setDbName(String dbName) {
			this.dbName = dbName;
		}

		public void setDbPort(int dbPort) {
			this.dbPort = dbPort;
		}

		public void setDbSrvname(String dbSrvname) {
			this.dbSrvname = dbSrvname;
		}

		public void setId(String id) {
			this.id = id;
		}

		public void setPassword(String password) {
			this.password = password;
		}

		public void setSvrId(int svrId) {
			this.svrId = svrId;
		}

		public void setSvrName(String svrName) {
			this.svrName = svrName;
		}

		public void setSvrUrl(String svrUrl) {
			this.svrUrl = svrUrl;
		}

		public void setTelIp(String telIp) {
			this.telIp = telIp;
		}

		public void setTelPort(int telPort) {
			this.telPort = telPort;
		}

		public void setTypeId(int typeId) {
			this.typeId = typeId;
		}

		public void setUser(String user) {
			this.user = user;
		}
	}

	public static class GameManagerDbConfigList {
		List<GameMangerDBConfig> gmDbConfigList;

		@XmlElement(name = "database")
		public List<GameMangerDBConfig> getGameManagerDBs() {
			return gmDbConfigList;
		}

		public void setGameServers(List<GameMangerDBConfig> gmDBs) {
			this.gmDbConfigList = gmDBs;
		}
	}

}
