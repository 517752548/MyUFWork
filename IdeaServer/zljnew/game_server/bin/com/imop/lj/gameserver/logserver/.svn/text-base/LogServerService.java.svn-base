package com.imop.lj.gameserver.logserver;

import java.net.URL;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.HashMap;
import java.util.Map;
import java.util.Timer;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.config.ConfigUtil;
import com.imop.lj.core.msg.MessageQueue;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.logserver.BaseLogMessage;
import com.imop.lj.logserver.LogServerConfig;
import com.imop.lj.logserver.common.LogServerHeartbeatThread;
import com.imop.lj.logserver.createtable.CreateTabaleTask;
import com.imop.lj.logserver.createtable.CreateTimer;
import com.imop.lj.logserver.createtable.ITableCreator;
import com.imop.lj.logserver.dao.DBConnection;
import com.imop.lj.logserver.dao.LogDao;
import com.imop.lj.logserver.droptable.DropTableTask;
import com.imop.lj.logserver.util.ResourcePathUtil;

public class LogServerService implements InitializeRequired {
	private static final String LOG_SERVER_CFG_JS = "log_server.cfg.js";
	
	protected static boolean SendLogToWorld = true;

	/** 日志服务器配置 */
	private LogServerConfig config = new LogServerConfig();

	/** 日志表创建器 */
	private ITableCreator iTableCreator;

	/** 心跳线程，处理消息 */
	private LogServerHeartbeatThread heartbeatThread;
	/** 消息队列 */
	private MessageQueue msgQueue;
	/** 是否初始化过 */
	private boolean isInited;

	/** 定时建表的timer */
	private Timer createTableTimer;
	
	@Override
	public void init() {
		if (isInited) {
			return;
		}

		msgQueue = new MessageQueue();
		heartbeatThread = new LogServerHeartbeatThread(msgQueue,
				Loggers.logServerServiceLogger);

		// logserver配置文件
		URL url = ResourcePathUtil.getRootPath(LOG_SERVER_CFG_JS);
		if (null == url) {
			throw new RuntimeException("Can't locate the config file "
					+ LOG_SERVER_CFG_JS + " in the classpath.");
		}
		Loggers.logServerServiceLogger
			.info("#LogServerService#init#log server cfg url=" + url);

		config = ConfigUtil.buildConfig(LogServerConfig.class, url);

		// 初始化数据库连接
		final URL _ibatisConfigFile = ResourcePathUtil.getRootPath(config.getIbatisConfig());
		if (_ibatisConfigFile == null) {
			throw new RuntimeException("Can't locate the ibatis config file "
					+ config.getIbatisConfig() + " in the classpath.");
		}

		Loggers.logServerServiceLogger
				.info("#LogServerService#init#log server _ibatisConfigFile url="
						+ _ibatisConfigFile);

		DBConnection.initDBConnection(_ibatisConfigFile);

		if (DBConnection.getInstance().getTypes().isEmpty()) {
			if (Loggers.logServerServiceLogger.isWarnEnabled()) {
				Loggers.logServerServiceLogger.warn("No log type found.");
			}
		}

		iTableCreator = config.getTableCreator();

		iTableCreator.setBaseTableNames(DBConnection.getInstance().getTypes());
		
		// 设置特殊日志表存活时间
		Map<String, Integer> specLogLiveTimeMap = new HashMap<String, Integer>();
		specLogLiveTimeMap.put("money_log", this.config.getMoneyLogLiveTime());
		specLogLiveTimeMap.put("item_gen_log", this.config.getItemGenLogLiveTime());
		specLogLiveTimeMap.put("charge_log", this.config.getChargeLogLiveTime());
		iTableCreator.setSpecLogLiveTimeMap(specLogLiveTimeMap);
		
		// 设置日志服务器配置
		iTableCreator.setLogServerConfig(config);

		if (Loggers.logServerServiceLogger.isInfoEnabled()) {
			Loggers.logServerServiceLogger.info("Table creator class:"
					+ this.iTableCreator);
			Loggers.logServerServiceLogger.info("Create log tables");
		}

		// 创建日志表
		iTableCreator.buildTable();
		// 删除日志表
		iTableCreator.dropTable();

		// 启动创建每日日志表任务
		createTableTimer = CreateTimer.scheduleTask(new CreateTabaleTask(
				iTableCreator), config.getCreateTableTaskDelay(), config
				.getCreateTableTaskPeriod());
		
		// 添加删除每日日志表任务
		long todayZero = TimeUtils.getTodayBegin(Globals.getTimeService());
		long startTime = todayZero + 24 * 60 * 60 * 1000 + this.config.getDropTableTaskStartTime();
		
		createTableTimer.schedule(new DropTableTask(iTableCreator), new Date(startTime), this.config.getDropTableTaskPeriod());

		// 记录日志
		Loggers.logServerServiceLogger
				.info("Schedule create new log table task [Delay:"
						+ config.getCreateTableTaskDelay() + "ms,period:"
						+ config.getCreateTableTaskPeriod() + "ms]");

		isInited = true;
	}

//	public URL getRootPath(String resourceFileName) {
//		try {
//			return LogServerService.class.getResource("/" + resourceFileName);
//		} catch (Exception e) {
//			throw new RuntimeException("Can't find the resource file ["
//					+ resourceFileName + "] in the class path.");
//		}
//	}

	public void sendLogMessage(BaseLogMessage msg) {
		try {
			if (msgQueue != null) {
				String _logName = LogDao.getLogNameByBeanClass(msg.getClass());
				if (_logName == null) {
					throw new IllegalStateException("Can't find the log name for class [" + msg.getClass() + "]");
				}
				SimpleDateFormat format = new SimpleDateFormat("yyyy_MM_dd");
				String timeStamp = format.format(new Date());
				msg.setTableName(_logName + "_" + timeStamp);
				msg.setCreateTime(System.currentTimeMillis());
				msgQueue.put(msg);
				
				// 发给worldServer
				sendWorldServerLog(msg);
			} else {
				Loggers.logServerServiceLogger.error("#LogServerService#sendLogMessage#msgQueue is null! may be not init!");
			}
		} catch (Exception e) {
			e.printStackTrace();
			Loggers.logServerServiceLogger.error("#LogServerService#sendLogMessage#Exception!e=" + e.getMessage());
		}
	}

	public void start() {
		if (Globals.getServerConfig().getSelfLogServer()) {
			if (!isInited) {
				// 还未初始化过，记录错误日志
				Loggers.logServerServiceLogger
						.error("#LogServerService#start#start failed!isInited is false!");
				return;
			}

			// 启动心跳线程
			heartbeatThread.start();

			Loggers.logServerServiceLogger.info("#LogServerService#start#ok!");
		} else {
			Loggers.logServerServiceLogger
					.info("#LogServerService#start#not need to start!");
		}
	}

	public void stop() {
		if (Globals.getServerConfig().getSelfLogServer()) {
			if (!isInited) {
				// 还未初始化过，记录错误日志
				Loggers.logServerServiceLogger
						.error("#LogServerService#start#stop failed!isInited is false!");
				return;
			}

			// 关闭心跳线程
			heartbeatThread.shutdown();

			Loggers.logServerServiceLogger
					.info("#LogServerService#stop#stop ok!");
		} else {
			Loggers.logServerServiceLogger
					.info("#LogServerService#stop#not need to stop!");
		}
	}

	public void gmStop() {
		if (!isInited) {
			// 还未初始化过，记录错误日志
			Loggers.logServerServiceLogger
					.error("#LogServerService#start#gmStop failed!isInited is false!");
			return;
		}
		if (!heartbeatThread.isLive()) {
			// 已经关闭
			Loggers.logServerServiceLogger
					.error("#LogServerService#start#gmStop failed!heartbeatThread.isLive() is false!");
			return;
		}

		if (Globals.getServerConfig().getSelfLogServer()) {
			Loggers.logServerServiceLogger
					.info("#LogServerService#gmStop#begin stop...");
			// 重置状态位
			Globals.getServerConfig().setSelfLogServer(false);

			// 定时建表取消
			createTableTimer.cancel();

			// 关闭心跳线程
			heartbeatThread.shutdown();

			// 记录日志
			Loggers.logServerServiceLogger
					.info("#LogServerService#gmStop#stop ok!");
		} else {
			Loggers.logServerServiceLogger
					.info("#LogServerService#gmStop#not need to stop!");
		}
	}

	public void gmStart() {
		// 原来的线程如果活着，则不做处理
		if (isInited && heartbeatThread.isLive()) {
			Loggers.logServerServiceLogger
					.info("#LogServerService#gmStart#not need to gmStart!");
			return;
		}

		if (!isInited) {
			// 初始化
			init();

			Loggers.logServerServiceLogger
					.info("#LogServerService#gmStart#isInited=false,init end.");

			// 启动
			heartbeatThread.start();

			// 重置状态位
			Globals.getServerConfig().setSelfLogServer(true);

			Loggers.logServerServiceLogger
					.info("#LogServerService#gmStart#gmStart end.");
		} else {
			// 曾经关过，不能再起了
			Loggers.logServerServiceLogger
					.error("#LogServerService#gmStart#can not restart!isInited=true,heartbeatThread.isLive() is false!");
		}
	}
	
	protected void sendWorldServerLog(BaseLogMessage msg) {
		try {
//			if (Globals.getWorldServerSession() == null || Globals.isWorldServer() || !SendLogToWorld) {
//				return;
//			}
//			
//			GWMessage gwMsg = null;
//			if (msg instanceof PlayerLoginLog) {
//				gwMsg = new GWQqworldSendPlayerloginLog((PlayerLoginLog)msg);
//			} else if (msg instanceof ChargeLog) {
//				gwMsg = new GWQqworldSendChargeLog((ChargeLog)msg);
//			}
//			
//			if (gwMsg != null) {
//				Globals.getWorldServerSession().sendMessage(gwMsg);
//			}
		} catch (Exception e) {
			Loggers.logServerServiceLogger.error("#LogServerService#sendWorldServerLog#Exception!", e);
		}
	}

}
