package com.imop.lj.probe;

import org.slf4j.Logger;

import com.imop.lj.probe.PIProbeConstants.ProbeName;
import com.imop.lj.probe.PIProbeConstants.ProbeStatus;
import com.imop.lj.probe.config.ProbeConfig;
import com.imop.lj.server.common.ServerType;
import com.opi.gibp.probe.Loggers;
import com.opi.gibp.probe.model.IProbeCategory;

/**
 * 性能指数采集器
 *
 *
 */
public class PIProbeCollector {
	public static final Logger logger = Loggers.probeLogger;

	private static ProbeHelper probeHelper;

	/** 状态标志 */
	private static ProbeStatus status = ProbeStatus.PREINIT;

	/**
	 * 初始化性能指数采集器
	 *
	 * @param probeConfig
	 *            探针相关配置
	 * @param serverDomain
	 *            域名
	 * @param serverIndexId
	 *            单个server的id
	 * @param serverType
	 *            server类型，区分各种server
	 */
	public static void init(ProbeConfig probeConfig, String serverDomain,
			int serverIndexId, ServerType serverType) {
		// 不可反复初始化
		if (status != ProbeStatus.PREINIT) {
			if (logger.isErrorEnabled()) {
				logger.error(
						"#CORE.PIProbeCollector.init: status="
								+ status.getIndex(), new RuntimeException());
			}
			return;
		}
		probeHelper = new ProbeHelper(probeConfig, serverDomain, serverIndexId,
				serverType);
		status = ProbeStatus.INITED;
	}

	/**
	 * 启动性能指数采集器
	 * <p>
	 * 启动后，管理器将开始定时汇报采集的数据
	 * </p>
	 */
	public static void start() {
		// 初始化完成才能启动
		if (status == ProbeStatus.INITED) {
			probeHelper.probeManager.start();
			if (probeHelper.probeManager.isTurnOn()) {
				status = ProbeStatus.STARTED;
			} else {
				status = ProbeStatus.PAUSED;
			}
		} else {
			if (logger.isErrorEnabled()) {
				logger.error(
						"#CORE.PIProbeCollector.start: status="
								+ status.getIndex(), new RuntimeException());
			}
		}
	}

	/**
	 * 注销性能指数采集器
	 * <p>
	 * 停止性能采集服务，注销过程中管理器将会shutdown掉由管理器自己创建的线程池，注销后采集器将不能通过
	 * {@link PIProbeCollector#start()}再次进行启动；如需要暂停采集汇报，请使用
	 * {@link PIProbeCollector#pause()}
	 * </p>
	 */
	public static void stop() {
		// 启动后的才能被停止
		if (status == ProbeStatus.STARTED || status == ProbeStatus.PAUSED) {
			probeHelper.probeManager.stop();
			status = ProbeStatus.STOPPED;
		} else {
			if (logger.isErrorEnabled()) {
				logger.error(
						"#CORE.PIProbeCollector.stop: status="
								+ status.getIndex(), new RuntimeException());
			}
		}
	}

	/**
	 * 开/关采集汇报工作
	 */
	public static void setTurnOn(boolean turnOn) {
		// 只要是初始化完成，就可以控制开关
		if (status == ProbeStatus.PREINIT) {
			return;
		}
		probeHelper.probeManager.setTurnOn(turnOn);
		if (turnOn) {
			status = ProbeStatus.STARTED;
		} else {
			status = ProbeStatus.PAUSED;
		}
	}

	/**
	 * 收集指定探针相应类型的性能数值
	 *
	 * @param probeName
	 *            探针名
	 * @param type
	 *            数据类型
	 * @param value
	 *            值
	 */
	public static void collect(final ProbeName probeName,
			final IProbeCategory type, long value) {
		if (status == ProbeStatus.STARTED) {
			probeHelper.probeManager.update(probeName.name, type, value);
		}
	}

	/**
	 * 收集指定探针相应类型的性能数值
	 *
	 * @param probeName
	 *            探针名
	 * @param type
	 *            数据类型
	 * @param value
	 *            值
	 */
	public static void collect(final ProbeName probeName,
			final IProbeCategory type, String value) {
		if (status == ProbeStatus.STARTED) {
			probeHelper.probeManager.update(probeName.name, type, value);
		}
	}

	/**
	 * 获得性能采集器的当前状态
	 *
	 * @return
	 */
	public static ProbeStatus getProbeStatus() {
		return status;
	}

}
