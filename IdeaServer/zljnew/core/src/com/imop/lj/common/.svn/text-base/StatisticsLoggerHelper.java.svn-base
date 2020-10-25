package com.imop.lj.common;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.probe.PIProbeCollector;
import com.imop.lj.probe.PIProbeConstants.ProbeName;
import com.opi.gibp.probe.category.NetTraffic;

public class StatisticsLoggerHelper {

	/**
	 * 统计收到的消息
	 *
	 * @param msg
	 */
	public static void logMessageRecived(IMessage msg) {
		// 采集接收流量
		PIProbeCollector.collect(ProbeName.NET_TRAFFIC, NetTraffic.RECEIVE, msg
				.getLength());
	}

	/**
	 * 统计发送的消息
	 *
	 * @param msg
	 */
	public static void logMessageSent(IMessage msg) {
		// 采集发送流量
		PIProbeCollector.collect(ProbeName.NET_TRAFFIC, NetTraffic.SEND, msg
				.getLength());
	}

	/**
	 * 统计所有收发的消息
	 *
	 * @param msg
	 */
	public static void logMessage(IMessage msg) {
		Loggers.serverStatusStatistics.info("#Message{" + msg.getTypeName()
				+ " Length:" + msg.getLength() + " }");
	}
}
