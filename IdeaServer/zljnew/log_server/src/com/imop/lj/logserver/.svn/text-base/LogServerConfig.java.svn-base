package com.imop.lj.logserver;

import org.apache.mina.core.service.IoHandlerAdapter;

import com.imop.lj.core.config.ServerConfig;
import com.imop.lj.core.msg.recognizer.IMessageRecognizer;
import com.imop.lj.logserver.createtable.ITableCreator;

/**
 * 定义LogServerConfig,源自天书log_server的同名类
 * 
 * @author <a href="mailto:fan.lin@opi-corp.com">lin fan<a>
 * 
 * 
 * 
 */
public class LogServerConfig extends ServerConfig {

	/** 是否是Debug模式 */
	private boolean debug = false;

	/** LogServer监听端口,必填 */
	private int port;

	/** 服务绑定的地址,必填 */
	private String bindIp;

	/** 消息识别配置,必填 */
	private IMessageRecognizer messageRecognizer;

	/** 消息处理器,必填 */
	private IoHandlerAdapter logMessageHandler;

	/** 日志表创建器,必填 */
	private ITableCreator iTableCreator;

	/** IBatis的配置文件路径,该文件必须存在于Classpath中,必填 */
	private String ibatisConfig;

	/** 定时创建每日日志表任务启动的延迟时间 */
	private long createTableTaskDelay;

	/** 定时创建每日日志表任务的执行周期 */
	private long createTableTaskPeriod;

	/** 定時刪除每日日志表任务启动时间,相对于每日零点时间：例如每日两点：2 * 24 * 60 * 1000 */
	private long dropTableTaskStartTime;

	/** 定时删除每日日志任务表任务的执行周期 */
	private long dropTableTaskPeriod;

	/** 服务器名称 */
	private String serverName;

	/** Telnet服务器名称 */
	private String telnetServerName;
	/** Telnet绑定的ip */
	private String telnetBindIp;
	/** Telnet绑定的端口 */
	private String telnetPort;

	/** 是否删除过期表 */
	private boolean dropLogTables;

	/** 日志数据库 */
	private String database;

	/** 金钱日志存活时间 */
	private int moneyLogLiveTime = -1;
	
	/** 物品生成日志存活时间 */
	private int itemGenLogLiveTime = -1;
	
	/** 充值日志存活时间 */
	private int chargeLogLiveTime = -1;
	
	/** 默认存活时间 */
	private int defLiveTime = 15;

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

	public String getServerName() {
		return serverName;
	}

	public void setServerName(String serverName) {
		this.serverName = serverName;
	}

	public long getCreateTableTaskDelay() {
		return createTableTaskDelay;
	}

	public void setCreateTableTaskDelay(long createTableTaskDelay) {
		this.createTableTaskDelay = createTableTaskDelay;
	}

	public long getCreateTableTaskPeriod() {
		return createTableTaskPeriod;
	}

	public void setCreateTableTaskPeriod(long createTableTaskPeriod) {
		this.createTableTaskPeriod = createTableTaskPeriod;
	}

	public String getIbatisConfig() {
		return ibatisConfig;
	}

	public void setIbatisConfig(String ibatisConfig) {
		this.ibatisConfig = ibatisConfig;
	}

	public ITableCreator getTableCreator() {
		return iTableCreator;
	}

	public void setTableCreator(ITableCreator iTableCreator) {
		this.iTableCreator = iTableCreator;
	}

	public boolean isDebug() {
		return debug;
	}

	public void setDebug(boolean debug) {
		this.debug = debug;
	}

	public int getPort() {
		return port;
	}

	public void setPort(int port) {
		this.port = port;
	}

	public static void print() {
	}

	public String getBindIp() {
		return bindIp;
	}

	public void setBindIp(String bindIp) {
		this.bindIp = bindIp;
	}

	public IMessageRecognizer getMessageRecognizer() {
		return messageRecognizer;
	}

	public void setMessageRecognizer(IMessageRecognizer messageRecognizer) {
		this.messageRecognizer = messageRecognizer;
	}

	public IoHandlerAdapter getLogMessageHandler() {
		return logMessageHandler;
	}

	public void setLogMessageHandler(IoHandlerAdapter logMessageHandler) {
		this.logMessageHandler = logMessageHandler;
	}

	/**
	 * 配置配置完成后进行
	 * 
	 * @exception IllegalStateException
	 */
	public void validate() {
		if (port <= 0) {
			throw new IllegalStateException("The port must be > 0.");
		}
		if (this.bindIp == null
				|| (this.bindIp = this.bindIp.trim()).length() == 0) {
			throw new IllegalStateException("The bindAddress must not be empty");
		}
		if (this.messageRecognizer == null) {
			throw new IllegalStateException(
					"The messageRecognizer must not be null.");
		}
		if (this.logMessageHandler == null) {
			throw new IllegalStateException(
					"The logMessageHandler must not be null");
		}
		if (this.ibatisConfig == null
				|| (this.ibatisConfig = this.ibatisConfig.trim()).length() == 0) {
			throw new IllegalStateException(
					"The ibatisConfig must not be null.");
		}
		// 版本号配置检查
		if (this.getVersion() == null) {
			throw new IllegalArgumentException("The version  must not be null");
		}
		/*
		 * if (this.tableCreator == null) { throw new
		 * IllegalStateException("The tableCreator must not be null"); }
		 */
		if (this.createTableTaskDelay <= 0) {
			throw new IllegalStateException(
					"The createTableTaskDelay must be >0");
		}
		if (this.createTableTaskPeriod <= 0) {
			throw new IllegalStateException(
					"The createTableTaskPeriod must be >0");
		}

	}

	public String getDatabase() {
		return database;
	}

	public void setDatabase(String database) {
		this.database = database;
	}

	public boolean isDropLogTables() {
		return dropLogTables;
	}

	public void setDropLogTables(boolean dropLogTables) {
		this.dropLogTables = dropLogTables;
	}

	public int getMoneyLogLiveTime() {
		return moneyLogLiveTime;
	}

	public void setMoneyLogLiveTime(int moneyLogLiveTime) {
		this.moneyLogLiveTime = moneyLogLiveTime;
	}

	public int getItemGenLogLiveTime() {
		return itemGenLogLiveTime;
	}

	public void setItemGenLogLiveTime(int itemGenLogLiveTime) {
		this.itemGenLogLiveTime = itemGenLogLiveTime;
	}

	public int getDefLiveTime() {
		return defLiveTime;
	}

	public void setDefLiveTime(int defLiveTime) {
		this.defLiveTime = defLiveTime;
	}

	public long getDropTableTaskStartTime() {
		return dropTableTaskStartTime;
	}

	public void setDropTableTaskStartTime(long dropTableTaskStartTime) {
		this.dropTableTaskStartTime = dropTableTaskStartTime;
	}

	public long getDropTableTaskPeriod() {
		return dropTableTaskPeriod;
	}

	public void setDropTableTaskPeriod(long dropTableTaskPeriod) {
		this.dropTableTaskPeriod = dropTableTaskPeriod;
	}

	public int getChargeLogLiveTime() {
		return chargeLogLiveTime;
	}

	public void setChargeLogLiveTime(int chargeLogLiveTime) {
		this.chargeLogLiveTime = chargeLogLiveTime;
	}
}
