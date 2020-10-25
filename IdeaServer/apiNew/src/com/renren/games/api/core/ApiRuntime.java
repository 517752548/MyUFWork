package com.renren.games.api.core;

/**
 * 游戏服务器运行时数据
 *
  *
 *
 */
public class ApiRuntime {
	/** 服务是否已经开放 */
	private static volatile boolean open;
	/** 服务是否正在关闭 */
	private static volatile boolean shutdowning;

	private ApiRuntime() {

	}

	/**
	 * 检查服务是否已经开放,只有在已经开放的情况下才能接收玩家的连接
	 *
	 * @return the open
	 */
	public static boolean isOpen() {
		return open;
	}

	/**
	 * 打开服务
	 *
	 */
	public static void setOpenOn() {
		open = true;
	}

	/**
	 * 关闭服务
	 */
	public static void setOpenOff() {
		open = false;
	}

	/**
	 * 设置服务器正在关闭
	 */
	public static void setShutdowning() {
		shutdowning = true;
		setOpenOff();
	}

	/**
	 * 服务器是否正在关闭
	 *
	 * @return
	 */
	public static boolean isShutdowning() {
		return shutdowning;
	}
}
