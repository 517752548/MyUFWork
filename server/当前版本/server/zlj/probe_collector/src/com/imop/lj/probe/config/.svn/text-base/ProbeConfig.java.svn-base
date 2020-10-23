package com.imop.lj.probe.config;

import com.imop.lj.probe.PIProbeConstants.ProbeReporter;
import com.opi.gibp.probe.ProbeManager;

/**
 * 性能收集汇报配置
 *
 * @author yisi.zheng
 * @since 2010-12-17
 */
public class ProbeConfig {

	/** 汇报的地址 */
	private String reporterIp = "127.0.0.1";

	/** 汇报的端口 */
	private int reporterPort = 1463;

	/** 汇报间隔,单位毫秒 */
	private int reportInterval = ProbeManager.DEFAULT_REPORT_INTERVAL;

	/** 是否启用 */
	private boolean turnOn = true;

	/** 性能汇报采用的类型 */
	private int probeReporterMask = ProbeReporter.PREFORMANCE.mark;

	public String getReporterIp() {
		return reporterIp;
	}

	public void setReporterIp(String reporterIp) {
		this.reporterIp = reporterIp;
	}

	public int getReporterPort() {
		return reporterPort;
	}

	public void setReporterPort(int reporterPort) {
		this.reporterPort = reporterPort;
	}

	public boolean isTurnOn() {
		return turnOn;
	}

	public void setTurnOn(boolean turnOn) {
		this.turnOn = turnOn;
	}

	public int getReportInterval() {
		return reportInterval;
	}

	public void setReportInterval(int reportInterval) {
		this.reportInterval = reportInterval;
	}

	public int getProbeReporterMask() {
		return probeReporterMask;
	}

	public void setProbeReporterMask(int probeReporterMask) {
		this.probeReporterMask = probeReporterMask;
	}

}
