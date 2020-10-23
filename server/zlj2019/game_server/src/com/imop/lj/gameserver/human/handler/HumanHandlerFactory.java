package com.imop.lj.gameserver.human.handler;


public class HumanHandlerFactory {
	/** 区域消息处理器 */
	private static HumanMessageHandler handler = new HumanMessageHandler();

	/** 类默认构造器 */
	private HumanHandlerFactory() {
	}

	/**
	 * 获取区域消息处理器
	 *
	 * @return
	 */
	public static HumanMessageHandler getHandler() {
		return handler;
	}
}
