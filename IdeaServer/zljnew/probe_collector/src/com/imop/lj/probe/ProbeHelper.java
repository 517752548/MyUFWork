package com.imop.lj.probe;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.Executors;

import com.imop.lj.probe.PIProbeConstants.ProbeReporter;
import com.imop.lj.probe.config.ProbeConfig;
import com.imop.lj.server.common.ServerType;
import com.opi.gibp.probe.IReporter;
import com.opi.gibp.probe.ProbeManager;
import com.opi.gibp.probe.probes.GroupReporter;

/**
 *
 * 性能探针管理器的初始化、配置、控制
 *
 *
 */
public final class ProbeHelper {
	final ProbeManager probeManager;

	ProbeHelper(ProbeConfig probeConfig, String serverDomain,
			int serverIndexId, ServerType serverType) {
		String hostName = probeConfig.getReporterIp();
		int port = probeConfig.getReporterPort();
		int probeReporterMask = probeConfig.getProbeReporterMask();
		IReporter reporter = null;
		List<ProbeReporter> reporterTypes = new ArrayList<ProbeReporter>();
		for (ProbeReporter _reporter : ProbeReporter.values()) {
			if ((probeReporterMask & _reporter.mark) != 0) {
				reporterTypes.add(_reporter);
			}
		}
		if (reporterTypes.size() <= 0) {
			throw new IllegalArgumentException("Must init probeManager!");
		}
		if (reporterTypes.size() == 1) {
			reporter = reporterTypes.get(0).getReporter(hostName, port);
		} else {
			IReporter[] reporterArray = new IReporter[reporterTypes.size()];
			int _index = 0;
			for (ProbeReporter _reporterType : reporterTypes) {
				reporterArray[_index] = _reporterType.getReporter(hostName,
						port);
				_index++;
			}
			reporter = new GroupReporter(reporterArray);
		}
		if (reporter == null) {
			throw new RuntimeException("Reporter is null.");
		}
		probeManager = new ProbeManager(
				Executors
						.newScheduledThreadPool(ProbeManager.DEFAULT_THREADPOOL_SIZE),
				probeConfig.getReportInterval(), reporter, "zlj", serverDomain,
				Integer.valueOf(serverIndexId).toString(), serverType.typeName);
		for (ProbeReporter _reporterType : reporterTypes) {
			_reporterType.registerProde(probeManager);
		}
		// 设置初始是否启用
		probeManager.setTurnOn(probeConfig.isTurnOn());
	}
}