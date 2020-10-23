package com.imop.lj.gameserver.player;

/**
 * 用于临时在服务端保存玩家的操作, 由玩家的后续操作触发
 * 执行 执行完成后由清除状态
 *
 */
public class StaticHandlelHolder {
	/** 状态标识, 惟一标识一个新的状态 */
	private String tag;
	/** 处理具体的选择实现 */
	private IStaticHandler handler;

	/**
	 * 清除状态
	 *
	 */
	public void clear() {
		this.tag = null;
		this.handler = null;
	}

	/**
	 * 获取状态标识
	 *
	 * @return
	 */
	public String getTag() {
		return tag;
	}

	/**
	 * 获取状态处理器
	 *
	 * @return
	 */
	public IStaticHandler getHandler() {
		return handler;
	}

	/**
	 * 设置状态处理器
	 *
	 * @param handler
	 */
	public void setHandler(IStaticHandler handler) {
		this.tag = String.valueOf(Math.random());
		this.handler = handler;
	}
}
