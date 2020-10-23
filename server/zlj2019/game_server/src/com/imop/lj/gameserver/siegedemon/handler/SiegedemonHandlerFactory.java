
package com.imop.lj.gameserver.siegedemon.handler;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class SiegedemonHandlerFactory {
	/** 区域消息处理器 */
	private static SiegedemonMessageHandler handler = new SiegedemonMessageHandler();

	/** 类默认构造器 */
	private SiegedemonHandlerFactory() {
	}

	/**
	 * 获取区域消息处理器
	 * 
	 * @return
	 */
	public static SiegedemonMessageHandler getHandler() {
		return handler;
	}
}
