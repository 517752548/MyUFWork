package com.imop.lj.logserver.common;

import com.imop.lj.common.model.LogServerStatus;
import com.imop.lj.core.msg.MessageQueue;
import com.imop.lj.core.schedule.ScheduleService;
import com.imop.lj.core.schedule.ScheduleServiceImpl;
import com.imop.lj.core.server.QueueMessageProcessor;
import com.imop.lj.core.server.ShutdownHooker;
import com.imop.lj.core.time.SystemTimeService;
import com.imop.lj.core.time.TimeService;
import com.imop.lj.logserver.LogServerConfig;

public class Globals {
	private static LogServerConfig config;
	private static ScheduleService scheduleService;
	private static TimeService timeService;
	/** 日志服务器状态 */
	private static LogServerStatus logServerStatus;
	private static ShutdownHooker shutdownHooker;
	
	/** 心跳线程，处理消息 */
	private static LogServerHeartbeatThread heartbeatThread;
	/** 消息队列 */
	private static MessageQueue msgQueue;

	public static void init(LogServerConfig cfg) {
		config = cfg;
		timeService = new SystemTimeService();
		scheduleService = new ScheduleServiceImpl(new QueueMessageProcessor(),
				timeService);
		shutdownHooker = new ShutdownHooker();
		logServerStatus = buildLogServerStatus(config);
		
		msgQueue = new MessageQueue();
		heartbeatThread = new LogServerHeartbeatThread(msgQueue, null);
	}

	public static LogServerConfig getServerConfig() {
		return config;
	}

	public static ScheduleService getScheduleService() {
		return scheduleService;
	}

	public static TimeService getTimeService() {
		return timeService;
	}

	public static LogServerStatus getLogServerStatus() {
		return logServerStatus;
	}

	public static ShutdownHooker getShutdownHooker() {
		return shutdownHooker;
	}

	/**
	 * 获取日志服务器状态
	 * @param logServerConfig
	 * @return
	 */
	private static LogServerStatus buildLogServerStatus(LogServerConfig logServerConfig)
	{
		LogServerStatus logServerStatus = new LogServerStatus();

		logServerStatus.setServerIndex(logServerConfig.getServerIndex());
		logServerStatus.setServerId(logServerConfig.getServerId());
		logServerStatus.setServerName(logServerConfig.getServerName());
		logServerStatus.setIp(logServerConfig.getServerHost());
		logServerStatus.setPort(String.valueOf(logServerConfig.getPort()));
		logServerStatus.setVersion(logServerConfig.getVersion());

		return logServerStatus;
	}

	public static LogServerHeartbeatThread getHeartbeatThread() {
		return heartbeatThread;
	}

	public static MessageQueue getMsgQueue() {
		return msgQueue;
	}
	
}
