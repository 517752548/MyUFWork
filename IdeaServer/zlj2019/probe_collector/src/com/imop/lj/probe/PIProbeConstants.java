package com.imop.lj.probe;

import com.opi.gibp.probe.IReporter;
import com.opi.gibp.probe.ProbeManager;
import com.opi.gibp.probe.probes.preformance.DefaultProbes;
import com.opi.gibp.probe.probes.preformance.DefaultReporter;
import com.opi.gibp.probe.probes.user.UserProbes;
import com.opi.gibp.probe.probes.user.UserReporter;

/**
 * 性能探测汇报常量
 *
 *
 */
public interface PIProbeConstants {

	/**
	 * 性能探针的运行状态
	 */
	public enum ProbeStatus {
		/** 初始化前，准备状态 */
		PREINIT(0),
		/** 初始化完成 */
		INITED(1),
		/** 启动的 */
		STARTED(2),
		/** 暂停的 */
		PAUSED(3),
		/** 停止的 */
		STOPPED(4);

		private final int index;
		/** 按索引顺序存放的枚举数组 */
		private static final ProbeStatus[] values = new ProbeStatus[] {
				PREINIT, INITED, STARTED, PAUSED, STOPPED };

		static {
			for (ProbeStatus _status : values()) {
				if (values[_status.index] != _status) {
					throw new IllegalArgumentException(
							"Illegal ProbeStatus index!");
				}
			}
		}

		/**
		 *
		 * @param index
		 *            枚举的索引,从0开始
		 */
		private ProbeStatus(int index) {
			this.index = index;
		}

		public int getIndex() {
			return this.index;
		}

		/**
		 * 根据指定的索引获取枚举的定义
		 *
		 * @param index
		 * @return
		 */
		public static ProbeStatus valueOf(final int index) {
			return values[index];
		}
	}

	/**
	 * 探测名称
	 */
	public enum ProbeName {
		/** 请求 */
		REQUEST(DefaultProbes.REQ),
		/** 消息 */
		MSG(DefaultProbes.MSG),
		/** 第三方调用 */
		RPC(DefaultProbes.RPC),
		/** 网络流量 */
		NET_TRAFFIC(DefaultProbes.NET),
		/** 数据库操作 */
		DB(DefaultProbes.DB),
		/** 用户信息 */
		USERS(DefaultProbes.USERS),
		/** 用户扩展信息 */
		USERS_EXT(UserProbes.USERS_EXT),
		/** 游戏场景 */
		SCENE(UserProbes.SCENE);

		public String name;

		private ProbeName(String name) {
			this.name = name;
		}
	}

	/**
	 * 探针回报类型
	 *
	 * @author yisi.zheng
	 * @since 2010-12-30
	 */
	public enum ProbeReporter {
		/** 性能采集 */
		PREFORMANCE(1) {
			@Override
			public IReporter getReporter(String hostName, int port) {
				return new DefaultReporter(hostName, port);
			}

			@Override
			public void registerProde(ProbeManager probeManager) {
				DefaultProbes.registerJVMProbe(probeManager);
				DefaultProbes.registerGameProbe(probeManager);
			}
		},
		/** 用户信息采集 */
		USER(2) {
			@Override
			public IReporter getReporter(String hostName, int port) {
				return new UserReporter(hostName, port);
			}

			@Override
			public void registerProde(ProbeManager probeManager) {
				UserProbes.registerUserProbe(probeManager);
				UserProbes.registerSceneProbe(probeManager);
			}
		};

		public final int mark;

		ProbeReporter(int mark) {
			this.mark = mark;
		}

		/**
		 * 返回汇报器
		 *
		 * @param hostName
		 * @param port
		 * @return
		 */
		public abstract IReporter getReporter(String hostName, int port);

		/**
		 * 注册采集探针
		 *
		 * @param probeManager
		 */
		public abstract void registerProde(ProbeManager probeManager);
	}
}
